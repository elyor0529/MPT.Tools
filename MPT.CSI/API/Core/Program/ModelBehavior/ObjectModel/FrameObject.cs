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
    /// Represents the frame object in the application.
    /// </summary>
    public class FrameObject : CSiApiBase, 
        IChangeableName, ICountable, IDeletable, IListableNames, IObservableTransformationMatrix, IObservablePoints,
        IObservableModifiers, IChangeableModifiers,
        IObservableSection, IChangeableSection
    {
        #region Initialization

        public FrameObject(CSiApiSeed seed) : base(seed) { }
        #endregion

        #region Methods: Interface
        /// <summary>
        /// This function changes the name of an existing frame object.
        /// </summary>
        /// <param name="currentName">The existing name of a defined frame object.</param>
        /// <param name="newName">The new name for the frame object.</param>
        public void ChangeName(string currentName, string newName)
        {
            _callCode = _sapModel.FrameObj.ChangeName(currentName, newName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function returns the total number of defined frame properties in the model.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.FrameObj.Count();
        }

        /// <summary>
        /// The function deletes a specified frame object.
        /// It returns an error if the specified object can not be deleted; for example, if it is currently used by a staged construction load case.
        /// </summary>
        /// <param name="name">The name of an existing frame object.</param>
        public void Delete(string name)
        {
            _callCode = _sapModel.FrameObj.Delete(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // === Get ===

        /// <summary>
        /// This function retrieves the names of all defined frame properties.
        /// </summary>
        /// <param name="numberOfNames">The number of frame object names retrieved by the program.</param>
        /// <param name="names">Frame object names retrieved by the program.</param>
        public void GetNameList(ref int numberOfNames, 
            ref string[] names)
        {
            _callCode = _sapModel.FrameObj.GetNameList(ref numberOfNames, ref names);
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
            _callCode = _sapModel.FrameObj.GetTransformationMatrix(nameCoordinateSystem, ref directionCosines);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of the point objects that define a frame object.
        /// </summary>
        /// <param name="name">The name of an existing frame object.</param>
        /// <param name="numberPoints">The number of point objects that define the frame object.</param>
        /// <param name="points">The names of the points that defined the frame object.
        /// The point names are listed in the positive order around the object.</param>
        public void GetPoints(string name, ref int numberPoints, ref string[] points)
        {
            string point1 = "";
            string point2 = "";

            _callCode = _sapModel.FrameObj.GetPoints(name, ref point1, ref point2);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            numberPoints = 2;
            points = new string[numberPoints - 1];
            points[0] = point1;
            points[1] = point2;
        }

        // === Get/Set ===

        /// <summary>
        /// This function retrieves the section property assigned to a frame object.
        /// </summary>
        /// <param name="name">The name of a defined frame object.</param>
        /// <param name="propertyName">The name of the section property assigned to the frame object.</param>
        public void GetSection(string name, 
            ref string propertyName)
        {
            string autoSelectList = "";

            _callCode = _sapModel.FrameObj.GetSection(name, ref propertyName,  ref autoSelectList);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the section property assigned to a frame object.
        /// </summary>
        /// <param name="name">The name of a defined frame object.</param>
        /// <param name="propertyName">The name of the section property assigned to the frame object.</param>
        /// <param name="autoSelectList">Name of the auto select list assigned to the frame object, if any. 
        /// If this item is returned as a blank string, no auto select list is assigned to the frame object.</param>
        public void GetSection(string name,
            ref string propertyName, 
            ref string autoSelectList)
        {
            _callCode = _sapModel.FrameObj.GetSection(name, ref propertyName, ref autoSelectList);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function assigns the section property to a frame object.
        /// </summary>
        /// <param name="name">The name of a defined frame object.</param>
        /// <param name="propertyName">The name of the section property assigned to the frame object.</param>
        /// <param name="itemType">If this item is Object, the assignment is made to the frame object specified by the Name item.
        /// If this item is Group, the assignment is made to all frame objects in the group specified by the Name item.
        /// If this item is SelectedObjects, assignment is made to all selected frame objects, and the Name item is ignored.</param>
        public void SetSection(string name, 
            string propertyName, 
            eItemType itemType = eItemType.Object)
        {
            double nonPrismaticTotalLength = 0;
            double nonPrismaticRelativeStartLocation = 0;

            _callCode = _sapModel.FrameObj.SetSection(name, propertyName, CSiEnumConverter.ToCSi(itemType), nonPrismaticTotalLength, nonPrismaticRelativeStartLocation);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function assigns the section property to a frame object.
        /// </summary>
        /// <param name="name">The name of a defined frame object.</param>
        /// <param name="propertyName">The name of the section property assigned to the frame object.</param>
        /// <param name="itemType">If this item is Object, the assignment is made to the frame object specified by the Name item.
        /// If this item is Group, the assignment is made to all frame objects in the group specified by the Name item.
        /// If this item is SelectedObjects, assignment is made to all selected frame objects, and the Name item is ignored.</param>
        /// <param name="nonPrismaticTotalLength">Total assumed length of the nonprismatic section. 
        /// Enter 0 for this item to indicate that the section length is the same as the frame object length.
        /// This item is applicable only when the assigned frame section property is a nonprismatic section.</param>
        /// <param name="nonPrismaticRelativeStartLocation">Relative distance along the nonprismatic section to the I-End (start) of the frame object. 
        /// This item is ignored when <paramref name="nonPrismaticTotalLength"/> is 0.
        /// This item is applicable only when the assigned frame section property is a nonprismatic section, and the <paramref name="nonPrismaticTotalLength"/> &gt; 0.</param>
        public void SetSection(string name, 
            string propertyName,
            double nonPrismaticTotalLength,
            double nonPrismaticRelativeStartLocation,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.FrameObj.SetSection(name, propertyName, CSiEnumConverter.ToCSi(itemType), nonPrismaticTotalLength, nonPrismaticRelativeStartLocation);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // ===

        /// <summary>
        /// This function retrieves the modifier assignment for frame objects. 
        /// The default value for all modifiers is one.
        /// </summary>
        /// <param name="name">The name of an existing frame object.</param>
        /// <param name="modifiers">Unitless modifiers.</param>
        public void GetModifiers(string name, ref Modifier modifiers)
        {
            if (modifiers == null) { modifiers = new Modifier(); }
            double[] csiModifiers = new double[0];

            _callCode = _sapModel.FrameObj.GetModifiers(name, ref csiModifiers);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            modifiers.FromArray(csiModifiers);
        }

        /// <summary>
        /// This function defines the modifier assignment for frame objects. 
        /// The default value for all modifiers is one.
        /// </summary>
        /// <param name="name">The name of an existing frame object.</param>
        /// <param name="modifiers">Unitless modifiers.</param>
        public void SetModifiers(string name, Modifier modifiers)
        {
            if (modifiers == null) { return; }
            double[] csiModifiers = modifiers.ToArray();

            _callCode = _sapModel.FrameObj.SetModifiers(name, ref csiModifiers);
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
