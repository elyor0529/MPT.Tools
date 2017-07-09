namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Mesh types available for meshing in the application.
    /// </summary>
    public enum eMeshType
    {

        /// <summary>
        /// No automatic meshing.
        /// </summary>
        None = 0,

        /// <summary>
        /// Mesh into a specified number of objects.
        /// </summary>
        SpecifiedNumber = 1,

        /// <summary>
        /// Mesh into objects of a specified maximum size.
        /// </summary>
        SpecifiedMaxSize = 2,

        /// <summary>
        /// Mesh based on points on area edge.
        /// Only applies to area objects.
        /// </summary>
        PointsOnAreaEdges = 3,

        /// <summary>
        /// Cookie cut mesh based on lines intersecting edges.
        /// Only applies to area objects.
        /// </summary>
        CookieCutLinesIntersectingEdges = 4,

        /// <summary>
        /// Cookie cut mesh based on points.
        /// Only applies to area objects.
        /// </summary>
        CookieCutPoints = 5,

        /// <summary>
        /// Mesh using General Divide Tool.
        /// Only applies to area objects.
        /// </summary>
        GeneralDivideTool = 6
    }
}
