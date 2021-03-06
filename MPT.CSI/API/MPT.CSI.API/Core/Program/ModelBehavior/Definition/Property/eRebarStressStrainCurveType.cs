﻿// ***********************************************************************
// Assembly         : MPT.CSI.API
// Author           : Mark Thomas
// Created          : 07-15-2017
//
// Last Modified By : Mark Thomas
// Last Modified On : 07-15-2017
// ***********************************************************************
// <copyright file="eRebarStressStrainCurveType.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Stress-strain curve types available for rebar in the application.
    /// </summary>
    public enum eRebarStressStrainCurveType
    {
        /// <summary>
        /// User defined.
        /// </summary>
        UserDefined = 0,

        /// <summary>
        /// Parametric – Simple.
        /// </summary>
        ParametricSimple = 1,

        /// <summary>
        /// Parametric – Park.
        /// </summary>
        ParametricPark = 2
    }
}