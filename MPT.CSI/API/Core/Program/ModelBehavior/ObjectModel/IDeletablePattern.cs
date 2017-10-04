#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Object can delete its assigned joint pattern.
    /// </summary>
    public interface IDeletablePattern
    {

        /// <summary>
        /// This function deletes all joint pattern assignments, associated with the specified joint pattern, from the specified point object(s).
        /// </summary>
        /// <param name="name">The name of an existing object or group, depending on the value of the <paramref name="itemType"/> item.</param>
        /// <param name="patternName">The name of a defined joint pattern.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are made for the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are made for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are made for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        void DeletePatternValue(string name,
            string patternName,
            eItemType itemType = eItemType.Object);
    }
}
#endif