
namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Load pattern types available in the application.
    /// </summary>
    public enum eLoadPatternType
    {
        None = 0,
        Dead = 1,
        SuperDead,
        Live,
        LiveReducible,
        Quake,
        Wind,
        Snow,
        Other,
        Move,
        Temperature,
        LiveRoof,
        Notional,
        LivePattern,
        Wave,
        Braking,
        Centrifugal,
        Friction,
        Ice,
        WindOnLiveLoad,
        EarthPressureHorizontal,
        EarthPressureVertical,
        EarthSurcharge,
        DownDrag,
        VehicleCollision,
        VesselCollision,
        TemperatureGradient,
        Settlement,
        Shrinkage,
        Creep,
        WaterLoadPressure,
        LiveLoadSurcharge,
        LockedInForces,
        LiveLoadPedestrian,
        PreStress,
        HyperStatic,
        Bouyancy,
        StreamFlow,
        Impact,
        Construction
    }
}
