﻿// ***********************************************************************
// Assembly         : MPT.CSI.API
// Author           : Mark Thomas
// Created          : 10-09-2017
//
// Last Modified By : Mark Thomas
// Last Modified On : 10-09-2017
// ***********************************************************************
// <copyright file="eZa_NBCC_1995.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadLateralCode.Seismic
{
    /// <summary>
    /// The acceleration related zone for NBCC 1995 seismic lateral code forces.
    /// </summary>
    public enum eZa_NBCC_1995
    {
        /// <summary>
        /// Acceleration related zone 1.
        /// </summary>
        Zone1 = 1,

        /// <summary>
        /// Acceleration related zone 2.
        /// </summary>
        Zone2 = 2,

        /// <summary>
        /// Acceleration related zone 3.
        /// </summary>
        Zone3 = 3,

        /// <summary>
        /// Acceleration related zone 4.
        /// </summary>
        Zone4 = 4,

        /// <summary>
        /// Acceleration related zone 5.
        /// </summary>
        Zone5 = 5,

        /// <summary>
        /// Acceleration related zone 6.
        /// </summary>
        Zone6 = 6
    }
}
#endif