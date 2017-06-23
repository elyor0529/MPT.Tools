
namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Element can return the corresponding object name.
    /// </summary>
    public interface IObservableObject
    {
        /// <summary>
        /// This function retrieves the name of the object from which an element was created.
        /// </summary>
        /// <param name="name">The name of an existing element.</param>
        /// <param name="nameObject">The name of the object from which the element was created.</param>
        void GetObject(string name, 
            ref string nameObject);
    }
}
