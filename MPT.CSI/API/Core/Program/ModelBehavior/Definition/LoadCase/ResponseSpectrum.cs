using MPT.CSI.API.Core.Support;
using MPT.Enums;
#if BUILD_SAP2000v16
using SAP2000v16;
#elif BUILD_SAP2000v17
using SAP2000v17;
#elif BUILD_SAP2000v18
using SAP2000v18;
#elif BUILD_SAP2000v19
using SAP2000v19;
#elif BUILD_ETABS2013
using ETABS2013;


#elif BUILD_ETABS2015
using ETABS2015;
#elif BUILD_ETABS2016
using ETABS2016;
#endif


namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Represents the response spectrum load case in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class ResponseSpectrum : CSiApiBase, IResponseSpectrum
    {
        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseSpectrum"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public ResponseSpectrum(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Interface
        /// <summary>
        /// This function initializes a load case. 
        /// If this function is called for an existing load case, all items for the case are reset to their default value.
        /// </summary>
        /// <param name="name">The name of an existing or new load case. 
        /// If this is an existing case, that case is modified; otherwise, a new case is added.</param>
        /// <exception cref="CSiException"></exception>
        public void SetCase(string name)
        {
            _callCode = _sapModel.LoadCases.ResponseSpectrum.SetCase(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }





        /// <summary>
        /// This function retrieves the load data for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing steady state load case.</param>
        /// <param name="numberOfLoads">The number of loads assigned to the specified analysis case.</param>
        /// <param name="loadDirections">U1, U2, U3, R1, R2 or R3, indicating the direction of each load.</param>
        /// <param name="functions">The name of the steady state function associated with each load.</param>
        /// <param name="scaleFactor">The scale factor of each load assigned to the load case. [L/s^2] for U1 U2 and U3; otherwise unitless.</param>
        /// <param name="coordinateSystems">This is an array that includes the name of the coordinate system associated with each load. 
        /// If this item is a blank string, the Global coordinate system is assumed.</param>
        /// <param name="angles">This is an array that includes the angle between the acceleration local 1 axis and the +X-axis of the coordinate system specified by <paramref name="coordinateSystems"/>. 
        /// The rotation is about the Z-axis of the specified coordinate system. [deg].</param>
        /// <exception cref="CSiException"></exception>
        public void GetLoads(string name,
            ref int numberOfLoads,
            ref eDegreeOfFreedom[] loadDirections,
            ref string[] functions,
            ref double[] scaleFactor,
            ref string[] coordinateSystems,
            ref double[] angles)
        {
            string[] csiLoadDirections = new string[0];

            _callCode = _sapModel.LoadCases.ResponseSpectrum.GetLoads(name, ref numberOfLoads, ref csiLoadDirections, ref functions, ref scaleFactor, ref coordinateSystems, ref angles);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            loadDirections = new eDegreeOfFreedom[numberOfLoads - 1];
            for (int i = 0; i < numberOfLoads; i++)
            {
                loadDirections[i] = EnumLibrary.ConvertStringToEnumByDescription<eDegreeOfFreedom>(csiLoadDirections[i]);
            }
        }

        /// <summary>
        /// This function sets the load data for the specified analysis case.
        /// </summary>
        /// <param name="name">The name of an existing steady state load case.</param>
        /// <param name="numberOfLoads">The number of loads assigned to the specified analysis case.</param>
        /// <param name="loadDirections">U1, U2, U3, R1, R2 or R3, indicating the direction of each load.</param>
        /// <param name="functions">The name of the steady state function associated with each load.</param>
        /// <param name="scaleFactor">The scale factor of each load assigned to the load case. [L/s^2] for U1 U2 and U3; otherwise unitless.</param>
        /// <param name="coordinateSystems">This is an array that includes the name of the coordinate system associated with each load. 
        /// If this item is a blank string, the Global coordinate system is assumed.</param>
        /// <param name="angles">This is an array that includes the angle between the acceleration local 1 axis and the +X-axis of the coordinate system specified by <paramref name="coordinateSystems"/>. 
        /// The rotation is about the Z-axis of the specified coordinate system. [deg].</param>
        /// <exception cref="CSiException"></exception>
        public void SetLoads(string name,
            int numberOfLoads,
            eDegreeOfFreedom[] loadDirections,
            string[] functions,
            double[] scaleFactor,
            string[] coordinateSystems,
            double[] angles)
        {
            string[] csiLoadDirections = new string[0];
            for (int i = 0; i < numberOfLoads; i++)
            {
                csiLoadDirections[i] = loadDirections[i].ToString();
            }

            _callCode = _sapModel.LoadCases.ResponseSpectrum.SetLoads(name, numberOfLoads, ref csiLoadDirections, ref functions, ref scaleFactor, ref coordinateSystems, ref angles);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        /// <summary>
        /// This function retrieves the modal case assigned to the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case.</param>
        /// <param name="modalCase">This is either None or the name of an existing modal analysis case. 
        /// It specifies the modal load case on which any mode-type load assignments to the specified load case are based.</param>
        /// <exception cref="CSiException"></exception>
        public void GetModalCase(string name,
            ref string modalCase)
        {
            _callCode = _sapModel.LoadCases.ResponseSpectrum.GetModalCase(name, ref modalCase);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function sets the modal case for the specified analysis case.
        /// If the specified modal case is not actually a modal case, the program automatically replaces it with the first modal case it can find. 
        /// If no modal load cases exist, an error is returned.
        /// TODO: Handle this.
        /// </summary>
        /// <param name="name">The name of an existing load case.</param>
        /// <param name="modalCase">This is either None or the name of an existing modal analysis case. 
        /// It specifies the modal load case on which any mode-type load assignments to the specified load case are based.</param>
        /// <exception cref="CSiException"></exception>
        public void SetModalCase(string name,
            string modalCase)
        {
            _callCode = _sapModel.LoadCases.ResponseSpectrum.SetModalCase(name, modalCase);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the modal combination option assigned to the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case.</param>
        /// <param name="modalCombination">The modal combination option.</param>
        /// <param name="gmcF1">The GMC f1 factor [cyc/s].
        /// This item does not apply when <paramref name="modalCombination"/> = <see cref="eModalCombination.ABS"/>.</param>
        /// <param name="gmcF2">The GMC f2 factor [cyc/s].
        /// This item does not apply when <paramref name="modalCombination"/> = <see cref="eModalCombination.ABS"/>.</param>
        /// <param name="periodicPlusRigidModalCombination">The periodic plus rigid modal combination option.</param>
        /// <param name="td">The factor td [s].
        /// This item applies only when <paramref name="modalCombination"/> = <see cref="eModalCombination.DoubleSum"/>.</param>
        /// <exception cref="CSiException"></exception>
        public void GetModalCombination(string name,
            ref eModalCombination modalCombination,
            ref double gmcF1,
            ref double gmcF2,
            ref ePeriodicPlusRigidModalCombination periodicPlusRigidModalCombination,
            ref double td)
        {
            int csiModalCombination = 0;
            int csiPeriodicPlusRigidModalCombination = 0;

            _callCode = _sapModel.LoadCases.ResponseSpectrum.GetModalComb_1(name, ref csiModalCombination, ref gmcF1, ref gmcF2, ref csiPeriodicPlusRigidModalCombination, ref td);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            modalCombination = (eModalCombination) csiModalCombination;
            periodicPlusRigidModalCombination = (ePeriodicPlusRigidModalCombination)csiPeriodicPlusRigidModalCombination;
        }

        /// <summary>
        /// This function retrieves the modal combination option assigned to the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case.</param>
        /// <param name="modalCombination">The modal combination option.</param>
        /// <param name="gmcF1">The GMC f1 factor [cyc/s].
        /// This item does not apply when <paramref name="modalCombination"/> = <see cref="eModalCombination.ABS"/>.</param>
        /// <param name="gmcF2">The GMC f2 factor [cyc/s].
        /// This item does not apply when <paramref name="modalCombination"/> = <see cref="eModalCombination.ABS"/>.</param>
        /// <param name="periodicPlusRigidModalCombination">The periodic plus rigid modal combination option.</param>
        /// <param name="td">The factor td [s].
        /// This item applies only when <paramref name="modalCombination"/> = <see cref="eModalCombination.DoubleSum"/>.</param>
        /// <exception cref="CSiException"></exception>
        public void SetModalCombination(string name,
            eModalCombination modalCombination,
            double gmcF1,
            double gmcF2,
            ePeriodicPlusRigidModalCombination periodicPlusRigidModalCombination,
            double td)
        {
            _callCode = _sapModel.LoadCases.ResponseSpectrum.SetModalComb_1(name, (int)modalCombination, gmcF1, gmcF2, (int)periodicPlusRigidModalCombination, td);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        /// <summary>
        /// This function retrieves the directional combination option assigned to the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case.</param>
        /// <param name="directionalCombination">The directional combination option.</param>
        /// <param name="scaleFactor">The abslute value scale factor.
        /// This item applies only when <paramref name="directionalCombination"/> = <see cref="eDirectionalCombination.ABS"/></param>
        /// <exception cref="CSiException"></exception>
        public void GetDirectionalCombination(string name,
            ref eDirectionalCombination directionalCombination,
            ref double scaleFactor)
        {
            int csiDirectionalCombination = 0;

            _callCode = _sapModel.LoadCases.ResponseSpectrum.GetDirComb(name, ref csiDirectionalCombination, ref scaleFactor);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            directionalCombination = (eDirectionalCombination)csiDirectionalCombination;
        }

        /// <summary>
        /// This function sets the directional combination option for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case.</param>
        /// <param name="directionalCombination">The directional combination option.</param>
        /// <param name="scaleFactor">The abslute value scale factor.
        /// This item applies only when <paramref name="directionalCombination"/> = <see cref="eDirectionalCombination.ABS"/></param>
        /// <exception cref="CSiException"></exception>
        public void SetDirectionalCombination(string name,
            eDirectionalCombination directionalCombination,
            double scaleFactor)
        {
            _callCode = _sapModel.LoadCases.ResponseSpectrum.SetDirComb(name, (int)directionalCombination, scaleFactor);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        /// <summary>
        /// This function retrieves the eccentricity ratio that applies to all diaphragms for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case.</param>
        /// <param name="eccentricity">The eccentricity ratio that applies to all diaphragms.</param>
        /// <exception cref="CSiException"></exception>
        public void GetEccentricity(string name,
            ref double eccentricity)
        {
            _callCode = _sapModel.LoadCases.ResponseSpectrum.GetEccentricity(name,
                ref eccentricity);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function sets the eccentricity ratio that applies to all diaphragms for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case.</param>
        /// <param name="eccentricity">The eccentricity ratio that applies to all diaphragms.</param>
        /// <exception cref="CSiException"></exception>
        public void SetEccentricity(string name,
            double eccentricity)
        {
            _callCode = _sapModel.LoadCases.ResponseSpectrum.SetEccentricity(name,
                eccentricity);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the diaphragm eccentricity overrides for a load case.
        /// </summary>
        /// <param name="name">The name of an existing load case.</param>
        /// <param name="numberOfItems">The number of diaphragm eccentricity overrides for the specified load case.</param>
        /// <param name="diaphragms">The names of the diaphragms that have eccentricity overrides.</param>
        /// <param name="eccentricities">The eccentricity applied to each diaphragm. [L].</param>
        /// <exception cref="CSiException"></exception>
        public void GetDiaphragmEccentricityOverride(string name,
            ref int numberOfItems,
            ref string[] diaphragms,
            ref double[] eccentricities)
        {
            _callCode = _sapModel.LoadCases.ResponseSpectrum.GetDiaphragmEccentricityOverride(name,
                ref numberOfItems, ref diaphragms, ref eccentricities);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        /// <summary>
        /// This function sets the eccentricity ratio that applies to all diaphragms for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case.</param>
        /// <param name="diaphragm">The name of an existing special rigid diaphragm constraint, that is, a diaphragm constraint with the following features:
        /// 1. The constraint type is <see cref="eConstraintType.Diaphragm"/>; 
        /// 2. The constraint coordinate system is <see cref="CoordinateSystems.Global"/>; 
        /// 3. The constraint axis is Z;</param>
        /// <param name="eccentricities">The eccentricity applied to each diaphragm. [L].</param>
        /// <param name="delete">True: The eccentricity override for the specified diaphragm is deleted.</param>
        /// <exception cref="CSiException"></exception>
        public void SetDiaphragmEccentricityOverride(string name,
            string diaphragm,
            double eccentricities,
            bool delete = false)
        {
            _callCode = _sapModel.LoadCases.ResponseSpectrum.SetDiaphragmEccentricityOverride(name, diaphragm, eccentricities, delete);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion

        #region Damping

        /// <summary>
        /// This function retrieves the hysteretic damping type for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case.</param>
        /// <param name="dampingType">The modal damping type for the load case.</param>
        /// <exception cref="CSiException"></exception>
        public void GetDampingType(string name,
            ref eDampingType dampingType)
        {
            int csiDampingType = 0;

            _callCode = _sapModel.LoadCases.ResponseSpectrum.GetDampType(name, ref csiDampingType);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            dampingType = (eDampingType)csiDampingType;
        }




        /// <summary>
        /// This function retrieves the constant modal damping for all modes assigned to the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case that has constant damping.</param>
        /// <param name="damping">The constant damping for all modes (0 &lt;= <paramref name="damping"/> &lt; 1).</param>
        /// <exception cref="CSiException"></exception>
        public void GetDampingConstant(string name,
            ref double damping)
        {
            _callCode = _sapModel.LoadCases.ResponseSpectrum.GetDampConstant(name, ref damping);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function sets constant modal damping for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case that has constant damping.</param>
        /// <param name="damping">The constant damping for all modes (0 &lt;= <paramref name="damping"/> &lt; 1).</param>
        /// <exception cref="CSiException"></exception>
        public void SetDampingConstant(string name,
            double damping)
        {
            _callCode = _sapModel.LoadCases.ResponseSpectrum.SetDampConstant(name, damping);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the interpolated modal damping data assigned to the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case that has interpolated damping.</param>
        /// <param name="dampingType">The interpolated modal damping type.</param>
        /// <param name="numberOfItems">The number of <paramref name="periodsOrFrequencies"/> and <paramref name="damping"/> pairs.</param>
        /// <param name="periodsOrFrequencies">The periods or frequencies, depending on the value of <paramref name="dampingType"/>.
        /// [s] for <paramref name="dampingType"/> = <see cref="eDampingTypeInterpolated.InterpolatedByPeriod"/> and [cyc/s] for <paramref name="dampingType"/> = <see cref="eDampingTypeInterpolated.InterpolatedByFrequency"/>.</param>
        /// <param name="damping">The damping for the specified period of frequency (0 &lt;= <paramref name="damping"/> &lt; 1).</param>
        /// <exception cref="CSiException"></exception>
        public void GetDampingInterpolated(string name,
            ref eDampingTypeInterpolated dampingType,
            ref int numberOfItems,
            ref double[] periodsOrFrequencies,
            ref double[] damping)
        {
            int csiDampingType = 0;

            _callCode = _sapModel.LoadCases.ResponseSpectrum.GetDampInterpolated(name, ref csiDampingType, ref numberOfItems, ref periodsOrFrequencies, ref damping);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            dampingType = (eDampingTypeInterpolated)csiDampingType;
        }

        /// <summary>
        /// This function retrieves the interpolated modal damping data assigned to the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case that has interpolated damping.</param>
        /// <param name="dampingType">The interpolated modal damping type.</param>
        /// <param name="numberOfItems">The number of <paramref name="periodsOrFrequencies"/> and <paramref name="damping"/> pairs.</param>
        /// <param name="periodsOrFrequencies">The periods or frequencies, depending on the value of <paramref name="dampingType"/>.
        /// [s] for <paramref name="dampingType"/> = <see cref="eDampingTypeInterpolated.InterpolatedByPeriod"/> and [cyc/s] for <paramref name="dampingType"/> = <see cref="eDampingTypeInterpolated.InterpolatedByFrequency"/>.</param>
        /// <param name="damping">The damping for the specified period of frequency (0 &lt;= <paramref name="damping"/> &lt; 1).</param>
        /// <exception cref="CSiException"></exception>
        public void SetDampingInterpolated(string name,
            eDampingTypeInterpolated dampingType,
            int numberOfItems,
            double[] periodsOrFrequencies,
            double[] damping)
        {
            _callCode = _sapModel.LoadCases.ResponseSpectrum.SetDampInterpolated(name, (int)dampingType, numberOfItems, ref periodsOrFrequencies, ref damping);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        /// <summary>
        /// This function retrieves the proportional modal damping data assigned to the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing linear modal history analysis case that has proportional damping.</param>
        /// <param name="dampingType">The proportional modal damping type.</param>
        /// <param name="massProportionalDampingCoefficient">The mass proportional damping coefficient.</param>
        /// <param name="stiffnessProportionalDampingCoefficient">The stiffness proportional damping coefficient.</param>
        /// <param name="periodOrFrequencyPt1">The period or frequency for point 1, depending on the value of <paramref name="dampingType"/>.
        /// [s] for <paramref name="dampingType"/> = <see cref="eDampingTypeProportional.ProportionalByPeriod"/> and [cyc/s] for <paramref name="dampingType"/> = <see cref="eDampingTypeProportional.ProportionalByFrequency"/>.
        /// This item applies only when <paramref name="dampingType"/> = <see cref="eDampingTypeProportional.ProportionalByPeriod"/> or <see cref="eDampingTypeProportional.ProportionalByFrequency"/>.</param>
        /// <param name="periodOrFrequencyPt2">The period or frequency for point 2, depending on the value of <paramref name="dampingType"/>.
        /// [s] for <paramref name="dampingType"/> = <see cref="eDampingTypeProportional.ProportionalByPeriod"/> and [cyc/s] for <paramref name="dampingType"/> = <see cref="eDampingTypeProportional.ProportionalByFrequency"/>.
        /// This item applies only when <paramref name="dampingType"/> = <see cref="eDampingTypeProportional.ProportionalByPeriod"/> or <see cref="eDampingTypeProportional.ProportionalByFrequency"/>.</param>
        /// <param name="dampingPt1">The damping for point 1 (0 &lt;= <paramref name="dampingPt1"/> &lt; 1).
        /// This item applies only when <paramref name="dampingType"/> = <see cref="eDampingTypeProportional.ProportionalByPeriod"/> or <see cref="eDampingTypeProportional.ProportionalByFrequency"/>.</param>
        /// <param name="dampingPt2">The damping for point 2 (0 &lt;= <paramref name="dampingPt1"/> &lt; 1).
        /// This item applies only when <paramref name="dampingType"/> = <see cref="eDampingTypeProportional.ProportionalByPeriod"/> or <see cref="eDampingTypeProportional.ProportionalByFrequency"/>.</param>
        /// <exception cref="CSiException"></exception>
        public void GetDampingProportional(string name,
            ref eDampingTypeProportional dampingType,
            ref double massProportionalDampingCoefficient,
            ref double stiffnessProportionalDampingCoefficient,
            ref double periodOrFrequencyPt1,
            ref double periodOrFrequencyPt2,
            ref double dampingPt1,
            ref double dampingPt2)
        {
            int csiDampingType = 0;

            _callCode = _sapModel.LoadCases.ResponseSpectrum.GetDampProportional(name, ref csiDampingType, ref massProportionalDampingCoefficient, ref stiffnessProportionalDampingCoefficient,
                ref periodOrFrequencyPt1, ref periodOrFrequencyPt2, ref dampingPt1, ref dampingPt2);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            dampingType = (eDampingTypeProportional)csiDampingType;
        }

        /// <summary>
        /// This function sets proportional modal damping data for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing linear modal history analysis case that has proportional damping.</param>
        /// <param name="dampingType">The proportional modal damping type.</param>
        /// <param name="massProportionalDampingCoefficient">The mass proportional damping coefficient.</param>
        /// <param name="stiffnessProportionalDampingCoefficient">The stiffness proportional damping coefficient.</param>
        /// <param name="periodOrFrequencyPt1">The period or frequency for point 1, depending on the value of <paramref name="dampingType"/>.
        /// [s] for <paramref name="dampingType"/> = <see cref="eDampingTypeProportional.ProportionalByPeriod"/> and [cyc/s] for <paramref name="dampingType"/> = <see cref="eDampingTypeProportional.ProportionalByFrequency"/>.
        /// This item applies only when <paramref name="dampingType"/> = <see cref="eDampingTypeProportional.ProportionalByPeriod"/> or <see cref="eDampingTypeProportional.ProportionalByFrequency"/>.</param>
        /// <param name="periodOrFrequencyPt2">The period or frequency for point 2, depending on the value of <paramref name="dampingType"/>.
        /// [s] for <paramref name="dampingType"/> = <see cref="eDampingTypeProportional.ProportionalByPeriod"/> and [cyc/s] for <paramref name="dampingType"/> = <see cref="eDampingTypeProportional.ProportionalByFrequency"/>.
        /// This item applies only when <paramref name="dampingType"/> = <see cref="eDampingTypeProportional.ProportionalByPeriod"/> or <see cref="eDampingTypeProportional.ProportionalByFrequency"/>.</param>
        /// <param name="dampingPt1">The damping for point 1 (0 &lt;= <paramref name="dampingPt1"/> &lt; 1).
        /// This item applies only when <paramref name="dampingType"/> = <see cref="eDampingTypeProportional.ProportionalByPeriod"/> or <see cref="eDampingTypeProportional.ProportionalByFrequency"/>.</param>
        /// <param name="dampingPt2">The damping for point 2 (0 &lt;= <paramref name="dampingPt1"/> &lt; 1).
        /// This item applies only when <paramref name="dampingType"/> = <see cref="eDampingTypeProportional.ProportionalByPeriod"/> or <see cref="eDampingTypeProportional.ProportionalByFrequency"/>.</param>
        /// <exception cref="CSiException"></exception>
        public void SetDampingProportional(string name,
            eDampingTypeProportional dampingType,
            double massProportionalDampingCoefficient,
            double stiffnessProportionalDampingCoefficient,
            double periodOrFrequencyPt1,
            double periodOrFrequencyPt2,
            double dampingPt1,
            double dampingPt2)
        {
            _callCode = _sapModel.LoadCases.ResponseSpectrum.SetDampProportional(name, (int)dampingType, massProportionalDampingCoefficient, stiffnessProportionalDampingCoefficient,
                periodOrFrequencyPt1, periodOrFrequencyPt2, dampingPt1, dampingPt2);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        /// <summary>
        /// This function retrieves the modal damping overrides assigned to the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing analysis case.</param>
        /// <param name="numberOfItems">The number of <paramref name="modes"/> and <paramref name="damping"/> pairs.</param>
        /// <param name="modes">The modes.</param>
        /// <param name="damping">The damping for the specified mode (0 &lt;= <paramref name="damping"/> &lt; 1).</param>
        /// <exception cref="CSiException"></exception>
        public void GetDampingOverrides(string name,
            ref int numberOfItems,
            ref int[] modes,
            ref double[] damping)
        {
            _callCode = _sapModel.LoadCases.ResponseSpectrum.GetDampOverrides(name, ref numberOfItems, ref modes, ref damping);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        /// <summary>
        /// This function retrieves the modal damping overrides assigned to the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing analysis case.</param>
        /// <param name="numberOfItems">The number of <paramref name="modes"/> and <paramref name="damping"/> pairs.</param>
        /// <param name="modes">The modes.</param>
        /// <param name="damping">The damping for the specified mode (0 &lt;= <paramref name="damping"/> &lt; 1).</param>
        /// <exception cref="CSiException"></exception>
        public void SetDampingOverrides(string name,
            int numberOfItems,
            int[] modes,
            double[] damping)
        {
            _callCode = _sapModel.LoadCases.ResponseSpectrum.SetDampOverrides(name, numberOfItems, ref modes, ref damping);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
