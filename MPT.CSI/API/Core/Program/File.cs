using IO = System.IO;

using MPT.CSI.API.Core.Support;

#if BUILD_SAP2000v16
using SAP2000v16;
#elif BUILD_SAP2000v17
using SAP2000v17;
#elif BUILD_SAP2000v18
using SAP2000v18;
#elif BUILD_SAP2000v19
using SAP2000v19;
#elif BUILD_CSiBridgev18
using CSiBridge18;
#elif BUILD_CSiBridgev19
using CSiBridge19;
#elif BUILD_ETABS2013
using ETABS2013;


#elif BUILD_ETABS2015
using ETABS2015;
#elif BUILD_ETABS2016
using ETABS2016;
#endif

namespace MPT.CSI.API.Core.Program
{
    /// <summary>
    /// Implements all API functions within the 'File' namespace.
    /// </summary>
    public class File :  CSiApiBase
    {
        #region Fields
        /// <summary>
        /// File name of the current model, as tracked by the program and not obtained from the API.
        /// </summary>
        private string _fileName;

        /// <summary>
        /// File path of the current model, as tracked by the program and not obtained from the API.
        /// </summary>
        private string _filePath;
        // TODO: Finish consideration of filePath.
        #endregion

        #region Properties
        /// <summary>
        /// Filename of the current model file, with or without the full path.
        /// </summary>
        /// <param name="includePath">True: Returned filename includes the full path where the file is located.</param>
        /// <returns></returns>
        public string FileName(bool includePath = true)
        {
            return GetModelFileName(includePath);
        }

        /// <summary>
        /// Path to the current model file.
        /// </summary>
        public string FilePath
        {
            get { return GetModelFilePath(); }
            set
            {
                _filePath = value;
                _fileName = IO.Path.GetFileName(value);
            }
        }
        #endregion

        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="File"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public File(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Public
        /// <summary>
        /// Opens the specified model file if it exists.
        /// The file name must have an sdb, $2k, s2k, xlsx, xls, or mdb extension. 
        /// Files with sdb extensions are opened as standard Sap2000 files. 
        /// Files with $2k and s2k extensions are imported as text files. 
        /// Files with xlsx and xls extensions are imported as Microsoft Excel files. 
        /// Files with mdb extensions are imported as Microsoft Access files.
        /// This function returns zero if the file is successfully opened and nonzero if it is not opened.
        /// The function is only applicable when you are accessing the application API from an external application. 
        /// It will return an error if you call it from VBA inside Sap2000.
        /// </summary>
        /// <param name="filePath">The full path of a model file to be opened in the application.</param>
        /// <returns></returns>
        public bool Open(string filePath)
        {
            if (!IO.File.Exists(filePath)) { throw new IO.IOException("The following file does not exist: " + filePath);}

            // TODO: Add checks for appropriate file types for the given open program.

            _callCode = _sapModel.File.OpenFile(filePath);
            if (apiCallIsSuccessful(_callCode))
            {
                _fileName = IO.Path.GetFileName(filePath);
                return true;
            }
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
            return false;
        }

        /// <summary>
        /// Saves the model to a file. 
        /// If no file name is specified, the file is saved using its current name.
        /// </summary>
        /// <param name="filePath">The full path to which the model file is saved.</param>
        /// <returns></returns>
        public bool Save(string filePath = "")
        {
            if (string.IsNullOrEmpty(_fileName) && string.IsNullOrEmpty(filePath)) { throw new IO.IOException("The current model has not been previously saved. Please provide a file name.");}

            _callCode = _sapModel.File.Save(filePath);
            if (apiCallIsSuccessful(_callCode))
            {
                if (string.IsNullOrEmpty(filePath)) return true;
                _filePath = filePath;
                _fileName = IO.Path.GetFileName(filePath);
                return true;
            }
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
            return false;
        }

        /// <summary>
        /// The function returns a string that represents the filename of the current model, with or without the full path.
        /// </summary>
        /// <param name="includePath">True: Returned filename includes the full path where the file is located.</param>
        /// <returns></returns>
        public string GetModelFileName(bool includePath)
        {
            return _sapModel.GetModelFilename();
        }

        /// <summary>
        /// Returns a string that represents the filepath of the current model.
        /// </summary>
        /// <returns></returns>
        public string GetModelFilePath()
        {
            return _sapModel.GetModelFilepath(); 
        }

        /// <summary>
        /// Creates a new blank model from template.
        /// Do not use this function to add to an existing model. 
        /// This function should be used only for creating a new model and typically would be preceded by calls to ApplicationStart or InitializeNewModel.
        /// </summary>
        public void NewBlank()
        {
            _callCode = _sapModel.File.NewBlank();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Creates a new template model of a 2D Frame.
        /// Do not use this function to add to an existing model. 
        /// This function should be used only for creating a new model and typically would be preceded by calls to ApplicationStart or InitializeNewModel.
        /// </summary>
        /// <param name="tempType"></param>
        /// <param name="numberStories"></param>
        /// <param name="storyHeight"></param>
        /// <param name="numberBays"></param>
        /// <param name="bayWidth"></param>
        /// <param name="restraint"></param>
        /// <param name="beam"></param>
        /// <param name="column"></param>
        /// <param name="brace"></param>
        public void New2DFrame(e2DFrameType tempType,
            int numberStories,
            double storyHeight,
            int numberBays,
            double bayWidth,
            bool restraint = true,
            string beam = "Default",
            string column = "Default",
            string brace = "Default")
        {
            _callCode = _sapModel.File.New2DFrame(tempType,
                numberStories,
                storyHeight,
                numberBays,
                bayWidth,
                restraint,
                beam, column, brace);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

#if BUILD_SAP2000v16 || BUILD_SAP2000v17 || BUILD_SAP2000v18 || BUILD_SAP2000v19
        /// <summary>
        /// Creates a new template model of a 3D Frame.
        /// Do not use this function to add to an existing model. 
        /// This function should be used only for creating a new model and typically would be preceded by calls to ApplicationStart or InitializeNewModel.
        /// </summary>
        /// <param name="tempType"></param>
        /// <param name="numberStories"></param>
        /// <param name="storyHeight"></param>
        /// <param name="numberBaysX"></param>
        /// <param name="numberBaysY"></param>
        /// <param name="bayWidthX"></param>
        /// <param name="bayWidthY"></param>
        /// <param name="restraint"></param>
        /// <param name="beam"></param>
        /// <param name="column"></param>
        /// <param name="area"></param>
        /// <param name="numberXDivisions"></param>
        /// <param name="numberYDivisions"></param>
        public void New3DFrame(e3DFrameType tempType,
            int numberStories,
            double storyHeight,
            int numberBaysX, int numberBaysY,
            double bayWidthX, double bayWidthY,
            bool restraint = true,
            string beam = "Default",
            string column = "Default",
            string area = "Default",
            int numberXDivisions = 4, int numberYDivisions = 4)
        {
            _callCode = _sapModel.File.New3DFrame(tempType,
                                         numberStories,
                                         storyHeight,
                                         numberBaysX, bayWidthX,
                                         numberBaysY, bayWidthY,
                                         restraint,
                                         beam, column, area,
                                         numberXDivisions, numberYDivisions);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Creates a new template model of a Beam.
        /// Do not use this function to add to an existing model. 
        /// This function should be used only for creating a new model and typically would be preceded by calls to ApplicationStart or InitializeNewModel.
        /// </summary>
        /// <param name="numberSpans"></param>
        /// <param name="spanLength"></param>
        /// <param name="restraint"></param>
        /// <param name="beam"></param>
        public void NewBeam(int numberSpans,
            double spanLength,
            bool restraint = true,
            string beam = "Default")
        {
            _callCode = _sapModel.File.NewBeam(numberSpans,
                                    spanLength,
                                    restraint,
                                    beam);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Creates a new template model of a Wall.
        /// Do not use this function to add to an existing model. 
        /// This function should be used only for creating a new model and typically would be preceded by calls to ApplicationStart or InitializeNewModel.
        /// </summary>
        /// <param name="numberXDivisions"></param>
        /// <param name="numberZDivisions"></param>
        /// <param name="divisionWidthX"></param>
        /// <param name="divisionWidthZ"></param>
        /// <param name="restraint"></param>
        /// <param name="area"></param>
        public void NewWall(int numberXDivisions,
            int numberZDivisions,
            double divisionWidthX,
            double divisionWidthZ,
            bool restraint = true,
            string area = "Default")
        {
            _callCode = _sapModel.File.NewWall(numberXDivisions, divisionWidthX,
                                        numberZDivisions, divisionWidthZ,
                                        restraint,
                                        area);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Creates a new template model of a Solid.
        /// Do not use this function to add to an existing model. 
        /// This function should be used only for creating a new model and typically would be preceded by calls to ApplicationStart or InitializeNewModel.
        /// </summary>
        /// <param name="xWidth"></param>
        /// <param name="yWidth"></param>
        /// <param name="height"></param>
        /// <param name="restraint"></param>
        /// <param name="solid"></param>
        /// <param name="numberXDivisions"></param>
        /// <param name="numberYDivisions"></param>
        /// <param name="numberZDivisions"></param>
        public void NewSolidBlock(double xWidth,
            double yWidth,
            double height,
            bool restraint = true,
            string solid = "Default",
            int numberXDivisions = 5,
            int numberYDivisions = 8,
            int numberZDivisions = 10)
        {
            _callCode = _sapModel.File.NewSolidBlock(xWidth, yWidth, height,
                                                restraint,
                                                solid,
                                                numberXDivisions, numberYDivisions, numberZDivisions);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
#elif BUILD_ETABS2013 || BUILD_ETABS2014 || BUILD_ETABS2015 || BUILD_ETABS2016

#endif
        #endregion
    }
}