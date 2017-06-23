using MPT.CSI.API.Core.Support;

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

namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisResult
{
    public class Results : CSiApiBase
    {

        #region Fields


        #endregion


        #region Properties



        #endregion


        #region Initialization


        public Results(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods



        #endregion
    }
}
