namespace MPT.CSI.API.Core.Program.ModelBehavior.Design
{
    /// <summary>
    /// Implements an interface for resetting design settings and results.
    /// </summary>
    public interface IResettable
    {
        /// <summary>
        /// Deletes all frame design results.
        /// </summary>
        void DeleteResults();

        /// <summary>
        /// Resets all frame design overwrites to default values.
        /// </summary>
        void ResetOverwrites();
    }
}
