
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Depends on the eLayoutCurveType.
    /// TODO: This is not to be used as an enum, but a reference for later object behavior.
    /// </summary>
    public enum eLayoutCurveValue2
    {
        /// <summary>
        /// Not used.
        /// </summary>
        NotUsed = 0,

        /// <summary>
        /// Not used.
        /// </summary>
        NotUsed1 = 1,

        /// <summary>
        /// Curve length, including length of spirals on either end. [L].
        /// </summary>
        CurveLength = 2,

        /// <summary>
        /// Rate at which the slope of a parabolic curve is changing in percent. [1/L].
        /// </summary>
        CurveSlopeChange = 3,

        /// <summary>
        /// Number of discretization points.
        /// </summary>
        NumberDiscretionPts = 4,

        /// <summary>
        /// Number of discretization points.
        /// </summary>
        NumberDiscretionPts1 = 5,

        /// <summary>
        /// Not used.
        /// </summary>
        NotUsed6 = 6,

        /// <summary>
        /// Not used.
        /// </summary>
        NotUsed7 = 7
    }
}
