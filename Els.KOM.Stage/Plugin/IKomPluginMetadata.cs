using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Els.KOM.Stage.Plugin
{
    /// <summary>
    ///  MEF Metadata
    /// </summary>
    public interface IKomPluginMetadata
    {
        //do not declare set method for the Property


        String FileVersion { get; }
        String Description { get; }
         Int32 Major { get; }
         Int32 Minor { get;  }
         Int32 Build { get;  }
         Int32 Revision { get;  }
    }
}
