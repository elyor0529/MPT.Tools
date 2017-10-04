namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Function
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    /// <summary>
    /// The direction to which the Eurocode 8 2004 response spectrum is applied.
    /// </summary>
    public enum eSpectrumDirection_Eurocode_8_2004
    {
        /// <summary>
        /// Response spectrum is applied in the horizontal direction.
        /// </summary>
        Horizontal = 1,

        /// <summary>
        /// Response spectrum is applied in the vertical direction.
        /// </summary>
        Vertical = 2
    }
#endif
}
