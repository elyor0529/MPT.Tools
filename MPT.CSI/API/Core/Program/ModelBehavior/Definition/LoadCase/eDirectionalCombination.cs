﻿namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Directional combination methods available in the application for combining multiple loads applied in different directions.
    /// </summary>
    public enum eDirectionalCombination
    {
        /// <summary>
        /// Square-Root of the Sum-of-Squares method.
        /// </summary>
        SRSS = 1,

        /// <summary>
        /// The absolute value of the sums method.
        /// </summary>
        ABS = 2,

        /// <summary>
        /// The Complete Quadratic Combination 3 method.
        /// This method was found to give the most realistic results when a bridge is analyzed using the Elastic Dynamic Analysis (EDA) method.
        /// </summary>
        CQC3 = 3
    }
}