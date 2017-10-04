#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.CodesAutoLoad.Seismic
{
    /// <summary>
    /// Indicates the time period option used in auto seismic loads.
    /// </summary>
    public enum eTimePeriodOption
    {
        /// <summary>
        /// Approximate.
        /// </summary>
        Approximate = 1,

        /// <summary>
        /// Program calculated.
        /// </summary>
        ProgramCalculated = 2,

        /// <summary>
        /// User defined.
        /// </summary>
        UserDefined = 3
    }
}
#endif
