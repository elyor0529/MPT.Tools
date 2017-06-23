﻿using System.Collections.Generic;
using NPoint = System.Windows.Point;

namespace MPT.Geometry.Line
{
    /// <summary>
    /// Interface related to line geometries in polar coordinates.
    /// </summary>
    public interface IPolarCoordinates
    {
        /// <summary>
        /// First coordinate value {radius, rotation[radians]}.
        /// </summary>
        KeyValuePair<double,double> IPolar { get; }

        /// <summary>
        /// Second coordinate value {radius, rotation[radians]}.
        /// </summary>
        KeyValuePair<double, double> JPolar { get; }

        /// <summary>
        /// Length of the path segment [radians].
        /// </summary>
        /// <returns></returns>
        double LengthPolar();


        /// <summary>
        /// Polar-coordinates of the centroid of the line {radius, rotation[radians]}.
        /// </summary>
        /// <returns></returns>
        KeyValuePair<double, double> CentroidPolar();

        /// <summary>
        /// X-coordinate on the path that corresponds to the polar-coordinate given.
        /// </summary>
        /// <param name="theta">Rotation-coordinate for which an x-coordinate is desired.</param>
        /// <returns></returns>
        double XPolar(double theta);

        /// <summary>
        /// Y-coordinate on the path that corresponds to the polar-coordinate given.
        /// </summary>
        /// <param name="theta">Rotation-coordinate for which a y-coordinate is desired [radians].</param>
        /// <returns></returns>
        double YPolar(double theta);


        /// <summary>
        /// Coordinate on the path that corresponds to the position along the path.
        /// </summary>
        /// <param name="theta">The relative position along the path [radians].</param>
        /// <returns></returns>
        NPoint PointByPathPositionPolar(double theta);

        /// <summary>
        /// Vector that is normal to the line connecting the defining points at the position specified.
        /// </summary>
        /// <param name="theta">The relative position along the path [radians].</param>
        NPoint NormalVectorPolar(double theta);

        /// <summary>
        /// Vector that is tangential to the line connecting the defining points at the position specified.
        /// </summary>
        /// <param name="theta">The relative position along the path [radians].</param>
        NPoint TangentVectorPolar(double theta);
    }
}
