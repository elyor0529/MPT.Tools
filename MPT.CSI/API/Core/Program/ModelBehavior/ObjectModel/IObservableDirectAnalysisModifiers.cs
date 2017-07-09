﻿namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Object has observable direct analysis modifiers.
    /// </summary>
    public interface IObservableDirectAnalysisModifiers
    {
        /// <summary>
        /// This function gets the modification factors for axial and flexural stiffness for a frame object if the Direct Analysis method is used.
        /// TODO: Handle? The function will return nonzero the modification factors are not available for the frame object.
        /// </summary>
        /// <param name="name">The name of an existing frame section whose design type is Steel Frame design.</param>
        /// <param name="EAModifier">The modification factor for axial stiffness if the Direct Analysis method is used.</param>
        /// <param name="EIModifier">The modification factor for flexural stiffness if the Direct Analysis method is used.</param>
        void GetDirectAnalysisModifiers(string name,
            ref double EAModifier,
            ref double EIModifier);
    }
}