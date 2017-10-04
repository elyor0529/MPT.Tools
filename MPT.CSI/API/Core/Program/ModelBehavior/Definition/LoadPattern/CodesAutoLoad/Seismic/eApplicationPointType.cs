#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.CodesAutoLoad.Seismic
{
    /// <summary>
    /// Application point type for the user load.
    /// </summary>
    public enum eApplicationPointType
    {
        /// <summary>
        /// User specified application point.
        /// </summary>
        UserSpecifiedApplicationPoint = 1,

        /// <summary>
        /// At center of mass with optional additional eccentricity.
        /// </summary>
        CenterOfMassWithEccentricity = 2
    }
}
#endif
