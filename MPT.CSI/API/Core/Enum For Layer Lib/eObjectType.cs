using System.ComponentModel;

namespace MPT.CSI.API.Core
{
    /// <summary>
    /// Object types.
    /// These are used with the program by numerical code.
    /// </summary>
    public enum eObjectType
    {
        [Description("Point Object")]PointObject = 1,
        [Description("Frame Object")]FrameObject = 2,
        [Description("Cable Object")]CableObject = 3,
        [Description("Tendon Object")]TendonObject = 4,
        [Description("Area Object")]AreaObject = 5,
        [Description("Solid bject")]SolidObject = 6,
        [Description("Link Object")]LinkObject = 7
    }
}
