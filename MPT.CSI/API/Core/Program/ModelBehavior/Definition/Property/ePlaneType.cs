#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Plane types available in the application.
    /// </summary>
    public enum ePlaneType
    {
        /// <summary>
        /// Plane-stress.
        /// </summary>
        PlaneStress = 1,

        /// <summary>
        /// Plane-strain.
        /// </summary>
        PlaneStrain = 2
    }
}
#endif
