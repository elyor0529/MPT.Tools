namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Function
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    /// <summary>
    /// The direction to which the SP 14.13330.2014 response spectrum is applied.
    /// </summary>
    public enum eSpectrumDirection_SP_14_13330_2014
    {
        /// <summary>
        /// Response spectrum is applied in the horizontal direction to a building.
        /// </summary>
        BuildingHorizontal = 1,

        /// <summary>
        /// Response spectrum is applied in the vertical direction to a building.
        /// </summary>
        BuildingVertical = 2,
        
        /// <summary>
        /// Response spectrum is applied in the horizontal direction to a bridge.
        /// </summary>
        BridgeHorizontal = 3,

        /// <summary>
        /// Response spectrum is applied in the vertical direction to a bridge.
        /// </summary>
        BridgeVertical = 4,
    }
#endif
}
