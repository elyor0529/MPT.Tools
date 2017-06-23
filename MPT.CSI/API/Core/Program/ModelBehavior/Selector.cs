﻿using MPT.CSI.API.Core.Program.ModelBehavior.Definition;
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
    public class Selector : CSiApiBase
    {
        #region Initialization


        public Selector(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Public
        // === General Selection ===
        /// <summary>
        /// This function selects or deselects all objects in the model.
        /// </summary>
        /// <param name="deselect">The item is False if objects are to be selected and True if they are to be deselected.</param>
        public void All(bool deselect = false)
        {
            _callCode = _sapModel.SelectObj.All(deselect);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function deselects all objects in the model.
        /// </summary>
        public void ClearSelection()
        {
            _callCode = _sapModel.SelectObj.ClearSelection();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function deselects all selected objects and selects all unselected objects; that is, it inverts the selection
        /// </summary>
        public void InvertSelection()
        {
            _callCode = _sapModel.SelectObj.InvertSelection();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function restores the previous selection.
        /// </summary>
        public void PreviousSelection()
        {
            _callCode = _sapModel.SelectObj.PreviousSelection();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves a list of selected objects.
        /// </summary>
        /// <param name="numberItems">The number of selected objects.</param>
        /// <param name="objectType">This is an array that includes the object type of each selected object. 1 = Point object, 2 = Frame object, 3 = Cable object, 4 = Tendon object, 5 = Area object, 6 = Solid object, 7 = Link object</param>
        /// <param name="objectName">This is an array that includes the name of each selected object.</param>
        public void GetSelected(ref int numberItems,
            ref int[] objectType,
            ref string[] objectName)
        {
            _callCode = _sapModel.SelectObj.GetSelected(ref numberItems, ref objectType, ref objectName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        // === Select By Name ===

        /// <summary>
        /// This function selects or deselects all point objects to which the specified constraint has been assigned.
        /// </summary>
        /// <param name="name">The name of an existing joint constraint.</param>
        /// <param name="deselect">The item is False if objects are to be selected and True if they are to be deselected.</param>
        public void Constraint(string name,
            bool deselect = false)
        {
            _callCode = _sapModel.SelectObj.Constraint(name, deselect);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function selects or deselects all objects in the specified group.
        /// </summary>
        /// <param name="name">The name of an existing group.</param>
        /// <param name="deselect">The item is False if objects are to be selected and True if they are to be deselected.</param>
        public void Group(string name,
            bool deselect = false)
        {
            _callCode = _sapModel.SelectObj.Group(name, deselect);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function selects or deselects all area objects to which the specified section has been assigned.
        /// </summary>
        /// <param name="name">The name of an existing area section property.</param>
        /// <param name="deselect">The item is False if objects are to be selected and True if they are to be deselected.</param>
        public void PropertyArea(string name,
            bool deselect = false)
        {
            _callCode = _sapModel.SelectObj.PropertyArea(name, deselect);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function selects or deselects all cable objects to which the specified section has been assigned.
        /// </summary>
        /// <param name="name">The name of an existing cable section property.</param>
        /// <param name="deselect">The item is False if objects are to be selected and True if they are to be deselected.</param>
        public void PropertyCable(string name,
            bool deselect = false)
        {
            _callCode = _sapModel.SelectObj.PropertyCable(name, deselect);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function selects or deselects all line objects to which the specified section has been assigned.
        /// </summary>
        /// <param name="name">The name of an existing frame section property.</param>
        /// <param name="deselect">The item is False if objects are to be selected and True if they are to be deselected.</param>
        public void PropertyFrame(string name,
            bool deselect = false)
        {
            _callCode = _sapModel.SelectObj.PropertyFrame(name, deselect);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function selects or deselects all link objects to which the specified section property has been assigned.
        /// </summary>
        /// <param name="name">The name of an existing link property.</param>
        /// <param name="deselect">The item is False if objects are to be selected and True if they are to be deselected.</param>
        public void PropertyLink(string name,
            bool deselect = false)
        {
            _callCode = _sapModel.SelectObj.PropertyLink(name, deselect);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function selects or deselects all link objects to which the specified frequency dependent link property has been assigned.
        /// </summary>
        /// <param name="name">The name of an existing frequency dependent link property</param>
        /// <param name="deselect">The item is False if objects are to be selected and True if they are to be deselected.</param>
        public void PropertyLinkFD(string name,
            bool deselect = false)
        {
            _callCode = _sapModel.SelectObj.PropertyLinkFD(name, deselect);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function selects or deselects all objects to which the specified material property has been assigned.
        /// </summary>
        /// <param name="name">The name of an existing material property.</param>
        /// <param name="deselect">The item is False if objects are to be selected and True if they are to be deselected.</param>
        public void PropertyMaterial(string name,
            bool deselect = false)
        {
            _callCode = _sapModel.SelectObj.PropertyMaterial(name, deselect);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function selects or deselects all solid objects to which the specified property has been assigned.
        /// </summary>
        /// <param name="name">The name of an existing solid property.</param>
        /// <param name="deselect">The item is False if objects are to be selected and True if they are to be deselected.</param>
        public void PropertySolid(string name,
            bool deselect = false)
        {
            _callCode = _sapModel.SelectObj.PropertySolid(name, deselect);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function selects or deselects all tendon objects to which the specified section has been assigned.
        /// </summary>
        /// <param name="name">The name of an existing tendon section property.</param>
        /// <param name="deselect">The item is False if objects are to be selected and True if they are to be deselected.</param>
        public void PropertyTendon(string name,
            bool deselect = false)
        {
            _callCode = _sapModel.SelectObj.PropertyTendon(name, deselect);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        // === Select by Position ===

        /// <summary>
        /// This function selects or deselects objects parallel to specified coordinate axes or planes.
        /// </summary>
        /// <param name="parallelTo">This is an array of six booleans representing three coordinate axes and three coordinate planes. Any combination of the six may be specified: X, Y, Z, XY, XZ, YZ.</param>
        /// <param name="coordinateSystem">The name of the coordinate system to which the ParallelTo items apply.</param>
        /// <param name="tolerance">Line objects that are within this angle in degrees of being parallel to a specified coordinate axis or plane are selected or deselected. [deg]</param>
        /// <param name="deselect">The item is False if objects are to be selected and True if they are to be deselected.</param>
        public void LinesParallelToCoordAxis(ref bool[] parallelTo,
            string coordinateSystem = CoordinateSystems.Global,
            double tolerance = 0.057,
            bool deselect = false)
        {
            _callCode = _sapModel.SelectObj.LinesParallelToCoordAxis(ref parallelTo, coordinateSystem, tolerance, deselect);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function selects or deselects all line objects that are parallel to a specified line object.
        /// </summary>
        /// <param name="name">The name of a line object.</param>
        /// <param name="deselect">The item is False if objects are to be selected and True if they are to be deselected.</param>
        public void LinesParallelToLine(string name,
            bool deselect = false)
        {
            _callCode = _sapModel.SelectObj.LinesParallelToLine(name, deselect);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function selects or deselects all objects that are in the same XY plane (in the present coordinate system) as the specified point object.
        /// </summary>
        /// <param name="name">The name of a point object.</param>
        /// <param name="deselect">The item is False if objects are to be selected and True if they are to be deselected.</param>
        public void PlaneXY(string name,
            bool deselect = false)
        {
            _callCode = _sapModel.SelectObj.PlaneXY(name, deselect);

            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function selects or deselects all objects that are in the same XZ plane (in the present coordinate system) as the specified point object.
        /// </summary>
        /// <param name="name">The name of a point object.</param>
        /// <param name="deselect">The item is False if objects are to be selected and True if they are to be deselected.</param>
        public void PlaneXZ(string name,
            bool deselect = false)
        {
            _callCode = _sapModel.SelectObj.PlaneXZ(name, deselect);

            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function selects or deselects all objects that are in the same YZ plane (in the present coordinate system) as the specified point object.
        /// </summary>
        /// <param name="name">The name of a point object.</param>
        /// <param name="deselect">The item is False if objects are to be selected and True if they are to be deselected.</param>
        public void PlaneYZ(string name,
            bool deselect = false)
        {
            _callCode = _sapModel.SelectObj.PlaneYZ(name, deselect);

            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function selects or deselects point objects with support in the specified degrees of freedom.
        /// </summary>
        /// <param name="DOF">This is an array of six booleans for the six degrees of freedom of a point object: U1, U2, U3, R1, R2, R3.</param>
        /// <param name="coordinateSystem">The name of the coordinate system in which degrees of freedom (DOF) are specified. 
        /// This is either Local or the name of a defined coordinate system. Local means the point local coordinate system.</param>
        /// <param name="deselect">The item is False if objects are to be selected and True if they are to be deselected.</param>
        /// <param name="selectRestraints">True: Points with restraint assignments in one of the specified degrees of freedom are selected or deselected.</param>
        /// <param name="selectJointSprings">True: Points with joint spring assignments in one of the specified degrees of freedom are selected or deselected.</param>
        /// <param name="selectLineSprings">True: Points with a contribution from line spring assignments in one of the specified degrees of freedom are selected or deselected.</param>
        /// <param name="selectAreaSprings">True: Points with a contribution from area spring assignments in one of the specified degrees of freedom are selected or deselected.</param>
        /// <param name="selectSolidSprings">True: Points with a contribution from solid surface spring assignments in one of the specified degrees of freedom are selected or deselected.</param>
        /// <param name="selectOneJointLinks">True: Points with one joint link assignments in one of the specified degrees of freedom are selected or deselected.</param>
        public void SupportedPoints(ref bool[] DOF,
            string coordinateSystem = "Local",
            bool deselect = false,
            bool selectRestraints = true,
            bool selectJointSprings = true,
            bool selectLineSprings = true,
            bool selectAreaSprings = true,
            bool selectSolidSprings = true,
            bool selectOneJointLinks = true)
        {
            _callCode = _sapModel.SelectObj.SupportedPoints(ref DOF, coordinateSystem, deselect, selectRestraints, selectJointSprings, selectLineSprings, selectAreaSprings, selectSolidSprings, selectOneJointLinks);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion
    }
}
