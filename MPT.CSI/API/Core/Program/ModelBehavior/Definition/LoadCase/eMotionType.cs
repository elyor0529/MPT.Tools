#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Time history motion types available in the application.
    /// </summary>
    public enum eMotionType
    {
        /// <summary>
        /// Transient motion type.
        /// </summary>
        Transient = 1,

        /// <summary>
        /// Periodic motion type.
        /// </summary>
        Periodic = 2
    }
}
#endif