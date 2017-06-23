

namespace MPT.CSI.API.Core
{
    /// <summary>
    /// Item type available for selection filtering.
    /// </summary>
    public enum eItemType
    {
        /// <summary>
        /// Object specified by GUID or name.
        /// </summary>
        Object = 0,

        /// <summary>
        /// Group specified by name.
        /// </summary>
        Group = 1,

        /// <summary>
        /// Objects currently selected in the program.
        /// </summary>
        SelectedObjects = 2
    }
}
