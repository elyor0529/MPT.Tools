﻿// ***********************************************************************
// Assembly         : MPT.CSI.API
// Author           : Mark Thomas
// Created          : 10-09-2017
//
// Last Modified By : Mark Thomas
// Last Modified On : 10-10-2017
// ***********************************************************************
// <copyright file="NBCC_2015.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
#if BUILD_SAP2000v19 || BUILD_CSiBridgev19
using MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadLateralCode.Seismic;
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.CodesAutoLoad.Seismic
{
    /// <summary>
    /// Represents the UBC_94 auto seismic load in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.CodesAutoLoad.Seismic.AutoSeismicLoad" />
    /// <seealso cref="AutoSeismicLoad" />
    public class NBCC_2015 : AutoSeismicLoad
    {
#region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="NBCC_2015" /> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public NBCC_2015(CSiApiSeed seed) : base(seed) { }


#endregion

#region Methods: Public
        /// <summary>
        /// This function retrieves auto seismic loading parameters for the 2015 NBCC code.
        /// </summary>
        /// <param name="name">The name of an existing Quake-type load pattern with a corresponding auto seismic load assignment.</param>
        /// <param name="loadDirection">The seismic load direction.</param>
        /// <param name="eccentricity">The eccentricity ratio that applies to all diaphragms.</param>
        /// <param name="periodOption">The time period option.</param>
        /// <param name="CtType">The structure type.</param>
        /// <param name="userSpecifiedPeriod">The user specified time period. [s]
        /// This only applies when <paramref name="periodOption" /> = <see cref="eTimePeriodOption.UserDefined" /></param>
        /// <param name="userSpecifiedHeights">True: Top and bottom elevations of the seismic load are user specified.
        /// Else, the program determines the elevations.</param>
        /// <param name="coordinateTopZ">Global Z-coordinate at the highest level where auto seismic loads are applied. [L].
        /// This only applies when <paramref name="userSpecifiedHeights" /> = True.</param>
        /// <param name="coordinateBottomZ">Global Z-coordinate at the lowest level where auto seismic loads are applied. [L].
        /// This only applies when <paramref name="userSpecifiedHeights" /> = True.</param>
        /// <param name="siteClass">The site class.</param>
        /// <param name="Ro">The overstrength modifier.</param>
        /// <param name="I">The importance factor.</param>
        /// <param name="PGA">The peak ground acceleration.</param>
        /// <param name="S02">The spectral acceleration at a 0.2 second period.</param>
        /// <param name="S05">The spectral acceleration at a 0.5 second period.</param>
        /// <param name="S1">The spectral acceleration at a 1 second period.</param>
        /// <param name="S2">The spectral acceleration at a 2 second period.</param>
        /// <param name="S5">The spectral acceleration at a 5 second period.</param>
        /// <param name="S10">The spectral acceleration at a 10 second period.</param>
        /// <param name="F02">The site coefficient at a 0.2 second period.
        /// This only applies when <paramref name="siteClass" /> = <see cref="eSiteClass_NBCC_2005.F" />.</param>
        /// <param name="F05">The site coefficient at a 0.5 second period.
        /// This only applies when <paramref name="siteClass" /> = <see cref="eSiteClass_NBCC_2005.F" />.</param>
        /// <param name="F1">The site coefficient at a 1 second period.
        /// This only applies when <paramref name="siteClass" /> = <see cref="eSiteClass_NBCC_2005.F" />.</param>
        /// <param name="F2">The site coefficient at a 2 second period.
        /// This only applies when <paramref name="siteClass" /> = <see cref="eSiteClass_NBCC_2005.F" />.</param>
        /// <param name="F5">The site coefficient at a 5 second period.
        /// This only applies when <paramref name="siteClass" /> = <see cref="eSiteClass_NBCC_2005.F" />.</param>
        /// <param name="F10">The site coefficient at a 10 second period.
        /// This only applies when <paramref name="siteClass" /> = <see cref="eSiteClass_NBCC_2005.F" />.</param>
        /// <param name="Mv">The higher mode factor.</param>
        /// <param name="Rd">The ductility modifier.</param>
        /// <exception cref="CSiException"></exception>
        public void GetLoad(string name,
            ref eSeismicLoadDirection loadDirection,
            ref double eccentricity,
            ref eTimePeriodOption periodOption,
            ref eCtType_NBCC_2005 CtType,
            ref double userSpecifiedPeriod,
            ref bool userSpecifiedHeights,
            ref double coordinateTopZ,
            ref double coordinateBottomZ,
            ref eSiteClass_NBCC_2005 siteClass,
            ref double Ro,
            ref double I,
            ref double PGA,
            ref double S02,
            ref double S05,
            ref double S1,
            ref double S2,
            ref double S5,
            ref double S10,
            ref double F02,
            ref double F05,
            ref double F1,
            ref double F2,
            ref double F5,
            ref double F10,
            ref double Mv,
            ref double Rd)
        {
            int csiLoadDirection = 0;
            int csiPeriodOption = 0;
            int csiCtType = 0;
            int csiSiteClass = 0;

            _callCode = _sapModel.LoadPatterns.AutoSeismic.GetNBCC2015(name,
                            ref csiLoadDirection,
                            ref eccentricity,
                            ref csiCtType,
                            ref csiPeriodOption,
                            ref userSpecifiedPeriod,
                            ref userSpecifiedHeights,
                            ref coordinateTopZ,
                            ref coordinateBottomZ,
                            ref PGA,
                            ref S02,
                            ref S05,
                            ref S1,
                            ref S2,
                            ref S5,
                            ref S10,
                            ref csiSiteClass,
                            ref F02,
                            ref F05,
                            ref F1,
                            ref F2,
                            ref F5,
                            ref F10,
                            ref I,
                            ref Mv,
                            ref Rd,
                            ref Ro);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            loadDirection = (eSeismicLoadDirection)csiLoadDirection;
            periodOption = (eTimePeriodOption)csiPeriodOption;
            CtType = (eCtType_NBCC_2005)csiCtType;
            siteClass = (eSiteClass_NBCC_2005)csiSiteClass;
        }


        /// <summary>
        /// This function assigns auto seismic loading parameters for the 2015 NBCC code.
        /// </summary>
        /// <param name="name">The name of an existing Quake-type load pattern with a corresponding auto seismic load assignment.</param>
        /// <param name="loadDirection">The seismic load direction.</param>
        /// <param name="eccentricity">The eccentricity ratio that applies to all diaphragms.</param>
        /// <param name="periodOption">The time period option.</param>
        /// <param name="CtType">The structure type.</param>
        /// <param name="userSpecifiedPeriod">The user specified time period. [s]
        /// This only applies when <paramnamef name="periodOption" /> = <see cref="eTimePeriodOption.UserDefined" /></param>
        /// <param name="userSpecifiedHeights">True: Top and bottom elevations of the seismic load are user specified.
        /// Else, the program determines the elevations.</param>
        /// <param name="coordinateTopZ">Global Z-coordinate at the highest level where auto seismic loads are applied. [L].
        /// This only applies when <paramnamef name="userSpecifiedHeights" /> = True.</param>
        /// <param name="coordinateBottomZ">Global Z-coordinate at the lowest level where auto seismic loads are applied. [L].
        /// This only applies when <paramnamef name="userSpecifiedHeights" /> = True.</param>
        /// <param name="siteClass">The site class.</param>
        /// <param name="Ro">The overstrength modifier.</param>
        /// <param name="I">The importance factor.</param>
        /// <param name="PGA">The peak ground acceleration.</param>
        /// <param name="S02">The spectral acceleration at a 0.2 second period.</param>
        /// <param name="S05">The spectral acceleration at a 0.5 second period.</param>
        /// <param name="S1">The spectral acceleration at a 1 second period.</param>
        /// <param name="S2">The spectral acceleration at a 2 second period.</param>
        /// <param name="S5">The spectral acceleration at a 5 second period.</param>
        /// <param name="S10">The spectral acceleration at a 10 second period.</param>
        /// <param name="F02">The site coefficient at a 0.2 second period.
        /// This only applies when <paramnamef name="siteClass" /> = <see cref="eSiteClass_NBCC_2005.F" />.</param>
        /// <param name="F05">The site coefficient at a 0.5 second period.
        /// This only applies when <paramnamef name="siteClass" /> = <see cref="eSiteClass_NBCC_2005.F" />.</param>
        /// <param name="F1">The site coefficient at a 1 second period.
        /// This only applies when <paramnamef name="siteClass" /> = <see cref="eSiteClass_NBCC_2005.F" />.</param>
        /// <param name="F2">The site coefficient at a 2 second period.
        /// This only applies when <paramnamef name="siteClass" /> = <see cref="eSiteClass_NBCC_2005.F" />.</param>
        /// <param name="F5">The site coefficient at a 5 second period.
        /// This only applies when <paramnamef name="siteClass" /> = <see cref="eSiteClass_NBCC_2005.F" />.</param>
        /// <param name="F10">The site coefficient at a 10 second period.
        /// This only applies when <paramnamef name="siteClass" /> = <see cref="eSiteClass_NBCC_2005.F" />.</param>
        /// <param name="Mv">The higher mode factor.</param>
        /// <param name="Rd">The ductility modifier.</param>
        /// <exception cref="CSiException"></exception>
        public void SetLoad(string name,
            eSeismicLoadDirection loadDirection,
            double eccentricity,
            eTimePeriodOption periodOption,
            eCtType_NBCC_2005 CtType,
            double userSpecifiedPeriod,
            bool userSpecifiedHeights,
            double coordinateTopZ,
            double coordinateBottomZ,
            eSiteClass_NBCC_2005 siteClass,
            double Ro,
            double I,
            double PGA,
            double S02,
            double S05,
            double S1,
            double S2,
            double S5,
            double S10,
            double F02,
            double F05,
            double F1,
            double F2,
            double F5,
            double F10,
            double Mv,
            double Rd)
        {
            _callCode = _sapModel.LoadPatterns.AutoSeismic.SetNBCC2015(name,
                            (int)loadDirection,
                            eccentricity,
                            (int)CtType,
                            (int)periodOption,
                            userSpecifiedPeriod,
                            userSpecifiedHeights,
                            coordinateTopZ,
                            coordinateBottomZ,
                            PGA,
                            S02,
                            S05,
                            S1,
                            S2,
                            S5,
                            S10,
                            (int)siteClass,
                            F02,
                            F05,
                            F1,
                            F2,
                            F5,
                            F10,
                            I,
                            Mv,
                            Rd,
                            Ro);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
#endregion
    }
}
#endif
