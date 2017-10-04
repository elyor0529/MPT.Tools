﻿#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// The general reference line plan layout curve type.
    /// </summary>
    public enum eLayoutCurveType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,

        /// <summary>
        /// Circular curve.
        /// </summary>
        Circular = 1,

        /// <summary>
        /// Highway curve.
        /// </summary>
        Highway = 2,

        /// <summary>
        /// Parabolic curve.
        /// </summary>
        Parabolic = 3,

        /// <summary>
        /// Bezier curve.
        /// </summary>
        Bezier = 4,

        /// <summary>
        /// BSpline curve.
        /// </summary>
        BSpline = 5,

        /// <summary>
        /// Bezier child point.
        /// </summary>
        BezierChildPoint = 6,

        /// <summary>
        /// BSpline child point.
        /// </summary>
        BSplineChildPoint = 7
    }
}
#endif
