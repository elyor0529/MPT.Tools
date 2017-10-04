#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Plot types available in the application.
    /// </summary>
    public enum ePlotType
    {
        /// <summary>
        /// Plot scaled to arithmetic type.
        /// </summary>
        Arithmetic = 1,

        /// <summary>
        /// Plot scaled to log type.
        /// </summary>
        Log = 2
    }
}
#endif