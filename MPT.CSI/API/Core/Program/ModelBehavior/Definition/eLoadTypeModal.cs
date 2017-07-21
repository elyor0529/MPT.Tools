
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Load type to set in modal load cases.
    /// </summary>
    public enum eLoadTypeModal
    {
        /// <summary>
        /// Load is applied as a force.
        /// </summary>
        Load = 1,

        /// <summary>
        /// Load is applied as an acceleration to the mass.
        /// </summary>
        Accel = 2,

        /// <summary>
        ///  Load is applied as a link force.
        /// </summary>
        Link = 3
    }
}
