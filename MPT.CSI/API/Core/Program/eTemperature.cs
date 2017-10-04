#if BUILD_ETABS2015 || BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program
{
    /// <summary>
    /// Temperature unit types available in the application.
    /// </summary>
    public enum eTemperature
    {
        /// <summary>
        /// Not applicable.
        /// </summary>
        NotApplicable = 0,

        /// <summary>
        /// Fahrenheit.
        /// </summary>
        F = 1,

        /// <summary>
        /// Celcius.
        /// </summary>
        C = 2
    }
}
#endif