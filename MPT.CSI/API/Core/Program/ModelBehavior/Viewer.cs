using MPT.CSI.API.Core.Support;

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
        /// This function refreshes the view for the specified window(s). <para /> 
        /// <see cref="Viewer.RefreshView(int, bool)"/> takes longer to complete than <see cref="Viewer.RefreshWindow(int)"/>.<para /> 
        /// <see cref="Viewer.RefreshView(int, bool)"/> rebuilds all object arrays used for display and then updates the display. <para /> 
        /// This function should be called after operations that add, delete or move objects.<para /> 
        /// For example, after adding a new point object to the model, this function should be called. <para /> 
        /// After modifying a joint restraint, <see cref="Viewer.RefreshWindow(int)"/> should be called.
        /// </summary>
        /// <param name="window">This is 0 meaning all windows or an existing window number. <para /> 
        /// It indicates the window(s) to have its view refreshed.</param>
        /// <param name="zoom">True: Window zoom is maintained when the view is refreshed. <para /> 
        /// False: Zoom returns to a default zoom.</param>
        public void RefreshView(int window = 0,
            bool zoom = true)
        {
            _callCode = _sapModel.View.RefreshView(window, zoom);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function refreshes the specified window(s).<para /> 
        /// <see cref="Viewer.RefreshWindow(int)"/> takes shorter to complete than <see cref="Viewer.RefreshView(int, bool)"/>.<para /> 
        /// <see cref="Viewer.RefreshWindow(int)"/> simply updates the display.<para /> 
        /// This function is adequate for other types of changes than operations that add, delete or move objects. <para /> 
        /// For example, after adding a new point object to the model, <see cref="Viewer.RefreshView(int, bool)"/> function should be called. <para /> 
        /// After modifying a joint restraint, the this function should be called.
        /// </summary>
        /// <param name="window">This is 0 meaning all windows or an existing window number. <para /> 
        /// It indicates the window(s) to have its view refreshed.</param>
        public void RefreshWindow(int window = 0)
        {
            _callCode = _sapModel.View.RefreshWindow();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        #endregion
    }
}
