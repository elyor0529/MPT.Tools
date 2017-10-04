namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Function
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    /// <summary>
    /// The spectrum type for Eurocode 8 2004 response spectrum.
    /// </summary>
    public enum eSpectrumType_Eurocode_8_2004
    {
        /// <summary>
        /// Type 1 response spectrum.
        /// </summary>
        Type1 = 1,
        
        /// <summary>
        /// Type 2 response spectrum.
        /// </summary>
        Type2 = 2,
    }
#endif
}