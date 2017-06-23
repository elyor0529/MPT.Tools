namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Temperature types available in the application.
    /// </summary>
    public enum eLoadTemperatureType
    {
        /// <summary>
        /// Uniform temperature load.
        /// </summary>
        Temperature = 1,

        /// <summary>
        /// Temperature gradient load along the local 2 axis.
        /// </summary>
        TemperatureGradient2Axis = 2,

        /// <summary>
        /// Temperature gradient load along the local 3 axis.
        /// </summary>
        TemperatureGradient3Axis = 3
    }
}
