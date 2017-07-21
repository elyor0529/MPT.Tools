namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Variations in EI of prismatic sections available in the application.
    /// </summary>
    public enum ePrismaticInertiaType
    {
        /// <summary>
        /// EI varies linearly along the segment length.
        /// </summary>
        Linear = 1,

        /// <summary>
        /// EI varies parabolically along the segment length.
        /// </summary>
        Parabolic = 2,

        /// <summary>
        /// EI varies cubically along the segment length.
        /// </summary>
        Cubic = 3
    }
}