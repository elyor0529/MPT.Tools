namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Hysteresis types available for links in the application.
    /// </summary>
    public enum eLinkHysteresisType
    {
        /// <summary>
        /// Kinematic hysteresis type.
        /// </summary>
        Kinematic = 1,

        /// <summary>
        /// Takeda hysteresis type.
        /// </summary>
        Takeda = 2,

        /// <summary>
        /// Pivot hysteresis type.
        /// </summary>
        Pivot = 3
    }
}