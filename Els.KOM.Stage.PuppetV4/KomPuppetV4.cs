using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Els.KOM.Stage.Plugin;

namespace Els.KOM.Stage.PuppetV4
{
    [KomPluginExport(FileVersion ="KOG GC TEAM MASSFILE V.0.4.")]
    public class KomPuppetV4 : IKomPlugin
    {
        public void AddChildFileData(Stream sourceFileData, KomChildEntity entity)
        {
            throw new NotImplementedException();
        }

        public void ReadFileIndex(KomHeader header, BinaryReader reader)
        {
            throw new NotImplementedException();
        }

        public void ReadKomChildFileData(KomHeader header, KomChildEntity entity, Stream outStream)
        {
            throw new NotImplementedException();
        }

        public void ReadKomHeaderDataAfterVersion(KomHeader header, BinaryReader reader)
        {
            Console.WriteLine("I'm V4");
        }

        public void ReplaceChildFileData(Stream sourceFileData, String targetName, KomChildEntity entity)
        {
            throw new NotImplementedException();
        }

        public void WriteFileIndex(KomHeader header, BinaryWriter writer)
        {
            throw new NotImplementedException();
        }

        public void WriteKomChildFileData(KomHeader header, Stream outStream)
        {
            throw new NotImplementedException();
        }

        public void WriteKomHeader(KomHeader header, Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}
