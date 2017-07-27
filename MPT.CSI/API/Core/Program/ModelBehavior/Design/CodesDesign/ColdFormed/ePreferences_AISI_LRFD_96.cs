﻿namespace MPT.CSI.API.Core.Program.ModelBehavior.Design.CodesDesign.ColdFormed
{
    #if !BUILD_CSiBridgev18 && !BUILD_CSiBridgev19
    /// <summary>
    /// Preferences available for <see cref="AISI_LRFD_96"/> cold-formed steel design in the application.
    /// </summary>
    public enum ePreferences_AISI_LRFD_96
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
        /// The bending stiffened Phi.
        /// </summary>
        BendingStiffened_Phi = 3,

        /// <summary>
        /// The bending unstiffened Phi.
        /// </summary>
        BendingUnstiffened_Phi = 4,

        /// <summary>
        /// The bending lateral torsional buckling Phi.
        /// </summary>
        BendingLateralTorsionalBuckling_Phi = 5,

        /// <summary>
        /// The shear slender Phi.
        /// </summary>
        ShearSlender_Phi = 6,

        /// <summary>
        /// The shear nonslender Phi.
        /// </summary>
        ShearNonslender_Phi = 7,

        /// <summary>
        /// The axial tension Phi.
        /// </summary>
        AxialTension_Phi = 8,

        /// <summary>
        /// The axial compression Phi.
        /// </summary>
        AxialCompression_Phi = 9,

        /// <summary>
        /// The time history design.
        /// </summary>
        TimeHistoryDesign = 10
    }
#endif
}