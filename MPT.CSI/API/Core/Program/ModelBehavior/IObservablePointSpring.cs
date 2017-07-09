using MPT.CSI.API.Core.Helpers;

namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Object can return point spring data.
    /// </summary>
    public interface IObservablePointSpring
    {
        /// <summary>
        /// This function returns the total number of point elements in the model with spring assignments.
        /// </summary>
        int CountSpring();

        /// <summary>
        /// This function retrieves uncoupled spring stiffness assignments for a point element; 
        /// that is, it retrieves the diagonal terms in the 6x6 spring matrix for the point element.
        /// The spring stiffnesses reported are the sum of all springs assigned to the point element either directly or indirectly through line, area and solid spring assignments. 
        /// The spring stiffness values are reported in the point local coordinate system.</summary>
        /// <param name="name">The name of an existing point element.</param>
        /// <param name="stiffnesses">Spring stiffness values for each decoupled degree of freedom.</param>
        void GetSpring(string name,
            ref Stiffness stiffnesses);

        /// <summary>
        /// This function retrieves coupled spring stiffness assignments for a point element; 
        /// that is, it retrieves the spring matrix of 21 stiffness values for the point element.
        /// The spring stiffnesses reported are the sum of all springs assigned to the point element either directly or indirectly through line, area and solid spring assignments. 
        /// The spring stiffness values are reported in the point local coordinate system.</summary>
        /// <param name="name">The name of an existing point element.</param>
        /// <param name="stiffnesses">Spring stiffness values for each coupled degree of freedom.</param>
        void GetSpringCoupled(string name,
            ref StiffnessCoupled stiffnesses);



        /// <summary>
        /// This function indicates if the spring assignments to a point element are coupled, that is, if there are off-diagonal terms in the 6x6 spring matrix for the point element.
        /// </summary>
        /// <param name="name">The name of an existing point element.</param>
        bool IsSpringCoupled(string name);

    }
}
