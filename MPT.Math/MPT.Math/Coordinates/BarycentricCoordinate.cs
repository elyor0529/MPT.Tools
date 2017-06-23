
using NVector = System.Windows.Vector;

namespace MPT.Math.Coordinates
{
    // See: https://en.wikipedia.org/wiki/Barycentric_coordinate_system

    /// <summary>
    /// A coordinate system in which the location of a point of a simplex (a triangle, tetrahedron, etc.) is specified as the center of mass, or barycenter, of usually unequal masses placed at its vertices.
    /// </summary>
    public struct BarycentricCoordinate
    {

        public double Alpha { get; set; }


        public double Beta { get; set; }


        public double Gamma { get; set; }
        
        public CartesianCoordinate ToCartesian(NVector vertexA, NVector vertexB, NVector vertexC)
        {
            double x = Alpha * vertexA.X + Beta * vertexB.X + Gamma * vertexC.X;
            double y = Alpha * vertexA.Y + Beta * vertexB.Y + Gamma * vertexC.Y;

            return new CartesianCoordinate()
            {
                X = x,
                Y = y,
            };
        }


        public TrilinearCoordinate ToTrilinear(NVector vertexA, NVector vertexB, NVector vertexC)
        {
            double sideA = (vertexC - vertexB).Length;
            double sideB = (vertexA - vertexC).Length;
            double sideC = (vertexB - vertexA).Length;

            return new TrilinearCoordinate()
            {
                X = Alpha / sideA,
                Y = Beta / sideB,
                Z = Gamma / sideC
            };
        }
    }
}
