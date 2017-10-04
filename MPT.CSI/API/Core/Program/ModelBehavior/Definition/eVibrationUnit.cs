#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Units by which vibration may be quantified.
    /// </summary>
    public enum eVibrationUnit
    {
        /// <summary>
        /// Frequency [1/sec].
        /// </summary>
        Frequency = 1,

        /// <summary>
        /// Period [sec].
        /// </summary>
        Period = 2
    }
}
#endif
