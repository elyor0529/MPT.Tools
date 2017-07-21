namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Proportional damping types available in the application.
    /// </summary>
    public enum eDampingTypeProportional
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
        ProportionalByFrequency = 3
    }
}