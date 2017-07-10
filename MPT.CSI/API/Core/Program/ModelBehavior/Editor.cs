using MPT.CSI.API.Core.Program.ModelBehavior.Edit;
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
    /// Represents editing actions in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class Editor : CSiApiBase
    {

        #region Fields
        private readonly CSiApiSeed _seed;

        private AreaEditor _areaEditor;
        private FrameEditor _frameEditor;
        private GeneralEditor _generalEditor;
        private PointEditor _pointEditor;
        private SolidEditor _solidEditor;
        #endregion


        #region Properties        
        /// <summary>
        /// Gets the area editor.
        /// </summary>
        /// <value>The area editor.</value>
        public AreaEditor AreaEditor => _areaEditor ?? (_areaEditor = new AreaEditor(_seed));

        /// <summary>
        /// Gets the frame editor.
        /// </summary>
        /// <value>The frame editor.</value>
        public FrameEditor FrameEditor => _frameEditor ?? (_frameEditor = new FrameEditor(_seed));

        /// <summary>
        /// Gets the general editor.
        /// </summary>
        /// <value>The general editor.</value>
        public GeneralEditor GeneralEditor => _generalEditor ?? (_generalEditor = new GeneralEditor(_seed));

        /// <summary>
        /// Gets the point editor.
        /// </summary>
        /// <value>The point editor.</value>
        public PointEditor PointEditor => _pointEditor ?? (_pointEditor = new PointEditor(_seed));

        /// <summary>
        /// Gets the solid editor.
        /// </summary>
        /// <value>The solid editor.</value>
        public SolidEditor SolidEditor => _solidEditor ?? (_solidEditor = new SolidEditor(_seed));
        #endregion


        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Editor"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public Editor(CSiApiSeed seed) : base(seed)
        {
            _seed = seed;
        }


        #endregion
        
    }
}
