using System;
using IO = System.IO;

using MPT.CSI.API.Core.Support;
using MPT.CSI.API.Core.Program.ModelBehavior;

#if BUILD_SAP2000v16
using SAP2000v16;
#elif BUILD_SAP2000v17
using SAP2000v17;
#elif BUILD_SAP2000v18
using SAP2000v18;
#elif BUILD_SAP2000v19
using SAP2000v19;
#elif BUILD_ETABS2013
using System.Reflection;
using ETABS2013;
#elif BUILD_ETABS2014
using ETABS2014;
#elif BUILD_ETABS2015
using ETABS2015;
#elif BUILD_ETABS2016
using ETABS2016;
#endif

namespace MPT.CSI.API.Core.Program
{
    /// <summary>
    /// Main CSi program object. Most API functions are called on this or contained delegate objects.
    /// </summary>
    public class CSiModel : CSiApiSeed
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public readonly File File;

        /// <summary>
        /// 
        /// </summary>
        public readonly CSiApplication Application;

        /// <summary>
        /// 
        /// </summary>
        public readonly AnalysisModeler AnalysisModel;

        /// <summary>
        /// 
        /// </summary>
        public readonly Analyzer Analyze;

        /// <summary>
        /// 
        /// </summary>
        public readonly Definitions Definitions;

        /// <summary>
        /// 
        /// </summary>
        public readonly Designer Design;

        /// <summary>
        /// 
        /// </summary>
        public readonly Editor Editor;

        /// <summary>
        /// 
        /// </summary>
        public readonly ObjectModeler ObjectModel;

        /// <summary>
        /// 
        /// </summary>
        public readonly Options Options;

        /// <summary>
        /// 
        /// </summary>
        public readonly AnalysisResults Results;

        /// <summary>
        /// 
        /// </summary>
        public readonly Selector Selector;

        /// <summary>
        /// 
        /// </summary>
        public readonly Viewer Viewer;

        /// <summary>
        /// True: Model is unlocked.
        /// With some exceptions, definitions and assignments can not be changed in a model while the model is locked. 
        /// If an attempt is made to change a definition or assignment while the model is locked and that change is not allowed in a locked model, an error will be returned.
        /// </summary>
        public bool IsModelLocked => GetModelIsLocked();

        /// <summary>
        /// Path to the CSi application that the class manipulates.
        /// </summary>
        public readonly string Path;



        #endregion


        #region Initialization

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">Path to the CSi application that the class manipulates.</param>
        public CSiModel(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Opens a fresh instance of the CSi program.
        /// </summary>
        /// <param name="units">The database units for the new model. 
        /// All data is internally stored in the model in these units.</param>
        /// <returns></returns>
        public bool InitializeProgram(eUnits units = eUnits.kip_in_F)
        {
          if (!IO.File.Exists(Path)) {throw new IO.IOException("The following CSi program path is invalid: " + Path);}
          return initializeProgramSpecific(Path) && InitializeNewModel(units);
        }

        /// <summary>
        /// This function clears the previous model and initializes the program for a new model. 
        /// If it is later needed, you should save your previous model prior to calling this function.
        /// After calling the InitializeNewModel function, it is not necessary to also call the ApplicationStart function because the functionality of the ApplicationStart function is included in the InitializeNewModel function.
        /// </summary>
        /// <param name="units">The database units for the new model. 
        /// All data is internally stored in the model in these units.</param>
        /// <returns></returns>
        public bool InitializeNewModel(eUnits units = eUnits.kip_in_F)
        {
            _callCode = _sapModel.InitializeNewModel(CSiEnumConverter.ToCSi(units));
            return apiCallIsSuccessful(_callCode);
        }
        #endregion

        #region Methods: Public
        // ==== Model States ===
        
        /// <summary>
        /// True: Model is unlocked.
        /// With some exceptions, definitions and assignments cannot be changed in a model while the model is locked. 
        /// If an attempt is made to change a definition or assignment while the model is locked and that change is not allowed in a locked model, an error will be returned.
        /// </summary>
        /// <returns></returns>
        public bool GetModelIsLocked()
        {
            return _sapModel.GetModelIsLocked();
        }

        /// <summary>
        /// Sets whether or not the model is locked.
        /// With some exceptions, definitions and assignments can not be changed in a model while the model is locked. 
        /// If an attempt is made to change a definition or assignment while the model is locked and that change is not allowed in a locked model, an error will be returned.
        /// </summary>
        /// <param name="lockModel">True: Model will be locked.</param>
        public void SetModelIsLocked(bool lockModel)
        {
            _callCode = _sapModel.SetModelIsLocked(lockModel);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // ==== User Comment ===
        /// <summary>
        /// Retrieves the data in the user comments and log.
        /// </summary>
        /// <returns></returns>
        public void GetUserComment(ref string commentUser)
        {
            _callCode = _sapModel.GetUserComment(ref commentUser);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function sets the user comments and log data.
        /// </summary>
        /// <param name="commentUser">The data to be added to the user comments and log.</param>
        /// <param name="numberLinesBlank">The number of carriage return and line feeds to be included before the specified comment. 
        /// This item is ignored if there are no existing comments.</param>
        /// <param name="replace">True: All existing comments are replaced with the specified comment.</param>
        public void SetUserComment(string commentUser, int numberLinesBlank = 1, bool replace = false)
        {
            _callCode = _sapModel.SetUserComment(commentUser, numberLinesBlank, replace);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        // ==== Units ===
        /// <summary>
        /// Returns the database units for the model. 
        /// All data is internally stored in the model in these units and converted to the present units as needed.
        /// </summary>
        /// <returns></returns>
        public eUnits GetDatabaseUnits()
        {
            return CSiEnumConverter.FromCSi(_sapModel.GetDatabaseUnits());
        }

        /// <summary>
        /// Returns the units presently specified for the model.
        /// </summary>
        /// <returns></returns>
        public eUnits GetPresentUnits()
        {
            return CSiEnumConverter.FromCSi(_sapModel.GetPresentUnits());
        }

        /// <summary>
        /// Sets the units presently specified for the model.
        /// </summary>
        /// <returns></returns>
        public void SetPresentUnits(eUnits units)
        {
            _callCode = _sapModel.SetPresentUnits(CSiEnumConverter.ToCSi(units));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // ==== Get/Set Methods ===

        /// <summary>
        /// Retrieves the value of the program auto merge tolerance.
        /// </summary>
        /// <param name="mergeTolerance">The program auto merge tolerance. [L</param>
        public void GetMergeTolerance(ref double mergeTolerance)
        {
            _callCode = _sapModel.GetMergeTol(ref mergeTolerance);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Sets the value of the program auto merge toleranc
        /// </summary>
        /// <param name="mergeTolerance">The program auto merge tolerance. [L]</param>
        public void SetMergeTolerance(double mergeTolerance)
        {
            _callCode = _sapModel.SetMergeTol(mergeTolerance);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Returns the name of the present coordinate system.
        /// </summary>
        /// <returns></returns>
        public string GetPresentCoordSystem()
        {
            return _sapModel.GetPresentCoordSystem();
        }

        /// <summary>
        /// Sets the present coordinate system.
        /// </summary>
        /// <param name="nameCoordinateSystem">The name of a defined coordinate system.</param>
        public void SetPresentCoordSystem(string nameCoordinateSystem)
        {
            _callCode = _sapModel.SetPresentCoordSystem(nameCoordinateSystem);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Retrieves the project information data.
        /// </summary>
        /// <param name="numberItems">The number of project info items returned.</param>
        /// <param name="projectInfoItems">This is an array that includes the name of the project information item.</param>
        /// <param name="projectInfoData">This is an array that includes the data for the specified project information item.</param>
        public void GetProjectInfo(ref int numberItems,
                                    ref string[] projectInfoItems,
                                    ref string[] projectInfoData)
        {
            _callCode = _sapModel.GetProjectInfo(ref numberItems, ref projectInfoItems, ref projectInfoData);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Sets the data for an item in the project information.
        /// </summary>
        /// <param name="projectInfoItem">Name of the project information item</param>
        /// <param name="projectInfoData">Data for the specified project information item.</param>
        public void SetProjectInfo(string projectInfoItem,
                                    string projectInfoData)
        {
            _callCode = _sapModel.SetProjectInfo(projectInfoItem, projectInfoData);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion


        #region Methods: Private

        /// <summary>
        /// Performs the application-specific steps of initializing the program.
        /// This initializes SapObject and SapModel.
        /// </summary>
        /// <param name="path">Path to the CSi application that the class manipulates. 
        /// Make sure this is a valid path before using this method.</param>
        /// <returns></returns>
        private bool initializeProgramSpecific(string path)
        {
            try
            {
#if BUILD_ETABS2013
                //  Create program object
                Assembly myAssembly = Assembly.LoadFrom(path);

        //  Create an instance of ETABSObject and get a reference to cOAPI interface 
                _sapObject = DirectCast(myAssembly.CreateInstance("CSI.ETABS.API.ETABSObject"), cOAPI);

        //  start ETABS application
                _sapObject.ApplicationStart();

        //  create SapModel object
                _sapModel = _SapObject.SapModel;

#elif BUILD_ETABS2014 || BUILD_ETABS2015 || BUILD_ETABS2016
                // Old Method: 32bit OAPI clients can only call 32bit ETABS 2014 and 64bit OAPI clients can only call
                //    64bit ETABS 2014. Currently only used in ETABS 2013.
                // Create an instance of ETABSObject and get a reference to cOAPI interface
                //    ETABSObject = DirectCast(myAssembly.CreateInstance("CSI.ETABS.API.ETABSObject"), cOAPI)

        // New Method: 32bit & 64bit API clients can call 32 & 64bit ETABS 2014
        //    Use the new OAPI helper class to get a reference to cOAPI interface
            cHelper myHelper = new Helper();
            _sapObject = helper.CreateObject(path);

        //    start ETABS application;
            _sapObject.ApplicationStart()

        //    create SapModel object
            _sapModel = _SapObject.SapModel;
#elif BUILD_SAP2000v16
            // NOTE: No path is needed for SAP2000v16. Instead, CSiProgressiveCollapse will automatically use the
            //    version currently installed. To change the version, say for testing, run the desired v16 version as 
            //    administrator first in order to register.
            _sapObject = new SAP2000v16.SapObject;

            //    start Sap2000 application
            _sapObject.ApplicationStart();

            //    create SapModel object
            _sapModel = _SapObject.SapModel;
#elif BUILD_SAP2000v17 || BUILD_SAP2000v19
                // Old Method: 32bit OAPI clients can only call 32bit ETABS 2014 and 64bit OAPI clients can only call 64bit ETABS 2014
                // Create program object
                // _SapObject = DirectCast(myAssembly.CreateInstance("CSI.SAP2000.API.SapObject"), cOAPI)

                // New Method: 32bit & 64bit API clients can call 32 & 64bit ETABS 2014
                // Use the new OAPI helper class to get a reference to cOAPI interface
                cHelper myHelper = new Helper();
                _sapObject = myHelper.CreateObject(path);

            // start Sap2000 application
                _sapObject.ApplicationStart();

            // create SapModel object
                _sapModel = SapObject.SapModel;
# endif
                return true;
            }
            catch (Exception)
            {
                // TODO: Determine action
                throw;
            }
            return false;
        }


#endregion
    }
}
