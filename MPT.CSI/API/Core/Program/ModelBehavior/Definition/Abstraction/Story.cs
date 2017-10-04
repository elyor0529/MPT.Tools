#if BUILD_ETABS2015 || BUILD_ETABS2016
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Abstraction
{
    /// <summary>
    /// Class Story.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.Abstraction.IStory" />
    public class Story : CSiApiBase, IStory
    {
        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Story"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public Story(CSiApiSeed seed) : base(seed)
        {

        }
        #endregion

        #region Methods: Interface

        #endregion


    }
}
#endif