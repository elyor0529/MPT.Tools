namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Function
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    /// <summary>
    /// Site class for NTC 2008 response spectrum function.
    /// </summary>
    public enum eSiteClass_NTC_2008
    {
        /// <summary>
        /// Site subsoil type class A.
        /// </summary>
        A = 1,

        /// <summary>
        /// Site subsoil type class B.
        /// </summary>
        B = 2,

        /// <summary>
        /// Site subsoil type class C.
        /// </summary>
        C = 3,

        /// <summary>
        /// Site subsoil type class D.
        /// </summary>
        D = 4,

        /// <summary>
        /// Site subsoil type class E.
        /// </summary>
        E = 5,
    }
#endif
}