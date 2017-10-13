﻿// ***********************************************************************
// Assembly         : MPT.CSI.API
// Author           : Mark Thomas
// Created          : 07-19-2017
//
// Last Modified By : Mark Thomas
// Last Modified On : 10-08-2017
// ***********************************************************************
// <copyright file="ITimeHistoryModalLinear.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    /// <summary>
    /// Represents the linear modal time history load case in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase.ISetLoadCase" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase.ILoadTimeHistory" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase.IDampingModal" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase.ITimeStep" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase.IObservableModalCase" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase.IChangeableModalCase" />
    public interface ITimeHistoryModalLinear:
        ISetLoadCase, ILoadTimeHistory, IDampingModal, ITimeStep, 
        IObservableModalCase, IChangeableModalCase
    {
        /// <summary>
        /// This function retrieves the motion type for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing linear modal history analysis case.</param>
        /// <param name="motionType">The time history motion type.</param>
        void GetMotionType(string name,
            ref eMotionType motionType);

        /// <summary>
        /// This function sets the motion type for the specified analysis case.
        /// </summary>
        /// <param name="name">The name of an existing linear modal history analysis case.</param>
        /// <param name="motionType">The time history motion type.</param>
        void SetMotionType(string name,
            eMotionType motionType);
    }
#else
    /// <summary>
    /// Represents the linear modal time history load case in the application.
    /// </summary>
    public interface ITimeHistoryModalLinear :
        ISetLoadCase, ILoadTimeHistory
    {
        /// <summary>
        /// This function sets the load data for the specified analysis case.
        /// </summary>
        /// <param name="name">The name of an existing steady state load case.</param>
        /// <param name="loadTypes">Either <see cref="eLoadType.Load"/> or <see cref="eLoadType.Accel"/>, indicating the type of each load assigned to the load case.</param>
        /// <param name="loadNames">The name of each load assigned to the load case.
        /// If <paramref name="loadTypes"/> = <see cref="eLoadType.Load"/>, this item is the name of a defined load pattern.
        /// If <paramref name="loadTypes"/> = <see cref="eLoadType.Accel"/>, this item is U1, U2, U3, R1, R2 or R3, indicating the direction of the load.</param>
        /// <param name="functions">The name of the steady state function associated with each load.</param>
        /// <param name="scaleFactor">The scale factor of each load assigned to the load case. [L/s^2] for U1 U2 and U3; otherwise unitless.</param>
        /// <param name="timeFactor">The time scale factor of each load assigned to the load case.</param>
        /// <param name="arrivalTime">The arrival time of each load assigned to the load case.</param>
        /// <param name="coordinateSystems">This is an array that includes the name of the coordinate system associated with each load. 
        /// If this item is a blank string, the Global coordinate system is assumed.
        /// This item applies only when <paramref name="loadTypes"/> = <see cref="eLoadType.Accel"/>.</param>
        /// <param name="angles">This is an array that includes the angle between the acceleration local 1 axis and the +X-axis of the coordinate system specified by <paramref name="coordinateSystems"/>. 
        /// The rotation is about the Z-axis of the specified coordinate system. [deg].
        /// This item applies only when <paramref name="loadTypes"/> = <see cref="eLoadType.Accel"/>.</param>
        void SetLoads(string name,
            eLoadType[] loadTypes,
            string[] loadNames,
            string[] functions,
            double[] scaleFactor,
            double[] timeFactor,
            double[] arrivalTime,
            string[] coordinateSystems,
            double[] angles);
    }
#endif
}
