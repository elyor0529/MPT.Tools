
namespace MPT.CSI.API.Core
{
    /// <summary>
    /// Section type used for notional size calculations.
    /// These are used with the program as strings.
    /// </summary>
    public enum eNotionalSectionType
    {
        /// <summary>
        /// Program will determine the notional size based on the average thickness of an area element.
        /// </summary>
        Auto = 1,

        /// <summary>
        /// The notional size is based on the user-defined value.
        /// </summary>
        User,

        /// <summary>
        /// Notional size will not be considered. In other words, the time-dependent effect of this section will not be considered.
        /// </summary>
        None
    }
}
