#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// The type of load assignable in the application.
    /// </summary>
    public enum eLoadType
    {
        /// <summary>
        /// Load, (i.e. force).
        /// </summary>
        Load = 1,

        /// <summary>
        /// Acceleration.
        /// </summary>
        Accel = 2
    }
}
#endif