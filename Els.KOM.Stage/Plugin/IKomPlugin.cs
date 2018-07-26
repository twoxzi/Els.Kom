using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Els.KOM.Stage.Plugin
{
    public interface IKomPlugin
    {
        #region  about reading
        /// <summary>
        /// The Plugin Manager will read the Version and choose the plugin.so,please check the position of the stream.
        /// please read the header-info into <paramref name="header"/> param,without version.
        /// </summary>
        /// <param name="header"></param>
        /// <param name="reader"></param>
        void ReadKomHeaderDataAfterVersion(KomHeader header, BinaryReader reader);

        
        /// <summary>
        /// Read the child file Index
        /// </summary>
        /// <param name="header"></param>
        /// <param name="reader"></param>
        void ReadFileIndex(KomHeader header, BinaryReader reader);
        
        /// <summary>
        /// Read the child file data ,index by <paramref name="header"/>
        /// </summary>
        /// <param name="header"></param>
        /// <param name="entity"></param>
        /// <param name="outStream"></param>
        void ReadKomChildFileData(KomHeader header, KomChildEntity entity,Stream outStream);
        #endregion about reading


        #region   about writing
        void WriteKomHeader(KomHeader header, Stream stream);
        /// <summary>
        /// write child file index
        /// </summary>
        /// <param name="header"></param>
        /// <param name="writer"></param>
        void WriteFileIndex(KomHeader header, BinaryWriter writer);
        /// <summary>
        /// write child file data
        /// </summary>
        /// <param name="header"></param>
        /// <param name="outStream"></param>
        void WriteKomChildFileData(KomHeader header, Stream outStream);
        /// <summary>
        /// add new child file
        /// </summary>
        /// <param name="sourceFileData"></param>
        /// <param name="entity"></param>
        void AddChildFileData(Stream sourceFileData, KomChildEntity entity);

        /// <summary>
        /// replace a child file
        /// </summary>
        /// <param name="sourceFileData"></param>
        /// <param name="targetName"></param>
        /// <param name="entity"></param>
        void ReplaceChildFileData(Stream sourceFileData, String targetName, KomChildEntity entity);
        #endregion about writing
    }
}
