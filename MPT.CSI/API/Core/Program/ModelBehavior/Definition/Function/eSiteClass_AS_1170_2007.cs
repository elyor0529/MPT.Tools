namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Function
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    /// <summary>
    /// Site class for AS 1170 2007 response spectrum function.
    /// </summary>
    public enum eSiteClass_AS_1170_2007
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
    }
#endif
}