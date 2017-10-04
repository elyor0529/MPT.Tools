using MPT.CSI.API.Core.Program.ModelBehavior.Design.CodesDesign.Concrete;
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Design
{
    /// <summary>
    /// Represents Concrete design in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Design.IDesignConcrete" />
    public class DesignConcrete : CSiApiBase, IDesignConcrete
    {
        #region Fields
        private readonly CSiApiSeed _seed;

        private ACI_318_08_IBC_2009 _ACI_318_08_IBC_2009;       
        private Eurocode_2_2004 _Eurocode_2_2004;
#if BUILD_SAP2000v16 || BUILD_SAP2000v17 || BUILD_SAP2000v18 || BUILD_SAP2000v19
        private AS_3600_09 _AS_3600_09;
        private BS_8110_97 _BS_8110_97;
        private Chinese_2002 _Chinese_2002;
        private Hong_Kong_CP_2013 _Hong_Kong_CP_2013;
        private Indian_IS_456_2000 _Indian_IS_456_2000;
        private Italian_NTC_2008 _Italian_NTC_2008;
        private KCI_1999 _KCI_1999;
        private Mexican_RCDF_2004 _Mexican_RCDF_2004;
        private NZS_3101_2006 _NZS_3101_2006;
        private Singapore_CP_6599 _Singapore_CP_6599;
        private TS_500_2000 _TS_500_2000;
#endif
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        private ACI_318_11 _ACI_318_11;
        private CSA_A23_3_04 _CSA_A23_3_04;
#endif
#if !BUILD_CSiBridgev18 && !BUILD_CSiBridgev19
        private Chinese_2010 _Chinese_2010;
#endif
#if BUILD_CSiBridgev18 || BUILD_CSiBridgev19
        private AASHTO_07 _AASHTO_07;
        private AASHTO_LRFD_2012 _AASHTO_LRFD_2012;
        private AASHTO_LRFD_2014 _AASHTO_LRFD_2014;
#endif
        #endregion

        #region Properties   

        /// <summary>
        /// Gets the ACI 318 08 IBC 2009 design code.
        /// </summary>
        /// <value>The ACI 318 08 IBC 2009 design code.</value>
        public ACI_318_08_IBC_2009 ACI_318_08_IBC_2009 => _ACI_318_08_IBC_2009 ?? (_ACI_318_08_IBC_2009 = new ACI_318_08_IBC_2009(_seed));

        /// <summary>
        /// Gets the Eurocode 2 2004 design code.
        /// </summary>
        /// <value>The Eurocode 2 2004 design code.</value>
        public Eurocode_2_2004 Eurocode_2_2004 => _Eurocode_2_2004 ?? (_Eurocode_2_2004 = new Eurocode_2_2004(_seed));
#if BUILD_SAP2000v16 || BUILD_SAP2000v17 || BUILD_SAP2000v18 || BUILD_SAP2000v19
        /// <summary>
        /// Gets AS 3600 09 design code.
        /// </summary>
        /// <value>The AS 3600 09.</value>
        public AS_3600_09 AS_3600_09 => _AS_3600_09 ?? (_AS_3600_09 = new AS_3600_09(_seed));

        /// <summary>
        /// Gets the BS 8110 97 design code.
        /// </summary>
        /// <value>The BS 8110 97 design code.</value>
        public BS_8110_97 BS_8110_97 => _BS_8110_97 ?? (_BS_8110_97 = new BS_8110_97(_seed));

        /// <summary>
        /// Gets the Chinese 2002 design code.
        /// </summary>
        /// <value>The Chinese 2002 design code.</value>
        public Chinese_2002 Chinese_2002 => _Chinese_2002 ?? (_Chinese_2002 = new Chinese_2002(_seed));

        /// <summary>
        /// Gets the Hong Kong CP 2013 design code.
        /// </summary>
        /// <value>The Hong Kong CP 2013 design code.</value>
        public Hong_Kong_CP_2013 Hong_Kong_CP_2013 => _Hong_Kong_CP_2013 ?? (_Hong_Kong_CP_2013 = new Hong_Kong_CP_2013(_seed));

        /// <summary>
        /// Gets the Indian IS 456 2000 design code.
        /// </summary>
        /// <value>The Indian IS 456 2000 design code.</value>
        public Indian_IS_456_2000 Indian_IS_456_2000 => _Indian_IS_456_2000 ?? (_Indian_IS_456_2000 = new Indian_IS_456_2000(_seed));

        /// <summary>
        /// Gets the Italian NTC 2008 design code.
        /// </summary>
        /// <value>The Italian NTC 2008 design code.</value>
        public Italian_NTC_2008 Italian_NTC_2008 => _Italian_NTC_2008 ?? (_Italian_NTC_2008 = new Italian_NTC_2008(_seed));

        /// <summary>
        /// Gets the KCI 1999 design code.
        /// </summary>
        /// <value>The KCI 1999 design code.</value>
        public KCI_1999 KCI_1999 => _KCI_1999 ?? (_KCI_1999 = new KCI_1999(_seed));

        /// <summary>
        /// Gets the Mexican RCDF 2004 design code.
        /// </summary>
        /// <value>The Mexican RCDF 2004 design code.</value>
        public Mexican_RCDF_2004 Mexican_RCDF_2004 => _Mexican_RCDF_2004 ?? (_Mexican_RCDF_2004 = new Mexican_RCDF_2004(_seed));

        /// <summary>
        /// Gets the NZS 3101 2006 design code.
        /// </summary>
        /// <value>The NZS 3101 2006 design code.</value>
        public NZS_3101_2006 NZS_3101_2006 => _NZS_3101_2006 ?? (_NZS_3101_2006 = new NZS_3101_2006(_seed));

        /// <summary>
        /// Gets the Singapore CP 6599 design code.
        /// </summary>
        /// <value>The Singapore CP 6599 design code.</value>
        public Singapore_CP_6599 Singapore_CP_6599 => _Singapore_CP_6599 ?? (_Singapore_CP_6599 = new Singapore_CP_6599(_seed));

        /// <summary>
        /// Gets the TS 500 2000 design code.
        /// </summary>
        /// <value>The TS 500 2000 design code.</value>
        public TS_500_2000 TS_500_2000 => _TS_500_2000 ?? (_TS_500_2000 = new TS_500_2000(_seed));
#endif
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        /// <summary>
        /// Gets the ACI 318 11 design code.
        /// </summary>
        /// <value>The ACI 318 11design code.</value>
        public ACI_318_11 ACI_318_11 => _ACI_318_11 ?? (_ACI_318_11 = new ACI_318_11(_seed));

        /// <summary>
        /// Gets the CSA A23 304 design code.
        /// </summary>
        /// <value>The CSA A23 304 design code.</value>
        public CSA_A23_3_04 CSA_A23_3_04 => _CSA_A23_3_04 ?? (_CSA_A23_3_04 = new CSA_A23_3_04(_seed));
#endif
#if !BUILD_CSiBridgev18 && !BUILD_CSiBridgev19
        /// <summary>
        /// Gets the Chinese 2010 design code.
        /// </summary>
        /// <value>The Chinese 2010 design code.</value>
        public Chinese_2010 Chinese_2010 => _Chinese_2010 ?? (_Chinese_2010 = new Chinese_2010(_seed));
#endif
#if BUILD_CSiBridgev18 || BUILD_CSiBridgev19
        /// <summary>
        /// Gets the AASHTO 07 design code.
        /// </summary>
        /// <value>The AASHTO 07 design code.</value>
        public AASHTO_07 AASHTO_07 => _AASHTO_07 ?? (_AASHTO_07 = new AASHTO_07(_seed));

        /// <summary>
        /// Gets the AASHTO LRFD 2012 design code.
        /// </summary>
        /// <value>The AASHTO LRFD 2012 design code.</value>
        public AASHTO_LRFD_2012 AASHTO_LRFD_2012 => _AASHTO_LRFD_2012 ?? (_AASHTO_LRFD_2012 = new AASHTO_LRFD_2012(_seed));

        /// <summary>
        /// Gets the AASHTO LRFD 2014 design code.
        /// </summary>
        /// <value>The AASHTO LRFD 2014 design code.</value>
        public AASHTO_LRFD_2014 AASHTO_LRFD_2014 => _AASHTO_LRFD_2014 ?? (_AASHTO_LRFD_2014 = new AASHTO_LRFD_2014(_seed));
#endif
        #endregion

        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="DesignConcrete"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public DesignConcrete(CSiApiSeed seed) : base(seed)
        {
            _seed = seed;
        }
        #endregion

        #region Methods: Interface
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        /// <summary>
        /// Deletes all frame design results.
        /// </summary>
        public void DeleteResults()
        {
            _callCode = _sapModel.DesignConcrete.DeleteResults();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Resets all frame design overwrites to default values.
        /// </summary>
        public void ResetOverwrites()
        {
            _callCode = _sapModel.DesignConcrete.ResetOverwrites();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
#endif


        /// <summary>
        /// Starts the frame design.
        /// </summary>
        public void StartDesign()
        {
            _callCode = _sapModel.DesignConcrete.StartDesign();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        /// <summary>
        /// True: Design results are available.
        /// </summary>
        /// <returns><c>true</c> if design results are available, <c>false</c> otherwise.</returns>
        public bool ResultsAreAvailable()
        {
            return _sapModel.DesignConcrete.GetResultsAvailable();
        }


#if !BUILD_ETABS2015 && !BUILD_ETABS2016
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
            _callCode = _sapModel.DesignConcrete.VerifyPassed(ref numberNotPassedOrChecked, ref numberDidNotPass, ref numberNotChecked, ref namesNotPassedOrChecked);
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
            _callCode = _sapModel.DesignConcrete.VerifySections(ref numberDifferentSections, ref namesDifferentSections);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
#endif

        
        // === Get/Set ===
        // TODO: Consider how to flexibly apply this as an enum.
        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <param name="codeName">Name of the code.</param>
        public void GetCode(ref string codeName)
        {
            _callCode = _sapModel.DesignConcrete.GetCode(ref codeName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // TODO: Consider how to flexibly apply this as an enum.
        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <param name="codeName">Name of the code.</param>
        public void SetCode(string codeName)
        {
            _callCode = _sapModel.DesignConcrete.SetCode(codeName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        // ===

        /// <summary>
        /// Retrieves the design section for a specified frame object.
        /// </summary>
        /// <param name="nameFrame">Name of a frame object with a frame design procedure.</param>
        /// <param name="nameSection">The name of the design section for the specified frame object.</param>
        public void GetDesignSection(string nameFrame,
            ref string nameSection)
        {
            _callCode = _sapModel.DesignConcrete.GetDesignSection(nameFrame, ref nameSection);
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
            _callCode = _sapModel.DesignConcrete.SetDesignSection(itemName, nameSection, resetToLastAnalysisSection, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // ===
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        /// <summary>
        /// Retrieves the value of the automatically generated code-based design load combinations option.
        /// </summary>
        /// <param name="autoGenerate">True: Option to automatically generate code-based design load combinations for concrete frame design is turned on.</param>
        public void GetComboAutoGenerate(ref bool autoGenerate)
        {
            _callCode = _sapModel.DesignConcrete.GetComboAutoGenerate(ref autoGenerate);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Sets the value of the automatically generated code-based design load combinations option.
        /// </summary>
        /// <param name="autoGenerate">True: Option to automatically generate code-based design load combinations for concrete frame design is turned on.</param>
        public void SetComboAutoGenerate(bool autoGenerate)
        {
            _callCode = _sapModel.DesignConcrete.SetComboAutoGenerate(autoGenerate);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        // ===

        /// <summary>
        /// Gets the load combination selected for strength design.
        /// </summary>
        /// <param name="nameLoadCombinations">The name of the load combinations selected.</param>
        /// <param name="numberOfItems">The number of frame objects for which results are obtained.</param>
        public void GetComboStrength(ref int numberOfItems, 
            ref string[] nameLoadCombinations)
        {
            _callCode = _sapModel.DesignConcrete.GetComboStrength(ref numberOfItems, ref nameLoadCombinations);
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
            _callCode = _sapModel.DesignConcrete.SetComboStrength(nameLoadCombination, selectLoadCombination);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
#endif
        #endregion


        #region Methods: Public

        /// <summary>
        /// Retrieves summary results for concrete design of beams.
        /// Torsion results are not included for all codes.
        /// </summary>
        /// <param name="name">The name of an existing frame object or group, depending on the value of the ItemType item.</param>
        /// <param name="numberItems">The number of frame objects for which results are obtained.</param>
        /// <param name="frameName">This is an array that includes each frame object name for which results are obtained.</param>
        /// <param name="location">This is an array that includes the distance from the I-end of the frame object to the location where the results are reported. [L]</param>
        /// <param name="topCombo">This is an array that includes the name of the design combination for which the controlling top longitudinal rebar area for flexure occurs. 
        /// A combination name followed by (Sp) indicates that the design loads were obtained by applying special, code-specific multipliers to all or part of the specified design load combination, or that the design was based on the capacity of other objects (or other design locations for the same object).</param>
        /// <param name="topArea">This is an array that includes the total top longitudinal rebar area required for the flexure at the specified location. 
        /// It does not include the area of steel required for torsion. [L^2]</param>
        /// <param name="botCombo">This is an array that includes the name of the design combination for which the controlling bottom longitudinal rebar area for flexure occurs. 
        /// A combination name followed by (Sp) indicates that the design loads were obtained by applying special, code-specific, multipliers to all or part of the specified design load combination, or that the design was based on the capacity of other objects (or other design locations for the same object).</param>
        /// <param name="botArea">This is an array that includes the total bottom longitudinal rebar area required for the flexure at the specified location. 
        /// It does not include the area of steel required for torsion. [L^2]</param>
        /// <param name="VMajorCombo">This is an array that includes the name of the design combination for which the controlling shear occurs. 
        /// A combination name followed by (Sp) indicates that the design loads were obtained by applying special, code-specific, multipliers to all or part of the specified design load combination, or that the design was based on the capacity of other objects (or other design locations for the same object).</param>
        /// <param name="VMajorArea">This is an array that includes the required area of transverse shear reinforcing per unit length along the frame object for shear at the specified location. [L^2/L]</param>
        /// <param name="TLCombo">This is an array that includes the name of the design combination for which the controlling longitudinal rebar area for torsion occurs. 
        /// A combination name followed by (Sp) indicates that the design loads were obtained by applying special, code-specific, multipliers to all or part of the specified design load combination, or that the design was based on the capacity of other objects (or other design locations for the same object).</param>
        /// <param name="TLArea">This is an array that includes the total longitudinal rebar area required for torsion. [L^2]</param>
        /// <param name="TTCombo">This is an array that includes the name of the design combination for which the controlling transverse reinforcing for torsion occurs. 
        /// A combination name followed by (Sp) indicates that the design loads were obtained by applying special, code-specific, multipliers to all or part of the specified design load combination, or that the design was based on the capacity of other objects (or other design locations for the same object).</param>
        /// <param name="TTArea">This is an array that includes the required area of transverse torsional shear reinforcing per unit length along the frame object for torsion at the specified location. [L^2/L]</param>
        /// <param name="errorSummary">This is an array that includes the design error messages for the frame object, if any.</param>
        /// <param name="warningSummary">This is an array that includes the design warning messages for the frame object, if any.</param>
        /// <param name="itemType">This is one of the following items in the eItemType enumeration.
        /// If this item is Object, the design results are retrieved for the frame object specified by the Name item.
        /// If this item is Group, the design results are retrieved for all frame objects in the group specified by the Name item.
        /// If this item is SelectedObjects, the design results are retrieved for all selected frame objects, and the Name item is ignored.</param>
        public void GetSummaryResultsBeam(string name, 
            ref int numberItems,
            ref string[] frameName,
            ref double[] location,
            ref string[] topCombo,
            ref double[] topArea,
            ref string[] botCombo,
            ref double[] botArea,
            ref string[] VMajorCombo,
            ref double[] VMajorArea,
            ref string[] TLCombo,
            ref double[] TLArea,
            ref string[] TTCombo,
            ref double[] TTArea,
            ref string[] errorSummary,
            ref string[] warningSummary,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.DesignConcrete.GetSummaryResultsBeam(name, ref numberItems, ref frameName, ref location, ref topCombo, ref topArea, ref botCombo, ref botArea, ref VMajorCombo, ref VMajorArea, ref TLCombo, ref TLArea, ref TTCombo, ref TTArea, ref errorSummary, ref warningSummary, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Retrieves summary results for concrete design of columns.
        /// </summary>
        /// <param name="name">The name of an existing frame object or group, depending on the value of the ItemType item.</param>
        /// <param name="numberItems">The number of frame objects for which results are obtained.</param>
        /// <param name="frameName">This is an array that includes each frame object name for which results are obtained.</param>
        /// <param name="myOption">This is an array that includes 1 or 2, indicating the design option for each frame object: 1 = Check, 2 = Design </param>
        /// <param name="location">This is an array that includes the distance from the I-end of the frame object to the location where the results are reported. [L]</param>
        /// <param name="PMMCombo">This is an array that includes the name of the design combination for which the controlling PMM ratio or rebar area occurs. 
        /// A combination name followed by (Sp) indicates that the design loads were obtained by applying special, code-specific multipliers to all or part of the specified design load combination, or that the design was based on the capacity of other objects (or other design locations for the same object).</param>
        /// <param name="PMMArea">This is an array that includes the total longitudinal rebar area required for the axial force plus biaxial moment (PMM) design at the specified location. [L^2]</param>
        /// <param name="PMMRatio">This is an array that includes the axial force plus biaxial moment (PMM) stress ratio at the specified location.
        /// Item applies only when MyOption = 1 (check).</param>
        /// <param name="VMajorCombo">This is an array that includes the name of the design combination for which the controlling major shear occurs.</param>
        /// <param name="AVMajor">This is an array that includes the required area of transverse shear reinforcing per unit length along the frame object for major shear at the specified location. [L^2/L]</param>
        /// <param name="VMinorCombo">This is an array that includes the name of the design combination for which the controlling minor shear occurs.</param>
        /// <param name="AVMinor">This is an array that includes the required area of transverse shear reinforcing per unit length along the frame object for minor shear at the specified location. [L^2/L]</param>
        /// <param name="errorSummary">This is an array that includes the design error messages for the frame object, if any.</param>
        /// <param name="warningSummary">This is an array that includes the design warning messages for the frame object, if any.</param>
        /// <param name="itemType">This is one of the following items in the eItemType enumeration.
        /// If this item is Object, the design results are retrieved for the frame object specified by the Name item.
        /// If this item is Group, the design results are retrieved for all frame objects in the group specified by the Name item.
        /// If this item is SelectedObjects, the design results are retrieved for all selected frame objects, and the Name item is ignored.</param>
        public void GetSummaryResultsColumn(string name,
            ref int numberItems,
            ref string[] frameName,
            ref int[] myOption,
            ref double[] location,
            ref string[] PMMCombo,
            ref double[] PMMArea,
            ref double[] PMMRatio,
            ref string[] VMajorCombo,
            ref double[] AVMajor,
            ref string[] VMinorCombo,
            ref double[] AVMinor,
            ref string[] errorSummary,
            ref string[] warningSummary,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.DesignConcrete.GetSummaryResultsColumn(name, ref numberItems, ref frameName, ref myOption, ref location, ref PMMCombo, ref PMMArea, ref PMMRatio, ref VMajorCombo, ref AVMajor, ref VMinorCombo, ref AVMinor, ref errorSummary, ref warningSummary, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Retrieves summary results for concrete design of joints.
        /// </summary>
        /// <param name="name">The name of an existing frame object or group, depending on the value of the ItemType item.</param>
        /// <param name="numberItems">The number of frame objects for which results are obtained.</param>
        /// <param name="frameName">This is an array that includes each frame object name for which results are obtained.</param>
        /// <param name="LCJSRatioMajor">This is an array that includes the name of the design combination for which the controlling joint shear ratio associated with the column major axis occurs. 
        /// A combination name followed by (Sp) indicates that the design loads were obtained by applying special, code-specific multipliers to all or part of the specified design load combination, or that the design was based on the capacity of other objects (or other design locations for the same object).</param>
        /// <param name="JSRatioMajor">This is an array that includes the joint shear ratio associated with the column major axis. 
        /// This is the joint shear divided by the joint shear capacity.</param>
        /// <param name="LCJSRatioMinor">This is an array that includes the name of the design combination for which the controlling joint shear ratio associated with the column minor axis occurs. 
        /// A combination name followed by (Sp) indicates that the design loads were obtained by applying special, code-specific multipliers to all or part of the specified design load combination, or that the design was based on the capacity of other objects (or other design locations for the same object).</param>
        /// <param name="JSRatioMinor">This is an array that includes the joint shear ratio associated with the column minor axis. 
        /// This is the joint shear divided by the joint shear capacity.</param>
        /// <param name="LCBCCRatioMajor">This is an array that includes the name of the design combination for which the controlling beam/column capacity ratio associated with the column major axis occurs. 
        /// A combination name followed by (Sp) indicates that the design loads were obtained by applying special, code-specific multipliers to all or part of the specified design load combination, or that the design was based on the capacity of other objects (or other design locations for the same object).</param>
        /// <param name="BCCRatioMajor">This is an array that includes the beam/column capacity ratio associated with the column major axis. 
        /// This is the sum of the column capacities divided by the sum of the beam capacities at the top of the specified column.</param>
        /// <param name="LCBCCRatioMinor">This is an array that includes the name of the design combination for which the controlling beam/column capacity ratio associated with the column minor axis occurs. 
        /// A combination name followed by (Sp) indicates that the design loads were obtained by applying special, code-specific multipliers to all or part of the specified design load combination, or that the design was based on the capacity of other objects (or other design locations for the same object).</param>
        /// <param name="BCCRatioMinor">This is an array that includes the beam/column capacity ratio associated with the column minor axis. This is the sum of the column capacities divided by the sum of the beam capacities at the top of the specified column.</param>
        /// <param name="errorSummary">This is an array that includes the design error messages for the frame object, if any.</param>
        /// <param name="warningSummary">This is an array that includes the design warning messages for the frame object, if any.</param>
        /// <param name="itemType">This is one of the following items in the eItemType enumeration.
        /// If this item is Object, the design results are retrieved for the frame object specified by the Name item.
        /// If this item is Group, the design results are retrieved for all frame objects in the group specified by the Name item.
        /// If this item is SelectedObjects, the design results are retrieved for all selected frame objects, and the Name item is ignored.</param>
        public void GetSummaryResultsJoint(string name,
            ref int numberItems,
            ref string[] frameName,
            ref string[] LCJSRatioMajor,
            ref double[] JSRatioMajor,
            ref string[] LCJSRatioMinor,
            ref double[] JSRatioMinor,
            ref string[] LCBCCRatioMajor,
            ref double[] BCCRatioMajor,
            ref string[] LCBCCRatioMinor,
            ref double[] BCCRatioMinor,
            ref string[] errorSummary,
            ref string[] warningSummary,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.DesignConcrete.GetSummaryResultsJoint(name, ref numberItems, ref frameName, ref LCJSRatioMajor, ref JSRatioMajor, ref LCJSRatioMinor, ref JSRatioMinor, ref LCBCCRatioMajor, ref BCCRatioMajor, ref LCBCCRatioMinor, ref BCCRatioMinor, ref errorSummary, ref warningSummary, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion
    }
}
