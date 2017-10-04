namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Function
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    /// <summary>
    /// Site class for SP 14.13330.2014 response spectrum function.
    /// </summary>
    public enum eSiteClass_SP_14_13330_2014
    {
        /// <summary>
        /// Site soil category class I.
        /// </summary>
        I = 1,

        /// <summary>
        /// Site soil category class II.
        /// </summary>
        II = 2,

        /// <summary>
        /// Site soil category class III.
        /// </summary>
        III = 3,

        /// <summary>
        /// Site soil category class IV.
        /// </summary>
        IV = 4,
    }
#endif
}