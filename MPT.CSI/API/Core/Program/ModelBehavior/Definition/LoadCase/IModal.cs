﻿namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Represents modal load cases in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase.ISetLoadCase" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase.IInitialLoadCase" />
    public interface IModal:
        ISetLoadCase, IInitialLoadCase
    {
        /// <summary>
        /// This function retrieves the number of modes requested for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing modal load case.</param>
        /// <param name="maxNumberModes">The maximum number of modes requested.</param>
        /// <param name="minNumberModes">The minimum number of modes requested.</param>
        void GetNumberModes(string name,
            ref int maxNumberModes,
            ref int minNumberModes);

        /// <summary>
        /// This function sets the number of modes requested for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing modal load case.</param>
        /// <param name="maxNumberModes">The maximum number of modes requested.</param>
        /// <param name="minNumberModes">The minimum number of modes requested.</param>
        void SetNumberModes(string name,
            int maxNumberModes,
            int minNumberModes);
    }
}
