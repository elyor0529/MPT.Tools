using MPT.CSI.API.Core.Helpers;
using MPT.CSI.API.Core.Program.ModelBehavior.Definition;

namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Object can assign line-unique properties.
    /// </summary>
    public interface IChangeableLine
    {
        /// <summary>
        /// This function assigns line object insertion point assignments. 
        /// The assignments are reported as end joint offsets.
        /// </summary>
        /// <param name="name">The name of an existing line object.</param>
        /// <param name="isMirroredLocal2">True: The object section is assumed to be mirrored (flipped) about its local 2-axis.</param>
        /// <param name="isStiffnessTransformed">True: The object stiffness is transformed for cardinal point and joint offsets from the section centroid.</param>
        /// <param name="offsetDistancesI">Three joint offset distances, in the Global coordinate system, at the I-End of the line object. [L]</param>
        /// <param name="offsetDistancesJ">Three joint offset distances, in the Global coordinate system, at the J-End of the line object. [L]</param>
        /// <param name="coordinateSystem">This is <see cref="ePDeltaDirection.Local_1"/> or the name of a defined coordinate system. 
        /// It is the coordinate system in which the <paramref name="offsetDistancesI"/> and <paramref name="offsetDistancesJ"/> items are specified.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are set for the objects specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are set for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are set for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        void SetInsertionPoint(string name,
            bool isMirroredLocal2,
            bool isStiffnessTransformed,
            Displacements offsetDistancesI,
            Displacements offsetDistancesJ,
            string coordinateSystem = CoordinateSystems.Global,
            eItemType itemType = eItemType.Object);
 

    }
}
