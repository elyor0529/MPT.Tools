#if !BUILD_ETABS2015 && !BUILD_ETABS2016
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Represents the moving modal load case in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase.ISetLoadCase" />
    /// <seealso cref="MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase.IInitialLoadCase" />
    public interface IMovingLoad :
        ISetLoadCase, IInitialLoadCase
    {
        /// <summary>
        /// This function retrieves the load data for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing moving load case.</param>
        /// <param name="numberOfLoads">The number of loads assigned to the specified analysis case.</param>
        /// <param name="vehicleClass">The vehicle class for each load assigned to the load case.</param>
        /// <param name="scaleFactor">The scale factor for each load assigned to the load case.</param>
        /// <param name="minLanesLoaded">The minimum number of lanes loaded for each load assigned to the load case.</param>
        /// <param name="maxLanesLoaded">The maximum number of lanes loaded for each load assigned to the load case.<para/> 
        /// This item must be 0, or it must be greater than or equal to <paramref name="minLanesLoaded"/>.<para/> 
        /// If this item is 0, all available lanes are loaded.</param>
        void GetLoads(string name,
            ref int numberOfLoads,
            ref string[] vehicleClass,
            ref double[] scaleFactor,
            ref double[] minLanesLoaded,
            ref double[] maxLanesLoaded);

        /// <summary>
        /// This function sets the load data for the specified analysis case.
        /// </summary>
        /// <param name="name">The name of an existing moving load case.</param>
        /// <param name="numberOfLoads">The number of loads assigned to the specified analysis case.</param>
        /// <param name="vehicleClass">The vehicle class for each load assigned to the load case.</param>
        /// <param name="scaleFactor">The scale factor for each load assigned to the load case.</param>
        /// <param name="minLanesLoaded">The minimum number of lanes loaded for each load assigned to the load case.</param>
        /// <param name="maxLanesLoaded">The maximum number of lanes loaded for each load assigned to the load case.<para/> 
        /// This item must be 0, or it must be greater than or equal to <paramref name="minLanesLoaded"/>.<para/> 
        /// If this item is 0, all available lanes are loaded.</param>
       void SetLoads(string name,
            int numberOfLoads,
            string[] vehicleClass,
            double[] scaleFactor,
            double[] minLanesLoaded,
            double[] maxLanesLoaded);




        /// <summary>
        /// This function retrieves the lanes loaded data for a specified load assignment number in a specified load case.
        /// </summary>
        /// <param name="name">The name of an existing moving load case.</param>
        /// <param name="loadNumber">The load assignment number.</param>
        /// <param name="numberOfItems">The number of lanes loaded for the specified load assignment number.</param>
        /// <param name="nameLanes">The name of each lane loaded for the specified load assignment number.</param>
        void GetLanesLoaded(string name,
            int loadNumber,
            ref int numberOfItems,
            ref string[] nameLanes);

        /// <summary>
        /// This function sets the lanes loaded data for a specified load assignment number in a specified load case.
        /// </summary>
        /// <param name="name">The name of an existing moving load case.</param>
        /// <param name="loadNumber">The load assignment number.</param>
        /// <param name="numberOfItems">The number of lanes loaded for the specified load assignment number.</param>
        /// <param name="nameLanes">The name of each lane loaded for the specified load assignment number.</param>
        void SetLanesLoaded(string name,
            int loadNumber,
            int numberOfItems,
            string[] nameLanes);





        /// <summary>
        /// This function retrieves the directional factors for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing moving load case.</param>
        /// <param name="verticalLoad">The moving load directional factor for vertical load.</param>
        /// <param name="brakingLoad">The moving load directional factor for loads in-line with the road.</param>
        /// <param name="centrifugalLoad">The moving directional factor for centrifugal load perpendicular with the road.</param>
        void GetDirectionalFactors(string name,
            ref double verticalLoad,
            ref double brakingLoad,
            ref double centrifugalLoad);

        /// <summary>
        /// This function sets the directional factors for the specified load case. 
        /// Calling this function is optional. 
        /// By default, the directional factors are set to Vertical = 1, Braking = 0, and Centrifugal = 0 when the moving load case is defined or re-defined. 
        /// If this function is called, the three directional factors must be nonnegative, and at least one must be positive.
        /// </summary>
        /// <param name="name">The name of an existing moving load case.</param>
        /// <param name="verticalLoad">The moving load directional factor for vertical load.</param>
        /// <param name="brakingLoad">The moving load directional factor for loads in-line with the road.</param>
        /// <param name="centrifugalLoad">The moving directional factor for centrifugal load perpendicular with the road.</param>
        void SetDirectionalFactors(string name,
            double verticalLoad,
            double brakingLoad,
            double centrifugalLoad);




        /// <summary>
        /// This function retrieves the multilane scale factor data for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing moving load case.</param>
        /// <param name="numberOfItems">The number of lanes loaded up to which reduction scale factors are provided (&gt;= 1).</param>
        /// <param name="scaleFactors">The reduction scale factor for the number of lanes loaded from 1 up to <paramref name="numberOfItems"/>.</param>
        void GetMultiLaneScaleFactor(string name,
            ref int numberOfItems,
            ref double[] scaleFactors);

        /// <summary>
        /// This function sets the multilane scale factor data for the specified load case.
        /// </summary>
        /// <param name="name">The name of an existing moving load case.</param>
        /// <param name="numberOfItems">The number of lanes loaded up to which reduction scale factors are provided (&gt;= 1).</param>
        /// <param name="scaleFactors">The reduction scale factor for the number of lanes loaded from 1 up to <paramref name="numberOfItems"/>.</param>
        void SetMultiLaneScaleFactor(string name,
            int numberOfItems,
            double[] scaleFactors);
    }
}
#endif
