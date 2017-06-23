
namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Represents the Point Object in the application.
    /// </summary>
    public interface IPointObject:
        ICountable, IListableNames, IObservableTransformationMatrix, ILocalAxes,
        IObservablePointSpring, IChangeablePointSpring, IDeletableSpring
    {
    }
}
