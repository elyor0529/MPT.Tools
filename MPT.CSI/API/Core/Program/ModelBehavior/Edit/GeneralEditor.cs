using MPT.CSI.API.Core.Support;

#if BUILD_SAP2000v16
using SAP2000v16;
#elif BUILD_SAP2000v17
using SAP2000v17;
#elif BUILD_SAP2000v18
using SAP2000v18;
#elif BUILD_SAP2000v19
using SAP2000v19;
#elif BUILD_ETABS2013
using ETABS2013;
#elif BUILD_ETABS2014
using ETABS2014;
#elif BUILD_ETABS2015
using ETABS2015;
#elif BUILD_ETABS2016
using ETABS2016;
#endif

namespace MPT.CSI.API.Core.Program.ModelBehavior.Edit
{
    /// <summary>
    /// Represents the general editor in the application.
    /// </summary>
    public class GeneralEditor : CSiApiBase
    {
        #region Initialization

        public GeneralEditor(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Public
        
        public void ExtrudeAreaToSolidLinearNormal(string param)
        {
            //_callCode = _sapModel.EditSolid.ExtrudeAreaToSolidLinearNormal();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        public void ExtrudeAreaToSolidLinearUser(string param)
        {
            //_callCode = _sapModel.EditSolid.ExtrudeAreaToSolidLinearUser();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void ExtrudeAreaToSolidRadial(string param)
        {
            //_callCode = _sapModel.EditSolid.ExtrudeAreaToSolidRadial();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void ExtrudeFrameToAreaLinear(string param)
        {
            //_callCode = _sapModel.EditSolid.ExtrudeFrameToAreaLinear();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void ExtrudeFrameToAreaRadial(string param)
        {
            //_callCode = _sapModel.EditSolid.ExtrudeFrameToAreaRadial();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void ExtrudePointToFrameLinear(string param)
        {
            //_callCode = _sapModel.EditSolid.ExtrudePointToFrameLinear();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void ExtrudePointToFrameRadial(string param)
        {
            //_callCode = _sapModel.EditSolid.ExtrudePointToFrameRadial();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void Move(string param)
        {
            //_callCode = _sapModel.EditSolid.Move();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void ReplicateLinear(string param)
        {
            //_callCode = _sapModel.EditSolid.ReplicateLinear();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        public void ReplicateMirror(string param)
        {
            //_callCode = _sapModel.EditSolid.ReplicateMirror();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void ReplicateRadial(string param)
        {
            //_callCode = _sapModel.EditSolid.ReplicateRadial();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
