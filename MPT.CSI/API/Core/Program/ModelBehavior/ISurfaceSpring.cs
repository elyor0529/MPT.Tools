﻿#if !BUILD_ETABS2015 && !BUILD_ETABS2016
using MPT.CSI.API.Core.Program.ModelBehavior.Definition;

namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Object has a readable/writeable surface pressure spring.
    /// </summary>
    public interface ISurfaceSpring
    {
        /// <summary>
        /// This function retrieves the spring assignments to an object face.
        /// </summary>
        /// <param name="name">The name of an existing object.</param>
        /// <param name="numberOfSprings">The number of springs assignments made to the specified object.</param>
        /// <param name="springTypes">The spring property type.</param>
        /// <param name="stiffnesses">Simple spring stiffness per unit area of the specified object face. [F/L^3]
        /// This item applies only when <paramref name="springTypes"/> = <see cref="eSpringType.Simple"/>.</param>
        /// <param name="springSimpleTypes">The simple spring type.
        /// This item applies only when <paramref name="springTypes"/> = <see cref="eSpringType.Simple"/>.</param>
        /// <param name="linkProperties">The name of the link property assigned to the spring.
        /// This item applies only when <paramref name="springTypes"/> = <see cref="eSpringType.Link"/>.</param>
        /// <param name="faces">Indicates the object face to which the specified spring assignment applies.</param>
        /// <param name="springLocalOneTypes">Indicates the method used to specify the spring positive local 1-axis orientation.</param>
        /// <param name="directions">This is 1, 2, 3, -1, -2 or -3, indicating the object local axis that corresponds to the positive local 1-axis of the spring.
        /// This item applies only when <paramref name="springLocalOneTypes"/> = <see cref="eSpringLocalOneType.Parallel"/>.</param>
        /// <param name="areOutward">True: The spring positive local 1 axis is outward from the specified object face.
        /// This item applies only when <paramref name="springLocalOneTypes"/> = <see cref="eSpringLocalOneType.Normal"/>.</param>
        /// <param name="vectorComponentsX">Each value in this array is the X-axis or object local 1-axis component (depending on the <paramref name="coordinateSystems"/> specified) of the user specified direction vector for the spring local 1-axis.
        /// The direction vector is in the coordinate system specified by the <paramref name="coordinateSystems"/> item.
        /// This item applies only when <paramref name="springLocalOneTypes"/> = <see cref="eSpringLocalOneType.User"/>.</param>
        /// <param name="vectorComponentsY">Each value in this array is the Y-axis or object local 2-axis component (depending on the <paramref name="coordinateSystems"/> specified) of the user specified direction vector for the spring local 1-axis.
        /// The direction vector is in the coordinate system specified by the <paramref name="coordinateSystems"/> item.
        /// This item applies only when <paramref name="springLocalOneTypes"/> = <see cref="eSpringLocalOneType.User"/>.</param>
        /// <param name="vectorComponentsZ">Each value in this array is the Z-axis or object local 3-axis component (depending on the <paramref name="coordinateSystems"/> specified) of the user specified direction vector for the spring local 1-axis.
        /// The direction vector is in the coordinate system specified by the <paramref name="coordinateSystems"/> item.
        /// This item applies only when <paramref name="springLocalOneTypes"/> = <see cref="eSpringLocalOneType.User"/>.</param>
        /// <param name="angleOffsets">This is the angle that the link local 2-axis is rotated from its default orientation. [deg]
        /// This item applies only when <paramref name="springTypes"/> = <see cref="eSpringType.Link"/>.</param>
        /// <param name="coordinateSystems">This is Local (meaning the solid object local coordinate system) or the name of a defined coordinate system. 
        /// This item is the coordinate system in which the user specified direction vector is specified. 
        /// This item applies only when <paramref name="springLocalOneTypes"/> = <see cref="eSpringLocalOneType.User"/>.</param>
        void GetSpring(string name,
            int numberOfSprings,
            ref eSpringType[] springTypes,
            ref double[] stiffnesses,
            ref eSpringSimpleType[] springSimpleTypes,
            ref string[] linkProperties,
            ref eFace[] faces,
            ref eSpringLocalOneType[] springLocalOneTypes,
            ref int[] directions,
            ref bool[] areOutward,
            ref double[] vectorComponentsX,
            ref double[] vectorComponentsY,
            ref double[] vectorComponentsZ,
            ref double[] angleOffsets,
            ref string[] coordinateSystems);

        /// <summary>
        /// This function makes spring assignments to objects. 
        /// The springs are assigned to a specified object face.
        /// </summary>
        /// <param name="name">The name of an existing object or group, depending on the value of the <paramref name="itemType"/> item.</param>
        /// <param name="springType">The spring property type.</param>
        /// <param name="stiffness">Simple spring stiffness per unit area of the specified object face. [F/L^3]
        /// This item applies only when <paramref name="springType"/> = <see cref="eSpringType.Simple"/>.</param>
        /// <param name="springSimpleType">The simple spring type.
        /// This item applies only when <paramref name="springType"/> = <see cref="eSpringType.Simple"/>.</param>
        /// <param name="linkProperty">The name of the link property assigned to the spring.
        /// This item applies only when <paramref name="springType"/> = <see cref="eSpringType.Link"/>.</param>
        /// <param name="face">Indicates the object face to which the specified spring assignment applies.</param>
        /// <param name="springLocalOneType">Indicates the method used to specify the spring positive local 1-axis orientation.</param>
        /// <param name="direction">This is 1, 2, 3, -1, -2 or -3, indicating the object local axis that corresponds to the positive local 1-axis of the spring.
        /// This item applies only when <paramref name="springLocalOneType"/> = <see cref="eSpringLocalOneType.Parallel"/>.</param>
        /// <param name="isOutward">True: The spring positive local 1 axis is outward from the specified object face.
        /// This item applies only when <paramref name="springLocalOneType"/> = <see cref="eSpringLocalOneType.Normal"/>.</param>
        /// <param name="vector">This is an array of three values that define the direction vector of the spring positive local 1-axis. 
        /// The direction vector is in the coordinate system specified by the <paramref name="coordinateSystem"/> item.
        /// This item applies only when <paramref name="springLocalOneType"/> = <see cref="eSpringLocalOneType.User"/>.</param>
        /// <param name="angleOffset">This is the angle that the link local 2-axis is rotated from its default orientation. [deg]
        /// This item applies only when <paramref name="springType"/> = <see cref="eSpringType.Link"/>.</param>
        /// <param name="replace">True: All existing spring assignments to the object are removed before assigning the specified spring. 
        /// False: The specified spring is added to any existing springs already assigned to the object.</param>
        /// <param name="coordinateSystem">This is Local (meaning the solid object local coordinate system) or the name of a defined coordinate system. 
        /// This item is the coordinate system in which the user specified direction vector, <paramref name="vector"/>, is specified. 
        /// This item applies only when <paramref name="springLocalOneType"/> = <see cref="eSpringLocalOneType.User"/>.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object"/>, the assignments are made for the object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group"/>, the assignments are made for the objects included in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects"/>, the assignments are made for all selected objects, and the <paramref name="name"/> item is ignored.</param>
        void SetSpring(string name,
            eSpringType springType,
            double stiffness,
            eSpringSimpleType springSimpleType,
            string linkProperty,
            eFace face,
            eSpringLocalOneType springLocalOneType,
            int direction,
            bool isOutward,
            double[] vector,
            double angleOffset,
            bool replace,
            string coordinateSystem = CoordinateSystems.Local,
            eItemType itemType = eItemType.Object);
    }
}
#endif