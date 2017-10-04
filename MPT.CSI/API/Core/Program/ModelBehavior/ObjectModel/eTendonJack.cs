#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// How the tendon is jacked.
    /// </summary>
    public enum eTendonJack
    {
        /// <summary>
        /// Tendon jacked from I-End.
        /// </summary>
        FromIEnd = 1,

        /// <summary>
        /// Tendon jacked from J-E.
        /// </summary>
        FromJEnd = 2,

        /// <summary>
        /// Tendon jacked from both ends.
        /// </summary>
        BothEnds = 3
    }
}
#endif