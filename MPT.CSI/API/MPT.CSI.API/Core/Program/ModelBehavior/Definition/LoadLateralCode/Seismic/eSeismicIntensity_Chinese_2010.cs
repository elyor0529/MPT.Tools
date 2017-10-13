﻿// ***********************************************************************
// Assembly         : MPT.CSI.API
// Author           : Mark Thomas
// Created          : 10-09-2017
//
// Last Modified By : Mark Thomas
// Last Modified On : 10-09-2017
// ***********************************************************************
// <copyright file="eSeismicIntensity_Chinese_2010.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadLateralCode.Seismic
{
    /// <summary>
    /// Seismic intensity for Chinese 2010 seismic lateral code forces.
    /// </summary>
    public enum eSeismicIntensity_Chinese_2010
    {
        /// <summary>
        /// Intensity 6 (0.05g).
        /// </summary>
        Intensity6_0_05g = 1,

        /// <summary>
        /// Intensity 7 (0.10g).
        /// </summary>
        Intensity7_0_10g = 2,

        /// <summary>
        /// Intensity 7 (0.15g).
        /// </summary>
        Intensity7_0_15g = 3,

        /// <summary>
        /// Intensity 8 (0.20g).
        /// </summary>
        Intensity8_0_20g = 4,

        /// <summary>
        /// Intensity 8 (0.30g).
        /// </summary>
        Intensity8_0_30g = 5,

        /// <summary>
        /// Intensity 9 (0.40g).
        /// </summary>
        Intensity9_0_40g = 6,
    }
}
#endif