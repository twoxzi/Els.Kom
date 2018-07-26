using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using Els.KOM.Stage.Plugin;

namespace Els.KOM.Stage
{
    public class KomPuppetmaster
    {
        [ImportMany]
        public IEnumerable<Lazy<IKomPlugin, IKomPluginMetadata>> puppets { get; set; }

        public KomPuppetmaster()
        {
            var catalog = new AggregateCatalog();

            ///使用当前程序集构造AssemblyCatalog,并添加
            ///AssemblyCatalog对于
            AssemblyCatalog assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            catalog.Catalogs.Add(assemblyCatalog);
            catalog.Catalogs.Add(new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
        }
        #region   Methods

        public void TestPlugin(String path)
        {
            Console.WriteLine($"{nameof(TestPlugin)} Begin:");
            try
            {
                if(puppets == null)
                {
                    Console.WriteLine("Can not load Plugins");

                    return;
                }

                Int32 i = (puppets.Count());
                Console.WriteLine($"Plugin Count: {i}");
                if(i == 0)
                {

                    return;
                }


                KomHeader header = new KomHeader();

                using(BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    String fileVersion = new String(reader.ReadChars(52)).TrimEnd('\0');
                    header.FileVersion = fileVersion;

                    Console.WriteLine(header.FileVersion);
                    var query = from a in puppets
                                where fileVersion.StartsWith(a.Metadata.FileVersion)
                                orderby a.Metadata.FileVersion descending
                                orderby a.Metadata.Major, a.Metadata.Minor, a.Metadata.Build, a.Metadata.Revision
                                select a.Value;
                    IKomPlugin puppet = query.FirstOrDefault();
                    if(puppet == null)
                    {
                        Console.WriteLine($"Without Plugin to analyse this file:{path}");

                        return;
                    }
                    puppet.ReadKomHeaderDataAfterVersion(header, reader);
                }
            }
            finally
            {
                Console.WriteLine($"{nameof(TestPlugin)} End.\r\n");

            }
        }

        public KomHeader ReadFromDirectory(String path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            String[] files = Directory.GetFiles(path);
            //FileVersion = new String(reader.ReadChars(52));
            KomHeader header = new KomHeader();

            foreach(FileInfo item in di.GetFiles())
            {
                header.Items.Add(new KomChildEntity() { FullName = item.FullName, Name = item.Name, Size = item.Length });
            }


            return header;
        }

        public KomHeader ReadFromStream(BinaryReader reader)
        {
            KomHeader header = new KomHeader();
            header.FileVersion = new String(reader.ReadChars(52));
            header.FileCount = reader.ReadInt32();
            header.Key = reader.ReadInt32();
            header.FileTime = reader.ReadInt32();
            header.FileStructChecksum = reader.ReadInt32();
            header.FileStructLength = reader.ReadInt32();
            return header;
        }

        public KomHeader ReadFromFile(String path)
        {


            return null;
        }
        /// <summary>
        /// Pack and Write the Data into <paramref name="outStream"/>
        /// </summary>
        /// <param name="header"></param>
        /// <param name="baseDir"></param>
        /// <param name="outStream"></param>
        public void Pack(KomHeader header, String baseDir, Stream outStream)
        {


        }

        public void Unpack(KomHeader header, String saveDir)
        {

        }

        #endregion static Methods
    }
}
