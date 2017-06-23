
namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Object can return the section/property assignment name.
    /// </summary>
    public interface IObservableSection
    {
        /// <summary>
        /// This function retrieves the section property assigned to an element/object.
        /// </summary>
        /// <param name="name">The name of a defined element/object.</param>
        /// <param name="propertyName">The name of the section property assigned to the element/object. 
        /// This item is None if there is no section property assigned to the element/object.</param>
        void GetSection(string name, 
            ref string propertyName);
    }
}
