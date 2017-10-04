﻿#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Strain components.
    /// </summary>
    public enum eStrainComponent
    {
        /// <summary>
        /// Strain 1-1.
        /// </summary>
        Strain11 = 1,

        /// <summary>
        /// Strain 2-2.
        /// </summary>
        Strain22 = 2,

        /// <summary>
        /// Strain 3-3.
        /// </summary>
        Strain12 = 3,

        /// <summary>
        /// Strain 1-3.
        /// </summary>
        Strain13 = 4,

        /// <summary>
        /// Strain 2-3.
        /// </summary>
        Strain23 = 5
    }
}
#endif