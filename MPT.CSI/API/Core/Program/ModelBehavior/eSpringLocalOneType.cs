#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Methods used to specify the spring positive local 1-axis orientation in the application.
    /// </summary>
    public enum eSpringLocalOneType
    {
        /// <summary>
        /// Parallel to object local axis.
        /// </summary>
        Parallel = 1,


        /// <summary>
        /// Normal to specified object face.
        /// </summary>
        Normal = 2,

        /// <summary>
        /// User specified direction vector.
        /// </summary>
        User = 3
    }
}
#endif