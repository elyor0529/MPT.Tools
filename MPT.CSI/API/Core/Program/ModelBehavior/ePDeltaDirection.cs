

namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Directions available for P-Delta force assignment.
    /// </summary>
    public enum ePDeltaDirection
    {
        /// <summary>
        /// Frame object local 1-axis direction.
        /// </summary>
        Local_1 = 0,

        /// <summary>
        /// Projected X direction in CSys coordinate system.
        /// </summary>
        ProjectedX = 1,

        /// <summary>
        /// Projected Y direction in CSys coordinate system.
        /// </summary>
        ProjectedY = 2,

        /// <summary>
        /// Projected Z direction in CSys coordinate system.
        /// </summary>
        ProjectedZ = 3,
    }
}
