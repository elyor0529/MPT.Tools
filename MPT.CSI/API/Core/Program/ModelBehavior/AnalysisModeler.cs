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
    /// <summary>
    /// Represents the various analysis elements in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
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
        /// <summary>
        /// Gets the area element.
        /// </summary>
        /// <value>The area element.</value>
        public AreaElement AreaElement => _areaElement ?? (_areaElement = new AreaElement(_seed));

        /// <summary>
        /// Gets the line element.
        /// </summary>
        /// <value>The line element.</value>
        public LineElement LineElement => _lineElement ?? (_lineElement = new LineElement(_seed));

        /// <summary>
        /// Gets the link element.
        /// </summary>
        /// <value>The link element.</value>
        public LinkElement LinkElement => _linkElement ?? (_linkElement = new LinkElement(_seed));

        /// <summary>
        /// Gets the plane element.
        /// </summary>
        /// <value>The plane element.</value>
        public PlaneElement PlaneElement => _planeElement ?? (_planeElement = new PlaneElement(_seed));

        /// <summary>
        /// Gets the point element.
        /// </summary>
        /// <value>The point element.</value>
        public PointElement PointElement => _pointElement ?? (_pointElement = new PointElement(_seed));

        /// <summary>
        /// Gets the solid element.
        /// </summary>
        /// <value>The solid element.</value>
        public SolidElement SolidElement => _solidElement ?? (_solidElement = new SolidElement(_seed));
        #endregion


        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalysisModeler"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public AnalysisModeler(CSiApiSeed seed) : base(seed)
        {
            _seed = seed;
        }


        #endregion
    }
}