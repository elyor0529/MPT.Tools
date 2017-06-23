namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Object can return frame-unique properties.
    /// </summary>
    public interface IObservableFrame : IObservableLine
    {

        /// <summary>
        /// This function retrieves the line element end offsets along the 1-axis of the element.
        /// </summary>
        /// <param name="name">The name of an existing line element.</param>
        /// <param name="lengthIEnd">The offset length along the 1-axis of the line element at the I-End of the line element. [L]</param>
        /// <param name="lengthJEnd">The offset along the 1-axis of the line element at the J-End of the line element. [L]</param>
        /// <param name="rigidZoneFactor">The rigid zone factor.  
        /// This is the fraction of the end offset length assumed to be rigid for bending and shear deformations.</param>
        void GetEndLengthOffset(string name,
            ref double lengthIEnd,
            ref double lengthJEnd,
            ref double rigidZoneFactor);

        /// <summary>
        /// This function retrieves the P-Delta force assignments to line elements.
        /// </summary>
        /// <param name="name">The name of an existing line element.</param>
        /// <param name="numberForces">The number of P-Delta forces assigned to the line element.</param>
        /// <param name="pDeltaForces">P-Delta force values assigned to the line element. [F]</param>
        /// <param name="directions">The direction of each P-Delta force assignment.</param>
        /// <param name="coordinateSystems">This is an array that contains the name of the coordinate system in which each projected P-Delta force is defined. 
        /// This item is blank when the <paramref name="directions"/> item is <see cref="ePDeltaDirection.Local_1"/>, that is, when the P-Delta force is defined in the line element local 1-axis direction.</param>
        void GetPDeltaForce(string name,
            ref int numberForces,
            ref double[] pDeltaForces,
            ref ePDeltaDirection[] directions,
            ref string[] coordinateSystems);
    }
}
