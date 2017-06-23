
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Types of Power Spectral Density functions available in the application.
    /// </summary>
    public enum eFunctionPowerSpectralDensityType
    {
        /// <summary>
        /// Function is read from an external file.
        /// </summary>
        FromFile = 0,

        /// <summary>
        /// User-defined function.
        /// </summary>
        User = 1
    }
}
