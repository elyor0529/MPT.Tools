using System;
using MPT.CSI.API.Core.Program.ModelBehavior.Design.CodesDesign.Concrete;
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
    /// Represents Concrete design in the application.
    /// </summary>
    public class DesignConcrete : CSiApiBase, IDesignCode
    {
        #region Fields
        private readonly CSiApiSeed _seed;

        private ACI_318_08_IBC_2009 _ACI_318_08_IBC_2009;

        #endregion

        #region Properties

        public ACI_318_08_IBC_2009 ACI_318_08_IBC_2009 => _ACI_318_08_IBC_2009 ?? (_ACI_318_08_IBC_2009 = new ACI_318_08_IBC_2009(_seed));



        #endregion

        #region Initialization

        public DesignConcrete(CSiApiSeed seed) : base(seed)
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

        /// <summary>
        /// Starts the frame design.
        /// </summary>
        public void StartDesign()
        {
            _callCode = _sapModel.DesignConcrete.StartDesign();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of the frame objects that did not pass the design check or have not yet been checked, if any.
        /// </summary>
        /// <param name="numberNotPassedOrChecked">The number of concrete frame objects that did not pass the design check or have not yet been checked.</param>
        /// <param name="numberDidNotPass">The number of concrete frame objects that did not pass the design check.</param>
        /// <param name="numberNotChecked">The number of concrete frame objects that have not yet been checked.</param>
        /// <param name="namesNotPassedOrChecked">This is an array that includes the name of each frame object that did not pass the design check or has not yet been checked.</param>
        public void VerifyPassed(ref int numberNotPassedOrChecked, ref int numberDidNotPass, ref int numberNotChecked, ref string[] namesNotPassedOrChecked)
        {
            _callCode = _sapModel.DesignConcrete.VerifyPassed(ref numberNotPassedOrChecked, ref numberDidNotPass, ref numberNotChecked, ref namesNotPassedOrChecked);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of the frame objects that have different analysis and design sections, if any.
        /// </summary>
        /// <param name="numberDifferentSections">The number of frame objects that have different analysis and design sections.</param>
        /// <param name="namesDifferentSections">This is an array that includes the name of each frame object that has different analysis and design sections.</param>
        public void VerifySections(ref int numberDifferentSections, ref string[] namesDifferentSections)
        {
            _callCode = _sapModel.DesignConcrete.VerifySections(ref numberDifferentSections, ref namesDifferentSections);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Selects or deselects a load combination for strength design.
        /// </summary>
        /// <param name="nameLoadCombination">Name of an existing load combination.</param>
        /// <param name="selectLoadCombination">True: The specified load combination is selected as a design combination for strength design. 
        /// False: The combination is not selected for strength design.</param>
        public void SetComboStrength(string nameLoadCombination, bool selectLoadCombination)
        {
            _callCode = _sapModel.DesignConcrete.SetComboStrength(nameLoadCombination, selectLoadCombination);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion


        #region Methods: Public

        /// <summary>
        /// Retrieves summary results for concrete design of beams.
        /// Torsion results are not included for all codes.
        /// </summary>
        /// <param name="name">The name of an existing frame object or group, depending on the value of the ItemType item.</param>
        /// <param name="numberItems">The number of frame objects for which results are obtained</param>
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
        /// <param name="numberItems">The number of frame objects for which results are obtained</param>
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
        /// <param name="numberItems">The number of frame objects for which results are obtained</param>
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
