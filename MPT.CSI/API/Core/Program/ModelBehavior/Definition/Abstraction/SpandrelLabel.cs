#if BUILD_ETABS2015 || BUILD_ETABS2016
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Abstraction
{
    /// <summary>
    /// Class SpandrelLabel.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.Abstraction.ISpandrelLabel" />
    public class SpandrelLabel : CSiApiBase, ISpandrelLabel
    {
        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="SpandrelLabel"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public SpandrelLabel(CSiApiSeed seed) : base(seed)
        {

        }
        #endregion

        #region Methods: Interface

        #endregion

    }
}
#endif