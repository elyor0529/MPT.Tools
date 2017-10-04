﻿namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Shell types available in the applicaion.
    /// </summary>
    public enum eShellType
    {
        /// <summary>
        /// Shell-thin section.
        /// </summary>
        ShellThin = 1,

        /// <summary>
        /// Shell-thick section.
        /// </summary>
        ShellThick = 2,

#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        /// <summary>
        /// Plate-thin section.
        /// </summary>
        PlateThin = 3,

        /// <summary>
        /// Plate-thick section.
        /// </summary>
        PlateThick = 4,

        /// <summary>
        /// Membrane section.
        /// </summary>
        Membrane = 5,
#else
        /// <summary>
        /// Membrane section.
        /// </summary>
        Membrane = 3,
#endif

        /// <summary>
        /// Shell layered/nonlinear section.
        /// </summary>
        ShellLayered = 6
    }
}
