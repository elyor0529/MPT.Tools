﻿using NPoint = System.Windows.Point;

namespace MPT.Geometry.Line
{
    /// <summary>
    /// Interface for all shapes that incorporate elements of a curve.
    /// </summary>
    public interface ICurve : IPathSegment
    {
        /// <summary>
        /// Point representing the center of the circular arc, which lies at a distance of the radius form either end point.
        /// </summary>
        NPoint Center { get; }
        
        /// <summary>
        /// Radius of the curve.
        /// </summary>
        double Radius { get; }

        /// <summary>
        /// Total length of the curve (radius*angle).
        /// </summary>
        double ArcLength { get; }

        /// <summary>
        /// The curvature of the line (1/radius).
        /// </summary>
        double Curvature { get; }

        /// <summary>
        /// Angle between the rays that connect each end of the curve to the common origin [radians].
        /// </summary>
        double Angle { get; }

        /// <summary>
        /// Angle between the rays that connect each end of the curve to the common origin [degrees].
        /// </summary>
        double AngleDegrees { get; }

        /// <summary>
        /// Angle that is tangent to the slope of the curve [radians].
        /// </summary>
        /// <param name="angleNormal">Angle [radians] along the curve sweep where the tangential angle is desired.</param>
        double TangentialAngle(double angleNormal);

        /// <summary>
        /// Angle that is normal to the slope of the curve [radians].
        /// </summary>
        /// <param name="angleTangential">The slope of the curve [radians] where the normal angle is desired.</param>
        /// <returns></returns>
        double NormalAngle(double angleTangential);
    }
}
