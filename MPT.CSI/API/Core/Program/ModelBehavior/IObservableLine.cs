
using MPT.CSI.API.Core.Helpers;

namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Object can return line-unique properties.
    /// </summary>
    public interface IObservableLine
    {

        /// <summary>
        /// This function retrieves line element insertion point assignments. 
        /// The assignments are reported as end joint offsets.
        /// </summary>
        /// <param name="name">The name of an existing line element.</param>
        /// <param name="offsetDistancesI">Three joint offset distances, in the Global coordinate system, at the I-End of the line element. [L]</param>
        /// <param name="offsetDistancesJ">Three joint offset distances, in the Global coordinate system, at the J-End of the line element. [L]</param>
        void GetInsertionPoint(string name,
            ref Displacements offsetDistancesI,
            ref Displacements offsetDistancesJ);



        
    }
}
