
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Types of Time History functions available in the application.
    /// </summary>
    public enum eFunctionTimeHistoryType
    {
        /// <summary>
        /// Function is read from an external file.
        /// </summary>
        FromFile = 0,

        /// <summary>
        /// User-defined function.
        /// </summary>
        User = 1,

        /// <summary>
        /// Sine function.
        /// </summary>
        Sine = 2,

        /// <summary>
        /// Cosine function.
        /// </summary>
        Cosine = 3,

        /// <summary>
        /// Ramp function.
        /// </summary>
        Ramp = 4,

        /// <summary>
        /// Sawtooth function.
        /// </summary>
        Sawtooth = 5,

        /// <summary>
        /// Triangular function.
        /// </summary>
        Triangular = 6,

        /// <summary>
        /// User periodic function.
        /// </summary>
        UserPeriodic = 7
    }
}
