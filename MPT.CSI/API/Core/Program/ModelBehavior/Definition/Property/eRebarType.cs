namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Rebar type used in a concrete frame. 
    /// This determines the rebar detailing available, and whether a frame is treated as a beam or a column.
    /// </summary>
    public enum eRebarType
    {
        /// <summary>
        /// None specified.
        /// </summary>
        None = 0,

        /// <summary>
        /// Column design.
        /// </summary>
        Column = 1,

        /// <summary>
        /// Beam design.
        /// </summary>
        Beam = 2
    }
}
