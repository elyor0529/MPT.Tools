namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Mesh types available for automeshing in the application.
    /// </summary>
    public enum eMeshType
    {

        /// <summary>
        /// No automatic meshing.
        /// </summary>
        None = 0,

        /// <summary>
        /// Mesh solid into a specified number of ob.
        /// </summary>
        SpecifiedNumber = 1,

        /// <summary>
        /// Mesh solid into objects of a specified maximum size.
        /// </summary>
        SpecifiedMaxSize = 2
    }
}
