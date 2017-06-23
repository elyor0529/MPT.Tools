using MPT.CSI.API.Core.Program.ModelBehavior.AnalysisResult;
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

namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    public class AnalysisResults : CSiApiBase
    {

        #region Fields
        private readonly CSiApiSeed _seed;

        private AnalysisResultsSetup _analysisResultsSetup;
        private Results _results;
        #endregion

        #region Properties

        public AnalysisResultsSetup AnalysisResultsSetup => _analysisResultsSetup ?? (_analysisResultsSetup = new AnalysisResultsSetup(_seed));


        public Results Results => _results ?? (_results = new Results(_seed));
        #endregion


        #region Initialization


        public AnalysisResults(CSiApiSeed seed) : base(seed)
        {
            _seed = seed;
        }


        #endregion
    }
}
