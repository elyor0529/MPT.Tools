
namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Object can return the property assignment name for a frequency-dependent link.
    /// </summary>
    public interface IObservableSectionFrequencyDependent
    {
        /// <summary>
        /// This function retrieves the frequency dependent property assignment to a link element. 
        /// If no frequency dependent property is assigned to the link, the PropName is returned as None.
        /// </summary>
        /// <param name="name">The name of an existing link element.</param>
        /// <param name="propertyName">The name of the frequency dependent link property assigned to the link element.</param>
        void GetSectionFrequencyDependent(string name, 
            string propertyName);
    }
}
