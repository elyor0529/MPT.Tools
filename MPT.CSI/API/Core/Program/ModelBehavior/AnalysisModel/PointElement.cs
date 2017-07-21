using System.Linq;
using MPT.CSI.API.Core.Helpers;
using MPT.CSI.API.Core.Program.ModelBehavior.Definition;
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

namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel
{
    /// <summary>
    /// Represents the point element in the application.
    /// </summary>
    public class PointElement : CSiApiBase, IPointElement
    {
        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="PointElement"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public PointElement(CSiApiSeed seed) : base(seed) {}

        #endregion

        #region Query
        /// <summary>
        /// This function returns the total number of defined point elements in the model.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.PointElm.Count();
        }


        /// <summary>
        /// If the <paramref name="name"/> item is provided, the function returns the total number of constraint assignments made to the specified point element. 
        /// If the <paramref name="name"/> item is not specified or is specified as an empty string, the function returns the total number of constraint assignments to all point elements in the model. 
        /// If the <paramref name="name"/> item is specified but it is not recognized by the program as a valid point element, an error is returned.
        /// TODO: Handle last case.
        /// </summary>
        /// <param name="name">The name of an existing point element.</param>
        public int CountConstraint(string name = "")
        {
            int count = 0;

            _callCode = _sapModel.PointElm.CountConstraint(ref count, name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            return count;
        }

        /// <summary>
        /// This function returns the total number of point elements in the model with restraint assignments.
        /// </summary>
        public int CountRestraint()
        {
            return _sapModel.PointElm.CountRestraint();
        }

        /// <summary>
        /// This function returns the total number of point elements in the model with spring assignments.
        /// </summary>
        public int CountSpring()
        {
            return _sapModel.PointElm.CountSpring();
        }

        /// <summary>
        /// If neither the <paramref name="name"/> item nor the <paramref name="loadPattern"/> item is provided, the function returns the total number of point load assignments to point elements in the model.
        /// If the <paramref name="name"/> item is provided but not the <paramref name="loadPattern"/> item, the function returns the total number of point load assignments made for the specified point element.
        /// If the <paramref name="name"/> item is not provided but the <paramref name="loadPattern"/> item is specified, the function returns the total number of point load assignments made to all point elements for the specified load pattern.
        /// If both the <paramref name="name"/> item and the <paramref name="loadPattern"/> item are provided, the function the total number of point load assignments made to the specified point element for the specified load pattern.
        /// If the <paramref name="name"/> item or the <paramref name="loadPattern"/> item is provided but is not recognized by the program as valid, an error is returned.
        /// TODO: Handle last case.
        /// </summary>
        /// <param name="name">The name of an existing point element.</param>
        /// <param name="loadPattern">The name of an existing load pattern.</param>
        public int CountLoadForce(string name = "",
            string loadPattern = "")
        {
            int count = 0;

            _callCode = _sapModel.PointElm.CountLoadForce(ref count, name, loadPattern);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            return count;
        }

        /// <summary>
        /// If neither the <paramref name="name"/> item nor the <paramref name="loadPattern"/> item is provided, the function returns the total number of ground displacement load assignments to point elements in the model.
        /// If the <paramref name="name"/> item is provided but not the <paramref name="loadPattern"/> item, the function returns the total number of ground displacement load assignments made for the specified point element.
        /// If the <paramref name="name"/> item is not provided but the <paramref name="loadPattern"/> item is specified, the function returns the total number of ground displacement load assignments made to all point elements for the specified load pattern.
        /// If both the <paramref name="name"/> item and the <paramref name="loadPattern"/> item are provided, the function the total number of ground displacement load assignments made to the specified point element for the specified load pattern.
        /// If the <paramref name="name"/> item or the <paramref name="loadPattern"/> item is provided but is not recognized by the program as valid, an error is returned.
        /// TODO: Handle last case.
        /// </summary>
        /// <param name="name">The name of an existing point element.</param>
        /// <param name="loadPattern">The name of an existing load pattern.</param>
        public int CountLoadDisplacements(string name = "",
            string loadPattern = "")
        {
            int count = 0;

            _callCode = _sapModel.PointElm.CountLoadDispl(ref count, name, loadPattern);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            return count;
        }


        /// <summary>
        /// This function retrieves the names of all items.
        /// </summary>
        /// <param name="numberOfNames">The number of item names retrieved by the program.</param>
        /// <param name="names">Names retrieved by the program.</param>
        public void GetNameList(ref int numberOfNames,
            ref string[] names)
        {
            _callCode = _sapModel.PointElm.GetNameList(ref numberOfNames, ref names);
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
            _callCode = _sapModel.PointElm.GetTransformationMatrix(nameCoordinateSystem, ref directionCosines);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        
        /// <summary>
        /// This function retrieves the name of the point object from which a point element was created.
        /// </summary>
        /// <param name="name">The name of an existing point element.</param>
        /// <param name="nameObject">The name of the point object from which the point element was created.</param>
        public void GetObject(string name, ref string nameObject)
        {
            int csiObjectType = 0;
            _callCode = _sapModel.PointElm.GetObj(name, ref nameObject, ref csiObjectType);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the name of the point object from which a point element was created. 
        /// It also retrieves the type of point object that it is.
        /// </summary>
        /// <param name="name">The name of an existing point element.</param>
        /// <param name="nameObject">The name of the point object from which the point element was created.</param>
        /// <param name="objectType">Type of object or defined item that is associated with the point element.</param>
        public void GetObject(string name, ref string nameObject, ref ePointTypeObject objectType)
        {
            int csiObjectType = 0;
            _callCode = _sapModel.PointElm.GetObj(name, ref nameObject, ref csiObjectType);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            objectType = (ePointTypeObject)csiObjectType;
        }



        /// <summary>
        /// Returns the x, y and z coordinates of the specified point element/object in the Present Units. 
        /// The coordinates are reported in the coordinate system specified by <paramref name="coordinateSystem"/>.
        /// </summary>
        /// <param name="name">The name of an existing point element/object.</param>
        /// <param name="coordinate">The cartesian x-, y-, z-coordinate of the specified point element/object in the specified coordinate system.</param>
        /// <param name="coordinateSystem">The name of the coordinate system in which the joint coordinates are returned.</param>
        public void GetCoordinate(string name,
            ref Coordinate3DCartesian coordinate,
            string coordinateSystem = CoordinateSystems.Global)
        {
            double x = 0;
            double y = 0;
            double z = 0;

            _callCode = _sapModel.PointElm.GetCoordCartesian(name, ref x, ref y, ref z, coordinateSystem);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            coordinate.X = x;
            coordinate.Y = y;
            coordinate.Z = z;
        }

        /// <summary>
        /// Returns the r, Theta and z coordinates of the specified point element/object in the Present Units. 
        /// The coordinates are reported in the coordinate system specified by <paramref name="coordinateSystem"/>.
        /// </summary>
        /// <param name="name">The name of an existing point element/object.</param>
        /// <param name="coordinate">The cylindrical r-, theta-, z-coordinate of the specified point element/object in the specified coordinate system.</param>
        /// <param name="coordinateSystem">The name of the coordinate system in which the joint coordinates are returned.</param>
        public void GetCoordinate(string name,
            ref Coordinate3DCylindrical coordinate,
            string coordinateSystem = CoordinateSystems.Global)
        {
            double radius = 0;
            double theta = 0;
            double z = 0;

            _callCode = _sapModel.PointElm.GetCoordCylindrical(name, ref radius, ref theta, ref z, coordinateSystem);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            coordinate.Radius = radius;
            coordinate.Theta = theta;
            coordinate.Z = z;
        }

        /// <summary>
        /// Returns the r, a and b coordinates of the specified point element/object in the Present Units. 
        /// The coordinates are reported in the coordinate system specified by <paramref name="coordinateSystem"/>.
        /// </summary>
        /// <param name="name">The name of an existing point element/object.</param>
        /// <param name="coordinate">The spherical r-, a-, b-coordinate of the specified point element/object in the specified coordinate system.</param>
        /// <param name="coordinateSystem">The name of the coordinate system in which the joint coordinates are returned.</param>
        public void GetCoordinate(string name,
            ref Coordinate3DSpherical coordinate,
            string coordinateSystem = CoordinateSystems.Global)
        {
            double radius = 0;
            double theta = 0;
            double phi = 0;

            _callCode = _sapModel.PointElm.GetCoordSpherical(name, ref radius, ref theta, ref phi, coordinateSystem);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            coordinate.Radius = radius;
            coordinate.Theta = theta;
            coordinate.Phi = phi;
        }


        /// <summary>
        /// This function returns a list of elements connected to a specified point element/object.
        /// </summary>
        /// <param name="name">The name of an existing point element/object.</param>
        /// <param name="numberItems">This is the total number of elements/objects connected to the specified point element/object.</param>
        /// <param name="objectTypes">The element/object type of each element/object connected to the specified point element/object.</param>
        /// <param name="objectNames">The element/object name of each element/object connected to the specified point element/object.</param>
        /// <param name="pointNumbers">The point number within the considered element/object that corresponds to the specified point element/object.</param>
        public void GetConnectivity(string name,
            ref int numberItems,
            ref eObjectType[] objectTypes,
            ref string[] objectNames,
            ref int[] pointNumbers)
        {
            int[] csiObjectTypes = new int[0];
            
            _callCode = _sapModel.PointElm.GetConnectivity(name, ref numberItems, ref csiObjectTypes, ref objectNames, ref pointNumbers);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            objectTypes = csiObjectTypes.Cast<eObjectType>().ToArray();
        }
        #endregion

        #region Axes
        /// <summary>
        /// This function retrieves the local axis angle assignment for the point element.
        /// </summary> 
        /// <param name="name">The name of an existing point element.</param>
        /// <param name="angleOffset">This is the angle 'a' that the local 1 and 2 axes are rotated about the positive local 3 axis from the default orientation. 
        /// The rotation for a positive angle appears counter clockwise when the local +3 axis is pointing toward you. [deg]
        /// For some objects, the following rotations are also performed:
        /// 2. Rotate about the resulting 2 axis by angle b.
        /// 3. Rotate about the resulting 1 axis by angle c.</param>
        public void GetLocalAxes(string name,
            ref AngleLocalAxes angleOffset)
        {
            double angleA = 0;
            double angleB = 0;
            double angleC = 0;
            _callCode = _sapModel.PointElm.GetLocalAxes(name, ref angleA, ref angleB, ref angleC);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            angleOffset.AngleA = angleA;
            angleOffset.AngleB = angleB;
            angleOffset.AngleC = angleC;
        }


        #endregion


        #region Point Properties
        

        /// <summary>
        /// This function retrieves the merge number for a point element/object. 
        /// By default the merge number for a point is zero. 
        /// Points with different merge numbers are not automatically merged by the program.
        /// </summary>
        /// <param name="name">The name of an existing point element/object.</param>
        /// <param name="mergeNumber">The merge number assigned to the specified point element/object.</param>
        public void GetMergeNumber(string name,
            ref int mergeNumber)
        {
            _callCode = _sapModel.PointElm.GetMergeNumber(name, ref mergeNumber);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the joint pattern value for a specific point element/object and joint pattern.
        /// Joint pattern values are unitless.
        /// </summary>
        /// <param name="name">The name of an existing point element/object.</param>
        /// <param name="patternName">The name of a defined joint pattern.</param>
        /// <param name="value">The value that the specified point element/object has for the specified joint pattern.</param>
        public void GetPatternValue(string name,
            string patternName,
            ref double value)
        {
            _callCode = _sapModel.PointElm.GetPatternValue(name, patternName, ref value);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion

        #region Support & Connections
        /// <summary>
        /// This function returns a list of constraint assignments made to one or more specified point elements.
        /// </summary>
        /// <param name="name">The name of an existing point object, element or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="numberItems">This is the total number of constraint assignments returned.</param>
        /// <param name="pointNames">The name of the point element to which the specified constraint assignment applies.</param>
        /// <param name="constraintNames">The name of the constraint that is assigned to the point element specified by the <paramref name="pointNames"/> item.</param>
        /// <param name="itemType">If this item is <see cref="eItemTypeElement.ObjectElement"/>, the load assignments are retrieved for the elements corresponding to the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemTypeElement.Element"/>, the load assignments are retrieved for the element specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemTypeElement.GroupElement"/>, the load assignments are retrieved for the elements corresponding to all objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemTypeElement.SelectionElement"/>, the load assignments are retrieved for elements corresponding to all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void GetConstraint(string name,
            ref int numberItems,
            ref string[] pointNames,
            ref string[] constraintNames,
            eItemTypeElement itemType = eItemTypeElement.Element)
        {
            _callCode = _sapModel.PointElm.GetConstraint(name, ref numberItems, ref pointNames, ref constraintNames, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function returns a list of constraint assignments made to one or more specified point elements.
        /// </summary>
        /// <param name="name">The name of an existing point element.</param>
        /// <param name="degreesOfFreedom">These are the restraint assignments for each local degree of freedom (DOF), where 'True' means the DOF is fixed.</param>
        public void GetRestraint(string name,
            ref DegreesOfFreedomLocal degreesOfFreedom)
        {

            bool[] values = new bool[0];

            _callCode = _sapModel.PointElm.GetRestraint(name, ref values);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            degreesOfFreedom.FromArray(values);
        }



        /// <summary>
        /// This function retrieves uncoupled spring stiffness assignments for a point element; 
        /// that is, it retrieves the diagonal terms in the 6x6 spring matrix for the point element.
        /// The spring stiffnesses reported are the sum of all springs assigned to the point element either directly or indirectly through line, area and solid spring assignments. 
        /// The spring stiffness values are reported in the point local coordinate system.</summary>
        /// <param name="name">The name of an existing point element.</param>
        /// <param name="stiffnesses">Spring stiffness values for each decoupled degree of freedom.</param>
        public void GetSpring(string name,
            ref Stiffness stiffnesses)
        {
            double[] csiStiffnesses = new double[0];

            _callCode = _sapModel.PointElm.GetSpring(name, ref csiStiffnesses);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            stiffnesses.FromArray(csiStiffnesses);
        }

        /// <summary>
        /// This function retrieves coupled spring stiffness assignments for a point element; 
        /// that is, it retrieves the spring matrix of 21 stiffness values for the point element.
        /// The spring stiffnesses reported are the sum of all springs assigned to the point element either directly or indirectly through line, area and solid spring assignments. 
        /// The spring stiffness values are reported in the point local coordinate system.</summary>
        /// <param name="name">The name of an existing point element.</param>
        /// <param name="stiffnesses">Spring stiffness values for each coupled degree of freedom.</param>
        public void GetSpringCoupled(string name,
            ref StiffnessCoupled stiffnesses)
        {
            double[] csiStiffnesses = new double[0];

            _callCode = _sapModel.PointElm.GetSpringCoupled(name, ref csiStiffnesses);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            stiffnesses.FromArray(csiStiffnesses);
        }

        /// <summary>
        /// This function indicates if the spring assignments to a point element are coupled, that is, if there are off-diagonal terms in the 6x6 spring matrix for the point element.
        /// </summary>
        /// <param name="name">The name of an existing point element.</param>
        public bool IsSpringCoupled(string name)
        {
            bool isCoupled = false;
            
            _callCode = _sapModel.PointElm.IsSpringCoupled(name, ref isCoupled);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            return isCoupled;
        }


        #endregion


        #region Loads

        /// <summary>
        /// This function returns a list of force load assignments made to one or more specified point elements.
        /// </summary>
        /// <param name="name">The name of an existing point object, element or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="numberItems">This is the total number of force load assignments returned.</param>
        /// <param name="pointNames">The name of the point element to which the specified force load assignment applies.</param>
        /// <param name="loadPatterns">The name of the load pattern for each load.</param>
        /// <param name="loadPatternSteps">The load pattern step for each load. 
        /// In most cases this item does not apply and will be returned as 0.</param>
        /// <param name="coordinateSystem">The name of the coordinate system for the load. 
        /// This is either Local or the name of a defined coordinate system.</param>
        /// <param name="forces">The forces assigned along the local or global axis direction, depending on the specified <paramref name="coordinateSystem"/>.</param>
        /// <param name="itemType">If this item is <see cref="eItemTypeElement.ObjectElement"/>, the load assignments are retrieved for the elements corresponding to the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemTypeElement.Element"/>, the load assignments are retrieved for the element specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemTypeElement.GroupElement"/>, the load assignments are retrieved for the elements corresponding to all objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemTypeElement.SelectionElement"/>, the load assignments are retrieved for elements corresponding to all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void GetLoadForce(string name,
            ref int numberItems,
            ref string[] pointNames,
            ref string[] loadPatterns,
            ref int[] loadPatternSteps,
            ref string[] coordinateSystem,
            ref Loads[] forces,
            eItemTypeElement itemType = eItemTypeElement.Element)
        {
            double[] F1 = new double[0];
            double[] F2 = new double[0];
            double[] F3 = new double[0];
            double[] M1 = new double[0];
            double[] M2 = new double[0];
            double[] M3 = new double[0];

            _callCode = _sapModel.PointElm.GetLoadForce(name, ref numberItems, ref pointNames, ref loadPatterns, ref loadPatternSteps, ref coordinateSystem, ref F1, ref F2, ref F3, ref M1, ref M2, ref M3,  CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            forces = new Loads[numberItems-1];
            for (int i = 0; i < numberItems; i++)
            {
                forces[i].F1 = F1[i];
                forces[i].F2 = F2[i];
                forces[i].F3 = F3[i];
                forces[i].M1 = M1[i];
                forces[i].M2 = M2[i];
                forces[i].M3 = M3[i];
            }
        }



        /// <summary>
        /// This function returns a list of ground displacement load assignments made to one or more specified point elements.
        /// </summary>
        /// <param name="name">The name of an existing point object, element or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="numberItems">This is the total number of ground displacement load assignments returned.</param>
        /// <param name="pointNames">The name of the point element to which the specified ground displacement load assignment applies.</param>
        /// <param name="loadPatterns">The name of the load pattern for each load.</param>
        /// <param name="loadPatternSteps">The load pattern step for each load. 
        /// In most cases this item does not apply and will be returned as 0.</param>
        /// <param name="coordinateSystem">The name of the coordinate system for the ground displacement. 
        /// This is either Local or the name of a defined coordinate system.</param>
        /// <param name="displacements">The ground displacements assigned along the local or global axis direction, depending on the specified <paramref name="coordinateSystem"/>.</param>
        /// <param name="itemType">If this item is <see cref="eItemTypeElement.ObjectElement"/>, the load assignments are retrieved for the elements corresponding to the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemTypeElement.Element"/>, the load assignments are retrieved for the element specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemTypeElement.GroupElement"/>, the load assignments are retrieved for the elements corresponding to all objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemTypeElement.SelectionElement"/>, the load assignments are retrieved for elements corresponding to all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void GetLoadDisplacement(string name,
            ref int numberItems,
            ref string[] pointNames,
            ref string[] loadPatterns,
            ref int[] loadPatternSteps,
            ref string[] coordinateSystem,
            ref Displacements[] displacements,
            eItemTypeElement itemType = eItemTypeElement.Element)
        {
            double[] U1 = new double[0];
            double[] U2 = new double[0];
            double[] U3 = new double[0];
            double[] R1 = new double[0];
            double[] R2 = new double[0];
            double[] R3 = new double[0];

            _callCode = _sapModel.PointElm.GetLoadDispl(name, ref numberItems, ref pointNames, ref loadPatterns, ref loadPatternSteps, ref coordinateSystem, ref U1, ref U2, ref U3, ref R1, ref R2, ref R3, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            displacements = new Displacements[numberItems - 1];
            for (int i = 0; i < numberItems; i++)
            {
                displacements[i].UX = U1[i];
                displacements[i].UY = U2[i];
                displacements[i].UZ = U3[i];
                displacements[i].RX = R1[i];
                displacements[i].RY = R2[i];
                displacements[i].RZ = R3[i];
            }
        }

        #endregion
    }
}
