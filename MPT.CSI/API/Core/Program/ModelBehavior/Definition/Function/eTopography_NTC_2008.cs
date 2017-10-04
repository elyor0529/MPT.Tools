namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Function
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
     /// <summary>
    /// The topography for NTC 2008 response spectrum.
    /// </summary>
    public enum eTopography_NTC_2008
    {
        /// <summary>
        /// Topography type T1.
        /// </summary>
        T1 = 1,
        
        /// <summary>
        /// Topography type T2.
        /// </summary>
        T2 = 2,
        
        /// <summary>
        /// Topography type T3.
        /// </summary>
        T3 = 3,
        
        /// <summary>
        /// Topography type T4.
        /// </summary>
        T4 = 4,
    }
#endif
}