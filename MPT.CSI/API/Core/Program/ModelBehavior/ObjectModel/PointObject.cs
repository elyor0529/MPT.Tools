using System;
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

namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Represents the point object in the application.
    /// </summary>
    public class PointObject : CSiApiBase, 
        IChangeableName, ICountable, IListableNames, IObservableTransformationMatrix
    {
        
        #region Initialization

        public PointObject(CSiApiSeed seed) : base(seed) { }
        #endregion

        #region Methods: Interface
        /// <summary>
        /// This function changes the name of an existing point object.
        /// </summary>
        /// <param name="currentName">The existing name of a defined point object.</param>
        /// <param name="newName">The new name for the point object.</param>
        public void ChangeName(string currentName, string newName)
        {
            _callCode = _sapModel.PointObj.ChangeName(currentName, newName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function returns the total number of defined point properties in the model.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.PointObj.Count();
        }

        /// <summary>
        /// This function retrieves the names of all defined point properties.
        /// </summary>
        /// <param name="numberOfNames">The number of point object names retrieved by the program.</param>
        /// <param name="names">Point object names retrieved by the program.</param>
        public void GetNameList(ref int numberOfNames, ref string[] names)
        {
            _callCode = _sapModel.PointObj.GetNameList(ref numberOfNames, ref names);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Returns the 3x3 direction cosines to transform local coordinates to global coordinates by the equation [directionCosines]*[localCoordinates] = [globalCoordinates].
        /// Direction cosines returned are ordered by row, and then by column.
        /// </summary>
        /// <param name="nameCoordinateSystem">The name of an existing coordinate system.</param>
        /// <param name="directionCosines">Value is an array of nine direction cosines that define the transformation matrix from the specified global coordinate system to the global coordinate system.
        /// </param>
        public void GetTransformationMatrix(string nameCoordinateSystem,
            ref double[] directionCosines)
        {
            _callCode = _sapModel.PointObj.GetTransformationMatrix(nameCoordinateSystem, ref directionCosines);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion

        #region Methods: Public

        public void GetThing(ref string param)
        {
            //_callCode = _sapModel.
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetThing(string param)
        {
            //_callCode = _sapModel.
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
