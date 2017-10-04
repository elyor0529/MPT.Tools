namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisResult
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    /// <summary>
    /// Display  style for results from steady state analyses in the application.
    /// </summary>
    public enum eAnalysisSteadyStateOptions
    {
        /// <summary>
        /// Envelopes.
        /// </summary>
        Envelopes = 1,

        /// <summary>
        /// At frequencies.
        /// </summary>
        Frequencies = 2
    }
#endif
}