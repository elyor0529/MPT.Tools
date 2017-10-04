namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Object has countable panel zones.
    /// </summary>
    public interface ICountablePanelZone
    {
        /// <summary>
        /// This function returns the total number of panel zone assignments to point objects in the model.
        /// </summary>
        int CountPanelZone();
    }
}