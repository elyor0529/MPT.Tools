using MPT.CSI.API.Core.Support;

#if BUILD_SAP2000v16
using CSiProgram = SAP2000v16;
#elif BUILD_SAP2000v17
using CSiProgram = SAP2000v17;
#elif BUILD_SAP2000v18
using CSiProgram = SAP2000v18;
#elif BUILD_SAP2000v19
using CSiProgram = SAP2000v19;
#elif BUILD_ETABS2013
using CSiProgram = ETABS2013;
#elif BUILD_ETABS2014
using CSiProgram = ETABS2014;
#elif BUILD_ETABS2015
using CSiProgram = ETABS2015;
#elif BUILD_ETABS2016
using CSiProgram = ETABS2016;
#endif

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Represents the bridge objects in the application.
    /// </summary>
    public class BridgeObjects : CSiApiBase
    {

        #region Initialization

        public BridgeObjects(CSiApiSeed seed) : base(seed)
        {
        }


        #endregion

        // TODO: Compiler notes for CSiBridge for thes.

        #region Methods: Public

        // === Get/Set ===

        /// <summary>
        /// This function returns a flag indicating if the specified bridge object is currently linked to existing objects in the model. 
        /// If the bridge object is linked, it returns the model type (spine, area or solid) and meshing data used when the linked bridge model was updated.
        /// </summary>
        /// <param name="name">The name of an existing bridge object.</param>
        /// <param name="linkedModelExists">True: a linked bridge model exists for the specified bridge object.</param>
        /// <param name="modelType">Indicates the linked bridge model type. 
        /// This only applies when <paramref name="linkedModelExists"/> is true.</param>
        /// <param name="maxLengthDeck">The maximum length for the deck objects in the linked bridge model. [L]
        /// This only applies when <paramref name="linkedModelExists"/> is true.</param>
        /// <param name="maxLengthCapBeam">The maximum length for the cap beam objects in the linked bridge model. [L]
        /// This only applies when <paramref name="linkedModelExists"/> is true.</param>
        /// <param name="maxLengthColumn">The maximum length for the column objects in the linked bridge model. [L]
        /// This only applies when <paramref name="linkedModelExists"/> is true.</param>
        /// <param name="subMeshSize">The maximum submesh size for area and solid objects in the linked bridge model. [L]
        /// This only applies when <paramref name="linkedModelExists"/> is true and <paramref name="modelType"/> is an area or solid model.</param>
        public void GetBridgeUpdateData(string name,
            ref bool linkedModelExists,
            ref eBridgeLinkModelType modelType,
            ref double maxLengthDeck,
            ref double maxLengthCapBeam,
            ref double maxLengthColumn,
            ref double subMeshSize)
        {
            int csiModelType = 0;

            //_callCode = _sapModel.BridgeObj.GetBridgeUpdateData(name, ref linkedModelExists, ref csiModelType, ref maxLengthDeck, ref maxLengthCapBeam, re maxLengthColumn, ref subMeshSize);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            modelType = (eBridgeLinkModelType) csiModelType;
        }

        /// <summary>
        /// This function updates a linked bridge model, clears all objects from a linked bridge model, or converts a linked bridge model to an unlinked model.
        /// </summary>
        /// <param name="name">The name of an existing bridge object.</param>
        /// <param name="action">The action to be taken to the linked bridge object.</param>
        /// <param name="modelType">Indicates the linked bridge model type. 
        /// This only applies when <paramref name="action"/> is set to update.</param>
        /// <param name="maxLengthDeck">The maximum length for the deck objects in the linked bridge model. [L]
        /// This only applies when <paramref name="action"/> is set to update.</param>
        /// <param name="maxLengthCapBeam">The maximum length for the cap beam objects in the linked bridge model. [L]
        /// This only applies when <paramref name="action"/> is set to update.</param>
        /// <param name="maxLengthColumn">The maximum length for the column objects in the linked bridge model. [L]
        /// This only applies when <paramref name="action"/> is set to update.</param>
        /// <param name="subMeshSize">The maximum submesh size for area and solid objects in the linked bridge model. [L]
        /// This only applies when <paramref name="action"/> is set to update and <paramref name="modelType"/> is an area or solid model.</param>
        public void SetBridgeUpdateData(string name,
            eBridgeLinkAction action,
            eBridgeLinkModelType modelType,
            double maxLengthDeck,
            double maxLengthCapBeam,
            double maxLengthColumn,
            double subMeshSize)
        {
            //_callCode = _sapModel.BridgeObj.SetBridgeUpdateData(name, (int)action, (int)modelType, maxLengthDeck, maxLengthCapBeam, maxLengthColumn, subMeshSize);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // ===

        /// <summary>
        /// Determines whether or not bridge objects are to be automatically updated before analysis, if needed.
        /// </summary>
        /// <param name="updateBridgeObjects">True: Program automatically updates bridge objects before running an analysis if it detects anything has been changed that might affect the bridge analysis.</param>
        public void GetBridgeUpdateForAnalysisFlag(ref bool updateBridgeObjects)
        {
            //updateBridgeObjects = _sapModel.BridgeObj.GetBridgeUpdateForAnalysisFlag();
        }

        /// <summary>
        /// Sets whether or not bridge objects are to be automatically updated before analysis, if needed.
        /// </summary>
        /// <param name="updateBridgeObjects">True: Program automatically updates bridge objects before running an analysis if it detects anything has been changed that might affect the bridge analysis.</param>
        public void SetBridgeUpdateForAnalysisFlag(bool updateBridgeObjects)
        {
            
            //_callCode = _sapModel.BridgeObj.SetBridgeUpdateForAnalysisFlag(updateBridgeObjects);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
