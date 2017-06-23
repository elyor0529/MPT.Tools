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
    /// Represents the solid object in the application.
    /// </summary>
    public class SolidObject : CSiApiBase, 
        IChangeableName, ICountable, IDeletable, IListableNames, IObservableTransformationMatrix, IObservablePoints,
        IObservableSection, IChangeableSection
    {
        #region Initialization

        public SolidObject(CSiApiSeed seed) : base(seed) { }
        #endregion

        #region Methods: Interface
        /// <summary>
        /// This function changes the name of an existing solid object.
        /// </summary>
        /// <param name="currentName">The existing name of a defined solid object.</param>
        /// <param name="newName">The new name for the solid object.</param>
        public void ChangeName(string currentName, string newName)
        {
            _callCode = _sapModel.SolidObj.ChangeName(currentName, newName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function returns the total number of defined solid properties in the model.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.SolidObj.Count();
        }

        /// <summary>
        /// The function deletes a specified solid object.
        /// It returns an error if the specified object can not be deleted; for example, if it is currently used by a staged construction load case.
        /// </summary>
        /// <param name="name">The name of an existing solid object.</param>
        public void Delete(string name)
        {
            _callCode = _sapModel.SolidObj.Delete(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // === Get ===

        /// <summary>
        /// This function retrieves the names of all defined solid properties.
        /// </summary>
        /// <param name="numberOfNames">The number of solid object names retrieved by the program.</param>
        /// <param name="names">Solid object names retrieved by the program.</param>
        public void GetNameList(ref int numberOfNames, ref string[] names)
        {
            _callCode = _sapModel.SolidObj.GetNameList(ref numberOfNames, ref names);
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
            _callCode = _sapModel.SolidObj.GetTransformationMatrix(nameCoordinateSystem, ref directionCosines);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of the point objects that define a solid object.
        /// </summary>
        /// <param name="name">The name of an existing solid object.</param>
        /// <param name="numberPoints">The number of point objects that define the solid object.</param>
        /// <param name="points">The names of the points that defined the solid object.
        /// The point names are listed in the positive order around the object.</param>
        public void GetPoints(string name, ref int numberPoints, ref string[] points)
        {
            _callCode = _sapModel.SolidObj.GetPoints(name, ref points);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            numberPoints = 8;
        }

        // === Get/Set ===

        /// <summary>
        /// This function retrieves the section property assigned to a solid object.
        /// </summary>
        /// <param name="name">The name of a defined solid object.</param>
        /// <param name="propertyName">The name of the section property assigned to the solid object.</param>
        public void GetSection(string name, ref string propertyName)
        {
            _callCode = _sapModel.SolidObj.GetProperty(name, ref propertyName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function assigns the section property to a solid object.
        /// </summary>
        /// <param name="name">The name of a defined solid object.</param>
        /// <param name="propertyName">The name of the section property assigned to the solid object.</param>
        /// <param name="itemType">If this item is Object, the assignment is made to the solid object specified by the Name item.
        /// If this item is Group, the assignment is made to all solid objects in the group specified by the Name item.
        /// If this item is SelectedObjects, assignment is made to all selected solid objects, and the Name item is ignored.</param>
        public void SetSection(string name, string propertyName, eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.SolidObj.SetProperty(name, propertyName, CSiEnumConverter.ToCSi(itemType));
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
