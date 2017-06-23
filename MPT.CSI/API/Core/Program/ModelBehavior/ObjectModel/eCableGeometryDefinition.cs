namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Cable definition used in the program for defining cable geometry.
    /// </summary>
    public enum eCableGeometryDefinition
    {


        /// <summary>
        /// Minimum tension at I-End.
        /// </summary>
        MinTensionIEnd = 1,

        /// <summary>
        /// Minimum tension at J-End.
        /// </summary>
        MinTensionJEnd = 2,

        /// <summary>
        /// Tension at I-End.
        /// </summary>
        TensionIEnd = 3,

        /// <summary>
        /// Tension at J-End.
        /// </summary>
        TensionJEnd = 4,

        /// <summary>
        /// Horizontal tension component.
        /// </summary>
        HorizontalTensionComponent = 5,

        /// <summary>
        /// Maximum vertical sag.
        /// </summary>
        MaximumVerticalSag = 6,

        /// <summary>
        /// Low-point vertical sag.
        /// </summary>
        LowPointVerticalSag = 7,

        /// <summary>
        /// Undeformed length.
        /// </summary>
        UndeformedLength = 8,

        /// <summary>
        /// Relative undeformed length.
        /// </summary>
        RelativeUndeformedLength = 9
    }
}
