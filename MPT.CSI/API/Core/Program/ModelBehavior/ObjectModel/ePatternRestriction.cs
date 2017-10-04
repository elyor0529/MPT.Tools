#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Restriction applied to what values are use from pattern calculations.
    /// </summary>
    public enum ePatternRestriction
    {
        /// <summary>
        /// All values are used.
        /// </summary>
        AllValuesUsed = 0,

        /// <summary>
        /// Negative values are set to zero.
        /// </summary>
        NegativeSetTo0 = 1,

        /// <summary>
        /// Positive values are set to zero.
        /// </summary>
        PositiveSetTo0 = 2
    }
}
#endif