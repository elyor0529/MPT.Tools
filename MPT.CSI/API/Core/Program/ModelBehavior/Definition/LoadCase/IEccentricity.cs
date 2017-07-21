﻿namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Load case implements eccentricity characteristics.
    /// </summary>
    public interface IEccentricity
    {
        /// <summary>
        /// This function retrieves the eccentricity ratio that applies to all diaphragms for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case.</param>
        /// <param name="eccentricity">The eccentricity ratio that applies to all diaphragms.</param>
        void GetEccentricity(string name,
            ref double eccentricity);

        /// <summary>
        /// This function sets the eccentricity ratio that applies to all diaphragms for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case.</param>
        /// <param name="eccentricity">The eccentricity ratio that applies to all diaphragms.</param>
        void SetEccentricity(string name,
            double eccentricity);



        /// <summary>
        /// This function retrieves the diaphragm eccentricity overrides for a load case.
        /// </summary>
        /// <param name="name">The name of an existing load case.</param>
        /// <param name="numberOfItems">The number of diaphragm eccentricity overrides for the specified load case.</param>
        /// <param name="diaphragms">The names of the diaphragms that have eccentricity overrides.</param>
        /// <param name="eccentricities">The eccentricity applied to each diaphragm. [L].</param>
        void GetDiaphragmEccentricityOverride(string name,
            ref int numberOfItems,
            ref string[] diaphragms,
            ref double[] eccentricities);


        /// <summary>
        /// This function sets the eccentricity ratio that applies to all diaphragms for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing load case.</param>
        /// <param name="diaphragm">The name of an existing special rigid diaphragm constraint, that is, a diaphragm constraint with the following features:
        /// 1. The constraint type is <see cref="eConstraintType.Diaphragm"/>; 
        /// 2. The constraint coordinate system is <see cref="CoordinateSystems.Global"/>; 
        /// 3. The constraint axis is Z;</param>
        /// <param name="eccentricities">The eccentricity applied to each diaphragm. [L].</param>
        /// <param name="delete">True: The eccentricity override for the specified diaphragm is deleted.</param>
        void SetDiaphragmEccentricityOverride(string name,
            string diaphragm,
            double eccentricities,
            bool delete = false);
    }
}