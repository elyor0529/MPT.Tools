namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Object can return the corresponding element name created for analysis.
    /// </summary>
    public interface IObservableElement
    {
        /// <summary>
        /// This function retrieves the name of the element (analysis model) associated with a specified object in the object-based model.
        /// An error occurs if the analysis model does not exist.
        /// </summary>
        /// <param name="name">The name of an existing object.</param>
        /// <param name="numberOfElements">The number of area elements created from the specified area object.</param>
        /// <param name="elementNames">The name of each element created from the specified object.</param>
        void GetElement(string name,
            ref int numberOfElements,
            ref string[] elementNames);
    }
}
