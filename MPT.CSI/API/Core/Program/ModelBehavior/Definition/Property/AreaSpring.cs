#if BUILD_ETABS2015 || BUILD_ETABS2016
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Class AreaSpring.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property.IAreaSpring" />
    public class AreaSpring : CSiApiBase, IAreaSpring
    {
        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="AreaSpring"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public AreaSpring(CSiApiSeed seed) : base(seed)
        {

        }
        #endregion

        #region Methods: Interface

        #endregion
    }
}
#endif