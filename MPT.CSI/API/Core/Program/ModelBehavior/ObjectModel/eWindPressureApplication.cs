namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Application of wind pressure to objects in the application.
    /// </summary>
    public enum eWindPressureApplication
    {
        /// <summary>
        /// Windward, pressure varies over height.
        /// </summary>
        Windward = 1,

        /// <summary>
        /// Other, pressure is constant over height.
        /// </summary>
        Other = 2
    }
}
