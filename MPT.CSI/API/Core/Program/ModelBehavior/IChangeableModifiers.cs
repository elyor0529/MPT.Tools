using MPT.CSI.API.Core.Helpers;

namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Object can have stiffness, weight, and mass modifiers set.
    /// </summary>
    public interface IChangeableModifiers
    {
        /// <summary>
        /// This function defines a modifier assignment. 
        /// The default value for all modifiers is one.
        /// </summary>
        /// <param name="name">The name of an existing element or object.</param>
        /// <param name="modifiers">Unitless modifiers.</param>
        void SetModifiers(string name, Modifier modifiers);
    }
}
