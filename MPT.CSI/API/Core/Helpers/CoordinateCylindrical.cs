﻿using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Helpers
{
    /// <summary>
    /// Coordinate by cylindrical values.
    /// </summary>
    public struct CoordinateCylindrical
    {
        /// <summary>
        /// The radius coordinate. [L]
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// The angle coordinate for the specified point. 
        /// The angle is measured in the XY plane from the positive X axis. 
        /// When looking in the XY plane with the positive Z axis pointing toward you, a positive angle is counter clockwise. [deg]
        /// </summary>
        public double Theta { get; set; }


        /// <summary>
        /// Coordinate along the Z-axis. [L]
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        /// Assigns array values to struct properties.
        /// Array must have 6 entries.
        /// </summary>
        /// <param name="coordinates">1x6 matrix of values of cylindrical coordinates along the corresponding degree of freedom:
        /// Value(0) = <see cref="Radius"/> [L];
        /// Value(1) = <see cref="Theta"/> [deg];
        /// Value(2) = <see cref="Z"/> [L];</param>
        public void FromArray(double[] coordinates)
        {
            if (coordinates.Length != 3)
            {
                throw new CSiException("Array has " + coordinates.Length + " elements when 3 elements was expected.");
            }
            Radius = coordinates[0];
            Theta = coordinates[1];
            Z = coordinates[2];
        }

        /// <summary>
        /// Return a 1x6 matrix of booleans indicating cylindrical coordinate:
        /// Value(0) = <see cref="Radius"/> [L];
        /// Value(1) = <see cref="Theta"/> [deg];
        /// Value(2) = <see cref="Z"/> [L];
        /// </summary>
        /// <returns></returns>
        public double[] ToArray()
        {
            double[] coordinates = { Radius, Theta, Z };
            return coordinates;
        }
    }
}
