// ***********************************************************************
// Assembly         : MPT.CSI.API
// Author           : Mark
// Created          : 06-15-2017
//
// Last Modified By : Mark
// Last Modified On : 09-28-2017
// ***********************************************************************
// <copyright file="ILineElement.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel
{
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
    /// <summary>
    /// Represents the Line Element in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel.IObservableInsertionPoint" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel.IObservableOffset" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.ICountable" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.IListableNames" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.IObservableTransformationMatrix" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel.IObservableLocalAxes" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.IObservableModifiers" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.IObservableObject" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.IObservablePoints" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.IObservableReleases" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.IObservableSection" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.IObservableMaterialOverwrite" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.IObservableTensionCompressionLimits" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.IObservablePDeltaForces" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.IObservableMaterialTemperature" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel.IObservableLoadDeformation" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel.IObservableLoadGravity" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel.IObservableLoadStrain" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel.IObservableLoadTargetForce" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel.IObservableLoadDistributed" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel.IObservableLoadPoint" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel.IObservableLoadTemperature" />
#else
    /// <summary>
    /// Represents the Line Element in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel.IObservableInsertionPoint" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel.IObservableOffset" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.ICountable" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.IListableNames" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.IObservableTransformationMatrix" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel.IObservableLocalAxes" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.IObservableModifiers" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.IObservableObject" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.IObservablePoints" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.IObservableReleases" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.IObservableSection" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.IObservableMaterialOverwrite" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.IObservableTensionCompressionLimits" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel.IObservableLoadDistributed" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel.IObservableLoadPoint" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.AnalysisModel.IObservableLoadTemperature" />
#endif
    public interface ILineElement:
        IObservableInsertionPoint, IObservableOffset,
        ICountable, IListableNames, IObservableTransformationMatrix, IObservableLocalAxes, 
        IObservableModifiers, IObservableObject, IObservablePoints, IObservableReleases,
        IObservableSection, IObservableMaterialOverwrite, IObservableTensionCompressionLimits,
#if !BUILD_ETABS2015 && !BUILD_ETABS2016
        IObservablePDeltaForces,
        IObservableMaterialTemperature, 

        IObservableLoadDeformation, 
        IObservableLoadGravity, 
        IObservableLoadStrain, 
        IObservableLoadTargetForce,
#endif
        IObservableLoadDistributed, 
        IObservableLoadPoint, 
        IObservableLoadTemperature
    {

    }
}
