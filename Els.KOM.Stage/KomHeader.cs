using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Els.KOM.Stage
{
    /// <summary>
    /// kom文件头(Length:72)(maybe)<br/>
    /// 除了0-51之外，都是根据按低位规则
    /// 规则：<br/>
    /// 0-51:52Byte,是文件版本，可以根据这个来判断是否为kom文件。<br/>
    /// 52-55:4Byte,文件数量<br/>
    /// 56-59:4Byte,1(意义不明)<br/>
    /// 60-63:4Byte,FileTime<br/>
    /// 64-67:4Byte,xml's checksum<br/>
    /// 68-71:4Byte, xml data length<br/>
    /// 注： kom的checksum指的是xml的checksum，而不是整个文件的checksum
    /// </summary>
    public class KomHeader
    {
        #region Fields
        private Int32 headerLength;
        private String fileVersion;
        private Int32 fileCount;
        private Int32 key;
        private Int32 fileTime;
        private Int32 fileStructChecksum;
        private Int32 fileStructLength;
        private String fullName;
        private KomChildEntityCollection items;
        #endregion Fields

        #region Properties
        /// <summary>
        /// 文件版本
        /// </summary>
        public String FileVersion
        {
            get
            {
                return fileVersion;
            }

            set
            {
                this.fileVersion = value;
            }
        }
        /// <summary>
        /// 文件数量
        /// </summary>
        public Int32 FileCount
        {
            get
            {
                return fileCount;
            }

            set
            {
                this.fileCount = value;
            }
        }
        /// <summary>
        /// Unknow
        /// </summary>
        public Int32 Key
        {
            get
            {
                return key;
            }

            set
            {
                this.key = value;
            }
        }
        /// <summary>
        /// Time
        /// </summary>
        public Int32 FileTime
        {
            get
            {
                return fileTime;
            }

            set
            {
                this.fileTime = value;
            }
        }
        /// <summary>
        /// 文件的Checksum。Kom文件内部索引的Checksum
        /// </summary>
        public Int32 FileStructChecksum
        {
            get
            {
                return fileStructChecksum;
            }

            set
            {
                this.fileStructChecksum = value;
            }
        }
        /// <summary>
        /// 文件列表索引数据长度
        /// </summary>
        public Int32 FileStructLength
        {
            get
            {
                return fileStructLength;
            }

            set
            {
                this.fileStructLength = value;
            }
        }

        public String FullName
        {
            get
            {
                return fullName;
            }

            set
            {
                this.fullName = value;
            }
        }

        public KomChildEntityCollection Items
        {
            get
            {
                if(items == null)
                {
                    items = new KomChildEntityCollection();
                }
                return items;
            }

            set
            {
                this.items = value;
            }
        }

        public Int32 HeaderLength
        {
            get
            {
                return headerLength;
            }

            set
            {
                this.headerLength = value;
            }
        }
        #endregion Properties

    }
}
