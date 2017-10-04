namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Function
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    /// <summary>
    /// The option for defining the parameters for NTC 2008.
    /// </summary>
    public enum eParameters_NTC_2008
    {
        /// <summary>
        /// Parameters are by latitiude and longitude.
        /// </summary>
        ByLatLong = 1,

        /// <summary>
        /// Parameters are by island.
        /// </summary>
        ByIsland = 2,

        /// <summary>
        /// Parameters are user defined.
        /// </summary>
        UserDefined = 3
    }
#endif
}