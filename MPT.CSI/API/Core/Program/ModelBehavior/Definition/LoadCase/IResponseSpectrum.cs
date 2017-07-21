namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadCase
{
    /// <summary>
    /// Represents the response spectrum load case in the application.
    /// </summary>
    public interface IResponseSpectrum :
        ISetLoadCase, ILoadResponseSpectrum, IDampingModal, IModalCase, IEccentricity, IModalCombination, IDirectionalCombination
    {
    }
}
