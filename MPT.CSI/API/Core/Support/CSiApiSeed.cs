#if BUILD_SAP2000v16
using SAP2000v16;
#elif BUILD_SAP2000v17
using SAP2000v17;
#elif BUILD_SAP2000v18
using SAP2000v18;
#elif BUILD_SAP2000v19
using SAP2000v19;
#elif BUILD_ETABS2013
using ETABS2013;
#elif BUILD_ETABS2014
using ETABS2014;
#elif BUILD_ETABS2015
using ETABS2015;
#elif BUILD_ETABS2016
using ETABS2016;
#endif

namespace MPT.CSI.API.Core.Support
{
    /// <summary>
    /// Exposes CSiApiBase properties as read-only.
    /// This class primarly functions as a means of compactly transporting this collection of core objects as a unit.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class CSiApiSeed : CSiApiBase
    {
        #region Fields

#if BUILD_SAP2000v16
        
        /// <summary>
        /// Gets the SAP object, which represents the SAP application process.
        /// </summary>
        /// <value>The sap object.</value>
        public SAP2000v16.SapObject SapObject;
#else        
        /// <summary>
        /// Gets the SAP object, which represents the SAP application process.
        /// </summary>
        /// <value>The sap object.</value>
        public cOAPI SapObject => _sapObject;
#endif        
        /// <summary>
        /// Gets the SAP model, which represents the SAP model object that contains most of the application API calls.
        /// </summary>
        /// <value>The sap model.</value>
        public cSapModel SapModel => _sapModel;


        #endregion

        #region Initialiation        
        /// <summary>
        /// Initializes a new instance of the <see cref="CSiApiSeed"/> class.
        /// </summary>
        public CSiApiSeed(){ }

#if BUILD_SAP2000v16
        /// <summary>
        /// Initializes a new instance of the <see cref="CSiApiSeed"/> class.
        /// </summary>
        /// <param name="sapObject">The sap object.</param>
        /// <param name="sapModel">The sap model.</param>
        public CSiApiBaseSeed(SapObject sapObject, cSapModel sapModel)
        {
            SapObject = sapObject;
            SapModel = sapModel;
        }
#else        
        /// <summary>
        /// Initializes a new instance of the <see cref="CSiApiSeed"/> class.
        /// </summary>
        /// <param name="sapObject">The sap object.</param>
        /// <param name="sapModel">The sap model.</param>
        public CSiApiSeed(cOAPI sapObject, cSapModel sapModel)
        {
            _sapObject = sapObject;
            _sapModel = sapModel;
        }
#endif

        #endregion
    }
}
