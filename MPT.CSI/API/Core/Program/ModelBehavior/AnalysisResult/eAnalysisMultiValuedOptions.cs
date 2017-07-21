namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisResult
{
    /// <summary>
    ///  Options for multi-valued analysis.
    /// </summary>
    public enum eAnalysisMultiValuedOptions
    {
        /// <summary>
        /// Envelopes.
        /// </summary>
        Envelopes = 1,

        /// <summary>
        /// Multiple values, if possible.
        /// </summary>
        StepByStep = 2,

        /// <summary>
        /// Correspondence.
        /// </summary>
        LastStep = 3
    }
}
