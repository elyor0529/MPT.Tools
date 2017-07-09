
using MPT.CSI.API.Core.Helpers;

namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Object can set and return local axes rotational offset.
    /// </summary>
    public interface ILocalAxes
    {
        /// <summary>
        /// This function retrieves the local axis angle assignment of the object.
        /// </summary> 
        /// <param name="name">The name of an existing object.</param>
        /// <param name="angleOffset">This is the angle 'a' that the local 1 and 2 axes are rotated about the positive local 3 axis from the default orientation. 
        /// The rotation for a positive angle appears counter clockwise when the local +3 axis is pointing toward you. [deg]</param>
        /// <param name="isAdvanced">True object local axes orientation was obtained using advanced local axes parameters.</param>
        void GetLocalAxes(string name,
            ref AngleLocalAxes angleOffset,
            ref bool isAdvanced);

        /// <summary>
        /// This function retrieves the local axis angle assignment for the object.
        /// </summary> 
        /// <param name="name">The name of an existing object or group, depending on the value of the <paramref name="itemType"/> item.</param>
        /// <param name="angleOffset">This is the angle 'a' that the local 2 and 3 axes are rotated about the positive local 1 axis, from the default orientation. 
        /// The rotation for a positive angle appears counter clockwise when the local +1 axis is pointing toward you. [deg]</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignment is made to the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignment is made to all objects in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, assignment is made to all selected objects, and the <paramref name="name"/> item is ignored.</param>
        void SetLocalAxes(string name,
            AngleLocalAxes angleOffset,
            eItemType itemType = eItemType.Object);
    }
}
