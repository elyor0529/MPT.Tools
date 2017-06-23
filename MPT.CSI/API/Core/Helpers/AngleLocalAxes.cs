
namespace MPT.CSI.API.Core.Helpers
{
    /// <summary>
    /// Local axes definition by angle rotation from the original local axes.
    /// The order of rotations is cricital to achieving a correct transformation.
    /// </summary>
    public struct AngleLocalAxes
    {
        /// <summary>
        /// Rotate about the 3 axis by <see cref="AngleA"/> [deg].
        /// </summary>
        public double AngleA { get; set; }

        /// <summary>
        /// From <see cref="AngleA"/>, rotate about the resulting 2 axis by <see cref="AngleB"/> [deg].
        /// </summary>
        public double AngleB { get; set; }

        /// <summary>
        /// From <see cref="AngleB"/>, rotate about the resulting 1 axis by <see cref="AngleC"/> [deg].
        /// </summary>
        public double AngleC { get; set; }
    }
}
