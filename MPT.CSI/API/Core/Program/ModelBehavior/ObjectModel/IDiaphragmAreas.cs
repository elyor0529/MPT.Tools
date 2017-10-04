#if BUILD_ETABS2015 || BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Implements gettable/settable diaphragms to areas.
    /// </summary>
    public interface IDiaphragmAreas
    {
        /// <summary>
        /// Retrieves the diaphragm for a specified area object.
        /// </summary>
        /// <param name="name">The name of an existing object.</param>
        /// <param name="diaphragmName">The name of an existing diaphragm.</param>
        void GetDiaphragm(string name,
            ref string diaphragmName);

        /// <summary>
        /// Assigns an existing diaphragm to an area object .
        /// </summary>
        /// <param name="name">The name of an existing object.</param>
        /// <param name="diaphragmName">The name of an existing diaphragm.</param>
        void SetDiaphragm(string name,
            string diaphragmName);
    }
}
#endif