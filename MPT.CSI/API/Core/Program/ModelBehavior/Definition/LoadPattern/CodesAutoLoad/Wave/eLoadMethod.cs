#if !BUILD_ETABS2015 && !BUILD_ETABS2016
using System.ComponentModel;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.CodesAutoLoad.Wave
{
    /// <summary>
    /// Auto load method types.
    /// </summary>
    public enum eLoadMethod
    {
        /// <summary>
        /// Rotations / Translations Vertical Input.
        /// </summary>
        [Description("Rotations / Translations Vertical Input")]
        RotationsTranslationsVerticalInput = 1,

        /// <summary>
        /// Rotations / Translations Full Input.
        /// </summary>
        [Description("Rotations / Translations Full Input")]
        RotationsTranslationsFullInput = 2,

        /// <summary>
        /// Accelerations / Velocities Input.
        /// </summary>
        [Description("Accelerations / Velocities Input")]
        AccelerationsVelocitiesInput = 3,
    }
}
#endif

