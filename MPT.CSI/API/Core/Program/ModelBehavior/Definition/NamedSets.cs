using MPT.CSI.API.Core.Support;

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
#elif BUILD_ETABS2014
using ETABS2014;
#elif BUILD_ETABS2015
using ETABS2015;
#elif BUILD_ETABS2016
using ETABS2016;
#endif

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Represents the joint response spectrum set in the application.
    /// </summary>
    public class NamedSets : CSiApiBase
    {

        #region Initialization

        public NamedSets(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Public

        /// <summary>
        /// This function gets a joint response spectrum named set definition. 
        /// </summary>
        /// <param name="nameSet">The name of an existing joint response spectrum named set.</param>
        /// <param name="loadCase">The name of a time history load case for which results will be extracted.</param>
        /// <param name="numberJoints">The number of joints for which to generate response spectra.</param>
        /// <param name="nameJoints">This is an array of joint names for which to generate response spectra.</param>
        /// <param name="coordinateSystem">The name of a coordinate system in which the direction for results is defined. 
        /// This can be Global, Local, or any other user-defined coordinate system.</param>
        /// <param name="direction">This specifies the direction, in the specified coordinate system, in which the results are to be retrieved. 
        /// Valid values for the direction are:
        /// 1 = Local 1, Global X, or user-defined coordinate system X
        /// 2 = Local 2, Global Y, or user-defined coordinate system Y
        /// 3 = Local 3, Global Z, or user-defined coordinate system Z</param>
        /// <param name="abscissa">Specifies the abscissa data type.</param>
        /// <param name="ordinate">Specifies the ordinate data type.</param>
        /// <param name="useDefaultFrequencies">True: Default frequencies are used for output.</param>
        /// <param name="useStructuralFrequencies">True: Structural frequencies are used for output.</param>
        /// <param name="numberUserFrequencies">The number of user-defined frequencies, which may be 0.</param>
        /// <param name="userFrequencies">User-defined frequencies.</param>
        /// <param name="numberDampingValues">The number of critical damping ratio values.</param>
        /// <param name="dampingValues">Critical damping ratio values.</param>
        /// <param name="abscissaPlotType">Abscissa axis scale type.</param>
        /// <param name="spectrumWidening">This specifies the percentage by which to widen the peaks of the spectrum.</param>
        /// <param name="ordinatePlotType">Ordinate axis scale type.</param>
        /// <param name="ordinateScaleFactor">This is the scale factor used to linearly scale the response spectrum ordinate values.</param>
        public void GetJointRespSpec(string nameSet,
            ref string loadCase,
            ref int numberJoints,
            ref string[] nameJoints,
            ref string coordinateSystem,
            ref int direction,
            ref eVibrationUnit abscissa,
            ref eSpectralResponse ordinate,
            ref bool useDefaultFrequencies,
            ref bool useStructuralFrequencies,
            ref int numberUserFrequencies,
            ref double[] userFrequencies,
            ref int numberDampingValues,
            ref double[] dampingValues,
            ref ePlotType abscissaPlotType,
            ref double spectrumWidening,
            ref ePlotType ordinatePlotType,
            ref double ordinateScaleFactor)
        {
            int csiAbscissa = 0;
            int csiOrdinate = 0;
            int csiAbscissaType = 0;
            int csiOrdinateType = 0;

            _callCode = _sapModel.NamedSet.GetJointRespSpec(nameSet, ref loadCase, ref numberJoints, ref nameJoints, ref coordinateSystem, ref direction, ref csiAbscissa, ref csiOrdinate, ref useDefaultFrequencies, ref useStructuralFrequencies, ref numberUserFrequencies, ref userFrequencies, ref numberDampingValues, ref dampingValues, ref csiAbscissaType, ref spectrumWidening, ref csiOrdinateType, ref ordinateScaleFactor);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            abscissa = (eVibrationUnit) csiAbscissa;
            ordinate = (eSpectralResponse)csiOrdinate;
            abscissaPlotType = (ePlotType)csiAbscissaType;
            ordinatePlotType = (ePlotType)csiOrdinateType;
        }

        /// <summary>
        /// This function defines a joint response spectrum named set.
        /// </summary>
        /// <param name="nameSet">The name of an existing joint response spectrum named set.</param>
        /// <param name="loadCase">The name of a time history load case for which results will be extracted.</param>
        /// <param name="numberJoints">The number of joints for which to generate response spectra.</param>
        /// <param name="nameJoints">This is an array of joint names for which to generate response spectra.</param>
        /// <param name="coordinateSystem">The name of a coordinate system in which the direction for results is defined. 
        /// This can be Global, Local, or any other user-defined coordinate system.</param>
        /// <param name="direction">This specifies the direction, in the specified coordinate system, in which the results are to be retrieved. 
        /// Valid values for the direction are:
        /// 1 = Local 1, Global X, or user-defined coordinate system X
        /// 2 = Local 2, Global Y, or user-defined coordinate system Y
        /// 3 = Local 3, Global Z, or user-defined coordinate system Z</param>
        /// <param name="abscissa">Specifies the abscissa data type.</param>
        /// <param name="ordinate">Specifies the ordinate data type.</param>
        /// <param name="useDefaultFrequencies">True: Default frequencies are used for output.</param>
        /// <param name="useStructuralFrequencies">True: Structural frequencies are used for output.</param>
        /// <param name="numberUserFrequencies">The number of user-defined frequencies, which may be 0.</param>
        /// <param name="userFrequencies">User-defined frequencies.</param>
        /// <param name="numberDampingValues">The number of critical damping ratio values.</param>
        /// <param name="dampingValues">Critical damping ratio values.</param>
        /// <param name="abscissaPlotType">Abscissa axis scale type.</param>
        /// <param name="spectrumWidening">This specifies the percentage by which to widen the peaks of the spectrum.</param>
        /// <param name="ordinatePlotType">Ordinate axis scale type.</param>
        /// <param name="ordinateScaleFactor">This is the scale factor used to linearly scale the response spectrum ordinate values.</param>
        public void SetJointRespSpec(string nameSet,
            string loadCase,
            int numberJoints,
            ref string[] nameJoints,
            string coordinateSystem,
            int direction,
            eVibrationUnit abscissa,
            eSpectralResponse ordinate,
            bool useDefaultFrequencies,
            bool useStructuralFrequencies,
            int numberUserFrequencies,
            ref double[] userFrequencies,
            int numberDampingValues,
            ref double[] dampingValues,
            ePlotType abscissaPlotType,
            double spectrumWidening,
            ePlotType ordinatePlotType,
            double ordinateScaleFactor)
        {
            int csiAbscissa = (int)abscissa;
            int csiOrdinate = (int)ordinate;
            int csiAbscissaType = (int)abscissaPlotType;
            int csiOrdinateType = (int)ordinatePlotType;

            _callCode = _sapModel.NamedSet.SetJointRespSpec(nameSet, loadCase, numberJoints, ref nameJoints, coordinateSystem, direction, csiAbscissa, csiOrdinate, useDefaultFrequencies, useStructuralFrequencies, numberUserFrequencies, ref userFrequencies, numberDampingValues, ref dampingValues, csiAbscissaType, spectrumWidening, csiOrdinateType, ordinateScaleFactor);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
