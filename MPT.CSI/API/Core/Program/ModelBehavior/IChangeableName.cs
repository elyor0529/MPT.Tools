
namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Object can have name set.
    /// </summary>
    public interface IChangeableName
    {
        /// <summary>
        /// Changes the name of the specified item.
        /// </summary>
        /// <param name="currentName">The existing name of the item.</param>
        /// <param name="newName">The new name for the item.</param>
        void ChangeName(string currentName, string newName);
       
    }
}
