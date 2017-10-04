#if BUILD_ETABS2015 || BUILD_ETABS2016
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Abstraction
{
    /// <summary>
    /// Class Tower.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.Abstraction.ITower" />
    public class Tower : CSiApiBase, ITower
    {
        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Tower"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public Tower(CSiApiSeed seed) : base(seed)
        {

        }
        #endregion

        #region Methods: Interface

        #endregion
    }
}
#endif