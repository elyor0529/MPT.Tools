using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program
{
    /// <summary>
    /// Manipulates the CSi application, such as opening, closing, setting visiblity and active object, etc.
    /// </summary>
    public class CSiApplication : CSiApiBase
    {
        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="CSiApplication"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public CSiApplication(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Public
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
        /// <param name="fileName">The full path of a model file to be opened when the application is started. 
        /// If no file name is specified, the application starts without loading an existing model.</param>
        public void ApplicationStart(eUnits units = eUnits.kip_in_F, 
                                    bool visible = true, 
                                    string fileName = "")
        {
            _callCode = _sapObject.ApplicationStart(CSiEnumConverter.ToCSi(units), visible, fileName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function closes the application. 
         /// If the model file is saved then it is saved with its current name.
        /// </summary>
        /// <param name="fileSave">True: The existing model file is saved prior to closing program.</param>
        public void ApplicationExit(bool fileSave)
        {
            _callCode = _sapObject.ApplicationExit(fileSave);
            _sapModel = null;
            _sapObject = null;
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function hides the application. 
        /// When the application is hidden it is not visible on the screen or on the Windows task bar.
        /// If the application is already hidden, no action is taken.
        /// </summary>
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
        ///  This function sets the active instance of a _SapObject in the system Running Object Table (ROT), replacing the previous instance(s).
        /// When a new _SapObject is created using the OAPI, it is automatically added to the system ROT if none is already present. 
        /// Subsequent instances of the _SapObject do not alter the ROT as long as at least one active instance of a _SapObject is present in the ROT.
        /// The Windows API call GetObject() can be used to attach to the active _SapObject instance registered in the ROT. 
        /// When the application is started normally (i.e. not from the OAPI), it does not add an instance of the _SapObject to the ROT, hence the GetObject() call cannot be used to attach to the active _SapObject instance.
        /// The Windows API call CreateObject() or New Sap2000v16._SapObject command can be used to attach to an instance of SAP2000 that is started normally (i.e. not from the OAPI). 
        /// If there are multiple such instances, the first instance that will be attached to is the one that is started first.
        /// </summary>
        public void SetAsActiveObject()
        {
            _callCode = _sapObject.SetAsActiveObject();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function removes the current instance of a _sapObject from the system Running Object Table (ROT).
        /// </summary>
        public void UnsetAsActiveObject()
        {
            _callCode = _sapObject.UnsetAsActiveObject();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion
    }
}