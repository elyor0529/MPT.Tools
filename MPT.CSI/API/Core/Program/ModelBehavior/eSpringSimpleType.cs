namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Simple spring types available in the application.
    /// </summary>
    public enum eSpringSimpleType
    {
        /// <summary>
        /// Spring resists tension and compression.
        /// </summary>
        TensionCompression = 1,

        /// <summary>
        /// Spring resists compression only.
        /// </summary>
        Compression =  2,

        /// <summary>
        /// Spring resists tension only.
        /// </summary>
        Tension = 3
    }
}
