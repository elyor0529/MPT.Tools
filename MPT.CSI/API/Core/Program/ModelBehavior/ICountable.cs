
namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Object can be counted.
    /// </summary>
    public interface ICountable
    {
        /// <summary>
        /// Returns the total number of items without regard for type.
        /// </summary>
        /// <returns></returns>
        int Count();
    }
}
