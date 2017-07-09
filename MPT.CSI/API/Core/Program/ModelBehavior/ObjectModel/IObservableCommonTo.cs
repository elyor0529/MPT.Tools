namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Object returns data on connected objects.
    /// </summary>
    public interface IObservableCommonTo
    {
        /// <summary>
        /// This function returns the total number of objects (line, area, solid and link) that connect to the specified point object.
        /// </summary>
        /// <param name="name">The name of a point object.</param>
        /// <param name="commonTo">The total number of objects (line, area, solid and link) that connect to the specified point object.</param>
        void GetCommonTo(string name,
            ref int commonTo);
    }
}