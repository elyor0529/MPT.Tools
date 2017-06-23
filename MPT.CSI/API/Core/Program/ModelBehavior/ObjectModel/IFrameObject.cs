
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Represents the Frame Object in the application.
    /// </summary>
    public interface IFrameObject:
        IObservableFrame, IChangeableFrame,

        IAddableObject,
        ICountable, IListableNames, IChangeableName, IGroupAssignable, ISelectable, IDeletable,
        ILocalAxes, ILocalAxesAdvanced, IGUID, IMass, IOutputStations, IAutoMesh, 
        ILineSpring, IDeletableSpring,

        IObservableTransformationMatrix, IObservablePoints, IObservableElement,
        
        IObservableSection, IChangeableSection,
        IObservableMaterialTemperature, IChangeableMaterialTemperature,
        IObservableModifiers, IChangeableModifiers,
        IObservableMaterialOverwrite, IChangeableMaterialOverwrite,
        IObservableTensionCompressionLimits, IChangeableTensionCompressionLimits,

        // Loads
        ILoadGravity, 
        ILoadDeformation, 
        ILoadTargetForce, 
        
        ILoadStrain, 
        ILoadTemperature, 

        ILoadDistributed, 

        ILoadDistributedWithGUID,

        ILoadPoint,

        ILoadPointWithGUID,

        ILoadTransfer
    {
        void GetFireProofing();
        void SetFireProofing();
        void DeleteFireProofing();

        void GetLateralBracing();
        void SetLateralBracing();
        void DeleteLateralBracing();

        // Adjust w/ IObservableFrame, IChangeableFrame
        void GetPDeltaForce();
        void SetPDeltaForce();
        void DeletePDeltaForce();

        void GetCurved();
        void SetCurved();
        void SetStraight();


        void GetDAMModifiers();


        void GetDesignProcedure();
        void SetDesignProcedure();

        void GetEndSkew();
        void SetEndSkew();

        void GetHingeAssigns();


        // Adjust w/ IObservableFrame, IChangeableFrame
        void GetInsertionPoint();
        void SetInsertionPoint();

        // Compare to Area
        /// <summary>
        /// This function retrieves the method to determine the notional size of an area section for the creep and shrinkage calculations. 
        /// This function is currently worked for shell type area section.
        /// </summary>
        /// <param name="name">The name of an existing shell-type area section property.</param>
        /// <param name="sizeType">The type to define the notional size of a section.</param>
        /// <param name="value">For <paramref name="sizeType"/> is <see cref="eNotionalSizeType.Auto"/>, the Value represents for the scale factor to the program-determined notional size.  
        /// For <paramref name="sizeType"/> is <see cref="eNotionalSizeType.User"/>, the Value represents for the user-defined notional size [L]. 
        /// For <paramref name="sizeType"/> is <see cref="eNotionalSizeType.None"/>, the Value will not be used and can be set to 1.</param>
        void GetNotionalSize(string name,
            ref eNotionalSizeType sizeType,
            ref double value);

        /// <summary>
        /// This function assigns the method to determine the notional size of an area section for the creep and shrinkage calculations. 
        /// This function is currently worked for shell type area section.
        /// </summary>
        /// <param name="name">The name of an existing shell-type area section property.</param>
        /// <param name="sizeType">The type to define the notional size of a section.</param>
        /// <param name="value">For <paramref name="sizeType"/> is <see cref="eNotionalSizeType.Auto"/>, represents for the scale factor to the program-determined notional size.  
        /// For <paramref name="sizeType"/> is <see cref="eNotionalSizeType.User"/>, represents for the user-defined notional size [L]. 
        /// For <paramref name="sizeType"/> is <see cref="eNotionalSizeType.None"/>, will not be used and can be set to 1.</param>
        void SetNotionalSize(string name,
            eNotionalSizeType sizeType,
            double value);


        void GetReleases();
        void SetReleases();


        void GetSectionNonPrismatic();
        //void SetSectionNonPrismatic();

        void GetTrapezoidal();
        void SetTrapezoidal();


        void GetTypeOAPI();

    }
}
