#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Hysteretic damping types available in the application.
    /// </summary>
    public enum eDampingTypeHysteretic
    {
        /// <summary>
        /// Constant hysteretic damping for all frequencies.
        /// </summary>
        Constant = 1,

        /// <summary>
        /// Interpolated hysteretic damping by frequency.
        /// </summary>
        Interpolated = 2
    }
}
#endif