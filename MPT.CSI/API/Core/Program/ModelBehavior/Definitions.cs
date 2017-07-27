using MPT.CSI.API.Core.Program.ModelBehavior.Definition;
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


#elif BUILD_ETABS2015
using ETABS2015;
#elif BUILD_ETABS2016
using ETABS2016;
#endif

namespace MPT.CSI.API.Core.Program.ModelBehavior
{
    /// <summary>
    /// Represents various definitions in the application, such as groups, load patterns, constraints, cross-sections, etc.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class Definitions : CSiApiBase
    {
        #region Fields
        private readonly CSiApiSeed _seed;

    #if BUILD_CSiBridgev18 || BUILD_CSiBridgev19
        private BridgeObjects _bridgeObjects;
    #endif
        private Constraints _constraints;
        private CoordinateSystems _coordinateSystems;
        private Functions _functions;
        private GeneralizedDisplacements _generalizedDisplacements;
        private GeneralReferenceLines _generalReferenceLines;
        private Groups _groups;
        private JointPatterns _jointPatterns;
        private LoadCases _loadCases;
        private LoadCombinations _loadCombinations;
        private LoadPatterns _loadPatterns;
        private MassSource _massSource;
        private NamedAssigns _namedAssigns;
        private NamedSets _namedSets;
        private Properties _properties;
        private SectionCuts _sectionCuts;
#endregion

#region Properties    
#if BUILD_CSiBridgev18 || BUILD_CSiBridgev19
        /// <summary>
        /// Gets the bridge objects.
        /// </summary>
        /// <value>The bridge objects.</value>
        public BridgeObjects BridgeObjects => _bridgeObjects ?? (_bridgeObjects = new BridgeObjects(_seed));
#endif
        /// <summary>
        /// Gets the constraints.
        /// </summary>
        /// <value>The constraints.</value>
        public Constraints Constraints => _constraints ?? (_constraints = new Constraints(_seed));

        /// <summary>
        /// Gets the coordinate systems.
        /// </summary>
        /// <value>The coordinate systems.</value>
        public CoordinateSystems CoordinateSystems => _coordinateSystems ?? (_coordinateSystems = new CoordinateSystems(_seed));

        /// <summary>
        /// Gets the functions.
        /// </summary>
        /// <value>The functions.</value>
        public Functions Functions => _functions ?? (_functions = new Functions(_seed));

        /// <summary>
        /// Gets the generalized displacements.
        /// </summary>
        /// <value>The generalized displacements.</value>
        public GeneralizedDisplacements GeneralizedDisplacements => _generalizedDisplacements ?? (_generalizedDisplacements = new GeneralizedDisplacements(_seed));

        /// <summary>
        /// Gets the general reference lines.
        /// </summary>
        /// <value>The general reference lines.</value>
        public GeneralReferenceLines GeneralReferenceLines => _generalReferenceLines ?? (_generalReferenceLines = new GeneralReferenceLines(_seed));

        /// <summary>
        /// Gets the groups.
        /// </summary>
        /// <value>The groups.</value>
        public Groups Groups => _groups ?? (_groups = new Groups(_seed));

        /// <summary>
        /// Gets the joint patterns.
        /// </summary>
        /// <value>The joint patterns.</value>
        public JointPatterns JointPatterns => _jointPatterns ?? (_jointPatterns = new JointPatterns(_seed));

        /// <summary>
        /// Gets the load cases.
        /// </summary>
        /// <value>The load cases.</value>
        public LoadCases LoadCases => _loadCases ?? (_loadCases = new LoadCases(_seed));

        /// <summary>
        /// Gets the load combinations.
        /// </summary>
        /// <value>The load combinations.</value>
        public LoadCombinations LoadCombinations => _loadCombinations ?? (_loadCombinations = new LoadCombinations(_seed));

        /// <summary>
        /// Gets the load patterns.
        /// </summary>
        /// <value>The load patterns.</value>
        public LoadPatterns LoadPatterns => _loadPatterns ?? (_loadPatterns = new LoadPatterns(_seed));

        /// <summary>
        /// Gets the mass source.
        /// </summary>
        /// <value>The mass source.</value>
        public MassSource MassSource => _massSource ?? (_massSource = new MassSource(_seed));

        /// <summary>
        /// Gets the named assigns.
        /// </summary>
        /// <value>The named assigns.</value>
        public NamedAssigns NamedAssigns => _namedAssigns ?? (_namedAssigns = new NamedAssigns(_seed));

        /// <summary>
        /// Gets the named sets.
        /// </summary>
        /// <value>The named sets.</value>
        public NamedSets NamedSets => _namedSets ?? (_namedSets = new NamedSets(_seed));

        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <value>The properties.</value>
        public Properties Properties => _properties ?? (_properties = new Properties(_seed));

        /// <summary>
        /// Gets the section cuts.
        /// </summary>
        /// <value>The section cuts.</value>
        public SectionCuts SectionCuts => _sectionCuts ?? (_sectionCuts = new SectionCuts(_seed));

#endregion


#region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Definitions"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public Definitions(CSiApiSeed seed) : base(seed)
        {
            _seed = seed;
        }


#endregion

    }
}
