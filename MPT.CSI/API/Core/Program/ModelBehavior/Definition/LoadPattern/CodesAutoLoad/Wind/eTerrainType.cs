#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.CodesAutoLoad.Wind
{
    /// <summary>
    /// Terrain type used in wind loads.
    /// NBCC2010
    /// </summary>
    public enum eTerrainType
    {
        /// <summary>
        /// Open terrain.
        /// </summary>
        Open = 1,

        /// <summary>
        /// Rough terrain.
        /// </summary>
        Rough = 2,

        /// <summary>
        /// User-specified terrain factors will be used.
        /// </summary>
        User = 3
    }
}
#endif
