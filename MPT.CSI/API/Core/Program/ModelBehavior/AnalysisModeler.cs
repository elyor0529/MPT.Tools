using MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel;
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
    public class AnalysisModeler : CSiApiBase
    {

        #region Fields
        private readonly CSiApiSeed _seed;

        private AreaElement _areaElement;
        private LineElement _lineElement;
        private LinkElement _linkElement;
        private PlaneElement _planeElement;
        private PointElement _pointElement;
        private SolidElement _solidElement;
        #endregion

        #region Properties
        public AreaElement AreaElement => _areaElement ?? (_areaElement = new AreaElement(_seed));


        public LineElement LineElement => _lineElement ?? (_lineElement = new LineElement(_seed));


        public LinkElement LinkElement => _linkElement ?? (_linkElement = new LinkElement(_seed));


        public PlaneElement PlaneElement => _planeElement ?? (_planeElement = new PlaneElement(_seed));


        public PointElement PointElement => _pointElement ?? (_pointElement = new PointElement(_seed));


        public SolidElement SolidElement => _solidElement ?? (_solidElement = new SolidElement(_seed));
        #endregion


        #region Initialization


        public AnalysisModeler(CSiApiSeed seed) : base(seed)
        {
            _seed = seed;
        }


        #endregion
    }
}