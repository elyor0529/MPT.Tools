﻿
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Constraint types available in the application.
    /// </summary>
    public enum eConstraintType
    {
        /// <summary>
        /// Body constraint.
        /// </summary>
        Body = 1,

        /// <summary>
        /// Diaphragm constraint.
        /// </summary>
        Diaphragm = 2,

        /// <summary>
        /// Plate constraint.
        /// </summary>
        Plate = 3,

        /// <summary>
        /// Rod constraint.
        /// </summary>
        Rod = 4,

        /// <summary>
        /// Beam constraint.
        /// </summary>
        Beam = 5,

        /// <summary>
        /// Equal constraint.
        /// </summary>
        Equal = 6,

        /// <summary>
        /// Local constraint.
        /// </summary>
        Local = 7,

        /// <summary>
        /// Weld constraint.
        /// </summary>
        Weld = 8,

        /// <summary>
        /// Line constraint.
        /// </summary>
        Line = 13
    }
}
