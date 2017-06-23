using System;
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

namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Represents the cable object in the application.
    /// </summary>
    public class CableObject : CSiApiBase, 
        IChangeableName, ICountable, IDeletable, IListableNames, IObservableTransformationMatrix, IObservablePoints,
        IObservableModifiers, IChangeableModifiers,
        IObservableSection, IChangeableSection
    {
        #region Initialization

        public CableObject(CSiApiSeed seed) : base(seed) { }
        #endregion

        #region Methods: Interface

        /// <summary>
        /// This function changes the name of an existing cable object.
        /// </summary>
        /// <param name="currentName">The existing name of a defined cable object.</param>
        /// <param name="newName">The new name for the cable object.</param>
        public void ChangeName(string currentName, string newName)
        {
            _callCode = _sapModel.CableObj.ChangeName(currentName, newName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function returns the total number of defined cable properties in the model.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.CableObj.Count();
        }

        /// <summary>
        /// The function deletes a specified cable object.
        /// It returns an error if the specified object can not be deleted; for example, if it is currently used by a staged construction load case.
        /// </summary>
        /// <param name="name">The name of an existing cable object.</param>
        public void Delete(string name)
        {
            _callCode = _sapModel.CableObj.Delete(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        
        
        // === Get ===

        /// <summary>
        /// This function retrieves the names of all defined cable properties.
        /// </summary>
        /// <param name="numberOfNames">The number of cable object names retrieved by the program.</param>
        /// <param name="names">Cable object names retrieved by the program.</param>
        public void GetNameList(ref int numberOfNames, ref string[] names)
        {
            _callCode = _sapModel.CableObj.GetNameList(ref numberOfNames, ref names);
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
            _callCode = _sapModel.CableObj.GetTransformationMatrix(nameCoordinateSystem, ref directionCosines);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of the point objects that define a cable object.
        /// </summary>
        /// <param name="name">The name of an existing cable object.</param>
        /// <param name="numberPoints">The number of point elements that define the cable object.</param>
        /// <param name="points">The names of the points that defined the cable object.
        /// The point names are listed in the positive order around the object.</param>
        public void GetPoints(string name, ref int numberPoints, ref string[] points)
        {
            string point1 = "";
            string point2 = "";
            
            _callCode = _sapModel.CableObj.GetPoints(name, ref point1, ref point2);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            numberPoints = 2;
            points = new string[numberPoints - 1];
            points[0] = point1;
            points[1] = point2;
        }

        // === Get/Set ===

        /// <summary>
        /// This function retrieves the section property assigned to a cable object.
        /// </summary>
        /// <param name="name">The name of a defined cable object.</param>
        /// <param name="propertyName">The name of the section property assigned to the cable object.</param>
        public void GetSection(string name, ref string propertyName)
        {
            _callCode = _sapModel.CableObj.GetProperty(name, ref propertyName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function assigns the section property to a cable object.
        /// </summary>
        /// <param name="name">The name of a defined cable object.</param>
        /// <param name="propertyName">The name of the section property assigned to the cable object.</param>
        /// <param name="itemType">If this item is Object, the assignment is made to the cable object specified by the Name item.
        /// If this item is Group, the assignment is made to all cable objects in the group specified by the Name item.
        /// If this item is SelectedObjects, assignment is made to all selected cable objects, and the Name item is ignored.</param>
        public void SetSection(string name, string propertyName, eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.CableObj.SetProperty(name, propertyName, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // ===

        /// <summary>
        /// This function retrieves the modifier assignment for cable objects. 
        /// The default value for all modifiers is one.
        /// </summary>
        /// <param name="name">The name of an existing cable object.</param>
        /// <param name="modifiers">Unitless modifiers.</param>
        public void GetModifiers(string name, ref Modifier modifiers)
        {
            if (modifiers == null) { modifiers = new Modifier(); }
            double[] csiModifiers = new double[0];

            _callCode = _sapModel.CableObj.GetModifiers(name, ref csiModifiers);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            modifiers.FromArray(csiModifiers);
        }

        /// <summary>
        /// This function defines the modifier assignment for cable objects. 
        /// The default value for all modifiers is one.
        /// </summary>
        /// <param name="name">The name of an existing cable object.</param>
        /// <param name="modifiers">Unitless modifiers.</param>
        public void SetModifiers(string name, Modifier modifiers)
        {
            if (modifiers == null) { return; }
            double[] csiModifiers = modifiers.ToArray();

            _callCode = _sapModel.CableObj.SetModifiers(name, ref csiModifiers);
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
