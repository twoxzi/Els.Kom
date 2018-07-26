using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using Els.KOM.Stage;
using Els.KOM.Stage.Plugin;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void TestMethod1()
        {
           
            KomPuppetmaster master = new KomPuppetmaster();
            master.TestPlugin(@"F:\新建文件夹\elsword\data\data023.kom");
            master.TestPlugin(@"F:\新建文件夹\elsword\data\data001.kom");

        }
    }
}
