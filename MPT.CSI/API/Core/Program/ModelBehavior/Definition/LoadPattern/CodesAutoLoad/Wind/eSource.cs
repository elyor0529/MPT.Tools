﻿#if !BUILD_ETABS2015 && !BUILD_ETABS2016
using System.ComponentModel;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.CodesAutoLoad.Wind
{
    /// <summary>
    /// List source to use for auto load method or values.
    /// </summary>
    public enum eSource
    {
        /// <summary>
        /// Per code.
        /// </summary>
        [Description("Per Code")]
        PerCode = 1,

        /// <summary>
        /// User defined.
        /// </summary>
        [Description("User Defined")]
        UserDefined = 2
    }
}
#endif
