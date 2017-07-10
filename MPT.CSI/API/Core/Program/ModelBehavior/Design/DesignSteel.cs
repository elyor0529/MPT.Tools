using MPT.CSI.API.Core.Program.ModelBehavior.Design.CodesDesign.Steel;
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

namespace MPT.CSI.API.Core.Program.ModelBehavior.Design
{
    /// <summary>
    /// Represents Steel design in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Design.IDesignMetal" />
    public class DesignSteel : CSiApiBase, IDesignMetal
    {
        #region Fields
        private readonly CSiApiSeed _seed;

        private AISC_360_05_IBC_2006 _AISC_360_05_IBC_2006;
        private AISC_360_10 _AISC_360_10;
        private AISC_LRFD_93 _AISC_LRFD_93;
        private API_RP2A_LRFD_97 _API_RP2A_LRFD_97;
        private API_RP2A_WSD_2000 _API_RP2A_WSD_2000;
        private API_RP2A_WSD_2014 _API_RP2A_WSD_2014;
        private AS_4100_1998 _AS_4100_1998;
        private ASCE_10_97 _ASCE_10_97;
        private BS_5950_2000 _BS_5950_2000;
        private Chinese_2010 _Chinese_2010;
        private CSA_S16_09 _CSA_S16_09;
        private Eurocode_3_2005 _Eurocode_3_2005;
        private Indian_IS_800_2007 _Indian_IS_800_2007;
        private Norsok_N_004 _Norsok_N_004;
        private Norsok_N_004_2013 _Norsok_N_004_2013;
        private NSZ_3404_1997 _NSZ_3404_1997;
        #endregion

        #region Properties        
        /// <summary>
        /// Gets the AISC 360 05 IBC 2006 design code.
        /// </summary>
        /// <value>The AISC 360 05 IBC 2006 design code.</value>
        public AISC_360_05_IBC_2006 AISC_360_05_IBC_2006 => _AISC_360_05_IBC_2006 ?? (_AISC_360_05_IBC_2006 = new AISC_360_05_IBC_2006(_seed));

        /// <summary>
        /// Gets the AISC 360 10 design code.
        /// </summary>
        /// <value>The AISC 360 10 design code.</value>
        public AISC_360_10 AISC_360_10 => AISC_360_10 ?? (_AISC_360_10 = new AISC_360_10(_seed));

        /// <summary>
        /// Gets the AISC LRFD 93 design code.
        /// </summary>
        /// <value>The AISC LRFD 93 design code.</value>
        public AISC_LRFD_93 AISC_LRFD_93 => _AISC_LRFD_93 ?? (_AISC_LRFD_93 = new AISC_LRFD_93(_seed));

        /// <summary>
        /// Gets the API RP2A LRFD 97 design code.
        /// </summary>
        /// <value>The API RP2A LRFD 97 design code.</value>
        public API_RP2A_LRFD_97 API_RP2A_LRFD_97 => _API_RP2A_LRFD_97 ?? (_API_RP2A_LRFD_97 = new API_RP2A_LRFD_97(_seed));

        /// <summary>
        /// Gets the API RP2A WSD 2000 design code.
        /// </summary>
        /// <value>The API RP2A WSD 2000 design code.</value>
        public API_RP2A_WSD_2000 API_RP2A_WSD_2000 => _API_RP2A_WSD_2000 ?? (_API_RP2A_WSD_2000 = new API_RP2A_WSD_2000(_seed));

        /// <summary>
        /// Gets the API RP2A WSD 2014 design code.
        /// </summary>
        /// <value>The API RP2A WSD 2014 design code.</value>
        public API_RP2A_WSD_2014 API_RP2A_WSD_2014 => _API_RP2A_WSD_2014 ?? (_API_RP2A_WSD_2014 = new API_RP2A_WSD_2014(_seed));

        /// <summary>
        /// Gets the AS 4100 1998 design code.
        /// </summary>
        /// <value>The As 4100 1998 design code.</value>
        public AS_4100_1998 AS_4100_1998 => _AS_4100_1998 ?? (_AS_4100_1998 = new AS_4100_1998(_seed));

        /// <summary>
        /// Gets the ASCE 10 97 design code.
        /// </summary>
        /// <value>The ASCE 10 97 design code.</value>
        public ASCE_10_97 ASCE_10_97 => _ASCE_10_97 ?? (_ASCE_10_97 = new ASCE_10_97(_seed));

        /// <summary>
        /// Gets the BS 5950 2000 design code.
        /// </summary>
        /// <value>The BS 5950 2000 design code.</value>
        public BS_5950_2000 BS_5950_2000 => _BS_5950_2000 ?? (_BS_5950_2000 = new BS_5950_2000(_seed));

        /// <summary>
        /// Gets the Chinese 2010 design code.
        /// </summary>
        /// <value>The Cchinese 2010 design code.</value>
        public Chinese_2010 Chinese_2010 => _Chinese_2010 ?? (_Chinese_2010 = new Chinese_2010(_seed));

        /// <summary>
        /// Gets the CSA S16 09 design code.
        /// </summary>
        /// <value>The CSA S16 09 design code.</value>
        public CSA_S16_09 CSA_S16_09 => _CSA_S16_09 ?? (_CSA_S16_09 = new CSA_S16_09(_seed));

        /// <summary>
        /// Gets the Eurocode 3 2005 design code.
        /// </summary>
        /// <value>The Eurocode 3 2005 design code.</value>
        public Eurocode_3_2005 Eurocode_3_2005 => _Eurocode_3_2005 ?? (_Eurocode_3_2005 = new Eurocode_3_2005(_seed));

        /// <summary>
        /// Gets the Indian IS 800 2007 design code.
        /// </summary>
        /// <value>The Indian IS 800 2007 design code.</value>
        public Indian_IS_800_2007 Indian_IS_800_2007 => _Indian_IS_800_2007 ?? (_Indian_IS_800_2007 = new Indian_IS_800_2007(_seed));

        /// <summary>
        /// Gets the NORSOK N 004 design code.
        /// </summary>
        /// <value>The NORSOK N 004 design code.</value>
        public Norsok_N_004 Norsok_N_004 => _Norsok_N_004 ?? (_Norsok_N_004 = new Norsok_N_004(_seed));

        /// <summary>
        /// Gets the NORSOK N 004 2013 design code.
        /// </summary>
        /// <value>The NORSOK N 004 2013 design code.</value>
        public Norsok_N_004_2013 Norsok_N_004_2013 => _Norsok_N_004_2013 ?? (_Norsok_N_004_2013 = new Norsok_N_004_2013(_seed));

        /// <summary>
        /// Gets the NSZ 3404 1997 design code.
        /// </summary>
        /// <value>The NSZ 3404 1997 design code.</value>
        public NSZ_3404_1997 NSZ_3404_1997 => _NSZ_3404_1997 ?? (_NSZ_3404_1997 = new NSZ_3404_1997(_seed));
        #endregion


        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="DesignSteel"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public DesignSteel(CSiApiSeed seed) : base(seed)
        {
            _seed = seed;
        }

        #endregion

        #region Methods: Interface

        /// <summary>
        /// Deletes all frame design results.
        /// </summary>
        public void DeleteResults()
        {
            _callCode = _sapModel.DesignSteel.DeleteResults();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Resets all frame design overwrites to default values.
        /// </summary>
        public void ResetOverwrites()
        {
            _callCode = _sapModel.DesignSteel.ResetOverwrites();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Starts the frame design.
        /// </summary>
        public void StartDesign()
        {
            _callCode = _sapModel.DesignSteel.StartDesign();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of the frame objects that did not pass the design check or have not yet been checked, if any.
        /// </summary>
        /// <param name="numberNotPassedOrChecked">The number of concrete frame objects that did not pass the design check or have not yet been checked.</param>
        /// <param name="numberDidNotPass">The number of concrete frame objects that did not pass the design check.</param>
        /// <param name="numberNotChecked">The number of concrete frame objects that have not yet been checked.</param>
        /// <param name="namesNotPassedOrChecked">This is an array that includes the name of each frame object that did not pass the design check or has not yet been checked.</param>
        public void VerifyPassed(ref int numberNotPassedOrChecked, 
            ref int numberDidNotPass, 
            ref int numberNotChecked, 
            ref string[] namesNotPassedOrChecked)
        {
            _callCode = _sapModel.DesignSteel.VerifyPassed(ref numberNotPassedOrChecked, ref numberDidNotPass, ref numberNotChecked, ref namesNotPassedOrChecked);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of the frame objects that have different analysis and design sections, if any.
        /// </summary>
        /// <param name="numberDifferentSections">The number of frame objects that have different analysis and design sections.</param>
        /// <param name="namesDifferentSections">This is an array that includes the name of each frame object that has different analysis and design sections.</param>
        public void VerifySections(ref int numberDifferentSections, 
            ref string[] namesDifferentSections)
        {
            _callCode = _sapModel.DesignSteel.VerifySections(ref numberDifferentSections, ref namesDifferentSections);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        // === Get/Set ===
        /// <summary>
        /// Retrieves the design section for a specified frame object.
        /// </summary>
        /// <param name="nameFrame">Name of a frame object with a frame design procedure.</param>
        /// <param name="nameSection">The name of the design section for the specified frame object.</param>
        public void GetDesignSection(string nameFrame, 
            ref string nameSection)
        {
            _callCode = _sapModel.DesignSteel.GetDesignSection(nameFrame, ref nameSection);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Modifies the design section for all specified frame objects that have a frame design procedure.
        /// </summary>
        /// <param name="itemName">Name of an existing frame object or group, depending on the value of the ItemType item.</param>
        /// <param name="nameSection">Name of an existing frame section property to be used as the design section for the specified frame objects. 
        /// This item applies only when resetToLastAnalysisSection = False.</param>
        /// <param name="resetToLastAnalysisSection">True: The design section for the specified frame objects is reset to the last analysis section for the frame object. 
        /// False: The design section is set to that specified by nameFrame.</param>
        /// <param name="itemType">Selection type to use for applying the method.</param>
        public void SetDesignSection(string itemName, 
            string nameSection, 
            bool resetToLastAnalysisSection, 
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.DesignSteel.SetDesignSection(itemName, nameSection, resetToLastAnalysisSection, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        // === Get ===
        /// <summary>
        /// Retrieves summary results for frame design.
        /// </summary>
        /// <param name="name">The name of an existing frame object or group, depending on the value of the ItemType item.</param>
        /// <param name="numberResults">The number of frame objects for which results are obtained.</param>
        /// <param name="frameNames">This is an array that includes each frame object name for which results are obtained.</param>
        /// <param name="ratios">This is an array that includes the controlling stress or capacity ratio for each frame object.</param>
        /// <param name="ratioTypes">This is an array that includes the controlling stress or capacity ratio for each frame object.</param>
        /// <param name="locations">This is an array that includes the distance from the I-end of the frame object to the location where the controlling stress or capacity ratio occurs. [L]</param>
        /// <param name="comboNames">This is an array that includes the name of the design combination for which the controlling stress or capacity ratio occurs.</param>
        /// <param name="errorSummaries">This is an array that includes the design error messages for the frame object, if any.</param>
        /// <param name="warningSummaries">This is an array that includes the design warning messages for the frame object, if any.</param>
        /// <param name="itemType">This is one of the following items in the eItemType enumeration: Object = 0, Group = 1, SelectedObjects = 2
        /// If this item is Object, the design results are retrieved for the frame object specified by the Name item.
        /// If this item is Group, the design results are retrieved for all frame objects in the group specified by the Name item.
        /// If this item is SelectedObjects, the design results are retrieved for all selected frame objects, and the Name item is ignored.</param>
        public void GetSummaryResults(string name, 
            ref int numberResults, 
            ref string[] frameNames, 
            ref double[] ratios, 
            ref int[] ratioTypes, 
            ref double[] locations, 
            ref string[] comboNames, 
            ref string[] errorSummaries, 
            ref string[] warningSummaries, 
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.DesignSteel.GetSummaryResults(name, ref numberResults, ref frameNames, ref ratios, ref ratioTypes, ref locations, ref comboNames, ref errorSummaries, ref warningSummaries, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // === Set
        /// <summary>
        /// Removes the auto select section assignments from all specified frame objects that have a steel frame design procedure.
        /// </summary>
        /// <param name="itemName">Name of an existing frame object or group, depending on the value of the ItemType item.</param>
        /// <param name="itemType">Selection type to use for applying the method.</param>
        public void SetAutoSelectNull(string itemName, 
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.DesignSteel.SetAutoSelectNull(itemName, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Selects or deselects a load combination for deflection design.
        /// </summary>
        /// <param name="nameLoadCombination">Name of an existing load combination.</param>
        /// <param name="selectLoadCombination">True: The specified load combination is selected as a design combination for deflection design. 
        /// False: The combination is not selected for deflection design.</param>
        public void SetComboDeflection(string nameLoadCombination, 
            bool selectLoadCombination)
        {
            _callCode = _sapModel.DesignSteel.SetComboDeflection(nameLoadCombination, selectLoadCombination);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Selects or deselects a load combination for strength design.
        /// </summary>
        /// <param name="nameLoadCombination">Name of an existing load combination.</param>
        /// <param name="selectLoadCombination">True: The specified load combination is selected as a design combination for strength design. 
        /// False: The combination is not selected for strength design.</param>
        public void SetComboStrength(string nameLoadCombination, 
            bool selectLoadCombination)
        {
            _callCode = _sapModel.DesignSteel.SetComboStrength(nameLoadCombination, selectLoadCombination);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        /// <summary>
        /// Selects or deselects a group for frame design.
        /// </summary>
        /// <param name="nameGroup">Name of an existing group.</param>
        /// <param name="selectForDesign">True: The specified group is selected as a design group for steel design. 
        /// False: The group is not selected for steel design.</param>
        public void SetGroup(string nameGroup, 
            bool selectForDesign)
        {
            _callCode = _sapModel.DesignSteel.SetGroup(nameGroup, selectForDesign);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        #endregion


        #region Methods: Public

        // === Local ===

        /// <summary>
        /// This function retrieves the design results from steel design output database tables.
        /// Note that the summary table of all design codes is not included in this function.
        /// </summary>
        /// <param name="itemName">Name of an existing frame object or group, depending on the value of the ItemType item.</param>
        /// <param name="itemType">Selection type to use for applying the method.</param>
        /// <param name="table">Table ID of the steel design output database Tables. 
        /// The table names are input as the representative table numbers and are code-based. 
        /// Please see the appendix at the bottom of the steel class.</param>
        /// <param name="field">Field name with TEXT output data type in the specified steel design result database Tables. 
        /// The Field Names need to be the exactly same as the names in the specified steel design output database tables except the case is insensitive.</param>
        /// <param name="numberFrames">Number of frame objects for which results are obtained.</param>
        /// <param name="frameNames">Frame object names for which results are obtained.</param>
        /// <param name="textResults">Design results with TEXT output data type of the request field in the request table for the specified frame objects.</param>
        public void GetDetailedResultsText(string itemName,
                                           eItemType itemType,
                                           int table,
                                           string field,
                                           ref int numberFrames,
                                           ref string[] frameNames,
                                           ref string[] textResults)
        {
            _callCode = _sapModel.DesignSteel.GetDetailResultsText(itemName, CSiEnumConverter.ToCSi(itemType), table, field, ref numberFrames, ref frameNames, ref textResults);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the design results from steel design output database tables.
        /// Note that the summary table of all design codes is not included in this function.
        /// </summary>
        /// <param name="itemName">Name of an existing frame object or group, depending on the value of the ItemType item.</param>
        /// <param name="itemType">Selection type to use for applying the method.</param>
        /// <param name="table">Table ID of the steel design output database Tables. 
        /// The table names are input as the representative table numbers and are code-based. 
        /// Please see the appendix at the bottom of the steel class.</param>
        /// <param name="field">Field name with Numerical output data type in the specified steel design result database Tables. 
        /// The Field Names need to be the exactly same as the names in the specified steel design output database tables except the case is insensitive.</param>
        /// <param name="numberFrames">Number of frame objects for which results are obtained.</param>
        /// <param name="frameNames">Frame object names for which results are obtained.</param>
        /// <param name="numericalResults">Design results with Numerical output data type of the request field in the request table for the specified frame objects.</param>
        public void GetDetailedResultsNumerical(string itemName,
                                           eItemType itemType,
                                           int table,
                                           string field,
                                           ref int numberFrames,
                                           ref string[] frameNames,
                                           ref double[] numericalResults)
        {
            _callCode = _sapModel.DesignSteel.GetDetailResultsValue(itemName, CSiEnumConverter.ToCSi(itemType), table, field, ref numberFrames, ref frameNames, ref numericalResults);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // === Get/Set ===

        /// <summary>
        /// Retrieves lateral displacement targets for steel design.
        /// </summary>
        /// <param name="numberItems">Number of lateral displacement targets specified.</param>
        /// <param name="loadCase">Name of the static linear load case associated with each lateral displacement target.</param>
        /// <param name="namePoint">Name of the point object associated to which the lateral displacement target applies.</param>
        /// <param name="displacementTargets">Lateral displacement targets. [L]</param>
        /// <param name="allSpecifiedTargetsActive">True: All specified lateral displacement targets are active. 
        /// False: They are inactive.</param>
        public void GetTargetDisplacement(ref int numberItems,
            ref string[] loadCase,
            ref string[] namePoint,
            ref double[] displacementTargets,
            ref bool allSpecifiedTargetsActive)
        {
            _callCode = _sapModel.DesignSteel.GetTargetDispl(ref numberItems, ref loadCase, ref namePoint, ref displacementTargets, ref allSpecifiedTargetsActive);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Sets lateral displacement targets for steel design.
        /// </summary>
        /// <param name="numberItems">Number of lateral displacement targets specified.</param>
        /// <param name="loadCase">Name of the static linear load case associated with each lateral displacement target.</param>
        /// <param name="namePoint">Name of the point object associated to which the lateral displacement target applies.</param>
        /// <param name="displacementTargets">Lateral displacement targets. [L]</param>
        /// <param name="allSpecifiedTargetsActive">True: All specified lateral displacement targets are active. 
        /// False: They are inactive.</param>
        public void SetTargetDisplacement(int numberItems,
            ref string[] loadCase,
            ref string[] namePoint,
            ref double[] displacementTargets,
            bool allSpecifiedTargetsActive)
        {
            _callCode = _sapModel.DesignSteel.SetTargetDispl(numberItems, ref loadCase, ref namePoint, ref displacementTargets, allSpecifiedTargetsActive);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // ===

        /// <summary>
        /// Retrieves time period targets for steel design.
        /// </summary>
        /// <param name="numberItems">Number of targets specified.</param>
        /// <param name="modalCase">Name of the modal load case for which the target applies.</param>
        /// <param name="modeNumbers">Mode number associated with each target.</param>
        /// <param name="periodTargets">Target periods. [s]</param>
        /// <param name="allSpecifiedTargetsActive">True: All specified targets are active. 
        /// False: They are inactive.</param>
        public void GetTargetPeriod(ref int numberItems,
            ref string modalCase,
            ref int[] modeNumbers,
            ref double[] periodTargets,
            ref bool allSpecifiedTargetsActive)
        {
            _callCode = _sapModel.DesignSteel.GetTargetPeriod(ref numberItems, ref modalCase, ref modeNumbers, ref periodTargets, ref allSpecifiedTargetsActive);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Sets time period targets for steel design.
        /// </summary>
        /// <param name="numberItems">Number of targets specified.</param>
        /// <param name="modalCase">Name of the modal load case for which the target applies.</param>
        /// <param name="modeNumbers">Mode number associated with each target.</param>
        /// <param name="periodTargets">Target periods. [s]</param>
        /// <param name="allSpecifiedTargetsActive">True: All specified targets are active. 
        /// False: They are inactive.</param>
        public void SetTargetPeriod(int numberItems,
            string modalCase,
            ref int[] modeNumbers,
            ref double[] periodTargets,
            bool allSpecifiedTargetsActive)
        {
            _callCode = _sapModel.DesignSteel.SetTargetPeriod(numberItems, modalCase, ref modeNumbers, ref periodTargets, allSpecifiedTargetsActive);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        #endregion
    }
}
