namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Object can be selected or checked for selection.
    /// </summary>
    public interface ISelectable
    {
        /// <summary>
        /// This function retrieves the selected status for an object.
        /// </summary>
        /// <param name="name">The name of an existing object.</param>
        /// <param name="isSelected">True: The specified object is selected.</param>
        void GetSelected(string name, 
            ref bool isSelected);

        /// <summary>
        /// This function retrieves the selected status for an object.
        /// </summary>
        /// <param name="name">The name of an existing object.</param>
        /// <param name="isSelected">True: The specified object is selected.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the selected status is set for the objects specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the selected status is set for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the selected status is set for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        void SetSelected(string name,
            bool isSelected,
            eItemType itemType = eItemType.Object);
    }
}