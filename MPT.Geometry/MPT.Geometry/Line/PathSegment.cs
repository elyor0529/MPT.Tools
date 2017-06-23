﻿using NPoint = System.Windows.Point;

using MPT.Math;

using GL = MPT.Geometry.GeometryLibrary;

namespace MPT.Geometry.Line
{
    /// <summary>
    /// Base class used for segment types.
    /// </summary>
    public abstract class PathSegment : IPathSegment
    {
        #region Properties
        /// <summary>
        /// Tolerance to use in all calculations with double types.
        /// </summary>
        public double Tolerance { get; set; } = GL.ZeroTolerance;

        /// <summary>
        /// First coordinate value.
        /// </summary>
        public NPoint I { get; set; }

        /// <summary>
        /// Second coordinate value.
        /// </summary>
        public NPoint J { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes the segment with empty points.
        /// </summary>
        protected PathSegment() { }

        /// <summary>
        /// Initializes the segment to span between the provided points.
        /// </summary>
        /// <param name="i">First point of the line.</param>
        /// <param name="j">Second point of the line.</param>
        protected PathSegment(NPoint i, NPoint j)
        {
            I = i;
            J = j;
        }
        #endregion

        #region Methods: Public
        /// <summary>
        /// Vector that is tangential to the line connecting the defining points.
        /// </summary>
        /// <returns></returns>
        public Vector TangentVector()
        {
            return GL.TangentVector(I, J);
        }

        /// <summary>
        /// Vector that is normal to the line connecting the defining points.
        /// </summary>
        /// <returns></returns>
        public Vector NormalVector()
        {
            return GL.NormalVector(I, J);
        }

        #endregion

        #region Methods: Abstract

        /// <summary>
        /// Length of the path segment.
        /// </summary>
        /// <returns></returns>
        public abstract double Length();


        /// <summary>
        /// X-coordinate of the centroid of the line.
        /// </summary>
        /// <returns></returns>
        public abstract double Xo();

        /// <summary>
        /// Y-coordinate of the centroid of the line.
        /// </summary>
        /// <returns></returns>
        public abstract double Yo();

        /// <summary>
        /// X-coordinate on the line segment that corresponds to the y-coordinate given.
        /// </summary>
        /// <param name="y">Y-coordinate for which an x-coordinate is desired.</param>
        /// <returns></returns>
        public abstract double X(double y);

        /// <summary>
        /// Y-coordinate on the line segment that corresponds to the x-coordinate given.
        /// </summary>
        /// <param name="x">X-coordinate for which a y-coordinate is desired.</param>
        /// <returns></returns>
        public abstract double Y(double x);

        /// <summary>
        /// Coordinate on the path that corresponds to the position along the path.
        /// </summary>
        /// <param name="sRelative">The relative position along the path.</param>
        /// <returns></returns>
        public abstract NPoint PointByPathPosition(double sRelative);

        /// <summary>
        /// Vector that is normal to the line connecting the defining points at the position specified.
        /// </summary>
        /// <param name="sRelative">The relative position along the path.</param>
        public abstract Vector NormalVector(double sRelative);

        /// <summary>
        /// Vector that is tangential to the line connecting the defining points at the position specified.
        /// </summary>
        /// <param name="sRelative">The relative position along the path.</param>
        public abstract Vector TangentVector(double sRelative);

        #endregion

    }
}
