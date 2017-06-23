namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Process options available for analysis in the application.
    /// </summary>
    public enum eSolverProcessType
    {
        /// <summary>
        /// Auto (program-determined).
        /// </summary>
        Auto = 0,

        /// <summary>
        /// GUI/Same process.
        /// </summary>
        Same = 1,

        /// <summary>
        /// Separate process.
        /// </summary>
        Separate = 2
    }
}
