
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Represents the Area Object in the application.
    /// </summary>
    public interface IAreaObject :
        IObservableArea, IChangeableArea,
        IObservableModifiers, IChangeableModifiers,
        IObservableMaterialOverwrite, IChangeableMaterialOverwrite,

        IAddableObject,
        ICountable, IListableNames, IChangeableName, IGroupAssignable, ISelectable, IDeletable,
        ILocalAxes, ILocalAxesAdvanced, IGUID, IMass, IAutoMesh, IEdgeConstraints, 
        ISurfaceSpring, IDeletableSpring,
        IObservableTransformationMatrix, IObservablePoints, IObservableElement,
              
        IObservableSection, IChangeableSection,
        IObservableMaterialTemperature, IChangeableMaterialTemperature,

        // Loads
        ILoadGravity,
        ILoadPorePressure, 
        ILoadStrain,
        ILoadSurfacePressure,
        ILoadTemperature,

        ILoadUniform,
        ILoadRotate,

        ILoadUniformToFrame,
        ILoadWindPressure
    {
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



        /// <summary>
        /// This function retrieves the selected status for area object edges.
        /// </summary>
        /// <param name="name">The name of an existing area object.</param>
        /// <param name="numberOfEdges">The number of edges in the specified area object.</param>
        /// <param name="areEdgesSelected">True: The specified area object edge is selected;
        /// Selected(0) = Selected status for edge 1;
        /// Selected(1) = Selected status for edge 2;
        /// Selected(n) = Selected status for edge(n + 1)</param>
        void GetSelectedEdge(string name,
            ref int numberOfEdges,
            ref bool[] areEdgesSelected);

        /// <summary>
        /// This function sets the selected status for area object edges.
        /// </summary>
        /// <param name="name">The name of an existing area object</param>
        /// <param name="numberOfEdges">The area object edge that is have its selected status set.</param>
        /// <param name="isEdgeSelected">True: The specified area object edge is selected.</param>
        void SetSelectedEdge(string name,
            int numberOfEdges,
            bool isEdgeSelected);
        
    }
}
