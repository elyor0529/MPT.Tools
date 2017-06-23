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

namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel
{
    /// <summary>
    /// Represents the link element in the application.
    /// </summary>
    public class LinkElement : CSiApiBase, ILinkElement
    {
        #region Initialization

        public LinkElement(CSiApiSeed seed) : base(seed) { }
        #endregion

        #region Methods: Interface
        /// <summary>
        /// This function returns the total number of defined link elements in the model.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.LinkElm.Count();
        }


        // === Get ===

        /// <summary>
        /// This function retrieves the names of all items.
        /// </summary>
        /// <param name="numberOfNames">The number of item names retrieved by the program.</param>
        /// <param name="names">Names retrieved by the program.</param>
        public void GetNameList(ref int numberOfNames,
            ref string[] names)
        {
            _callCode = _sapModel.LineElm.GetNameList(ref numberOfNames, ref names);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        /// <summary>
        /// This function retrieves the section property assigned to a link element.
        /// </summary>
        /// <param name="name">The name of a defined link element.</param>
        /// <param name="propertyName">The name of the section property assigned to the link element.</param>
        public void GetSection(string name, 
            ref string propertyName)
        {
            _callCode = _sapModel.LinkElm.GetProperty(name, ref propertyName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the frequency dependent property assignment to a link element. 
        /// If no frequency dependent property is assigned to the link, the PropName is returned as None.
        /// </summary>
        /// <param name="name">The name of an existing link element.</param>
        /// <param name="propertyName">The name of the frequency dependent link property assigned to the link element.</param>
        public void GetSectionFrequencyDependent(string name, 
            string propertyName)
        {
            _callCode = _sapModel.LinkElm.GetPropertyFD(name, ref propertyName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the local axis angle assignment for the link element.
        /// </summary> 
        /// <param name="name">The name of an existing link element.</param>
        /// <param name="angleOffset">This is the angle 'a' that the local 1 and 2 axes are rotated about the positive local 3 axis from the default orientation. 
        /// The rotation for a positive angle appears counter clockwise when the local +3 axis is pointing toward you. [deg]</param>
        public void GetLocalAxes(string name,
            ref AngleLocalAxes angleOffset)
        {
            double angleA = 0;
            _callCode = _sapModel.LinkElm.GetLocalAxes(name, ref angleA);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            angleOffset.AngleA = angleA;
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
            _callCode = _sapModel.LinkElm.GetTransformationMatrix(nameCoordinateSystem, ref directionCosines);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of the point elements that define a link element.
        /// </summary>
        /// <param name="name">The name of an existing link element.</param>
        /// <param name="numberPoints">The number of point elements that define the link element.</param>
        /// <param name="points">The names of the points that defined the link element.
        /// The point names are listed in the positive order around the element.</param>
        public void GetPoints(string name, 
            ref int numberPoints, 
            ref string[] points)
        {
            string point1 = "";
            string point2 = "";

            _callCode = _sapModel.LinkElm.GetPoints(name, ref point1, ref point2);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            numberPoints = 2;
            points = new string[numberPoints - 1];
            points[0] = point1;
            points[1] = point2;
        }

        /// <summary>
        /// This function retrieves the name of the link object from which a link element was created.
        /// </summary>
        /// <param name="name">The name of an existing link element.</param>
        /// <param name="nameObject">The name of the link object from which the link element was created.</param>
        public void GetObject(string name, 
            ref string nameObject)
        {
            int csiObjectType = 0;

            _callCode = _sapModel.LinkElm.GetObj(name, ref nameObject, ref csiObjectType);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the name of the link object from which a link element was created. 
        /// It also retrieves the type of link object that it is.
        /// </summary>
        /// <param name="name">The name of an existing link element.</param>
        /// <param name="nameObject">The name of the link object from which the link element was created.</param>
        /// <param name="objectType">Type of object or defined item that is associated with the link element.</param>
        public void GetObject(string name, 
            ref string nameObject, 
            ref ePointTypeObject objectType)
        {
            int csiObjectType = 0;
            _callCode = _sapModel.LinkElm.GetObj(name, ref nameObject, ref csiObjectType);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            objectType = (ePointTypeObject)csiObjectType;
        }

        // === Loads ===

        /// <summary>
        /// This function retrieves the deformation load assignments to elements.
        /// </summary>
        /// <param name="name">The name of an existing object, element or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="numberItems">The total number of deformation loads retrieved for the specified elements.</param>
        /// <param name="names">The name of the element associated with each deformation load.</param>
        /// <param name="loadPatterns">The name of the load pattern associated with each deformation load.</param>
        /// <param name="degreesOfFreedom">Indicates if the considered degree of freedom has a deformation load for each load pattern.</param>
        /// <param name="deformations">Deformation load values for each load pattern. 
        /// The deformations specified for a given degree of freedom are applicable only if the corresponding DOF item for that degree of freedom is True.</param>
        /// <param name="itemType">If this item is <see cref="eItemTypeElement.ObjectElement"/>, the load assignments are retrieved for the elements corresponding to the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemTypeElement.Element"/>, the load assignments are retrieved for the element specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemTypeElement.GroupElement"/>, the load assignments are retrieved for the elements corresponding to all objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemTypeElement.SelectionElement"/>, the load assignments are retrieved for elements corresponding to all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void GetLoadDeformation(string name,
            ref int numberItems,
            ref string[] names,
            ref string[] loadPatterns,
            ref DegreesOfFreedomLocal[] degreesOfFreedom,
            ref Deformations[] deformations,
            eItemTypeElement itemType = eItemTypeElement.Element)
        {
            bool[] dof1 = new bool[0];
            bool[] dof2 = new bool[0];
            bool[] dof3 = new bool[0];
            bool[] dof4 = new bool[0];
            bool[] dof5 = new bool[0];
            bool[] dof6 = new bool[0];

            double[] u1Deformation = new double[0];
            double[] u2Deformation = new double[0];
            double[] u3Deformation = new double[0];
            double[] r1Deformation = new double[0];
            double[] r2Deformation = new double[0];
            double[] r3Deformation = new double[0];

            _callCode = _sapModel.LinkElm.GetLoadDeformation(name, ref numberItems, ref names, ref loadPatterns, ref dof1, ref dof2, ref dof3, ref dof4, ref dof5, ref dof6, ref u1Deformation, ref u2Deformation, ref u3Deformation, ref r1Deformation, ref r2Deformation, ref r3Deformation, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            degreesOfFreedom = new DegreesOfFreedomLocal[numberItems - 1];
            deformations = new Deformations[numberItems - 1];
            for (int i = 0; i < numberItems; i++)
            {
                degreesOfFreedom[i].U1 = dof1[i];
                degreesOfFreedom[i].U2 = dof2[i];
                degreesOfFreedom[i].U3 = dof3[i];
                degreesOfFreedom[i].R1 = dof4[i];
                degreesOfFreedom[i].R2 = dof5[i];
                degreesOfFreedom[i].R3 = dof6[i];

                deformations[i].U1 = u1Deformation[i];
                deformations[i].U2 = u2Deformation[i];
                deformations[i].U3 = u3Deformation[i];
                deformations[i].R1 = r1Deformation[i];
                deformations[i].R2 = r2Deformation[i];
                deformations[i].R3 = r3Deformation[i];
            }
        }

        ///<summary>
        /// This function retrieves the gravity load assignments to elements.
        /// </summary>
        /// <param name="name">The name of an existing object, element or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="numberItems">The total number of gravity loads retrieved for the specified elements.</param>
        /// <param name="names">The name of the element associated with each gravity load.</param>
        /// <param name="loadPatterns">The name of the coordinate system in which the gravity load multipliers are specified.</param>
        /// <param name="coordinateSystems">The name of the coordinate system associated with each gravity load.</param>
        /// <param name="xLoadMultiplier">Gravity load multipliers in the x direction of the specified coordinate system.</param>
        /// <param name="yLoadMultiplier">Gravity load multipliers in the y direction of the specified coordinate system.</param>
        /// <param name="zLoadMultiplier">Gravity load multipliers in the z direction of the specified coordinate system.</param>
        /// <param name="itemType">If this item is <see cref="eItemTypeElement.ObjectElement"/>, the load assignments are retrieved for the elements corresponding to the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemTypeElement.Element"/>, the load assignments are retrieved for the element specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemTypeElement.GroupElement"/>, the load assignments are retrieved for the elements corresponding to all objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemTypeElement.SelectionElement"/>, the load assignments are retrieved for elements corresponding to all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void GetLoadGravity(string name,
            ref int numberItems,
            ref string[] names,
            ref string[] loadPatterns,
            ref string[] coordinateSystems,
            ref double[] xLoadMultiplier,
            ref double[] yLoadMultiplier,
            ref double[] zLoadMultiplier,
            eItemTypeElement itemType = eItemTypeElement.Element)
        {
            _callCode = _sapModel.LinkElm.GetLoadGravity(name, ref numberItems, ref names, ref loadPatterns, ref coordinateSystems, ref xLoadMultiplier, ref yLoadMultiplier, ref zLoadMultiplier, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the target force assignments to elements.
        /// </summary>
        /// <param name="name">The name of an existing object, element or group of objects, depending on the value of <paramref name="itemType"/>.</param>
        /// <param name="numberItems">The total number of deformation loads retrieved for the specified elements.</param>
        /// <param name="names">The name of the element associated with each target force.</param>
        /// <param name="loadPatterns">The name of the load pattern associated with each target force.</param>
        /// <param name="forcesActive">Boolean values indicating if the considered degree of freedom has a target force assignment for each load pattern.</param>
        /// <param name="deformations">Target force values for each load pattern. 
        /// The target forces specified for a given degree of freedom are only applicable if the corresponding DOF item for that degree of freedom is True.</param>
        /// <param name="relativeForcesLocation">Relative distances along the line elements where the target force values apply for each load pattern. 
        /// The relative distances specified for a given degree of freedom are only applicable if the corresponding dofn item for that degree of freedom is True.</param>
        /// <param name="itemType">If this item is <see cref="eItemTypeElement.ObjectElement"/>, the load assignments are retrieved for the elements corresponding to the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemTypeElement.Element"/>, the load assignments are retrieved for the element specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemTypeElement.GroupElement"/>, the load assignments are retrieved for the elements corresponding to all objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemTypeElement.SelectionElement"/>, the load assignments are retrieved for elements corresponding to all selected objects, and the <paramref name="name"/> item is ignored.</param>
        public void GetLoadTargetForce(string name,
            ref int numberItems,
            ref string[] names,
            ref string[] loadPatterns,
            ref ForcesActive[] forcesActive,
            ref Deformations[] deformations,
            ref Forces[] relativeForcesLocation,
            eItemTypeElement itemType = eItemTypeElement.Element)
        {
            bool[] dof1 = new bool[0];
            bool[] dof2 = new bool[0];
            bool[] dof3 = new bool[0];
            bool[] dof4 = new bool[0];
            bool[] dof5 = new bool[0];
            bool[] dof6 = new bool[0];

            double[] u1Deformation = new double[0];
            double[] u2Deformation = new double[0];
            double[] u3Deformation = new double[0];
            double[] r1Deformation = new double[0];
            double[] r2Deformation = new double[0];
            double[] r3Deformation = new double[0];

            double[] T1 = new double[0];
            double[] T2 = new double[0];
            double[] T3 = new double[0];
            double[] T4 = new double[0];
            double[] T5 = new double[0];
            double[] T6 = new double[0];

            _callCode = _sapModel.LineElm.GetLoadTargetForce(name, ref numberItems, ref names, ref loadPatterns, ref dof1, ref dof2, ref dof3, ref dof4, ref dof5, ref dof6, ref u1Deformation, ref u2Deformation, ref u3Deformation, ref r1Deformation, ref r2Deformation, ref r3Deformation, ref T1, ref T2, ref T3, ref T4, ref T5, ref T6, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            forcesActive = new ForcesActive[numberItems - 1];
            deformations = new Deformations[numberItems - 1];
            relativeForcesLocation = new Forces[numberItems - 1];
            for (int i = 0; i < numberItems; i++)
            {
                forcesActive[i].P = dof1[i];
                forcesActive[i].V2 = dof2[i];
                forcesActive[i].V3 = dof3[i];
                forcesActive[i].T = dof4[i];
                forcesActive[i].M2 = dof5[i];
                forcesActive[i].M3 = dof6[i];

                deformations[i].U1 = u1Deformation[i];
                deformations[i].U2 = u2Deformation[i];
                deformations[i].U3 = u3Deformation[i];
                deformations[i].R1 = r1Deformation[i];
                deformations[i].R2 = r2Deformation[i];
                deformations[i].R3 = r3Deformation[i];

                relativeForcesLocation[i].P = T1[i];
                relativeForcesLocation[i].V2 = T2[i];
                relativeForcesLocation[i].V3 = T3[i];
                relativeForcesLocation[i].T = T4[i];
                relativeForcesLocation[i].M2 = T5[i];
                relativeForcesLocation[i].M3 = T6[i];
            }
        }
        #endregion
    }
}
