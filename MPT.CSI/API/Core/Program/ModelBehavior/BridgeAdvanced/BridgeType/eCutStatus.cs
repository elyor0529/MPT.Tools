﻿namespace MPT.CSI.API.Core.Program.ModelBehavior.BridgeAdvanced.BridgeType
{
    /// <summary>
    /// Status available for bridge superstructure cuts.
    /// </summary>
    public enum eCutStatus
    {
        /// <summary>
        /// No portion of the section is cut.
        /// </summary>
        NoCut = 0,

        /// <summary>
        /// Only the section is cut; no interior cell is cut.
        /// </summary>
        OnlySectionCut = 1,

        /// <summary>
        /// The section and an interior cell are cut.
        /// </summary>
        SectionAndInteriorCellCut = 2
    }
}