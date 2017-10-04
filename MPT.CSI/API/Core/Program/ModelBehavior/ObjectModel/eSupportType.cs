#if BUILD_ETABS2015 || BUILD_ETABS2016
using System.ComponentModel;

namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Support types available in the application.
    /// </summary>
    public enum eSupportType
    {
        /// <summary>
        /// Point Object.
        /// </summary>
        [Description("Point Object")]
        PointObject = 1,

        /// <summary>
        /// Frame Object.
        /// </summary>
        [Description("Frame Object")]
        FrameObject = 2,

        /// <summary>
        /// Area Object.
        /// </summary>
        [Description("Area Object")]
        AreaObject = 3,

        /// <summary>
        /// Solid bject.
        /// </summary>
        [Description("Solid Object")]
        SolidObject = 6
    }
}
#endif