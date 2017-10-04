﻿namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property
{
    /// <summary>
    /// Material types available in the program.
    /// </summary>
    public enum eMaterialPropertyType
    {
        /// <summary>
        /// The steel material.
        /// </summary>
        Steel = 1,

        /// <summary>
        /// The concrete material.
        /// </summary>
        Concrete = 2,

        /// <summary>
        /// The no design material.
        /// </summary>
        NoDesign = 3,

#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        /// <summary>
        /// The aluminum material.
        /// </summary>
        Aluminum = 4,

        /// <summary>
        /// The cold formed material.
        /// </summary>
        ColdFormed = 5,
#endif

        /// <summary>
        /// The rebar material.
        /// </summary>
        Rebar = 6,

        /// <summary>
        /// The tendon material.
        /// </summary>
        Tendon = 7,

#if BUILD_ETABS2015 || BUILD_ETABS2016        
        /// <summary> material.
        /// The masonry
        /// </summary>
        Masonry = 8,
#endif

    }
}
