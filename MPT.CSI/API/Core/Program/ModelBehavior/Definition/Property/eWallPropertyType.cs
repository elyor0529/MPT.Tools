#if BUILD_ETABS2015 || BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Local axes available in plane elements the applicaion.
    /// </summary>
    public enum eWallPropertyType
    {
        /// <summary>
        /// The wall property is manually specified.
        /// </summary>
        Specified = 1,

        /// <summary>
        /// Property is from the auto select list.
        /// </summary>
        AutoSelectList = 2
    }
}
#endif