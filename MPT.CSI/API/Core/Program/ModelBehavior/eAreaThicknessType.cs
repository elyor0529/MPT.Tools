namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Thickness types avilable for aera elements in the application.
    /// </summary>
    public enum eAreaThicknessType
    {
        /// <summary>
        /// No thickness overwrite.
        /// </summary>
        NoOverwrites = 0,

        /// <summary>
        /// User defined thickness overwrites specified by joint patte.
        /// </summary>
        OverwriteByJointPattern = 1,

        /// <summary>
        /// User defined thickness overwrites specified by point.
        /// </summary>
        OverwriteByPoint = 2
    }
}
