namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisResult
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
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
#endif
}