
namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Object can be removed from the application.
    /// </summary>
    public interface IDeletable
    {
        /// <summary>
        /// The function deletes the specified item by name.
        /// </summary>
        /// <param name="name">The name of an existing item.</param>
        void Delete(string name);
    }
}
