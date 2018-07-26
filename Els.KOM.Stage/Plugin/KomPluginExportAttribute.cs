using System;
using System.ComponentModel.Composition;

namespace Els.KOM.Stage.Plugin
{
    /// <summary>
    /// Plugin metadata Attribute
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class KomPluginExportAttribute : ExportAttribute
    {
        /// <summary>
        /// Target Kom File Version
        /// </summary>
        public String FileVersion { get;  set; }
        public String Description { get; set; }
        public Int32 Major { get; set; }
        public Int32 Minor { get; set; }
        public Int32 Build { get; set; }
        public Int32 Revision { get; set; }
        /// <summary>
        /// Version default "1.0.0.0"
        /// </summary>
        public KomPluginExportAttribute():this(1)
        {

        }

        /// <summary>
        /// Set Attribute with the Version info
        /// </summary>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        /// <param name="build"></param>
        /// <param name="revision"></param>
        public KomPluginExportAttribute(Int32 major=1, Int32 minor=0, Int32 build=0, Int32 revision=0):base(typeof(IKomPlugin))
        {
            Major = major;
            Minor = minor;
            Build = build;
            Revision = revision;
        }
    }
}
