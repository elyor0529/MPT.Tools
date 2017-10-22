using System;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;
using MPT.CSI.API.Core.Program;
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.EndToEndTests.Core.Program
{

    /// <exclude />
    [TestFixture]
    public class CSiApplicationTests
    {
        [Test]
        public void CSiApplication_Initialize_New_Instance_Defaults()
        {
            bool programWasOpened;
            using (CSiApplication app = new CSiApplication(CSiData.pathApp))
            {
                programWasOpened = true;
            }
            Assert.IsTrue(programWasOpened);
        }

        [Test]
        public void CSiApplication_Initialize_New_Instance_with_Invalid_Application_Path_Throws_IOException()
        {
            string badPath = "FooBar.Exe";
            var ex = Assert.Throws<IOException>(CSiApplication_Initialize_New_Instance_with_Invalid_Application_Path);
            Assert.That(ex.Message, Is.EqualTo("The following CSi program path is invalid: " + badPath));
        }

        private void CSiApplication_Initialize_New_Instance_with_Invalid_Application_Path()
        {
            using (CSiApplication app = new CSiApplication("FooBar.Exe"))
            {
            }
        }

#if !BUILD_SAP2000v18 && !BUILD_SAP2000v17 && !BUILD_SAP2000v16 && !BUILD_CSiBridgev18 && !BUILD_CSiBridgev17 && !BUILD_CSiBridgev16 && !BUILD_ETABS2015
        [Test]
        public void CSiApplication_Initialize_New_Instance_By_Object_With_Defaults()
        {
            bool programWasOpened;
            using (CSiApplication app = new CSiApplication())
            {
                programWasOpened = true;
            }
            Assert.IsTrue(programWasOpened);
        }



        [Test]
        public void CSiApplication_Initialize_AttachToProcess()
        {
            ProcessStartInfo processInfo = new ProcessStartInfo(CSiData.pathApp)
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process process = Process.Start(processInfo);
            System.Threading.Thread.Sleep(10000);
            
            bool programWasAttachedTo;
            using (CSiApplication app = new CSiApplication(startNewProcess: false))
            {
                programWasAttachedTo = true;
            }
            Assert.IsTrue(programWasAttachedTo);
        }

        [Test]
        public void CSiApplication_Initialize_AttachToProcess_of_Nonexisting_Process_Throws_CSiException()
        {
            var ex = Assert.Throws<CSiException>(CSiApplication_Initialize_AttachToProcess_of_Nonexisting_Process);
            Assert.That(ex.Message, Is.EqualTo("No running instance of the program found or failed to attach."));
        }

        private void CSiApplication_Initialize_AttachToProcess_of_Nonexisting_Process()
        {
            using (CSiApplication app = new CSiApplication(startNewProcess: false))
            {

            }
        }

        [Test]
        public void CSiApplication_Application_Start_Default()
        {
            bool programWasOpened;
            using (CSiApplication app = new CSiApplication(CSiData.pathApp))
            {
                app.ApplicationStart();
                programWasOpened = true;
            }
            Assert.IsTrue(programWasOpened);
        }

        [Test]
        public void CSiApplication_Application_Start_Default_is_Visible()
        {
            bool programIsVisible;
            using (CSiApplication app = new CSiApplication(CSiData.pathApp))
            {
                app.ApplicationStart(visible: true);
                programIsVisible = app.Visible();
            }
            Assert.IsTrue(programIsVisible);
        }

        [Test]
        public void CSiApplication_Application_Start_with_Custom_Units()
        {
            bool programWasOpened;
            using (CSiApplication app = new CSiApplication(CSiData.pathApp))
            {
                app.ApplicationStart(eUnits.kgf_mm_C);
                programWasOpened = true;
            }
            Assert.IsTrue(programWasOpened);
        }

        [Test]
        public void CSiApplication_Application_Start_with_Invisible_is_Invisible()
        {
            bool programIsVisible = true;
            using (CSiApplication app = new CSiApplication(CSiData.pathApp))
            {
                app.ApplicationStart(visible: false);
                programIsVisible = app.Visible();
            }
            Assert.IsFalse(programIsVisible);
        }

        [Test]
        public void CSiApplication_Application_Start_with_Valid_Model_Path()
        {
            bool programWasOpened;
            using (CSiApplication app = new CSiApplication(CSiData.pathApp))
            {
                app.ApplicationStart(filePath: Path.Combine(CSiData.pathResources, CSiData.pathModelDemo + CSiData.extension));
                programWasOpened = true;
            }
            Assert.IsTrue(programWasOpened);
        }

        [Test]
        public void CSiApplication_Application_Start_with_Invalid_Model_Path_Throws_CSiException()
        {
            Assert.Throws<CSiException>(CSiApplication_Application_Start_with_Invalid_Model_Path);
        }

        private void CSiApplication_Application_Start_with_Invalid_Model_Path()
        {
            using (CSiApplication app = new CSiApplication(CSiData.pathApp))
            {
                app.ApplicationStart(filePath: "FooBar.BadType");
            }
        }

        [Test]
        public void CSiApplication_Hide_Hidden_Hides()
        {
            bool programIsVisible = true;
            using (CSiApplication app = new CSiApplication(CSiData.pathApp))
            {
                app.ApplicationStart(visible: false);
                programIsVisible = app.Visible();
                //Assert.IsFalse(programIsVisible); // TODO: This is suppressed as there is a problem with initializing hidden.

                app.Hide();
                programIsVisible = app.Visible();
                Assert.IsFalse(programIsVisible);

                app.Hide();
                programIsVisible = app.Visible();
                Assert.IsFalse(programIsVisible);
            }
        }

        [Test]
        public void CSiApplication_Hide_Visible_Hides()
        {
            bool programIsVisible;
            using (CSiApplication app = new CSiApplication(CSiData.pathApp))
            {
                app.ApplicationStart(visible: true);
                programIsVisible = app.Visible();
                Assert.IsTrue(programIsVisible);

                app.Hide();
                programIsVisible = app.Visible();
                Assert.IsFalse(programIsVisible);
            }
        }


        [Test]
        public void CSiApplication_Show_Hidden_Shows()
        {
            bool programIsVisible;
            using (CSiApplication app = new CSiApplication(CSiData.pathApp))
            {
                app.ApplicationStart();
                programIsVisible = app.Visible();
                Assert.IsTrue(programIsVisible);

                app.Hide();
                programIsVisible = app.Visible();
                Assert.IsFalse(programIsVisible);

                app.Unhide();
                programIsVisible = app.Visible();
                Assert.IsTrue(programIsVisible);
            }
        }

        [Test]
        public void CSiApplication_Show_Visible_Shows()
        {
            bool programIsVisible;
            using (CSiApplication app = new CSiApplication(CSiData.pathApp))
            {
                app.ApplicationStart(visible: true);
                programIsVisible = app.Visible();
                Assert.IsTrue(programIsVisible);

                app.Unhide();
                programIsVisible = app.Visible();
                Assert.IsTrue(programIsVisible);
            }
        }
#endif


    }
}
