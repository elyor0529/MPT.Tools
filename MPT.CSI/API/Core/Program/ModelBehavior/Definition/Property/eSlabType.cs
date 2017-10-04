#if BUILD_ETABS2015 || BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Slab types available in the applicaion.
    /// </summary>
    public enum eSlabType
    {
        /// <summary>
        /// Slab.
        /// </summary>
        Slab = 0,

        /// <summary>
        /// Drop slab.
        /// </summary>
        Drop = 1,

        // Do not use
        /// <summary>
        /// Stiff slab.
        /// </summary>
        // Stiff = 2,

        /// <summary>
        /// Ribbed slab.
        /// </summary>
        Ribbed = 3,

        /// <summary>
        /// Waffle slab.
        /// </summary>
        Waffle = 4


    }
}
#endif