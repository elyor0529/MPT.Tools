using MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property;
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Represents the various object sections/properties in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class Properties : CSiApiBase
    {
        #region Fields
        private readonly CSiApiSeed _seed;

        private AreaSection _areaSection;
        private FrameSection _frameSection;
        private TendonSection _tendonSection;
        private LinkProperties _linkProperties;
        private MaterialProperties _materialProperties;
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        private CableSection _cableSection;
        private SolidProperties _solidProperties;
#endif
        #endregion

        #region Properties                        
        /// <summary>
        /// Gets the area section.
        /// </summary>
        /// <value>The area section.</value>
        public AreaSection AreaSection => _areaSection ?? (_areaSection = new AreaSection(_seed));

        /// <summary>
        /// Gets the frame section.
        /// </summary>
        /// <value>The frame section.</value>
        public FrameSection FrameSection => _frameSection ?? (_frameSection = new FrameSection(_seed));

        /// <summary>
        /// Gets the tendon section.
        /// </summary>
        /// <value>The tendon section.</value>
        public TendonSection TendonSection => _tendonSection ?? (_tendonSection = new TendonSection(_seed));

        /// <summary>
        /// Gets the link properties.
        /// </summary>
        /// <value>The link properties.</value>
        public LinkProperties LinkProperties => _linkProperties ?? (_linkProperties = new LinkProperties(_seed));
        
        /// <summary>
        /// Gets the material properties.
        /// </summary>
        /// <value>The material properties.</value>
        public MaterialProperties MaterialProperties => _materialProperties ?? (_materialProperties = new MaterialProperties(_seed));

#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        /// <summary>
        /// Gets the cable section.
        /// </summary>
        /// <value>The cable section.</value>
        public CableSection CableSection => _cableSection ?? (_cableSection = new CableSection(_seed));

        /// <summary>
        /// Gets the solid properties.
        /// </summary>
        /// <value>The solid properties.</value>
        public SolidProperties SolidProperties => _solidProperties ?? (_solidProperties = new SolidProperties(_seed));
#endif
        #endregion

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Properties"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public Properties(CSiApiSeed seed) : base(seed)
        {
            _seed = seed;
        }


        #endregion
    }
}