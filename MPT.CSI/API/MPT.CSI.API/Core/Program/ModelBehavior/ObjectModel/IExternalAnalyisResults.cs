﻿// ***********************************************************************
// Assembly         : MPT.CSI.API
// Author           : Mark Thomas
// Created          : 10-06-2017
//
// Last Modified By : Mark Thomas
// Last Modified On : 10-08-2017
// ***********************************************************************
// <copyright file="IExternalAnalyisResults.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Implements the external analysis results in the application.
    /// </summary>
    public interface IExternalAnalyisResults
    {
        /// <summary>
        /// This function deletes all the external results previously provided for all frame objects.
        /// </summary>
        void DeleteAllFrameForces();

        /// <summary>
        /// This function deletes all the external results previously provided for a given frame object.
        /// </summary>
        /// <param name="name">The name of an existing frame object.</param>
        void DeleteFrameForces(string name);

        /// <summary>
        /// Calling this function is optional, but it can speed up subsequent assignment of external analysis results which are available for more than one load case.
        /// The first time this function is called for a particular frame object, it sets the list of names of external result load cases for which results relevant to the object are available.
        /// Subsequent calls to this function for the same object reset the results for load cases already in the list, and add load cases not already in.
        /// </summary>
        /// <param name="name">The name of an existing frame object.</param>
        /// <param name="numberCaseNames">Number of names of previously defined external result load cases for which user-supplied external analysis results are available for the frame object.</param>
        /// <param name="caseNames">Names of previously defined external result load cases for which user-supplied external analysis results are available for the frame object.</param>
        void PresetFrameCases(string name,
            int numberCaseNames,
            ref string[] caseNames);

        // === Get/Set ===

        /// <summary>
        /// This function reports the external result forces for a given step of a given external results load case on a given object.
        /// </summary>
        /// <param name="name">The name of an existing frame object.</param>
        /// <param name="initialCase">The name of an existing external results load case for which external results relevant to the object may have been previously provided.</param>
        /// <param name="caseStep">The zero based index of a load case step: 0 for the first step, 1 for the second, and so on.</param>
        /// <param name="P">Axial force for each frame station where external forces are reported. [F].</param>
        /// <param name="V2">Shear force in the local 2-direction for each frame station where external forces are reported. [F].</param>
        /// <param name="V3">Shear force in the local 3-direction for each frame station where external forces are reported. [F].</param>
        /// <param name="T">Torsion force for each frame station where external forces are reported. [F*L].</param>
        /// <param name="M2">Moment about the local 2-axis for each frame station where external forces are reported. [F*L].</param>
        /// <param name="M3">Moment about the local 3-axis for each frame station where external forces are reported. [F*L].</param>
        void GetFrameForces(string name,
            string initialCase,
            int caseStep,
            ref double[] P,
            ref double[] V2,
            ref double[] V3,
            ref double[] T,
            ref double[] M2,
            ref double[] M3);

        /// <summary>
        /// This function sets the external result forces for a given step of a given external results load case on a frame object.
        /// </summary>
        /// <param name="name">The name of an existing frame object.</param>
        /// <param name="initialCase">The name of an existing external results load case for which external results relevant to the object may have been previously provided.</param>
        /// <param name="P">Axial force for each frame station where result forces are reported.[F].
        /// These arrays are each expected to contain a number of values equal to the  previously declared number of stations at which external results are available for the object – see SapObject.SapModel.ExternalAnalysisResults.SetFrameStations() for that declaration.
        /// If any of these arrays is empty, the function substitutes zero values for the missing values.</param>
        /// <param name="V2">Shear force in the local 2-direction for each frame station where result forces are reported. [F].
        /// These arrays are each expected to contain a number of values equal to the  previously declared number of stations at which external results are available for the object – see SapObject.SapModel.ExternalAnalysisResults.SetFrameStations() for that declaration.
        /// If any of these arrays is empty, the function substitutes zero values for the missing values.</param>
        /// <param name="V3">Shear force in the local 3-direction for each frame station where result forces are reported. [F].
        /// These arrays are each expected to contain a number of values equal to the  previously declared number of stations at which external results are available for the object – see SapObject.SapModel.ExternalAnalysisResults.SetFrameStations() for that declaration.
        /// If any of these arrays is empty, the function substitutes zero values for the missing values.</param>
        /// <param name="T">Torsion force where result forces are reported. [F*L].
        /// These arrays are each expected to contain a number of values equal to the  previously declared number of stations at which external results are available for the object – see SapObject.SapModel.ExternalAnalysisResults.SetFrameStations() for that declaration.
        /// If any of these arrays is empty, the function substitutes zero values for the missing values.</param>
        /// <param name="M2">Moment about the local 2-axis where result forces are reported. [F*L].
        /// These arrays are each expected to contain a number of values equal to the  previously declared number of stations at which external results are available for the object – see SapObject.SapModel.ExternalAnalysisResults.SetFrameStations() for that declaration.
        /// If any of these arrays is empty, the function substitutes zero values for the missing values.</param>
        /// <param name="M3">Moment about the local 3-axis where result forces are reported. [F*L].
        /// These arrays are each expected to contain a number of values equal to the  previously declared number of stations at which external results are available for the object – see SapObject.SapModel.ExternalAnalysisResults.SetFrameStations() for that declaration.
        /// If any of these arrays is empty, the function substitutes zero values for the missing values.</param>
        void SetFrameForce(string name,
            string initialCase,
            double[] P,
            double[] V2,
            double[] V3,
            double[] T,
            double[] M2,
            double[] M3);

        /// <summary>
        /// This function sets the external result forces for all input frames and load cases.
        /// The P, V2, V3, T, M2, M3 arrays should be of length:
        /// (Sum of all steps for all input Load Cases) * (Sum of all stations for all input Frames)
        /// The number of stations must be previously declared using SetFrameStations.
        /// Enter 0 for any unneeded values in these arrays.
        /// </summary>
        /// <param name="frameNames">Names of existing frame objects.</param>
        /// <param name="loadCases">Existing external results load cases for which user-supplied external analysis results relevant to the frame objects are available.</param>
        /// <param name="firstSteps">First step values for each load case.
        /// This should be of length <paramref name="loadCases" />.</param>
        /// <param name="lastSteps">Last step values for each load case.
        /// This should be of length <paramref name="loadCases" />.</param>
        /// <param name="P">Axial force for each frame station [F].</param>
        /// <param name="V2">Shear force in the local 2-direction for each frame station [F].</param>
        /// <param name="V3">Shear force in the local 3-direction for each frame station [F].</param>
        /// <param name="T">Torsion force for each frame station [F*L].</param>
        /// <param name="M2">Moment about the local 2-axis for each frame station [F*L].</param>
        /// <param name="M3">Moment about the local 3-axis for each frame station [F*L].</param>
        /// <remarks>The P, V2, V3, T, M2, M3 arrays should be of length:
        /// (Sum of all steps for all input Load Cases) * (Sum of all stations for all input Frames)
        /// As an example, consider setting results for two Frames, each with two defined Stations, for two Load Cases, each Load Case containing three steps, eg First Step = 1, Last step = 3.
        /// The values of this array will be iterated over in the following order:
        /// The P[0] value will be the axial force for FrameName[0], LoadCase[0], FirstStep[0], 1st Station
        /// The P[1] value will be the axial force for FrameName[0], LoadCase[0], FirstStep[0], 2nd Station
        /// The P[2] value will be the axial force for FrameName[0], LoadCase[0], FirstStep[0]+1, 1st Station
        /// The P[3] value will be the axial force for FrameName[0], LoadCase[0], FirstStep[0]+1, 2nd Station
        /// The P[4] value will be the axial force for FrameName[0], LoadCase[0], LastStep[0], 1st Station
        /// The P[5] value will be the axial force for FrameName[0], LoadCase[0], LastStep[0], 2nd Station
        /// The P[6] value will be the axial force for FrameName[0], LoadCase[1], FirstStep[1], 1st Station
        /// The P[7] value will be the axial force for FrameName[0], LoadCase[1], FirstStep[1], 2nd Station
        /// The P[8] value will be the axial force for FrameName[0], LoadCase[1], FirstStep[1]+1, 1st Station
        /// The P[9] value will be the axial force for FrameName[0], LoadCase[1], FirstStep[1]+1, 2nd Station
        /// The P[10] value will be the axial force for FrameName[0], LoadCase[1], LastStep[1], 1st Station
        /// The P[11] value will be the axial force for FrameName[0], LoadCase[1], LastStep[1], 2nd Station
        /// The P[12] value will be the axial force for FrameName[1], LoadCase[0], FirstStep[0], 1st Station
        /// And so on…
        /// The number of stations must be previously declared using SetFrameStations.
        /// Enter 0 for any unneeded values in these arrays.</remarks>
        void SetFrameForceMultiple(string[] frameNames,
            string[] loadCases,
            int[] firstSteps,
            int[] lastSteps,
            double[] P,
            double[] V2,
            double[] V3,
            double[] T,
            double[] M2,
            double[] M3);

        // === 

        /// <summary>
        /// This function gets the frame stations on a frame object for which user-supplied external analysis results are available.
        /// </summary>
        /// <param name="name">The name of an existing frame object.</param>
        /// <param name="distancesFromIEnd">The distances measured from the I-end of the object to the result location.</param>
        void GetFrameStations(string name,
            ref double[] distancesFromIEnd);

        /// <summary>
        /// This function sets the frame stations on a frame object for which user-supplied external analysis results are available.
        /// </summary>
        /// <param name="name">The name of an existing frame object.</param>
        /// <param name="distancesFromIEnd">The distances measured from the I-end of the object to the result location.</param>
        void SetFrameStations(string name,
            ref double[] distancesFromIEnd);
    }
}
#endif