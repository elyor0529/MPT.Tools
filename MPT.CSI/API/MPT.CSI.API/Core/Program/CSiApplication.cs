// ***********************************************************************
// Assembly         : MPT.CSI.API
// Author           : Mark Thomas
// Created          : 06-04-2017
//
// Last Modified By : Mark Thomas
// Last Modified On : 10-10-2017
// ***********************************************************************
// <copyright file="CSiApplication.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using IO = System.IO;
#if BUILD_SAP2000v16
using CSiProgram = SAP2000v16;
#elif BUILD_SAP2000v17
using CSiProgram = SAP2000v17;
#elif BUILD_SAP2000v18
using CSiProgram = SAP2000v18;
#elif BUILD_SAP2000v19
using CSiProgram = SAP2000v19;
#elif BUILD_CSiBridgev18
using CSiProgram = CSiBridge18;
#elif BUILD_CSiBridgev19
using CSiProgram = CSiBridge19;
#elif BUILD_ETABS2013
using CSiProgram = ETABS2013;
#elif BUILD_ETABS2015
using CSiProgram = ETABS2015;
#elif BUILD_ETABS2016
using CSiProgram = ETABS2016;
#endif
using MPT.Enums;
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program
{
    /// <summary>
    /// Manipulates the CSi application, such as opening, closing, setting visiblity and active object, etc.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class CSiApplication : CSiApiBase, IDisposable
    {
        #region Fields
#if BUILD_ETABS2015 || BUILD_ETABS2016
        const string TYPE_NAME = "CSI.ETABS.API.ETABSObject";
#else
        /// <summary>
        /// The type name
        /// </summary>
        const string TYPE_NAME = "CSI.SAP2000.API.SapObject";
#endif

        /// <summary>
        /// The seed
        /// </summary>
        private CSiApiSeed _seed;

        /// <summary>
        /// The model
        /// </summary>
        private CSiModel _model;
        #endregion

        #region Properties               

        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <value>The file.</value>
        public CSiModel Model => _model ?? (_model = new CSiModel(_seed));

        /// <summary>
        /// Path to the CSi application that the class manipulates.
        /// This might not be specifed if the object attaches to a process or initializes the default isntalled program.
        /// </summary>
        /// <value>The path.</value>
        public string Path { get; private set; }
        #endregion

        #region Initialization        

        /// <summary>
        /// Initializes a new instance of the <see cref="CSiApplication" /> class.
        /// </summary>
        public CSiApplication(string modelPath,
            string applicationPath = "")
        {
            InitializeProgram(modelPath, applicationPath);
        }

        public CSiApplication(string applicationPath,
            eUnits units = eUnits.kip_in_F)
        {
            InitializeProgram(applicationPath, units);
        }

        public CSiApplication(bool startNewProcess = true)
        {
            if (startNewProcess)
            {
                InitializeProgram();
            }
            else
            {
                AttachToProcess();
            }
        }


        #endregion

        #region Methods: Public
        /// <summary>
        /// Opens a fresh instance of the CSi program.
        /// </summary>
        /// <param name="units">The database units for the new model.
        /// All data is internally stored in the model in these units.</param>
        /// <param name="applicationPath"></param>
        /// <returns><c>true</c> if the program is successfully initialied, <c>false</c> otherwise.</returns>
        /// <exception cref="IO.IOException">The following CSi program path is invalid: " + Path</exception>
        public bool InitializeProgram(string applicationPath = "",
            eUnits units = eUnits.kip_in_F)
        {
            if (!string.IsNullOrWhiteSpace(applicationPath))
            {
                if (!IO.File.Exists(applicationPath))
                {
                    throw new IO.IOException("The following CSi program path is invalid: " + applicationPath);
                }
                return initializeProgramSpecific(applicationPath) && Model.InitializeNewModel(units);
            }
            return initializeProgramFromLatestInstallation() && Model.InitializeNewModel(units);
        }

        /// <summary>
        /// Opens the specified model in a fresh instance of the CSi program.
        /// </summary>
        /// <param name="applicationPath"></param>
        /// <returns><c>true</c> if the program is successfully initialied, <c>false</c> otherwise.</returns>
        /// <exception cref="IO.IOException">The following CSi program path is invalid: " + Path</exception>
        public bool InitializeProgram(string modelPath, 
            string applicationPath = "")
        {
            if (!string.IsNullOrWhiteSpace(applicationPath))
            {
                if (!IO.File.Exists(applicationPath))
                {
                    throw new IO.IOException("The following CSi program path is invalid: " + applicationPath);
                }
                return initializeProgramSpecific(applicationPath) && Model.File.Open(modelPath);
            }
            return initializeProgramFromLatestInstallation() && Model.File.Open(modelPath);
        }

        /// <summary>
        /// Attaches to an existing process.
        /// The program can be ended manually or by calling ApplicationExit
        /// Please note that if multiple instances of ETABS are manually started, an API client can only attach to the instance that was started first.
        /// </summary>
        /// <returns><c>true</c> if the process is successfully attached to, <c>false</c> otherwise.</returns>
        public bool AttachToProcess()
        {
            try
            {
                Helper helper = Helper.Initialize();
                _sapObject = helper.GetObject(TYPE_NAME);

                //Get a reference to cSapModel to access all API classes and functions
                _sapModel = _sapObject.SapModel;
                _seed = new CSiApiSeed(_sapObject, _sapModel);

                return true;
            }
            catch (Exception ex)
            {
                throw new CSiException("No running instance of the program found or failed to attach.", ex);
                // TODO: Replace the exception with a logger.
                //return false;
            };
        }

#if BUILD_ETABS2015 || BUILD_ETABS2016
        /// <summary>
        /// This function starts the application.
        /// If no filename is specified, you can later open a model or create a model through the API.
        /// The file name must have an .edb, .$et, .e2k, .xls, or .mdb extension. 
        /// Files with .edb extensions are opened as standard ETABS files. 
        /// Files with .$et and .e2k extensions are imported as text files. 
        /// Files with .xls extensions are imported as Microsoft Excel files. 
        /// Files with .mdb extensions are imported as Microsoft Access files.
        /// </summary>
        /// <param name="visible">True: The application is visible when started.  False: The application is hidden when started.</param>
        /// <param name="filePath">The full path of a model file to be opened when the application is started.
        /// If no file name is specified, the application starts without loading an existing model.</param>
        /// <exception cref="CSiException"></exception>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void ApplicationStart(bool visible = true, 
                                     string filePath = "")
        {
            _callCode = _sapObject.ApplicationStart();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
            if (!visible) Hide();
            if (!string.IsNullOrWhiteSpace(filePath)) Model.File.Open(filePath);
        }
#else
        /// <summary>
        /// This function starts the application.
        /// When the model is not visible it does not appear on screen and it does not appear in the Windows task bar.
        /// If no filename is specified, you can later open a model or create a model through the API.
        /// The file name must have an .sdb, .$2k, .s2k, .xls, or .mdb extension.
        /// Files with .sdb extensions are opened as standard SAP2000 files.
        /// Files with .$2k and .s2k extensions are imported as text files.
        /// Files with .xls extensions are imported as Microsoft Excel files.
        /// Files with .mdb extensions are imported as Microsoft Access files.
        /// </summary>
        /// <param name="units">The database units used when a new model is created.
        /// Data is internally stored in the program in the database units.</param>
        /// <param name="visible">True: The application is visible when started.  False: The application is hidden when started.</param>
        /// <param name="filePath">The full path of a model file to be opened when the application is started.
        /// If no file name is specified, the application starts without loading an existing model.</param>
        /// <exception cref="CSiException"></exception>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void ApplicationStart(eUnits units = eUnits.kip_in_F, 
                                    bool visible = true, 
                                    string filePath = "")
        {
            _callCode = _sapObject.ApplicationStart(EnumLibrary.Convert<eUnits, CSiProgram.eUnits>(units), visible, filePath);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
#endif
        
        /// <summary>
        /// This function closes the application.
        /// If the model file is saved then it is saved with its current name.
        /// </summary>
        /// <param name="fileSave">True: The existing model file is saved prior to closing program.</param>
        /// <exception cref="CSiException"></exception>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void ApplicationExit(bool fileSave)
        {
            if (_sapObject == null) { return; }
            _callCode = _sapObject.ApplicationExit(fileSave);
            _sapModel = null;
            _sapObject = null;
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

#if BUILD_ETABS2015 || BUILD_ETABS2016
        /// <summary>
        /// Retrieves the OAPI version number.
        /// </summary>
        /// <returns>System.Double.</returns>
        public double GetOAPIVersionNumber()
        {
            return _sapObject.GetOAPIVersionNumber();
        }
#endif

        /// <summary>
        /// This function hides the application.
        /// When the application is hidden it is not visible on the screen or on the Windows task bar.
        /// If the application is already hidden, no action is taken.
        /// </summary>
        /// <exception cref="CSiException"></exception>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void Hide()
        {
            _callCode = _sapObject.Hide();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function unhides the application.
        /// When the application is hidden it is not visible on the screen or on the Windows task bar.
        /// If the application is already visible, no action is taken.
        /// </summary>
        /// <exception cref="CSiException"></exception>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void UnHide()
        {
            _callCode = _sapObject.Unhide();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// True: The application is visible on the screen.
        /// </summary>
        public void Visible()
        {
            _sapObject.Visible();
        }

        /// <summary>
        /// This function sets the active instance of a _SapObject in the system Running Object Table (ROT), replacing the previous instance(s).
        /// When a new _SapObject is created using the OAPI, it is automatically added to the system ROT if none is already present.
        /// Subsequent instances of the _SapObject do not alter the ROT as long as at least one active instance of a _SapObject is present in the ROT.
        /// The Windows API call GetObject() can be used to attach to the active _SapObject instance registered in the ROT.
        /// When the application is started normally (i.e. not from the OAPI), it does not add an instance of the _SapObject to the ROT, hence the GetObject() call cannot be used to attach to the active _SapObject instance.
        /// The Windows API call CreateObject() or New Sap2000v16._SapObject command can be used to attach to an instance of SAP2000 that is started normally (i.e. not from the OAPI).
        /// If there are multiple such instances, the first instance that will be attached to is the one that is started first.
        /// </summary>
        /// <exception cref="CSiException"></exception>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void SetAsActiveObject()
        {
            _callCode = _sapObject.SetAsActiveObject();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function removes the current instance of a _sapObject from the system Running Object Table (ROT).
        /// </summary>
        /// <exception cref="CSiException"></exception>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void UnsetAsActiveObject()
        {
            _callCode = _sapObject.UnsetAsActiveObject();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion

        
        #region IDisposable        
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            ApplicationExit(fileSave: false);
        }
        #endregion

        #region Methods: Private        

        /// <summary>
        /// Performs the application-specific steps of initializing the program.
        /// This initializes SapObject and SapModel.
        /// </summary>
        /// <param name="path">Path to the CSi application that the class manipulates.
        /// Make sure this is a valid path before using this method.</param>
        /// <returns><c>true</c> if program is successfully initialized, <c>false</c> otherwise.</returns>
        private bool initializeProgramSpecific(string path)
        {
            try
            {
#if BUILD_ETABS2013
                //  Create program object
                Assembly myAssembly = Assembly.LoadFrom(path);

        //  Create an instance of ETABSObject and get a reference to cOAPI interface 
                _sapObject = DirectCast(myAssembly.CreateInstance(TYPE_NAME), cOAPI);
#elif BUILD_ETABS2015 || BUILD_ETABS2016
                // Old Method: 32bit OAPI clients can only call 32bit ETABS 2014 and 64bit OAPI clients can only call
                //    64bit ETABS 2014. Currently only used in ETABS 2013.
                // Create an instance of ETABSObject and get a reference to cOAPI interface
                //    ETABSObject = DirectCast(myAssembly.CreateInstance("CSI.ETABS.API.ETABSObject"), cOAPI)

                // New Method: 32bit & 64bit API clients can call 32 & 64bit ETABS 2014
                //    Use the new OAPI helper class to get a reference to cOAPI interface
                Helper helper = Helper.Initialize();
                _sapObject = helper.CreateObject(path);
#elif BUILD_SAP2000v16
            // NOTE: No path is needed for SAP2000v16. Instead, the tested program will automatically use the
            //    version currently installed. To change the version, say for testing, run the desired v16 version as 
            //    administrator first in order to register.
            _sapObject = new SAP2000v16.SapObject;
#elif BUILD_SAP2000v17 || BUILD_SAP2000v19
                // Old Method: 32bit OAPI clients can only call 32bit ETABS 2014 and 64bit OAPI clients can only call 64bit ETABS 2014
                // Create program object
                // _SapObject = DirectCast(myAssembly.CreateInstance("CSI.SAP2000.API.SapObject"), cOAPI)

                // New Method: 32bit & 64bit API clients can call 32 & 64bit ETABS 2014
                // Use the new OAPI helper class to get a reference to cOAPI interface
                Helper helper = Helper.Initialize();
                _sapObject = helper.CreateObject(path);
#endif
                // start Sap2000 application
                _sapObject.ApplicationStart();

                // create SapModel object
                _sapModel = _sapObject.SapModel;
                _seed = new CSiApiSeed(_sapObject, _sapModel);

                Path = path;
                return true;
            }
            catch (Exception ex)
            {
                throw new CSiException("Cannot start a new instance of the program from " + path, ex);
                // TODO: Replace the exception with a logger.
                //return false;
            }
        }

        private bool initializeProgramFromLatestInstallation()
        {
            try
            {
#if BUILD_ETABS2013
                //  Create program object
                Assembly myAssembly = Assembly.LoadFrom(path);

        //  Create an instance of ETABSObject and get a reference to cOAPI interface 
                _sapObject = DirectCast(myAssembly.CreateInstance(TYPE_NAME), cOAPI);
#elif BUILD_ETABS2015 || BUILD_ETABS2016
                // Old Method: 32bit OAPI clients can only call 32bit ETABS 2014 and 64bit OAPI clients can only call
                //    64bit ETABS 2014. Currently only used in ETABS 2013.
                // Create an instance of ETABSObject and get a reference to cOAPI interface
                //    ETABSObject = DirectCast(myAssembly.CreateInstance("CSI.ETABS.API.ETABSObject"), cOAPI)

                // New Method: 32bit & 64bit API clients can call 32 & 64bit ETABS 2014
                //    Use the new OAPI helper class to get a reference to cOAPI interface
                Helper helper = Helper.Initialize();
                _sapObject = helper.CreateObjectProgId(TYPE_NAME);
#elif BUILD_SAP2000v16
            // NOTE: No path is needed for SAP2000v16. Instead, the tested program will automatically use the
            //    version currently installed. To change the version, say for testing, run the desired v16 version as 
            //    administrator first in order to register.
            _sapObject = new SAP2000v16.SapObject;
#elif BUILD_SAP2000v17 || BUILD_SAP2000v19
                // Old Method: 32bit OAPI clients can only call 32bit ETABS 2014 and 64bit OAPI clients can only call 64bit ETABS 2014
                // Create program object
                // _SapObject = DirectCast(myAssembly.CreateInstance("CSI.SAP2000.API.SapObject"), cOAPI)

                // New Method: 32bit & 64bit API clients can call 32 & 64bit ETABS 2014
                // Use the new OAPI helper class to get a reference to cOAPI interface
                Helper helper = Helper.Initialize();
                _sapObject = helper.CreateObjectProgId(TYPE_NAME);
#endif
                // start Sap2000 application
                _sapObject.ApplicationStart();

                // create SapModel object
                _sapModel = _sapObject.SapModel;
                _seed = new CSiApiSeed(_sapObject, _sapModel);

                // TODO: Assign path of installation to Path property.

                return true;
            }
            catch (Exception ex)
            {
                throw new CSiException("Cannot start a new instance of the program.", ex);
                // TODO: Replace the exception with a logger.
                //return false;
            }
        }
        #endregion
    }
}