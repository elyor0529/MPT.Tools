namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Directions available for links in the application.
    /// </summary>
    public enum eLinkDirection
    {
        /// <summary>
        /// Tension direction only.
        /// </summary>
        Tension = 0,

        /// <summary>
        /// Compression direction only.
        /// </summary>
        Compression = 1,

        /// <summary>
        /// Both directions.
        /// </summary>
        Both = 2
    }
}