namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Hysteresis types available in the application.
    /// </summary>
    public enum eHysteresisType
    {
        /// <summary>
        /// Elastic hysteresis type.
        /// </summary>
        Elastic = 0,

        /// <summary>
        /// Kinematic hysteresis type.
        /// </summary>
        Kinematic = 1,

        /// <summary>
        /// Takeda hysteresis type.
        /// </summary>
        Takeda = 2
    }
}