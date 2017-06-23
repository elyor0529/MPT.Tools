using MPT.CSI.API.Core.Support;

#if BUILD_SAP2000v16
using CSiProgram = SAP2000v16;
#elif BUILD_SAP2000v17
using CSiProgram = SAP2000v17;
#elif BUILD_SAP2000v18
using CSiProgram = SAP2000v18;
#elif BUILD_SAP2000v19
using CSiProgram = SAP2000v19;
#elif BUILD_ETABS2013
using CSiProgram = ETABS2013;
#elif BUILD_ETABS2014
using CSiProgram = ETABS2014;
#elif BUILD_ETABS2015
using CSiProgram = ETABS2015;
#elif BUILD_ETABS2016
using CSiProgram = ETABS2016;
#endif


namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Represents the load cases in the application.
    /// </summary>
    public class LoadCases : CSiApiBase, IChangeableName, ICountable, IDeletable, IListableNames
    {

        #region Fields


        #endregion


        #region Properties



        #endregion


        #region Initialization

        public LoadCases(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Public

        /// <summary>
        /// This function changes the name of an existing load case.
        /// </summary>
        /// <param name="loadCaseName">The existing name of a defined load case</param>
        /// <param name="newName">The new name for the load case.</param>
        public void ChangeName(string loadCaseName,
            string newName)
        {
            _callCode = _sapModel.LoadCases.ChangeName(loadCaseName, newName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function returns the total number of defined load cases in the model.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.LoadCases.Count();
        }

        /// <summary>
        /// This function returns the total number of defined load cases in the model of a specified load case type.
        /// </summary>
        /// <param name="caseType">Load case type for which a count is desired.
        /// If 'all' is selected, a count is returned for all load cases in the model regardless of type.</param>
        /// <returns></returns>
        public int Count(eLoadCaseType caseType)
        {
            return _sapModel.LoadCases.Count(CSiEnumConverter.ToCSi(caseType));
        }

        /// <summary>
        /// The name of an existing load case.
        /// </summary>
        /// <param name="loadCaseName">The name of an existing load case.</param>
        public void Delete(string loadCaseName)
        {
            _callCode = _sapModel.LoadCases.Delete(loadCaseName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of all defined load cases.
        /// </summary>
        /// <param name="numberNames">The number of load case names retrieved by the program.</param>
        /// <param name="namesOfLoadCaseType">Names of all load cases of the specified type.</param>
        public void GetNameList(ref int numberNames,
            ref string[] namesOfLoadCaseType)
        {
            _callCode = _sapModel.LoadCases.GetNameList(ref numberNames, ref namesOfLoadCaseType);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of all defined load cases of the specified type.
        /// </summary>
        /// <param name="numberNames">The number of load case names retrieved by the program.</param>
        /// <param name="namesOfLoadCaseType">Names of all load cases of the specified type.</param>
        /// <param name="caseType">Load case type for which names are desired.</param>
        public void GetNameList(ref int numberNames,
            ref string[] namesOfLoadCaseType,
            eLoadCaseType caseType)
        {
            _callCode = _sapModel.LoadCases.GetNameList(ref numberNames, ref namesOfLoadCaseType, CSiEnumConverter.ToCSi(caseType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the case type, design type, and auto flag for the specified load case.
        /// </summary>
        /// <param name="nameLoadCase">The name of an existing load case.</param>
        /// <param name="loadCaseType">Load case type corresponding to the name provided.</param>
        /// <param name="loadCaseSubType">Load case sub-type corresponding to the name provided.</param>
        /// <param name="designType">Load case design type corresponding to the name provided.</param>
        /// <param name="designTypeOption">Load case type corresponding to the name provided.</param>
        /// <param name="autoCreatedCase">This is one of the following values indicating if the load case has been automatically created.</param>
        public void GetType_1(string nameLoadCase,
            ref eLoadCaseType loadCaseType,
            ref int loadCaseSubType,
            ref eLoadPatternType designType,
            ref eSpecificationSource designTypeOption,
            ref eAutoCreatedCase autoCreatedCase)
        {
            CSiProgram.eLoadCaseType csiCaseType = CSiProgram.eLoadCaseType.Modal;
            CSiProgram.eLoadPatternType csiPatternType = CSiProgram.eLoadPatternType.Dead;

            int csiDesignTypeOption = 0;
            int csiAutoCreatedCase = 0;

            _callCode = _sapModel.LoadCases.GetTypeOAPI_1(nameLoadCase, ref csiCaseType, ref loadCaseSubType, ref csiPatternType, ref csiDesignTypeOption, ref csiAutoCreatedCase);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            loadCaseType = CSiEnumConverter.FromCSi(csiCaseType);
            designType = CSiEnumConverter.FromCSi(csiPatternType);
            designTypeOption = (eSpecificationSource)csiDesignTypeOption;
            autoCreatedCase = (eAutoCreatedCase)csiAutoCreatedCase;
        }

        /// <summary>
        /// This function sets the design type for the specified load case.
        /// </summary>
        /// <param name="nameLoadCase">The name of an existing load case.</param>
        /// <param name="designTypeOption">This is one of the following options for the DesignType item.</param>
        /// <param name="designType">This item only applies when the DesignTypeOption is 1 (user specified). It is one of the following items in the eLoadPatternType enumeration.</param>
        public void SetDesignType(string nameLoadCase,
            eSpecificationSource designTypeOption,
            eLoadPatternType designType = eLoadPatternType.Dead)
        {
            int csiDesignTypeOption = (int)designTypeOption;

            _callCode = _sapModel.LoadCases.SetDesignType(nameLoadCase, csiDesignTypeOption, CSiEnumConverter.ToCSi(designType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
