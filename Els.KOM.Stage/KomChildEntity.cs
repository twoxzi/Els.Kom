using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Els.KOM.Stage
{
    public class KomChildEntity
    {
        #region Fields
        private String name = "";
        private Int64 size = 0;
        private String checksum = "";
        private String fileTime = "";
        private Int64 compressedSize = 0;
        private Int64 checksumSize = 0;
        private String algorithm = "0";
        private String fullName;
        private System.IO.MemoryStream fileData;
        #endregion Fields

        #region Properties
        public String Name
        {
            get
            {
                return name;
            }

            set
            {
                this.name = value;
            }
        }

        public Int64 Size
        {
            get
            {
                return size;
            }

            set
            {
                this.size = value;
            }
        }

        public String Checksum
        {
            get
            {
                return checksum;
            }

            set
            {
                this.checksum = value;
            }
        }

        public String FileTime
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

        public Int64 CompressedSize
        {
            get
            {
                return compressedSize;
            }

            set
            {
                this.compressedSize = value;
            }
        }

        public Int64 ChecksumSize
        {
            get
            {
                return checksumSize;
            }

            set
            {
                this.checksumSize = value;
            }
        }

        public String Algorithm
        {
            get
            {
                return algorithm;
            }

            set
            {
                this.algorithm = value;
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

        public MemoryStream FileData
        {
            get
            {
                return fileData;
            }

            set
            {
                this.fileData = value;
            }
        }

        #endregion Properties


    }
}
