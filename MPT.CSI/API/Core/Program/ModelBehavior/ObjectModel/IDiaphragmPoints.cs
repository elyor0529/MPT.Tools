﻿#if BUILD_ETABS2015 || BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Implements gettable/settable diaphragms to points.
    /// </summary>
    public interface IDiaphragmPoints
    {
        /// <summary>
        /// Retrieves the diaphragm for a specified point object.
        /// </summary>
        /// <param name="name">The name of an existing point object.</param>
        /// <param name="diaphragmOption">The diaphragm option.</param>
        /// <param name="diaphragmName">The name of an existing diaphragm. 
        /// This item will only be filled if <paramref name="diaphragmOption"/> = <see cref="eDiaphragmOption.DefinedDiaphragm"/>.</param>
        void GetDiaphragm(string name,
            ref eDiaphragmOption diaphragmOption,
            ref string diaphragmName);

        /// <summary>
        /// Assigns a diaphragm to a point object .
        /// </summary>
        /// <param name="name">The name of an existing point object.</param>
        /// <param name="diaphragmOption">The diaphragm option.</param>
        /// <param name="diaphragmName">The name of an existing diaphragm.</param>
        void SetDiaphragm(string name,
            eDiaphragmOption diaphragmOption,
            string diaphragmName = "");
    }
}
#endif