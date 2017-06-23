
namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Names of the object type can be listed.
    /// </summary>
    public interface IListableNames
    {
        /// <summary>
        /// This function retrieves the names of all items.
        /// </summary>
        /// <param name="numberOfNames">The number of item names retrieved by the program.</param>
        /// <param name="names">Names retrieved by the program.</param>
        void GetNameList(ref int numberOfNames, ref string[] names);
    }
}
