namespace MPT.CSI.API.Core.Program.ModelBehavior.Design.CodesDesign.Aluminum
{
    #if BUILD_SAP2000v16 || BUILD_SAP2000v17 || BUILD_SAP2000v18 || BUILD_SAP2000v19
    /// <summary>
    /// Preferences available for <see cref="AA_ASD_2000"/> aluminum design in the application.
    /// </summary>
    public enum ePreferences_AA_ASD_2000
    {
        /// <summary>
        /// The framing type.
        /// </summary>
        FramingType = 1,

        /// <summary>
        /// The demand/capacity ratio limit.
        /// </summary>
        DemandCapacityRatioLimit = 2,

        /// <summary>
        /// The lateral factor.
        /// </summary>
        LateralFactor = 3,

        /// <summary>
        /// Use lateral factor?
        /// </summary>
        UseLateralFactor = 4,

        /// <summary>
        /// The bridge type structure.
        /// </summary>
        BridgeTypeStructure = 5,

        /// <summary>
        /// The time history design.
        /// </summary>
        TimeHistoryDesign = 6
    }
#endif
}