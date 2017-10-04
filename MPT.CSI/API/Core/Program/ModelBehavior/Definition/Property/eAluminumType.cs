#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Types of aluminum.
    /// </summary>
    public enum eAluminumType
    {
        /// <summary>
        /// Wrought aluminum.
        /// </summary>
        Wrought = 1,

        /// <summary>
        /// Cast-mold aluminum.
        /// </summary>
        CastMold = 2,

        /// <summary>
        /// Cast-sand aluminum.
        /// </summary>
        CastSand = 3
    }
}
#endif