
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Geometric nonlinearity option to set in the non-linear analysis cases.
    /// </summary>
    public enum eGeometricNonlinearity
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,

        /// <summary>
        /// P-delta.
        /// </summary>
        PDelta = 1,

        /// <summary>
        /// P-delta plus large displacements.
        /// </summary>
        PDeltaLargeDisp = 2
    }
}
