#if BUILD_ETABS2015 || BUILD_ETABS2016
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Class PointSpring.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property.IPointSpring" />
    public class PointSpring : CSiApiBase, IPointSpring
    {
        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="PointSpring"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public PointSpring(CSiApiSeed seed) : base(seed)
        {

        }
        #endregion

        #region Methods: Interface

        #endregion


    }
}
#endif