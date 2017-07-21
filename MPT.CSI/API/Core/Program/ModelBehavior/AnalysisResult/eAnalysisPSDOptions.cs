namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisResult
{
    /// <summary>
    /// Options available for output from PSD analysis.
    /// </summary>
    public enum eAnalysisPSDOptions
    {
        /// <summary>
        /// The RMS (Root Mean Square).
        /// </summary>
        RMS = 1,

        /// <summary>
        /// The sqrt(PSD).
        /// </summary>
        SQRTPSD = 2
    }
}