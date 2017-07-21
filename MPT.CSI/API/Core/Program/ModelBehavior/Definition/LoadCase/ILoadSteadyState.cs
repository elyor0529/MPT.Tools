﻿namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Represents the steady state load in the application.
    /// </summary>
    public interface ILoadSteadyState
    {
        /// <summary>
        /// This function retrieves the load data for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing steady state load case.</param>
        /// <param name="numberOfLoads">The number of loads assigned to the specified analysis case.</param>
        /// <param name="loadTypes">Either <see cref="eLoadType.Load"/> or <see cref="eLoadType.Accel"/>, indicating the type of each load assigned to the load case.</param>
        /// <param name="loadNames">The name of each load assigned to the load case.
        /// If <paramref name="loadTypes"/> = <see cref="eLoadType.Load"/>, this item is the name of a defined load pattern.
        /// If <paramref name="loadTypes"/> = <see cref="eLoadType.Accel"/>, this item is U1, U2, U3, R1, R2 or R3, indicating the direction of the load.</param>
        /// <param name="functions">The name of the steady state function associated with each load.</param>
        /// <param name="scaleFactor">The scale factor of each load assigned to the load case. [L/s^2] for U1 U2 and U3; otherwise unitless.</param>
        /// <param name="phaseAngle">The phase angle for each load. [deg].</param>
        /// <param name="coordinateSystems">This is an array that includes the name of the coordinate system associated with each load. 
        /// If this item is a blank string, the Global coordinate system is assumed.
        /// This item applies only when <paramref name="loadTypes"/> = <see cref="eLoadType.Accel"/>.</param>
        /// <param name="angles">This is an array that includes the angle between the acceleration local 1 axis and the +X-axis of the coordinate system specified by <paramref name="coordinateSystems"/>. 
        /// The rotation is about the Z-axis of the specified coordinate system. [deg].
        /// This item applies only when <paramref name="loadTypes"/> = <see cref="eLoadType.Accel"/>.</param>
        void GetLoads(string name,
            ref int numberOfLoads,
            ref eLoadType[] loadTypes,
            ref string[] loadNames,
            ref string[] functions,
            ref double[] scaleFactor,
            ref double[] phaseAngle,
            ref string[] coordinateSystems,
            ref double[] angles);

        /// <summary>
        /// This function sets the load data for the specified analysis case.
        /// </summary>
        /// <param name="name">The name of an existing steady state load case.</param>
        /// <param name="numberOfLoads">The number of loads assigned to the specified analysis case.</param>
        /// <param name="loadTypes">Either <see cref="eLoadType.Load"/> or <see cref="eLoadType.Accel"/>, indicating the type of each load assigned to the load case.</param>
        /// <param name="loadNames">The name of each load assigned to the load case.
        /// If <paramref name="loadTypes"/> = <see cref="eLoadType.Load"/>, this item is the name of a defined load pattern.
        /// If <paramref name="loadTypes"/> = <see cref="eLoadType.Accel"/>, this item is U1, U2, U3, R1, R2 or R3, indicating the direction of the load.</param>
        /// <param name="functions">The name of the steady state function associated with each load.</param>
        /// <param name="scaleFactor">The scale factor of each load assigned to the load case. [L/s^2] for U1 U2 and U3; otherwise unitless.</param>
        /// <param name="phaseAngle">The phase angle for each load. [deg].</param>
        /// <param name="coordinateSystems">This is an array that includes the name of the coordinate system associated with each load. 
        /// If this item is a blank string, the Global coordinate system is assumed.
        /// This item applies only when <paramref name="loadTypes"/> = <see cref="eLoadType.Accel"/>.</param>
        /// <param name="angles">This is an array that includes the angle between the acceleration local 1 axis and the +X-axis of the coordinate system specified by <paramref name="coordinateSystems"/>. 
        /// The rotation is about the Z-axis of the specified coordinate system. [deg].
        /// This item applies only when <paramref name="loadTypes"/> = <see cref="eLoadType.Accel"/>.</param>
        void SetLoads(string name,
            int numberOfLoads,
            eLoadType[] loadTypes,
            string[] loadNames,
            string[] functions,
            double[] scaleFactor,
            double[] phaseAngle,
            string[] coordinateSystems,
            double[] angles);
    }
}
