#if BUILD_ETABS2015 || BUILD_ETABS2016
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Design
{
    /// <summary>
    /// Represents concrete detailing in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Design.IDesignDetailing" />
    public class DesignDetailing : CSiApiBase, IDesignDetailing
    {
        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="DesignDetailing"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public DesignDetailing(CSiApiSeed seed) : base(seed)
        {

        }
        #endregion

        #region Methods: Interface
        /// <summary>
        /// Starts the frame detailing.
        /// </summary>
        public void StartDesign()
        { 
            _callCode = _sapModel.Detailing.StartDetailing(OverwriteExisting: true);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Starts the frame detailing.
        /// </summary>
        /// <param name="overwriteExisting">True: Any existing detailing will be overwritten.</param>
        public void StartDesign(bool overwriteExisting)
        {
            _callCode = _sapModel.Detailing.StartDetailing(overwriteExisting);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// True: Design results are available.
        /// </summary>
        /// <returns><c>true</c> if design results are available, <c>false</c> otherwise.</returns>
        public bool ResultsAreAvailable()
        {
            return _sapModel.Detailing.GetDetailingAvailable();
        }


        /// <summary>
        /// Deletes all frame detailing results.
        /// </summary>
        public void DeleteResults()
        {
            _callCode = _sapModel.Detailing.ClearDetailing();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion

    }
}
#endif