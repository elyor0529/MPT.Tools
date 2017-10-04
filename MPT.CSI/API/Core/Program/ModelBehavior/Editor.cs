using MPT.CSI.API.Core.Program.ModelBehavior.Edit;
using MPT.CSI.API.Core.Support;

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
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        private SolidEditor _solidEditor;
#endif
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

#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        /// <summary>
        /// Gets the solid editor.
        /// </summary>
        /// <value>The solid editor.</value>
        public SolidEditor SolidEditor => _solidEditor ?? (_solidEditor = new SolidEditor(_seed));
#endif
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
