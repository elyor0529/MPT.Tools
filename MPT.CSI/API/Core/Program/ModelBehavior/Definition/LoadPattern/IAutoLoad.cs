
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern
{
    /// <summary>
    /// Implements a design interface for all auto load types.
    /// </summary>
    public interface IAutoLoad
    {
        #region Methods: Public

        /// <summary>
        /// This function retrieves the code name used for auto parameters in auto load patterns.
        /// An error is returned if the specified load pattern is not an auto load pattern.
        /// TODO: Handle this.
        /// </summary>
        /// <param name="name">The name of an existing auto load pattern.</param>
        /// <param name="codeName">This is either blank or the name code used for the auto parameters. 
        /// Blank means no auto load is specified for the auto load pattern.</param>
        void GetAutoCode(string name,
                            ref string codeName);

        /// <summary>
        /// This function sets the auto loading type for the specified load pattern to None.
        /// </summary>
        /// <param name="name">The name of an existing auto load pattern.</param>
        void SetNone(string name);

        #endregion
    }
}
