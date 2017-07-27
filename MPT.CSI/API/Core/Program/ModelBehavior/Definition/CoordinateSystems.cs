﻿using MPT.CSI.API.Core.Support;

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


#elif BUILD_ETABS2015
using ETABS2015;
#elif BUILD_ETABS2016
using ETABS2016;
#endif

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Represents the coordinate systems in the application.
    /// </summary>
    public class CoordinateSystems : CSiApiBase, 
        IChangeableName, ICountable, IDeletable, IListableNames, IObservableTransformationMatrix
    {

        #region Fields

        public const string Global = "GLOBAL";
        public const string Local = "LOCAL";

        #endregion

        #region Initialization

        public CoordinateSystems(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Interface

        /// <summary>
        /// The function returns zero if the new name is successfully applied, otherwise it returns a nonzero value.
        /// Changing the name of the Global coordinate system will fail and return an error.
        /// </summary>
        /// <param name="name">The existing name of a defined coordinate system.</param>
        /// <param name="newName">The new name for the coordinate system.</param>
        public void ChangeName(string name,
            string newName)
        {
            if (Global.CompareTo(name) == 0)
            {
                throw new CSiReservedNameException("Cannot change global coordinate system name " + Global);
            }
            if (Global.CompareTo(newName) == 0)
            {
                throw new CSiReservedNameException("Cannot change coordinate system name " + newName  + "to global coordinate system name " + Global);
            }

            _callCode = _sapModel.CoordSys.ChangeName(name, newName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// The function returns the number of defined coordinate systems.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.CoordSys.Count();
        }

        /// <summary>
        /// The function deletes the specified coordinate system. 
        /// Attempting to delete the Global coordinate system will fail and return an error.
        /// </summary>
        /// <param name="nameCoordinateSystem">The name of an existing coordinate system.</param>
        public void Delete(string nameCoordinateSystem)
        {
            if (Global.CompareTo(nameCoordinateSystem) == 0)
            {
                throw new CSiReservedNameException("Cannot delete global coordinate system " + Global);
            }

            _callCode = _sapModel.CoordSys.Delete(nameCoordinateSystem);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of all defined coordinate systems.
        /// </summary>
        /// <param name="numberOfNames">The number of coordinate system names retrieved by the program.</param>
        /// <param name="coordinateSystemNames">The coordinate system names retrieved by the program.</param>
        public void GetNameList(ref int numberOfNames,
            ref string[] coordinateSystemNames)
        {
            _callCode = _sapModel.CoordSys.GetNameList(ref numberOfNames, ref coordinateSystemNames);
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
            _callCode = _sapModel.CoordSys.GetTransformationMatrix(nameCoordinateSystem, ref directionCosines);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion

        #region Methods: Public

        // === Get/Set ===

        /// <summary>
        /// Retrieves the translation and rotation of the specified coordinate system origin and axes in relation to the global coordinate system.
        /// </summary>
        /// <param name="nameCoordinateSystem">The name of an existing coordinate system.</param>
        /// <param name="xCoordinateOrigin">The global X coordinate of the origin of the coordinate system. [L]</param>
        /// <param name="yCoordinateOrigin">The global Y coordinate of the origin of the coordinate system. [L]</param>
        /// <param name="zCoordinateOrigin">The global Z coordinate of the origin of the coordinate system. [L]</param>
        /// <param name="rzCoordinateOrigin">The rotation of an axis of the new coordinate system relative to the global coordinate system is defined as follows: 
        /// (1) Rotate the coordinate system about the positive global Z-axis as defined by the RZ item. 
        /// (2) Rotate the coordinate system about the positive global Y-axis as defined by the RY item. 
        /// (3) Rotate the coordinate system about the positive global X-axis as defined by the RX item.  
        /// Note that the order in which these rotations are performed is important.  
        /// RX, RY and RZ are angles in degrees [deg].</param>
        /// <param name="ryCoordinateOrigin">The rotation of an axis of the new coordinate system relative to the global coordinate system is defined as follows: 
        /// (1) Rotate the coordinate system about the positive global Z-axis as defined by the RZ item. 
        /// (2) Rotate the coordinate system about the positive global Y-axis as defined by the RY item. 
        /// (3) Rotate the coordinate system about the positive global X-axis as defined by the RX item.  
        /// Note that the order in which these rotations are performed is important.  
        /// RX, RY and RZ are angles in degrees [deg].</param>
        /// <param name="rxCoordinateOrigin">The rotation of an axis of the new coordinate system relative to the global coordinate system is defined as follows: 
        /// (1) Rotate the coordinate system about the positive global Z-axis as defined by the RZ item. 
        /// (2) Rotate the coordinate system about the positive global Y-axis as defined by the RY item. 
        /// (3) Rotate the coordinate system about the positive global X-axis as defined by the RX item.  
        /// Note that the order in which these rotations are performed is important.  
        /// RX, RY and RZ are angles in degrees [deg].</param>
        public void GetCoordSys(string nameCoordinateSystem,
            ref double xCoordinateOrigin,
            ref double yCoordinateOrigin,
            ref double zCoordinateOrigin,
            ref double rzCoordinateOrigin,
            ref double ryCoordinateOrigin,
            ref double rxCoordinateOrigin)
        {
            _callCode = _sapModel.CoordSys.GetCoordSys(nameCoordinateSystem, ref xCoordinateOrigin, ref yCoordinateOrigin, ref zCoordinateOrigin, ref rzCoordinateOrigin, ref ryCoordinateOrigin, ref rxCoordinateOrigin);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// Sets the translation and rotation of the specified coordinate system origin and axes in relation to the global coordinate system.
        /// Modifying the Global coordinate system will fail and return an error.
        /// </summary>
        /// <param name="nameCoordinateSystem">The name of an existing coordinate system.</param>
        /// <param name="xCoordinateOrigin">The global X coordinate of the origin of the coordinate system. [L]</param>
        /// <param name="yCoordinateOrigin">The global Y coordinate of the origin of the coordinate system. [L]</param>
        /// <param name="zCoordinateOrigin">The global Z coordinate of the origin of the coordinate system. [L]</param>
        /// <param name="rzCoordinateOrigin">The rotation of an axis of the new coordinate system relative to the global coordinate system is defined as follows: 
        /// (1) Rotate the coordinate system about the positive global Z-axis as defined by the RZ item. 
        /// (2) Rotate the coordinate system about the positive global Y-axis as defined by the RY item. 
        /// (3) Rotate the coordinate system about the positive global X-axis as defined by the RX item.  
        /// Note that the order in which these rotations are performed is important.  
        /// RX, RY and RZ are angles in degrees [deg].</param>
        /// <param name="ryCoordinateOrigin">The rotation of an axis of the new coordinate system relative to the global coordinate system is defined as follows: 
        /// (1) Rotate the coordinate system about the positive global Z-axis as defined by the RZ item. 
        /// (2) Rotate the coordinate system about the positive global Y-axis as defined by the RY item. 
        /// (3) Rotate the coordinate system about the positive global X-axis as defined by the RX item.  
        /// Note that the order in which these rotations are performed is important.  
        /// RX, RY and RZ are angles in degrees [deg].</param>
        /// <param name="rxCoordinateOrigin">The rotation of an axis of the new coordinate system relative to the global coordinate system is defined as follows: 
        /// (1) Rotate the coordinate system about the positive global Z-axis as defined by the RZ item. 
        /// (2) Rotate the coordinate system about the positive global Y-axis as defined by the RY item. 
        /// (3) Rotate the coordinate system about the positive global X-axis as defined by the RX item.  
        /// Note that the order in which these rotations are performed is important.  
        /// RX, RY and RZ are angles in degrees [deg].</param>
        public void SetCoordSys(string nameCoordinateSystem,
            double xCoordinateOrigin,
            double yCoordinateOrigin,
            double zCoordinateOrigin,
            double rzCoordinateOrigin,
            double ryCoordinateOrigin,
            double rxCoordinateOrigin)
        {
            if (Global.CompareTo(nameCoordinateSystem) == 0)
            {
                throw new CSiReservedNameException("Cannot modify global coordinate system " + Global);
            }
            _callCode = _sapModel.CoordSys.SetCoordSys(nameCoordinateSystem, xCoordinateOrigin, yCoordinateOrigin, zCoordinateOrigin, rzCoordinateOrigin, ryCoordinateOrigin, rxCoordinateOrigin);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
