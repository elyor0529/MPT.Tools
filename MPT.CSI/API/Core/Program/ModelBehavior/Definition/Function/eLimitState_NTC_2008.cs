namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Function
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        /// <summary>
    /// The limit state for NTC 2008 response spectrum.
    /// </summary>
    public enum eLimitState_NTC_2008
    {
        /// <summary>
        /// SLO.
        /// </summary>
        SLO = 1,
        
        /// <summary>
        /// SLD.
        /// </summary>
        SLD = 2,
        
        /// <summary>
        /// SLV.
        /// </summary>
        SLV = 3,
        
        /// <summary>
        /// SLC.
        /// </summary>
        SLC = 4,
    }
#endif
}