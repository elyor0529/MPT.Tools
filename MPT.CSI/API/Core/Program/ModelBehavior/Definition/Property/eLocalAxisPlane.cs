﻿#if BUILD_ETABS2015 || BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Local axes available in plane elements the applicaion.
    /// </summary>
    public enum eLocalAxisPlane
    {
        /// <summary>
        /// Local-1 axis.
        /// </summary>
        Local1 = 1,

        /// <summary>
        /// Local-2 axis.
        /// </summary>
        Local2 = 2
    }
}
#endif