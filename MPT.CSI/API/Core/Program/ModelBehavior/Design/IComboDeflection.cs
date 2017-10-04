namespace MPT.CSI.API.Core.Program.ModelBehavior.Design
{
    /// <summary>
    /// Implements an interface for using load combinations for deflection-based design criteria.
    /// </summary>
    public interface IComboDeflection
    {
        // ===        
        /// <summary>
        /// Gets the names of all load combinatiojns used for deflection design.
        /// </summary>
        /// <param name="nameLoadCombinations">The name of each load combination used for consideration of deflecton limits.</param>
        /// <param name="numberOfItems">The number of frame objects for which results are obtained.</param>
        void GetComboDeflection(ref int numberOfItems, ref string[] nameLoadCombinations);

        /// <summary>
        /// Selects or deselects a load combination for deflection design.
        /// </summary>
        /// <param name="nameLoadCombination">Name of an existing load combination.</param>
        /// <param name="selectLoadCombination">True: The specified load combination is selected as a design combination for deflection design. 
        /// False: The combination is not selected for deflection design.</param>
        void SetComboDeflection(string nameLoadCombination, bool selectLoadCombination);

    }
}