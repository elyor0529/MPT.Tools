﻿namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Object has CRUDabe mass properties.
    /// </summary>
    public interface IMass
    {
        /// <summary>
        /// This function retrieves the mass per unit area assignment for area objects.
        /// </summary>
        /// <param name="name">The name of an existing object.</param>
        /// <param name="value">The mass per unit area or length assigned to the object. [M/L^2] or [M/L]</param>
        void GetMass(string name,
            ref double value);

        /// <summary>
        /// This function assigns mass per unit area to objects.
        /// </summary>
        /// <param name="name">The name of an existing object or group, depending on the value of the <paramref name="itemType"/> item.</param>
        /// <param name="value">The mass per unit area or length assigned to the object. [M/L^2] or [M/L]</param>
        /// <param name="replace">True: All existing mass assignments to the object are removed before assigning the specified mass. 
        /// False: The specified mass is added to any existing mass already assigned to the object.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are made for the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are made for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are made for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        void SetMass(string name,
            double value,
            bool replace,
            eItemType itemType = eItemType.Object);

        /// <summary>
        /// This function deletes all mass assignments for the specified objects.
        /// </summary>
        /// <param name="name">The name of an existing object or group, depending on the value of the <paramref name="itemType"/> item.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are deleted for the objects specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are deleted for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are deleted for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        void DeleteMass(string name,
            eItemType itemType = eItemType.Object);
    }
}