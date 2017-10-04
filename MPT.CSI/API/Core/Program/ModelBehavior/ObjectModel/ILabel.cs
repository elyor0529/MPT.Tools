#if BUILD_ETABS2015 || BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Object can return label information. 
    /// </summary>
    public interface ILabel
    {
        /// <summary>
        /// Retrieves the label and story for a unique object name.
        /// </summary>
        /// <param name="name">The name of the object.</param>
        /// <param name="label">The object label.</param>
        /// <param name="story">The object story label.</param>
        void GetLabelFromName(string name,
            ref string label, 
            ref string story);

        /// <summary>
        /// Retrieves the names and labels of all defined objects.
        /// </summary>
        /// <param name="numberOfNames">The number of object names retrieved by the program.</param>
        /// <param name="names">The object names.</param>
        /// <param name="labels">The object labels.</param>
        /// <param name="stories">The story levels of the objects.</param>
        void GetLabelNameList(ref int numberOfNames,
            ref string[] names,
            ref string[] labels,
            ref string[] stories);

        /// <summary>
        /// Retrieves the unique name of an object, given the label and story level .
        /// </summary>
        /// <param name="label">The object label.</param>
        /// <param name="story">The object story level.</param>
        /// <param name="name">The object unique name.</param>
        void GetNameFromLabel(string label,
            string story,
            ref string name);

        /// <summary>
        /// This function retrieves the names of all defined object properties for a given story.
        /// </summary>
        /// <param name="storyName">Name of the story to filter the object names by.</param>
        /// <param name="numberOfNames">The number of object names retrieved by the program.</param>
        /// <param name="names">Object names retrieved by the program.</param>
        void GetNameListOnStory(string storyName, ref int numberOfNames, ref string[] names);
    }
}
#endif