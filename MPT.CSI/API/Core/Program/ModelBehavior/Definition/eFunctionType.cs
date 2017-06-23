
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Function types available in the program for applying dynamic loads.
    /// </summary>
    public enum eFunctionType
    {
        /// <summary>
        /// Response spectrum.
        /// </summary>
        ResponseSpectrum = 1,

        /// <summary>
        /// Time history.
        /// </summary>
        TimeHistory = 2,

        /// <summary>
        /// Power spectral density.
        /// </summary>
        PowerSpectralDensity = 3,

        /// <summary>
        /// Steady state.
        /// </summary>
        SteadyState = 4
    }
}
