namespace MPT.CSI.API.Core.Program.ModelBehavior.Design
{
    /// <summary>
    /// Implements an interface for using load combinations for strength-based design criteria.
    /// </summary>
    public interface IComboStrength
    {
        /// <summary>
        /// Gets the load combination selected for strength design.
        /// </summary>
        /// <param name="nameLoadCombinations">The name of the load combinations selected.</param>
        /// <param name="numberOfItems">The number of frame objects for which results are obtained.</param>
        void GetComboStrength(ref int numberOfItems, ref string[] nameLoadCombinations);

        /// <summary>
        /// Selects or deselects a load combination for strength design.
        /// </summary>
        /// <param name="nameLoadCombination">Name of an existing load combination.</param>
        /// <param name="setLoadCombination">True: The specified load combination is selected as a design combination for strength design. 
        /// False: The combination is not selected for strength design.</param>
        void SetComboStrength(string nameLoadCombination, bool setLoadCombination);
    }
}
