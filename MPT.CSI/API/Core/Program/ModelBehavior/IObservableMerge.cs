#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Object returns merge number data.
    /// </summary>
    public interface IObservableMerge
    {
        /// <summary>
        /// This function retrieves the merge number for a point element/object. 
        /// By default the merge number for a point is zero. 
        /// Points with different merge numbers are not automatically merged by the program.
        /// </summary>
        /// <param name="name">The name of an existing point element/object.</param>
        /// <param name="mergeNumber">The merge number assigned to the specified point element/object.</param>
        void GetMergeNumber(string name, 
            ref int mergeNumber);
    }
}
#endif