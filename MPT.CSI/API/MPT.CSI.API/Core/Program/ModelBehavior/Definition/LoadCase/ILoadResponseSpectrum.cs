﻿// ***********************************************************************
// Assembly         : MPT.CSI.API
// Author           : Mark Thomas
// Created          : 07-20-2017
//
// Last Modified By : Mark Thomas
// Last Modified On : 10-08-2017
// ***********************************************************************
// <copyright file="ILoadResponseSpectrum.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Represents the response spectrum load in the application.
    /// </summary>
    public interface ILoadResponseSpectrum
    {
        /// <summary>
        /// This function retrieves the load data for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing steady state load case.</param>
        /// <param name="loadDirections">U1, U2, U3, R1, R2 or R3, indicating the direction of each load.</param>
        /// <param name="functions">The name of the steady state function associated with each load.</param>
        /// <param name="scaleFactor">The scale factor of each load assigned to the load case. [L/s^2] for U1 U2 and U3; otherwise unitless.</param>
        /// <param name="coordinateSystems">This is an array that includes the name of the coordinate system associated with each load.
        /// If this item is a blank string, the Global coordinate system is assumed.</param>
        /// <param name="angles">This is an array that includes the angle between the acceleration local 1 axis and the +X-axis of the coordinate system specified by <paramref name="coordinateSystems" />.
        /// The rotation is about the Z-axis of the specified coordinate system. [deg].</param>
        void GetLoads(string name,
            ref eDegreeOfFreedom[] loadDirections,
            ref string[] functions,
            ref double[] scaleFactor,
            ref string[] coordinateSystems,
            ref double[] angles);


#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        /// <summary>
        /// This function sets the load data for the specified analysis case.
        /// </summary>
        /// <param name="name">The name of an existing steady state load case.</param>
        /// <param name="loadDirections">U1, U2, U3, R1, R2 or R3, indicating the direction of each load.</param>
        /// <param name="functions">The name of the steady state function associated with each load.</param>
        /// <param name="scaleFactor">The scale factor of each load assigned to the load case. [L/s^2] for U1 U2 and U3; otherwise unitless.</param>
        /// <param name="coordinateSystems">This is an array that includes the name of the coordinate system associated with each load.
        /// If this item is a blank string, the Global coordinate system is assumed.</param>
        /// <param name="angles">This is an array that includes the angle between the acceleration local 1 axis and the +X-axis of the coordinate system specified by <paramref name="coordinateSystems" />.
        /// The rotation is about the Z-axis of the specified coordinate system. [deg].</param>
        void SetLoads(string name,
            eDegreeOfFreedom[] loadDirections,
            string[] functions,
            double[] scaleFactor,
            string[] coordinateSystems,
            double[] angles);
#endif
    }
}
