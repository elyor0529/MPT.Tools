﻿#if BUILD_ETABS2015 || BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Diaphragm options available in the application.
    /// </summary>
    public enum eDiaphragmOption
    {
        /// <summary>
        /// The object is disconnected from any diaphragm.
        /// </summary>
        Disconnect = 1,

        /// <summary>
        /// The object inherits the diaphragm assignment of its bounding area object.
        /// </summary>
        FromShellObject = 2,

        /// <summary>
        /// The object is assigned to the existing diaphragm specified by the diaphragm name.
        /// </summary>
        DefinedDiaphragm = 3
    }
}
#endif