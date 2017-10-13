﻿// ***********************************************************************
// Assembly         : MPT.CSI.API
// Author           : Mark Thomas
// Created          : 10-09-2017
//
// Last Modified By : Mark Thomas
// Last Modified On : 10-09-2017
// ***********************************************************************
// <copyright file="eSiteClass_NZS_1170_2004.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadLateralCode.Seismic
{
    /// <summary>
    /// Site class for NZS 1170 2004 seismic lateral code forces.
    /// </summary>
    public enum eSiteClass_NZS_1170_2004
    {
        /// <summary>
        /// Site class A.
        /// </summary>
        A = 1,

        /// <summary>
        /// Site class B.
        /// </summary>
        B = 2,

        /// <summary>
        /// Site class C.
        /// </summary>
        C = 3,

        /// <summary>
        /// Site class D.
        /// </summary>
        D = 4,

        /// <summary>
        /// Site class E.
        /// </summary>
        E = 5,
    }
}
#endif