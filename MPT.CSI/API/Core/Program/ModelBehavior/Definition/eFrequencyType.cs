#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Frequency types used in power spectral density functions.
    /// </summary>
    public enum eFrequencyType
    {
        /// <summary>
        /// Frequency as hertz [cyc/s].
        /// </summary>
        HZ = 1,

        /// <summary>
        /// Frequency as rotations per minute.
        /// </summary>
        RPM = 2
    }
}
#endif