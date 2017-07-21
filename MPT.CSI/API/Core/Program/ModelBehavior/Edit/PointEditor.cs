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

namespace MPT.CSI.API.Core.Program.ModelBehavior.Edit
{
    /// <summary>
    /// Represents the point editor in the application.
    /// </summary>
    public class PointEditor : CSiApiBase
    {
        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="PointEditor"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public PointEditor(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Public
        /// <summary>
        /// This function aligns selected point objects.
        /// </summary>
        /// <param name="alignmentOption">Method by which a point is aligned.</param>
        /// <param name="ordinate">The X, Y or Z ordinate that applies if MyType is 1, 2 or 3, respectively. [L]</param>
        /// <param name="numberPoints">The number of point objects that are in a new location after the alignment is complete</param>
        /// <param name="pointNames">The name of each point object that is in a new location after the alignment is complete.</param>
        public void Align(ePointAlignOption alignmentOption,
            double ordinate,
            ref int numberPoints,
            ref string[] pointNames)
        {
            _callCode = _sapModel.EditPoint.Align((int)alignmentOption, ordinate, ref numberPoints, ref pointNames);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function connects objects that have been disconnected using the <see cref="Disconnect"/> function. 
        /// If two or more objects have different end points objects that are at the same location, all of those objects can be connected together by selecting the objects, and selecting their end points, and calling the <see cref="Connect"/> function. 
        /// The result will be that all of the objects are connected at a single point.
        /// </summary>
        /// <param name="numberPoints">The number of the point objects that remain at locations where connections were made.</param>
        /// <param name="pointNames">The name of each point object that remains at locations where connections were made.</param>
        public void Connect(ref int numberPoints,
            ref string[] pointNames)
        {
            _callCode = _sapModel.EditPoint.Connect(ref numberPoints, ref pointNames);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function disconnects selected point objects. 
        /// It creates a separate point for each object that frames into the selected point object.
        /// </summary>
        /// <param name="numberPoints">The number of the point objects (including the original selected point objects) that are created by the disconnect action.</param>
        /// <param name="pointNames">The name of each point object (including the original selected point objects) that is created by the disconnect action.</param>
        public void Disconnect(ref int numberPoints,
            ref string[] pointNames)
        {
            _callCode = _sapModel.EditPoint.Disconnect(ref numberPoints, ref pointNames);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function merges selected point objects that are within a specified distance of one another.
        /// </summary>
        /// <param name="tolerance">Point objects within this distance of one another are merged into one point object. [L]</param>
        /// <param name="numberPoints">The number of the selected point objects that still exist after the merge is complete.</param>
        /// <param name="pointNames">The name of each selected point object that still exists after the merge is complete.</param>
        public void Merge(double tolerance,
            ref int numberPoints,
            ref string[] pointNames)
        {
            _callCode = _sapModel.EditPoint.Merge(tolerance, ref numberPoints, ref pointNames);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function changes the coordinates of a specified point object.
        /// </summary>
        /// <param name="name">The name of an existing point object.</param>
        /// <param name="coordinate">Coordinate for the new point location.</param>
        /// <param name="noWindoRefresh">True: The model display window is not refreshed after the point object is moved.</param>
        public void Move(string name,
            Coordinate3DCartesian coordinate,
            bool noWindoRefresh = false)
        {
            _callCode = _sapModel.EditPoint.ChangeCoordinates_1(name, coordinate.X, coordinate.Y, coordinate.Z, noWindoRefresh);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion
    }
}
