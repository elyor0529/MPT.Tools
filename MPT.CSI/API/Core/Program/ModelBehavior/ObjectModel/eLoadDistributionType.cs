namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Load distribution types available for uniform loads in the application.
    /// Indicates how the load is tranferred to element edges.
    /// </summary>
    public enum eLoadDistributionType
    {
        /// <summary>
        /// One-way load distribution.
        /// This is parallel to the area object local 1 axis
        /// </summary>
        OneWay = 1,

        /// <summary>
        /// Two-way load distribution.
        /// This is parallel to the area object local 1 and 2 axes.
        /// </summary>
        TwoWay = 2
    }
}
