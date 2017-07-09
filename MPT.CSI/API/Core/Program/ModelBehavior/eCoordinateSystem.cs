namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Common coordinate system types.
    /// These are used with the program as strings.
    /// </summary>
    public enum eCoordinateSystem
    {
        /// <summary>
        /// Coordinate system is local to the element referenced.
        /// </summary>
        Local = 1,

        /// <summary>
        /// Coordinate system is the default or a user-defined global system.
        /// </summary>
        Global = 2,
    }
}
