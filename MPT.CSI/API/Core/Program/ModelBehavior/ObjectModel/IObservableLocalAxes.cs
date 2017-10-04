using MPT.CSI.API.Core.Helpers;

namespace MPT.CSI.API.Core.Program.ModelBehavior.ObjectModel
{
    /// <summary>
    /// Object can return local axes rotational offset.
    /// </summary>
    public interface IObservableLocalAxes
    {
        /// <summary>
        /// This function retrieves the local axis angle assignment of the object.
        /// </summary> 
        /// <param name="name">The name of an existing object.</param>
        /// <param name="angleOffset">This is the angle 'a' that the local 1 and 2 axes are rotated about the positive local 3 axis from the default orientation. 
        /// The rotation for a positive angle appears counter clockwise when the local +3 axis is pointing toward you. [deg]</param>
        /// <param name="isAdvanced">True object local axes orientation was obtained using advanced local axes parameters.</param>
        void GetLocalAxes(string name,
            ref AngleLocalAxes angleOffset,
            ref bool isAdvanced);
    }
}
