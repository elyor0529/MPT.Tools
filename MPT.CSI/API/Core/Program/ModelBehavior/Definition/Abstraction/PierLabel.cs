#if BUILD_ETABS2015 || BUILD_ETABS2016
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Abstraction
{
    /// <summary>
    /// Class PierLabel.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.Abstraction.IPierLabel" />
    public class PierLabel : CSiApiBase, IPierLabel
    {
        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="PierLabel"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public PierLabel(CSiApiSeed seed) : base(seed)
        {

        }
        #endregion

        #region Methods: Interface

        #endregion
    }
}
#endif