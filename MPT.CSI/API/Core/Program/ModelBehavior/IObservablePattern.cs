namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Object returns joint pattern data.
    /// </summary>
    public interface IObservablePattern
    {
        /// <summary>
        /// This function retrieves the joint pattern value for a specific point element/object and joint pattern.
        /// Joint pattern values are unitless.
        /// </summary>
        /// <param name="name">The name of an existing point element/object.</param>
        /// <param name="patternName">The name of a defined joint pattern.</param>
        /// <param name="value">The value that the specified point element/object has for the specified joint pattern.</param>
        void GetPatternValue(string name,
            string patternName,
            ref double value);
    }
}
