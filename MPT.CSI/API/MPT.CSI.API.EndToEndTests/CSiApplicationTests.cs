using System;
using NUnit.Framework;
using MPT.CSI.API.Core.Program;

namespace MPT.CSI.API.EndToEndTests
{
    [TestFixture]
    public class CSiApplicationTests
    {
        [Test]
        public void CSiApplication_Initialize_New_Instance_Defaults()
        {
            bool programWasOpened;
            using (CSiApplication app = new CSiApplication())
            {
                programWasOpened = true;
            }
            Assert.IsTrue(programWasOpened);
        }
    }
}
