using MPT.CSI.API.Core.Helpers;
using MPT.CSI.API.Core.Support;

#if BUILD_SAP2000v16
using SAP2000v16;
#elif BUILD_SAP2000v17
using SAP2000v17;
#elif BUILD_SAP2000v18
using SAP2000v18;
#elif BUILD_SAP2000v19
using SAP2000v19;
#elif BUILD_ETABS2013
using ETABS2013;
#elif BUILD_ETABS2014
using ETABS2014;
#elif BUILD_ETABS2015
using ETABS2015;
#elif BUILD_ETABS2016
using ETABS2016;
#endif

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.NamedAssign
{
    /// <summary>
    /// Represents the frame releases in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class FrameReleases : CSiApiBase, 
        IChangeableName, ICountable, IDeletable, IListableNames,
        IObservableReleases
    {

        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="FrameReleases"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public FrameReleases(CSiApiSeed seed) : base(seed) { }

        #endregion

        #region Methods: Interface

        /// <summary>
        /// This function changes the name of an existing frame end release.
        /// </summary>
        /// <param name="currentName">The existing name of a defined frame end release.</param>
        /// <param name="newName">The new name for the frame end release</param>
        public void ChangeName(string currentName, 
            string newName)
        {
            _callCode = _sapModel.NamedAssign.ReleaseFrame.ChangeName(currentName, newName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function returns the total number of defined frame end releases in the model.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.NamedAssign.ReleaseFrame.Count();
        }


        /// <summary>
        /// The function deletes a specified frame end release.
        /// </summary>
        /// <param name="name">The name of an existing frame end release.
        /// It returns an error if the specified end release can not be deleted; for example, if it is currently used by a staged construction load case.</param>
        public void Delete(string name)
        {
            _callCode = _sapModel.NamedAssign.ReleaseFrame.Delete(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of all defined frame end releases
        /// </summary>
        /// <param name="numberOfNames">The number of frame end release names retrieved by the program.</param>
        /// <param name="names">Frame end release names retrieved by the program.</param>
        public void GetNameList(ref int numberOfNames, 
            ref string[] names)
        {
            _callCode = _sapModel.NamedAssign.ReleaseFrame.GetNameList(ref numberOfNames, ref names);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        #endregion

        #region Methods: Public
        // === Get/Set

        /// <summary>
        /// This function retrieves the release assignments for a frame end release.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="iEndRelease">Booleans indicating the I-End releases.</param>
        /// <param name="jEndRelease">Booleans indicating the J-End releases.</param>
        /// <param name="iEndFixity">Values indicating the I-End partial fixity springs.</param>
        /// <param name="jEndFixity">Values indicating the J-End partial fixity springs.</param>
        public void GetReleases(string name,
            ref DegreesOfFreedomLocal iEndRelease,
            ref DegreesOfFreedomLocal jEndRelease,
            ref Fixity iEndFixity,
            ref Fixity jEndFixity)
        {
            bool[] csiiEndRelease = new bool[0];
            bool[] csijEndRelease = new bool[0];
            double[] csiiEndFixity = new double[0];
            double[] csijEndFixity = new double[0];

            _callCode = _sapModel.NamedAssign.ReleaseFrame.GetReleases(name, ref csiiEndRelease, ref csijEndRelease, ref csiiEndFixity, ref csijEndFixity);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            iEndRelease.FromArray(csiiEndRelease);
            jEndRelease.FromArray(csijEndRelease);
            iEndFixity.FromArray(csiiEndFixity);
            jEndFixity.FromArray(csijEndFixity);
        }

        /// <summary>
        /// This function defines a named frame end release.
        /// </summary>
        /// <param name="name">The name of a new or existing frame end release.</param>
        /// <param name="iEndRelease">Booleans indicating the I-End releases.</param>
        /// <param name="jEndRelease">Booleans indicating the J-End releases.</param>
        /// <param name="iEndFixity">Values indicating the I-End partial fixity springs.
        /// The value will be inactive if there is not a released specified for the corresponding degree of freedom.</param>
        /// <param name="jEndFixity">Values indicating the J-End partial fixity springs.
        /// The value will be inactive if there is not a released specified for the corresponding degree of freedom.</param>
        public void SetReleases(string name,
            DegreesOfFreedomLocal iEndRelease,
            DegreesOfFreedomLocal jEndRelease,
            Fixity iEndFixity,
            Fixity jEndFixity)
        {
            bool[] csiiEndRelease = iEndRelease.ToArray();
            bool[] csijEndRelease = jEndRelease.ToArray();
            double[] csiiEndFixity = iEndFixity.ToArray();
            double[] csijEndFixity = jEndFixity.ToArray();

            _callCode = _sapModel.NamedAssign.ReleaseFrame.SetReleases(name, ref csiiEndRelease, ref csijEndRelease, ref csiiEndFixity, ref csijEndFixity);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
