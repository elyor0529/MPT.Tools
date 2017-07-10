using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Property.Frame
{
    /// <summary>
    /// Represents the section designer frame section in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class SectionDesigner : CSiApiBase
    {
        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="SectionDesigner"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public SectionDesigner(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Public


        public void GetMethod(string nameFrame)
        {
            //_callCode = _sapModel.SapModel.PropFrame.SDShape
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetMethod(string nameFrame, eItemType itemType = eItemType.Object)
        {
            //_callCode = _sapModel.SapModel.PropFrame.SDShape
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}