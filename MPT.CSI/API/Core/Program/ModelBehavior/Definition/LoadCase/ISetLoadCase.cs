﻿namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Load case can be set.
    /// </summary>
    public interface ISetLoadCase
    {
        /// <summary>
        /// This function initializes a load case. 
        /// If this function is called for an existing load case, all items for the case are reset to their default value.
        /// </summary>
        /// <param name="name">The name of an existing or new load case. 
        /// If this is an existing case, that case is modified; otherwise, a new case is added.</param>
        void SetCase(string name);
    }
}
