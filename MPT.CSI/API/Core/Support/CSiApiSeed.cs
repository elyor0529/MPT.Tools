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
    public class CSiApiSeed : CSiApiBase
    {
        #region Fields

#if BUILD_SAP2000v16
        public SAP2000v16.SapObject SapObject;
#else
        public cOAPI SapObject => _sapObject;
#endif
        public cSapModel SapModel => _sapModel;


        #endregion

        #region Initialiation
        public CSiApiSeed(){ }

#if BUILD_SAP2000v16
        public CSiApiBaseSeed(SapObject sapObject, cSapModel sapModel)
        {
            SapObject = sapObject;
            SapModel = sapModel;
        }
#else
        public CSiApiSeed(cOAPI sapObject, cSapModel sapModel)
        {
            _sapObject = sapObject;
            _sapModel = sapModel;
        }
#endif

        #endregion
    }
}
