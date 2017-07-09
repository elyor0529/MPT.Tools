﻿namespace MPT.CSI.API.Core.Program.ModelBehavior.Edit
{
    /// <summary>
    /// Method by which a point object is aligned.
    /// </summary>
    public enum ePointAlignOption
    {
        /// <summary>
        /// Align points to X-ordinate in present coordinate system.
        /// </summary>
        XOrdinate = 1,

        /// <summary>
        /// Align points to Y-ordinate in present coordinate system.
        /// </summary>
        YOrdinate = 2,

        /// <summary>
        /// Align points to Z-ordinate in present coordinate system.
        /// </summary>
        ZOrdinate = 3,

        /// <summary>
        /// Align points to nearest selected line object, area object edge or solid object edge.
        /// </summary>
        NearestLineOrEdge = 4
    }
}
