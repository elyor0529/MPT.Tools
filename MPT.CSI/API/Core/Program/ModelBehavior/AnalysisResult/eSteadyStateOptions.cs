namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisResult
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    /// <summary>
    /// Steady state options available for display in the application.
    /// </summary>
    public enum eSteadyStateOptions
    {
        /// <summary>
        /// In and out of phase.
        /// </summary>
        InAndOutOfPhase = 1,

        /// <summary>
        /// The magnitude.
        /// </summary>
        Magnitude = 2,

        /// <summary>
        /// All.
        /// </summary>
        All = 3
    }
#endif
}