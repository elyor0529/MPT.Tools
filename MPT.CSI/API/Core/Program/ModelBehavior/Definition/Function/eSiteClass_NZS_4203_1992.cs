namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Function
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    /// <summary>
    /// Site class for NZS 4203 1992 response spectrum function.
    /// </summary>
    public enum eSiteClass_NZS_4203_1992
    {
        /// <summary>
        /// Site subsoil category class A.
        /// </summary>
        A = 1,

        /// <summary>
        /// Site subsoil category class B.
        /// </summary>
        B = 2,

        /// <summary>
        /// Site subsoil category class C.
        /// </summary>
        C = 3,
    }
#endif
}