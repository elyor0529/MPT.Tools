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

namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel
{
    /// <summary>
    /// Represents the point element in the application.
    /// </summary>
    public class PointElement : CSiApiBase, IPointElement
    {
        #region Initialization

        public PointElement(CSiApiSeed seed) : base(seed) {}

        #endregion

        #region Methods: Interface

        /// <summary>
        /// This function returns the total number of defined point elements in the model.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.PointElm.Count();
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
            _callCode = _sapModel.PointElm.GetNameList(ref numberOfNames, ref names);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

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

            objectType = (ePointTypeObject) csiObjectType;
        }
        #endregion

        #region Methods: Public

        public void GetThing(ref string param)
        {
            //_callCode = _sapModel.PointElm.
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        #endregion
    }
}
