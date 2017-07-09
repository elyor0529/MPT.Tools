namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Bracing locations available in the cross section of frames in the application.
    /// </summary>
    public enum eBracingLocation
    {
        /// <summary>
        /// Bracing on the top face/flange only.
        /// </summary>
        Top = 1,

        /// <summary>
        /// Bracing on the botton face/flange only.
        /// </summary>
        Bottom = 2,

        /// <summary>
        /// Bracing on the top and bottom faces/flanges.
        /// </summary>
        All = 3
    }
}