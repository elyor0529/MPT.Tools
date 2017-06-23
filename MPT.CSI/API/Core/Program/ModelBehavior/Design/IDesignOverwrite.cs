
namespace MPT.CSI.API.Core.Program.ModelBehavior.Design
{
    /// <summary>
    /// Implements a design interface for all design overwrites.
    /// </summary>
    public interface IDesignOverwrite
    {
        #region Properties
        /// <summary>
        /// Name of the design code used.
        /// </summary>
        string CodeName { get; set; }
        #endregion

        #region Methods: Public
        /// <summary>
        /// Retrieves the value of a design overwrite item.
        /// </summary>
        /// <param name="nameFrame">Name of an object with a corresponding design procedure.</param>
        /// <param name="overwrite">Object containing the paired overwrite name/value codes.</param>
        void GetOverwrite(string nameFrame, DesignOverwriteItem overwrite);

        /// <summary>
        /// Sets the value of a design overwrite item.
        /// </summary>
        /// <param name="nameFrame">Name of an object with a corresponding design procedure.</param>
        /// <param name="overwrite">Object containing the paired overwrite name/value codes.</param>
        /// <param name="itemType">Selection type to use for applying the method.</param>
        void SetOverwrite(string nameFrame, DesignOverwriteItem overwrite, eItemType itemType = eItemType.Object);

        /// <summary>
        /// Retrieves the value of a design preference item.
        /// </summary>
        /// <param name="preference">>Object containing the paired preference name/value codes.</param>
        void GetPreference(ref DesignPreferenceItem preference);

        /// <summary>
        /// Sets the value of a design preference item.
        /// </summary>
        /// <param name="preference">Object containing the paired preference name/value codes.</param>
        void SetPreference(DesignPreferenceItem preference);

        #endregion
    }
}
