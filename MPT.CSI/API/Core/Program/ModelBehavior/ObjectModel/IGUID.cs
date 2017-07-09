namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Object has a GUID (Global Unique ID) that can be retrieved or changed.
    /// </summary>
    public interface IGUID
    {

        /// <summary>
        /// This function retrieves the GUID for the specified object. 
        /// </summary>
        /// <param name="name">The name of an existing object.</param>
        /// <param name="GUID">The GUID (Global Unique ID) for the specified object.</param>
        void GetGUID(string name,
            ref string GUID);

        /// <summary>
        /// This function sets the GUID for the specified object. 
        /// If the GUID is passed in as a blank string, the program automatically creates a GUID for the object.
        /// </summary>
        /// <param name="name">The name of an existing object.</param>
        /// <param name="GUID">The GUID (Global Unique ID) for the specified object.</param>
        void SetGUID(string name,
            string GUID = "");

    }
}