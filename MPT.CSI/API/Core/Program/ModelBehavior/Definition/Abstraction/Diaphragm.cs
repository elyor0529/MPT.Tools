#if BUILD_ETABS2015 || BUILD_ETABS2016
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Abstraction
{
    /// <summary>
    /// Class Diaphragm.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.Abstraction.IDiaphragm" />
    public class Diaphragm : CSiApiBase, IDiaphragm
    {
        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Diaphragm"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public Diaphragm(CSiApiSeed seed) : base(seed)
        {

        }
        #endregion

        #region Methods: Interface

        #endregion
    }
}
#endif