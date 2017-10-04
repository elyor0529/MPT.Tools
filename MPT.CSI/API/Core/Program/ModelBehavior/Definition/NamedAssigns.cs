#if !BUILD_ETABS2015 && !BUILD_ETABS2016
using MPT.CSI.API.Core.Program.ModelBehavior.Definition.NamedAssign;
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Represents modifiers and releases to basic objects in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class NamedAssigns : CSiApiBase
    {
#region Fields
        private readonly CSiApiSeed _seed;

        private AreaModifiers _areaModifiers;
        private CableModifiers _cableModifiers;
        private FrameModifiers _frameModifiers;
        private FrameReleases _frameReleases;
#endregion

#region Properties                        
        /// <summary>
        /// Gets the area modifiers.
        /// </summary>
        /// <value>The area modifiers.</value>
        public AreaModifiers AreaModifiers => _areaModifiers ?? (_areaModifiers = new AreaModifiers(_seed));

        /// <summary>
        /// Gets the cable modifiers.
        /// </summary>
        /// <value>The cable modifiers.</value>
        public CableModifiers CableModifiers => _cableModifiers ?? (_cableModifiers = new CableModifiers(_seed));

        /// <summary>
        /// Gets the frame modifiers.
        /// </summary>
        /// <value>The frame modifiers.</value>
        public FrameModifiers FrameModifiers => _frameModifiers ?? (_frameModifiers = new FrameModifiers(_seed));

        /// <summary>
        /// Gets the frame releases.
        /// </summary>
        /// <value>The frame releases.</value>
        public FrameReleases FrameReleases => _frameReleases ?? (_frameReleases = new FrameReleases(_seed));

#endregion

#region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="NamedAssigns"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public NamedAssigns(CSiApiSeed seed) : base(seed)
        {
            _seed = seed;
        }


#endregion
    }
}
#endif