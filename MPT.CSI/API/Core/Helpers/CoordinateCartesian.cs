using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Helpers
{
    /// <summary>
    /// Coordinate by Cartesian values.
    /// </summary>
    public struct CoordinateCartesian
    {
        /// <summary>
        /// Coordinate along the X-axis. [L]
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Coordinate along the Y-axis. [L]
        /// </summary>
        public double Y { get; set; }


        /// <summary>
        /// Coordinate along the Z-axis. [L]
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        /// Assigns array values to struct properties.
        /// Array must have 6 entries.
        /// </summary>
        /// <param name="coordinates">1x6 matrix of values of Cartesian coordinates along the corresponding degree of freedom:
        /// Value(0) = <see cref="X"/> [L];
        /// Value(1) = <see cref="Y"/> [L];
        /// Value(2) = <see cref="Z"/> [L];</param>
        public void FromArray(double[] coordinates)
        {
            if (coordinates.Length != 3)
            {
                throw new CSiException("Array has " + coordinates.Length + " elements when 3 elements was expected.");
            }
            X = coordinates[0];
            Y = coordinates[1];
            Z = coordinates[2];
        }

        /// <summary>
        /// Return a 1x6 matrix of booleans indicating Cartesian coordinate:
        /// Value(0) = <see cref="X"/> [L];
        /// Value(1) = <see cref="Y"/> [L];
        /// Value(2) = <see cref="Z"/> [L];
        /// </summary>
        /// <returns></returns>
        public double[] ToArray()
        {
            double[] coordinates = {X, Y, Z};
            return coordinates;
        }
    }
}
