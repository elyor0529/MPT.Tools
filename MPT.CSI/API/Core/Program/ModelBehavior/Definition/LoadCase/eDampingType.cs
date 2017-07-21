namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Damping types available in the application.
    /// </summary>
    public enum eDampingType
    {
        /// <summary>
        /// Mass and stiffness proportional damping by direct specification.
        /// </summary>
        ProportionalBySpecification = 1,

        /// <summary>
        /// Mass and stiffness proportional damping by period.
        /// </summary>
        ProportionalByPeriod = 2,

        /// <summary>
        /// Mass and stiffness proportional damping by frequency.
        /// </summary>
        ProportionalByFrequency = 3,

        /// <summary>
        /// Constant damping for all modes.
        /// </summary>
        Constant = 4,

        /// <summary>
        /// Interpolated damping by period.
        /// </summary>
        InterpolatedByPeriod = 5,

        /// <summary>
        /// Interpolated damping by frequency.
        /// </summary>
        InterpolatedByFrequency = 6
    }
}