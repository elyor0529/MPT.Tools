
namespace MPT.CSI.API.Core
{
    /// <summary>
    /// Rebar type used in a concrete frame. 
    /// This determines the rebar detailing available, and whether a frame is treated as a beam or a column.
    /// </summary>
    public enum eRebarType
    {
        None = 0,
        Column = 1,
        Beam = 2
    }
}
