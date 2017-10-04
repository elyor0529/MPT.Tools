namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Object can return material overwrites.
    /// </summary>
    public interface IObservableMaterialOverwrite
    {
        /// <summary>
        /// This function retrieves the material overwrite assigned to an element, if any. 
        /// The material property name is indicated as None if there is no material overwrite assignment.
        /// </summary>
        /// <param name="name">The name of a defined element.</param>
        /// <param name="propertyName">This is None, indicating that no material overwrite exists for the specified element, or it is the name of an existing material property.</param>
        void GetMaterialOverwrite(string name, 
            ref string propertyName);
    }
}
