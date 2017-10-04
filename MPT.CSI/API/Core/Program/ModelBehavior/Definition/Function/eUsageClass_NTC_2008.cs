namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Function
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    /// <summary>
    /// The usage class for NTC 2008 response spectrum.
    /// </summary>
    public enum eUsageClass_NTC_2008
    {
        /// <summary>
        /// Usage class I.
        /// </summary>
        I = 1,
        
        /// <summary>
        /// Usage class II.
        /// </summary>
        II = 2,
        
        /// <summary>
        /// Usage class III.
        /// </summary>
        III = 3,
        
        /// <summary>
        /// Usage class IV.
        /// </summary>
        IV = 4,
    }
#endif
}