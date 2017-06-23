using MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel;
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
    public class ObjectModeler : CSiApiBase
    {

        #region Fields
        private readonly CSiApiSeed _seed;

        private AreaObject _areaObject;
        private CableObject _cableObject;
        private FrameObject _frameObject;
        private LinkObject _linkObject;
        private PointObject _pointObject;
        private SolidObject _solidObject;
        private TendonObject _tendonObject;
        private ExternalAnalysisResults _externalAnalysisResults;
        #endregion

        #region Properties

        public AreaObject AreaObject => _areaObject ?? (_areaObject = new AreaObject(_seed));

        public CableObject CableObject => _cableObject ?? (_cableObject = new CableObject(_seed));


        public FrameObject FrameObject => _frameObject ?? (_frameObject = new FrameObject(_seed));


        public LinkObject LinkObject => _linkObject ?? (_linkObject = new LinkObject(_seed));


        public PointObject PointObject => _pointObject ?? (_pointObject = new PointObject(_seed));


        public SolidObject SolidObject => _solidObject ?? (_solidObject = new SolidObject(_seed));


        public TendonObject TendonObject => _tendonObject ?? (_tendonObject = new TendonObject(_seed));


        public ExternalAnalysisResults ExternalAnalysisResults => _externalAnalysisResults ?? (_externalAnalysisResults = new ExternalAnalysisResults(_seed));
        #endregion


        #region Initialization


        public ObjectModeler(CSiApiSeed seed) : base(seed)
        {
            _seed = seed;
        }


        #endregion

        #region Methods



        #endregion
    }
}
