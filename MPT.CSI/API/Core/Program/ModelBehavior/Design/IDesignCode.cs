
namespace MPT.CSI.API.Core.Program.ModelBehavior.Design
{
    /// <summary>
    /// Implements a design interface for all frame elements.
    /// </summary>
    public interface IDesignCode
    {
        #region Methods: Public
        /// <summary>
        /// Deletes all frame design results.
        /// </summary>
        void DeleteResults();

        /// <summary>
        /// Resets all frame design overwrites to default values.
        /// </summary>
        void ResetOverwrites();

        /// <summary>
        /// Starts the frame design.
        /// </summary>
        void StartDesign();

        /// <summary>
        /// This function retrieves the names of the frame objects that did not pass the design check or have not yet been checked, if any.
        /// </summary>
        /// <param name="numberNotPassedOrChecked">The number of concrete frame objects that did not pass the design check or have not yet been checked.</param>
        /// <param name="numberDidNotPass">The number of concrete frame objects that did not pass the design check.</param>
        /// <param name="numberNotChecked">The number of concrete frame objects that have not yet been checked.</param>
        /// <param name="namesNotPassedOrChecked">This is an array that includes the name of each frame object that did not pass the design check or has not yet been checked.</param>
        void VerifyPassed(ref int numberNotPassedOrChecked, ref int numberDidNotPass, ref int numberNotChecked, ref string[] namesNotPassedOrChecked);

        /// <summary>
        /// This function retrieves the names of the frame objects that have different analysis and design sections, if any.
        /// </summary>
        /// <param name="numberDifferentSections">The number of frame objects that have different analysis and design sections.</param>
        /// <param name="namesDifferentSections">This is an array that includes the name of each frame object that has different analysis and design sections.</param>
        void VerifySections(ref int numberDifferentSections, ref string[] namesDifferentSections);

        // === Set Methods ===

        /// <summary>
        /// Selects or deselects a load combination for strength design.
        /// </summary>
        /// <param name="nameLoadCombination">Name of an existing load combination.</param>
        /// <param name="setLoadCombination">True: The specified load combination is selected as a design combination for strength design. 
        /// False: The combination is not selected for strength design.</param>
        void SetComboStrength(string nameLoadCombination, bool setLoadCombination);

        #endregion
    }
}
