namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Function
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    /// <summary>
    /// Site class for NBCC 2010 response spectrum function.
    /// </summary>
    public enum eSiteClass_NBCC_2010
    {
        /// <summary>
        /// Site class A.
        /// </summary>
        A = 1,

        /// <summary>
        /// Site class B.
        /// </summary>
        B = 2,

        /// <summary>
        /// Site class C.
        /// </summary>
        C = 3,

        /// <summary>
        /// Site class D.
        /// </summary>
        D = 4,

        /// <summary>
        /// Site class E.
        /// </summary>
        E = 5,

        /// <summary>
        /// Site class F.
        /// </summary>
        F = 6
    }
#endif
}