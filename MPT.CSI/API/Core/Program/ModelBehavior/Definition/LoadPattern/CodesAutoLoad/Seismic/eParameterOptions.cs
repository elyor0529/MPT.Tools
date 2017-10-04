#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.CodesAutoLoad.Seismic
{
    /// <summary>
    /// Option for defining parameters in the NTC2008 seismic load pattern.
    /// </summary>
    public enum eParameterOptions
    {
        /// <summary>
        /// By latitude and longitude.
        /// </summary>
        LatLong = 1,

        /// <summary>
        /// By island.
        /// </summary>
        Island = 2,

        /// <summary>
        /// User specified.
        /// </summary>
        UserSpecified = 3
    }
}
#endif
