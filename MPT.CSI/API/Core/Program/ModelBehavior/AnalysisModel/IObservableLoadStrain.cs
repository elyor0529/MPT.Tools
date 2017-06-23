
namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel
{
    /// <summary>
    /// Object can return strain load data.
    /// </summary>
    public interface IObservableLoadStrain
    {
        /// <summary>
        /// This function retrieves the strain load assignments to elements.
        /// </summary>
        /// <param name="name">The name of an existing object, element or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="numberItems">The total number of strain loads retrieved for the specified elements.</param>
        /// <param name="names">The name of the element associated with each strain load.</param>
        /// <param name="loadPatterns">The name of the load pattern associated with each strain load.</param>
        /// <param name="component">Indicates the strain component associated with each strain load.</param>
        /// <param name="strainLoadValues">The strain values. [L/L]</param>
        /// <param name="jointPatternNames">The joint pattern name, if any, used to specify each strain load.</param>
        /// <param name="itemType">If this item is <see cref="eItemTypeElement.ObjectElement"/>, the load assignments are retrieved for the elements corresponding to the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemTypeElement.Element"/>, the load assignments are retrieved for the element specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemTypeElement.GroupElement"/>, the load assignments are retrieved for the elements corresponding to all objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemTypeElement.SelectionElement"/>, the load assignments are retrieved for elements corresponding to all selected objects, and the <paramref name="name"/> item is ignored.</param>
        void GetLoadStrain(string name,
            ref int numberItems,
            ref string[] names,
            ref string[] loadPatterns,
            ref eStrainComponent[] component,
            ref double[] strainLoadValues,
            ref string[] jointPatternNames,
            eItemTypeElement itemType = eItemTypeElement.Element);
    }
}
