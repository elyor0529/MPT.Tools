using System;
using System.IO;
using System.Reflection;

namespace MPT.CSI.API.Core.Support
{
    /// <summary>
    /// Handles the registration of CSi program *.dll files.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class CSiRegistration
    {
        #region Fields

        private BatchFile _batch;

        private bool _programPathIsValid;

        #endregion


        #region Properties
        /// <summary>
        /// Path to the CSi program to register.
        /// </summary>
        internal readonly string ProgramPath;

        /// <summary>
        /// Name of the API *.dll file corresponding with the program to be used.
        /// </summary>
        internal readonly string ApiDllFileName;

        #endregion


        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="CSiRegistration"/> class.
        /// </summary>
        /// <param name="apiDllFileName">Name of the API *.dll file corresponding with the program to be used.</param>
        /// <param name="programPath">Path to the CSi program to register.</param>
        internal CSiRegistration(string apiDllFileName,
                                 string programPath)
        {
            ProgramPath = programPath;
            _programPathIsValid = File.Exists(programPath);
            ApiDllFileName = apiDllFileName;
        }


        #endregion

        #region Methods

        /// <summary>
        /// Registers the specified CSi program if it is currently unregistered. Returns 'True' if successful.
        /// </summary>
        /// <param name="registerIfFileNotExists">If no *.dll file currently exists, then any existing matching program will be unregistered and the specified program will be registered.</param>
        /// <remarks></remarks>
        internal bool Register(bool registerIfFileNotExists = true)
        {
            try
            {
                if (!File.Exists(ProgramPath)) {throw new IOException("Program path refers to a file that does not exist.");}

                string referencePath = ProgramPath + Path.PathSeparator + ApiDllFileName;

                if (!File.Exists(referencePath) && registerIfFileNotExists)
                {
                    string pathBatch = Assembly.GetExecutingAssembly().Location + Path.PathSeparator + "Register.bat";

                    _batch = new BatchFile(pathBatch)
                    {
                        CloseAfterRun = true,
                        ConsoleIsVisible = true,
                        DeleteExistingBatch = true,
                        WaitForExit = true
                    };

                if (WriteRegisterBatchFile()) { _batch.Run();}

                if (File.Exists(referencePath)) {return true;}
                }
            }
            catch (Exception)
            {
                // No action needed here
            }

            return false;
        }


        /// <summary>
        /// Writes a batch file registers the CSi program after unregistering any currently registered CSi program of the same name.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private bool WriteRegisterBatchFile()
        {
            if (_batch == null) { return false; }

            string programName = Path.GetFileName(ProgramPath);

            string commandLine = "cd \"" + ProgramPath + "\"\n" +
                                 "\"UnRegister" + programName + "\"\n" +
                                 "\"Register" + programName + "\"\n";

            _batch.Append(commandLine);

            return true;
        }
        
        #endregion
    }
}
