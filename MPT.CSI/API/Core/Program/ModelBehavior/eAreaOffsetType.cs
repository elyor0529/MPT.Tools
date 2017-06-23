namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Joint offset types avilable for aera elements in the application.
    /// </summary>
    public enum eAreaOffsetType
    {
        /// <summary>
        /// No joint offsets.
        /// </summary>
        NoOffsets = 0,

        /// <summary>
        /// User defined joint offsets specified by joint patte.
        /// </summary>
        OffsetByJointPattern = 1,

        /// <summary>
        /// User defined joint offsets specified by point.
        /// </summary>
        OffsetByPoint = 2
    }
}
