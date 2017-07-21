namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Options available in the application for combining multiple loads applied in different directions for periodic plus methods.
    /// </summary>
    public enum ePeriodicPlusRigidModalCombination
    {
        /// <summary>
        /// Square-Root of the Sum-of-Squares option.
        /// </summary>
        SRSS = 1,

        /// <summary>
        /// The absolute value of the sums option.
        /// </summary>
        ABS = 2
    }
}