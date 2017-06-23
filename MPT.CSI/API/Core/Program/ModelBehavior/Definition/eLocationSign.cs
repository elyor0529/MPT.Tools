namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Location reference by sign.
    /// Used in SectioCut.Get/SetResultsSide.
    /// </summary>
    public enum eLocationSign
    {
        /// <summary>
        /// Positive 3-axis side of quadrilateral.
        /// </summary>
        Positive3 = 1,

        /// <summary>
        /// Negative 3-axis side of quadrilateral.
        /// </summary>
        Negative3 = 2
    }
}
