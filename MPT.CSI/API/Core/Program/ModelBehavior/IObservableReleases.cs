using MPT.CSI.API.Core.Helpers;

namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Object can return the names of all associated releases.
    /// </summary>
    public interface IObservableReleases
    {
        /// <summary>
        /// This function retrieves the release assignments for a frame end release.
        /// </summary>
        /// <param name="name">The name of an existing frame end release.</param>
        /// <param name="iEndRelease">Booleans indicating the I-End releases.</param>
        /// <param name="jEndRelease">Booleans indicating the J-End releases.</param>
        /// <param name="iEndFixity">Values indicating the I-End partial fixity springs.</param>
        /// <param name="jEndFixity">Values indicating the J-End partial fixity springs.</param>
        void GetReleases(string name,
        ref DegreesOfFreedomLocal iEndRelease,
        ref DegreesOfFreedomLocal jEndRelease,
        ref Fixity iEndFixity,
        ref Fixity jEndFixity);
    }
}
