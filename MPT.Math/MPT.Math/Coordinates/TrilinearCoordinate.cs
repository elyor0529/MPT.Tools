
using NVector = System.Windows.Vector;

namespace MPT.Math.Coordinates
{
    // See: https://en.wikipedia.org/wiki/Trilinear_coordinates#Formulas

    /// <summary>
    /// A point relative to a given triangle describe the relative directed distances from the three sidelines of the triangle.
    /// </summary>
    public struct TrilinearCoordinate
    {

        public double X { get; set; }


        public double Y { get; set; }


        public double Z { get; set; }


        public CartesianCoordinate ToCartesian(NVector vertexA, NVector vertexB, NVector vertexC)
        {
            double sideA = (vertexC - vertexB).Length;
            double sideB = (vertexA - vertexC).Length;
            double sideC = (vertexB - vertexA).Length;

            double denominator = sideA * X + sideB * Y + sideC * Z;

            double weight1 = (sideA * X) / denominator;
            double weight2 = (sideB * Y) / denominator;
            double weight3 = (sideC * Z) / denominator;

            NVector pVector = weight1 * vertexA + weight2 * vertexB + weight3 * vertexC;

            return new CartesianCoordinate
            {
                X = pVector.X,
                Y = pVector.Y
            };
        }

        public BarycentricCoordinate ToBarycentric(NVector vertexA, NVector vertexB, NVector vertexC)
        {
            double sideA = (vertexC - vertexB).Length;
            double sideB = (vertexA - vertexC).Length;
            double sideC = (vertexB - vertexA).Length;

            return new BarycentricCoordinate
            {
                Alpha = X * sideA,
                Beta = Y * sideB,
                Gamma = Z * sideC
            };
        }
    }
}
