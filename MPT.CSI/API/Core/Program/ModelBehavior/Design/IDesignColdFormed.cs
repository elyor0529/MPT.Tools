#if BUILD_SAP2000v16 || BUILD_SAP2000v17 || BUILD_SAP2000v18 || BUILD_SAP2000v19
namespace MPT.CSI.API.Core.Program.ModelBehavior.Design
{
    /// <summary>
    /// Implements a design interface for all cold-formed steel frame elements.
    /// </summary>
    public interface IDesignColdFormed : IDesignMetal
    {

    }
}
#endif