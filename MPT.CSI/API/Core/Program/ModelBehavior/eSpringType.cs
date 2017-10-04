#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Spring property types available in the application.
    /// </summary>
    public enum eSpringType
    {
        /// <summary>
        /// Simple spring.
        /// </summary>
        Simple = 1,

        /// <summary>
        /// Link property.
        /// </summary>
        Link = 2
    }
}
#endif