﻿// ***********************************************************************
// Assembly         : MPT.CSI.API
// Author           : Mark Thomas
// Created          : 10-06-2017
//
// Last Modified By : Mark Thomas
// Last Modified On : 10-06-2017
// ***********************************************************************
// <copyright file="IFrameEditor.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Edit
{
    /// <summary>
    /// Implements the frame editor in the application.
    /// </summary>
    public interface IFrameEditor
    {
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        #region Methods: Public

        /// <summary>
        /// This function divides straight frame objects into two objects at a location defined by the Dist and IEnd items.
        /// Curved frame objects are not divided.
        /// TODO: Handle this.
        /// </summary>
        /// <param name="name">The name of an existing straight frame object.</param>
        /// <param name="divideDistance">The frame object is divided at this distance from the end specified by the IEnd item.[L]</param>
        /// <param name="fromIEnd">True: The <paramref name="divideDistance" /> item is measured from the I-end of the frame object.
        /// False: The <paramref name="divideDistance" /> item is measured from the J-end of the frame object.</param>
        /// <param name="newName">The names of the new frame objects.</param>
        void DivideAtDistance(string name,
            double divideDistance,
            bool fromIEnd,
            ref string[] newName);

        /// <summary>
        /// This function divides straight frame objects at intersections with selected point objects, line objects, area edges and solid edges.
        /// Curved frame objects are not divided.
        /// TODO: Handle this.
        /// </summary>
        /// <param name="name">The name of an existing straight frame object.</param>
        /// <param name="numberOfObjects">This is the number of frame objects into which the specified frame object is divided.</param>
        /// <param name="newName">The names of the new frame objects.</param>
        void DivideAtIntersections(string name,
            ref int numberOfObjects,
            ref string[] newName);

        /// <summary>
        /// This function divides straight frame objects based on a specified Last/First length ratio.
        /// Curved frame objects are not divided.
        /// TODO: Handle this.
        /// </summary>
        /// <param name="name">The name of an existing straight frame object.</param>
        /// <param name="numberOfObjects">The frame object is divided into this number of new objects.</param>
        /// <param name="ratioFirstLast">The Last/First length ratio for the new frame objects.</param>
        /// <param name="newName">The names of the new frame objects.</param>
        void DivideByRatio(string name,
            int numberOfObjects,
            double ratioFirstLast,
            ref string[] newName);

        /// <summary>
        /// This function trims straight frame objects.
        /// </summary>
        /// <param name="name">The name of an existing straight frame object to be trimmed.</param>
        /// <param name="IEnd">True: The I-End of the frame object specified by the <paramref name="name" /> item is to be trimmed.</param>
        /// <param name="JEnd">False: The I-End of the frame object specified by the <paramref name="name" /> item is to be trimmed.</param>
        /// <param name="extendLine1">The name of an existing straight frame object used as an extension line.</param>
        /// <param name="extendline2">The name of an existing straight frame object used as an extension line.</param>
        void Extend(string name,
            bool IEnd,
            bool JEnd,
            string extendLine1,
            string extendline2 = "");

        /// <summary>
        /// This function joins two straight frame objects that have a common end point and are colinear.
        /// </summary>
        /// <param name="name1">The name of an existing frame object to be joined.
        /// The new joined frame object keeps this name.</param>
        /// <param name="name2">The name of an existing frame object to be joined.</param>
        void Join(string name1,
            string name2);

        /// <summary>
        /// This function trims straight frame objects.
        /// Curved frame objects are not trimmed.
        /// TODO: Handle this.
        /// </summary>
        /// <param name="name">The name of an existing straight frame object to be trimmed.</param>
        /// <param name="IEnd">True: The I-End of the frame object specified by the <paramref name="name" /> item is to be trimmed.</param>
        /// <param name="JEnd">False: The I-End of the frame object specified by the <paramref name="name" /> item is to be trimmed.</param>
        /// <param name="trimLine1">The name of an existing straight frame object used as a trim line.</param>
        /// <param name="trimline2">The name of an existing straight frame object used as a trim line.</param>
        void Trim(string name,
            bool IEnd,
            bool JEnd,
            string trimLine1,
            string trimline2 = "");

        /// <summary>
        /// This function modifies the connectivity of a frame object.
        /// </summary>
        /// <param name="name">The name of an existing frame object.</param>
        /// <param name="point1">The name of the point object at the I-End of the frame object.</param>
        /// <param name="point2">The name of the point object at the J-End of the frame object.</param>
        void ChangeConnectivity(string name,
            string point1,
            string point2);

        #endregion

#endif
    }
}