using MPT.CSI.API.Core.Helpers;
using MPT.CSI.API.Core.Program.ModelBehavior.Definition;

namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Object can assign frame-unique properties.
    /// </summary>
    public interface IChangeableFrame : IChangeableLine
    {
        /// <summary>
        /// This function assigns the P-Delta force assignments to frame objects.
        /// </summary>
        /// <param name="name">The name of an frame line object .</param>
        /// <param name="pDeltaForce">P-Delta force value assigned to the frame object. [F]</param>
        /// <param name="direction">The direction of the P-Delta force assignment.</param>
        /// <param name="replaceExistingLoads">True: All existing P-Delta force assignments to the frame object are removed before assigning the specified P-Delta force.  
        /// False: the specified P-Delta force is added to any existing P-Delta forces already assigned to the frame object.</param>
        /// <param name="coordinateSystem">The name of the coordinate system in which the projected P-Delta force is defined. 
        /// This item is blank when the <paramref name="direction"/> item is <see cref="ePDeltaDirection.Local_1"/>, that is, when the P-Delta force is defined in the frame object local 1-axis direction.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are set for the objects specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are set for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are set for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        void SetPDeltaForce(string name,
            double pDeltaForce,
            ePDeltaDirection direction,
            bool replaceExistingLoads,
            string coordinateSystem = CoordinateSystems.Global,
            eItemType itemType = eItemType.Object);

        /// <summary>
        /// This function assigns frame object insertion point data. 
        /// The assignments are reported as end joint offsets.
        /// </summary>
        /// <param name="name">The name of an existing frame object.</param>
        /// <param name="cardinalPoint">Specifies the cardinal point for the frame object. 
        /// The cardinal point specifies the relative position of the frame section on the line representing the frame object.</param>
        /// <param name="isMirroredLocal2">True: The frame object section is assumed to be mirrored (flipped) about its local 2-axis.</param>
        /// <param name="isStiffnessTransformed">True: The frame object stiffness is transformed for cardinal point and joint offsets from the frame section centroid.</param>
        /// <param name="offsetDistancesI">Three joint offset distances, in the Global coordinate system, at the I-End of the frame object. [L]</param>
        /// <param name="offsetDistancesJ">Three joint offset distances, in the Global coordinate system, at the J-End of the frame object. [L]</param>
        /// <param name="coordinateSystem">This is <see cref="ePDeltaDirection.Local_1"/> or the name of a defined coordinate system. 
        /// It is the coordinate system in which the <paramref name="offsetDistancesI"/> and <paramref name="offsetDistancesJ"/> items are specified.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are set for the objects specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are set for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are set for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        void SetInsertionPoint(string name,
            eInsertionPoint cardinalPoint,
            bool isMirroredLocal2,
            bool isStiffnessTransformed,
            Displacements offsetDistancesI,
            Displacements offsetDistancesJ,
            string coordinateSystem = CoordinateSystems.Global,
            eItemType itemType = eItemType.Object);
    }
}
