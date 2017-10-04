namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Function
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    /// <summary>
    /// Site class for Eurocode 8 response spectrum function.
    /// </summary>
    public enum eSiteClass_Eurocode_8
    {
        /// <summary>
        /// Site subsoil class A.
        /// </summary>
        A = 1,

        /// <summary>
        /// Site subsoil class B.
        /// </summary>
        B = 2,

        /// <summary>
        /// Site subsoil class C.
        /// </summary>
        C = 3,
    }
#endif
}