
namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Object can return the names of all associated points.
    /// </summary>
    public interface IObservablePoints
    {
        /// <summary>
        /// This function retrieves the names of the point elements that define an element.
        /// </summary>
        /// <param name="name">The name of an existing element.</param>
        /// <param name="numberPoints">The number of point elements that define the element.</param>
        /// <param name="points">The names of the points that defined the element.
        /// The point names are listed in the positive order around the element.</param>
        void GetPoints(string name, 
            ref int numberPoints, 
            ref string[] points);
    }
}
