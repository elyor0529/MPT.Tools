namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Material component behavior types available in the applicaion.
    /// </summary>
    public enum eMaterialComponentBehaviorType
    {
        /// <summary>
        /// Material is inactive.
        /// </summary>
        Inactive = 0,

        /// <summary>
        /// Linear material behavior.
        /// </summary>
        Linear = 1,

        /// <summary>
        /// Nonlinear material behavior.
        /// </summary>
        Nonlinear = 2
    }
}
