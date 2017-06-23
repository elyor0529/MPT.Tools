
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Spectral response types available in the application.
    /// </summary>
    public enum eSpectralResponse
    {
        /// <summary>
        /// Spectral displacement.
        /// </summary>
        SpectralDisplacement = 1,

        /// <summary>
        /// Spectral velo.
        /// </summary>
        SpectralVelocity = 2,

        /// <summary>
        /// Pseudo-spectral velocity.
        /// </summary>
        PseudoSpectralVelocity = 3,

        /// <summary>
        /// Spectral acceleration.
        /// </summary>
        SpectralAcceleration = 4,

        /// <summary>
        /// Pseudo-spectral acceleration.
        /// </summary>
        PseudoSpectralAcceleration = 5
    }
}
