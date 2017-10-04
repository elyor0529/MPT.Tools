#if BUILD_ETABS2015 || BUILD_ETABS2016 || BUILD_SAP2000v17 || BUILD_SAP2000v19 || BUILD_CSiBridgev18 || BUILD_CSiBridgev19
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
namespace MPT.CSI.API.Core.Support
{
    /// <summary>
    /// The new OAPI helper class to get a reference to cOAPI interface.
    /// </summary>
    public class Helper
    {
        #region Fields
        private readonly CSiProgram.cHelper _helper;
        #endregion

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Helper"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public Helper()
        {
            _helper = new CSiProgram.Helper();
        }
        #endregion

        #region Methods: Public        
        /// <summary>
        /// Creates the base application object to call API methods on.
        /// </summary>
        /// <param name="fullPath">Path to the CSi application that the class manipulates. 
        /// Make sure this is a valid path before using this method.</param>
        /// <returns>CSiProgram.cOAPI.</returns>
        public CSiProgram.cOAPI CreateObject(string fullPath)
        {
            return _helper.CreateObject(fullPath);
        }


        public CSiProgram.cOAPI CreateObjectProgID(string progID)
        {
            return _helper.CreateObjectProgID(progID);
        }


        public CSiProgram.cOAPI GetObject(string typeName)
        {
            return _helper.GetObject(typeName);
        }
        #endregion
    }
}
#endif