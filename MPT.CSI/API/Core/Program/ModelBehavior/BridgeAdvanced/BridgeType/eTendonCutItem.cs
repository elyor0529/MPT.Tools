﻿#if BUILD_CSiBridgev18 || BUILD_CSiBridgev19
namespace MPT.CSI.API.Core.Program.ModelBehavior.BridgeAdvanced.BridgeType
{
    /// <summary>
    /// Superstructure tendon cut items available in the application.
    /// </summary>
    public enum eTendonCutItem
    {
        /// <summary>
        /// X coordinate of tendon centroid, Xcg.
        /// </summary>
        XCoordinate = 1,

        /// <summary>
        /// Y coordinate of tendon centroid, Ycg.
        /// </summary>
        YCoordinate = 2,

        /// <summary>
        /// Duct diameter for tendon.
        /// </summary>
        Diameter = 3,

        /// <summary>
        /// Bonding type for tendon.
        /// </summary>
        BondingType = 4,

        /// <summary>
        /// Tendon slope.
        /// </summary>
        Slope = 5
    }
}
#endif