using System.ComponentModel;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.CodesAutoLoad.Wind
{
    /// <summary>
    /// Indicates sources of the wind exposure.
    /// </summary>
    public enum eWindExposure
    {
        /// <summary>
        /// From extents of rigid diaphragms.
        /// </summary>
        [Description("Extents of rigid diaphragms")]
        ExtentsOfRigidDiaphragms = 1,

        /// <summary>
        /// From area objects.
        /// </summary>
        [Description("Area objects")]
        AreaObjects = 2,

        /// <summary>
        /// From frame objects (open structure).
        /// </summary>
        [Description("Frame objects (open structure)")]
        FrameObjects = 3,

        /// <summary>
        /// From area objects and frame objects (open structure).
        /// </summary>
        [Description("Area and Frame objects (open structure)")]
        AreaAndFrameObjects = 4
    }
}
