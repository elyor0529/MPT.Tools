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

namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Represents control of the view in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class Viewer : CSiApiBase
    {
        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Viewer"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public Viewer(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Public
        /// <summary>
        /// This function refreshes the view for the specified window(s). 
        /// A RefreshView takes longer to complete than a RefreshWindow.
        /// RefreshView rebuilds all object arrays used for display and then updates the display. 
        /// The RefreshView function should be called after operations that add, delete or move objects.
        /// For example, after adding a new point object to the model, the  RefreshView function should be called. 
        /// After modifying a joint restraint, the RefreshWindow function should be called.
        /// </summary>
        /// <param name="window">This is 0 meaning all windows or an existing window number. 
        /// It indicates the window(s) to have its view refreshed.</param>
        /// <param name="zoom">True: Window zoom is maintained when the view is refreshed. 
        /// False: Zoom returns to a default zoom.</param>
        public void RefreshView(int window = 0,
            bool zoom = true)
        {
            _callCode = _sapModel.View.RefreshView(window, zoom);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function refreshes the specified window(s).
        /// A RefreshWindow takes shorter to complete than a RefreshView.
        /// RefreshWindow simply updates the display.
        /// The RefreshWindow function is adequate for other types of changes than operations that add, delete or move objects. 
        /// For example, after adding a new point object to the model, the  RefreshView function should be called. 
        /// After modifying a joint restraint, the RefreshWindow function should be called.
        /// </summary>
        /// <param name="window">This is 0 meaning all windows or an existing window number. 
        /// It indicates the window(s) to have its view refreshed.</param>
        public void RefreshWindow(int window = 0)
        {
            _callCode = _sapModel.View.RefreshWindow();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        #endregion
    }
}
