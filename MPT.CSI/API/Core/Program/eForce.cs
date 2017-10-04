#if BUILD_ETABS2015 || BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program
{
    /// <summary>
    /// Force unit types available in the application.
    /// </summary>
    public enum eForce
    {
        /// <summary>
        /// Not applicable.
        /// </summary>
        NotApplicable = 0,

        /// <summary>
        /// Pound.
        /// </summary>
        lb = 1,

        /// <summary>
        /// Kip.
        /// </summary>
        kip = 2,

        /// <summary>
        /// Newton.
        /// </summary>
        N = 3,

        /// <summary>
        /// Kilonewton.
        /// </summary>
        kN = 4,

        /// <summary>
        /// Kilogram-force.
        /// </summary>
        kgf = 5,

        /// <summary>
        /// Ton-force.
        /// </summary>
        tonf = 6
    }
}
#endif