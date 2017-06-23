
namespace MPT.CSI.API.Core.Program.ModelBehavior.Design
{
    /// <summary>
    /// Implements a design interface for all metal-based frame elements.
    /// </summary>
    public interface IDesignMetal : IDesignCode
    {
        #region Methods: Public
        // === Get Methods ===

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
        void GetSummaryResults(string name, 
            ref int numberResults, 
            ref string[] frameNames, 
            ref double[] ratios, 
            ref int[] ratioTypes,
            ref double[] locations,
            ref string[] comboNames,
            ref string[] errorSummaries,
            ref string[] warningSummaries,
            eItemType itemType = eItemType.Object);

        /// <summary>
        /// Retrieves the design section for a specified frame object.
        /// </summary>
        /// <param name="name">Name of a frame object with a frame design procedure.</param>
        /// <param name="propName">The name of the design section for the specified frame object.</param>
        void GetDesignSection(string name, ref string propName);

        // === Set Methods ===

        /// <summary>
        /// Selects or deselects a load combination for deflection design.
        /// </summary>
        /// <param name="nameLoadCombination">Name of an existing load combination.</param>
        /// <param name="selectLoadCombination">True: The specified load combination is selected as a design combination for deflection design. 
        /// False: The combination is not selected for deflection design.</param>
        void SetComboDeflection(string nameLoadCombination, bool selectLoadCombination);

        /// <summary>
        /// Modifies the design section for all specified frame objects that have a frame design procedure.
        /// </summary>
        /// <param name="itemName">Name of an existing frame object or group, depending on the value of the ItemType item.</param>
        /// <param name="nameFrame">Name of an existing frame section property to be used as the design section for the specified frame objects. 
        /// This item applies only when resetToLastAnalysisSection = False.</param>
        /// <param name="resetToLastAnalysisSection">True: The design section for the specified frame objects is reset to the last analysis section for the frame object. 
        /// False: The design section is set to that specified by nameFrame.</param>
        /// <param name="itemType">Selection type to use for applying the method.</param>
        void SetDesignSection(string itemName, string nameFrame, bool resetToLastAnalysisSection, eItemType itemType = eItemType.Object);

        /// <summary>
        /// Selects or deselects a group for frame design.
        /// </summary>
        /// <param name="nameGroup">Name of an existing group.</param>
        /// <param name="selectForDesign">True: The specified group is selected as a design group for steel design. 
        /// False: The group is not selected for steel design.</param>
        void SetGroup(string nameGroup, bool selectForDesign);

        /// <summary>
        /// Removes the auto select section assignments from all specified frame objects that have a steel frame design procedure.
        /// </summary>
        /// <param name="itemName">Name of an existing frame object or group, depending on the value of the ItemType item.</param>
        /// <param name="itemType">Selection type to use for applying the method.</param>
        void SetAutoSelectNull(string itemName, eItemType itemType = eItemType.Object);

        #endregion
    }
}
