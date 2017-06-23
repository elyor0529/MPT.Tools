using System;
using MPT.CSI.API.Core.Program.ModelBehavior.Design.CodesDesign.ColdFormed;
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
    /// Represents Cold-Formed Steel design in the application.
    /// </summary>
    public class DesignColdFormed : CSiApiBase, IDesignMetal
    {
        #region Fields
        private readonly CSiApiSeed _seed;

        private AISI_ASD_96 _AISI_ASD_96;
        private AISI_LRFD_96 _AISI_LRFD_96;

        #endregion

        #region Properties

        public AISI_ASD_96 AISI_ASD_96 => _AISI_ASD_96 ?? (_AISI_ASD_96 = new AISI_ASD_96(_seed));
        public AISI_LRFD_96 AISI_LRFD_96 => _AISI_LRFD_96 ?? (_AISI_LRFD_96 = new AISI_LRFD_96(_seed));


        #endregion

        #region Initialization

        public DesignColdFormed(CSiApiSeed seed) : base(seed)
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
            _callCode = _sapModel.DesignColdFormed.DeleteResults();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Resets all frame design overwrites to default values.
        /// </summary>
        public void ResetOverwrites()
        {
            _callCode = _sapModel.DesignColdFormed.ResetOverwrites();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Starts the frame design.
        /// </summary>
        public void StartDesign()
        {
            _callCode = _sapModel.DesignColdFormed.StartDesign();
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
            _callCode = _sapModel.DesignColdFormed.VerifyPassed(ref numberNotPassedOrChecked, ref numberDidNotPass, ref numberNotChecked,ref  namesNotPassedOrChecked);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of the frame objects that have different analysis and design sections, if any.
        /// </summary>
        /// <param name="numberDifferentSections">The number of frame objects that have different analysis and design sections.</param>
        /// <param name="namesDifferentSections">This is an array that includes the name of each frame object that has different analysis and design sections.</param>
        public void VerifySections(ref int numberDifferentSections, ref string[] namesDifferentSections)
        {
            _callCode = _sapModel.DesignColdFormed.VerifySections(ref numberDifferentSections, ref namesDifferentSections);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        // === Get/Set ===
        /// <summary>
        /// Retrieves the design section for a specified frame object.
        /// </summary>
        /// <param name="nameFrame">Name of a frame object with a frame design procedure.</param>
        /// <param name="nameSection">The name of the design section for the specified frame object.</param>
        public void GetDesignSection(string nameFrame, ref string nameSection)
        {
            _callCode = _sapModel.DesignColdFormed.GetDesignSection(nameFrame, ref nameSection);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        public void SetDesignSection(string itemName, string nameSection, bool resetToLastAnalysisSection, eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.DesignColdFormed.SetDesignSection(itemName, nameSection, resetToLastAnalysisSection, CSiEnumConverter.ToCSi(itemType));
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
        public void GetSummaryResults(string name, ref int numberResults, ref string[] frameNames, ref double[] ratios, ref int[] ratioTypes, ref double[] locations, ref string[] comboNames, ref string[] errorSummaries, ref string[] warningSummaries, eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.DesignColdFormed.GetSummaryResults(name, ref numberResults, ref frameNames, ref ratios, ref ratioTypes, ref locations, ref comboNames, ref errorSummaries, ref warningSummaries, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        
        // === Set ===

        public void SetAutoSelectNull(string itemName, eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.DesignColdFormed.SetAutoSelectNull(itemName, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        public void SetComboDeflection(string nameLoadCombination, bool selectLoadCombination)
        {
            _callCode = _sapModel.DesignColdFormed.SetComboDeflection(nameLoadCombination, selectLoadCombination);
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
            _callCode = _sapModel.DesignColdFormed.SetComboStrength(nameLoadCombination, selectLoadCombination);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        

        public void SetGroup(string nameGroup, bool selectForDesign)
        {
            _callCode = _sapModel.DesignColdFormed.SetGroup(nameGroup, selectForDesign);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        
        #endregion
    }
}
