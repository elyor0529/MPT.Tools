namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Load case uses modal case.
    /// </summary>
    public interface IModalCase
    {
        /// <summary>
        /// This function retrieves the modal case assigned to the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case.</param>
        /// <param name="modalCase">This is either None or the name of an existing modal analysis case. 
        /// It specifies the modal load case on which any mode-type load assignments to the specified load case are based.</param>
        void GetModalCase(string name,
            ref string modalCase);

#if !BUILD_ETABS2015 && !BUILD_ETABS2016
/// <summary>
        /// This function sets the modal case for the specified analysis case.
        /// If the specified modal case is not actually a modal case, the program automatically replaces it with the first modal case it can find. 
        /// If no modal load cases exist, an error is returned.
        /// TODO: Handle this.
        /// </summary>
        /// <param name="name">The name of an existing load case.</param>
        /// <param name="modalCase">This is either None or the name of an existing modal analysis case. 
        /// It specifies the modal load case on which any mode-type load assignments to the specified load case are based.</param>
        void SetModalCase(string name,
            string modalCase);
#endif
    }
}