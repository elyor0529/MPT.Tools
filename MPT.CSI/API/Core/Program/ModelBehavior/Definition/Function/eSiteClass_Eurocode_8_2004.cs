namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Function
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    /// <summary>
    /// Site class for Eurocode 8 2004  response spectrum function.
    /// </summary>
    public enum eSiteClass_Eurocode_8_2004
    {
        /// <summary>
        /// Site ground type class A.
        /// </summary>
        A = 1,

        /// <summary>
        /// Site ground type class B.
        /// </summary>
        B = 2,

        /// <summary>
        /// Site ground type class C.
        /// </summary>
        C = 3,

        /// <summary>
        /// Site ground type class D.
        /// </summary>
        D = 4,

        /// <summary>
        /// Site ground type class E.
        /// </summary>
        E = 5,
    }
#endif
}