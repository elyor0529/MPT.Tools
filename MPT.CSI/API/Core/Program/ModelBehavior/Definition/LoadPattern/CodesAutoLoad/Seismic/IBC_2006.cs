using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.LoadPattern.CodesAutoLoad.Seismic
{
    /// <summary>
    /// Represents the IBC_2006 auto seismic load in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class IBC_2006 : CSiApiBase
    {

        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="IBC_2006"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public IBC_2006(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: Public

        public void GetIBC2006(
                        string Name,
                        ref int DirFlag,
                        ref double Eccen,
                        ref int PeriodFlag,
                        ref int CtType,
                        ref double UserT,
                        ref bool UserZ,
                        ref double TopZ,
                        ref double BottomZ,
                        ref double R,
                        ref double Omega,
                        ref double Cd,
                        ref double I,
                        ref int IBC2006Option,
                        ref double Latitude,
                        ref double Longitude,
                        ref string ZipCode,
                        ref double Ss,
                        ref double S1,
                        ref double Tl,
                        ref int SiteClass,
                        ref double Fa,
                        ref double Fv
                    )
        {
            //_callCode = _sapModel.
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetIBC2006(
                        string Name,
                        int DirFlag,
                        double Eccen,
                        int PeriodFlag,
                        int CtType,
                        double UserT,
                        bool UserZ,
                        double TopZ,
                        double BottomZ,
                        double R,
                        double Omega,
                        double Cd,
                        double I,
                        int IBC2006Option,
                        double Latitude,
                        double Longitude,
                        string ZipCode,
                        double Ss,
                        double S1,
                        double Tl,
                        int SiteClass,
                        double Fa,
                        double Fv
                    )
        {
            //_callCode = _sapModel.
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion

    }
}