using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition.Function
{
    /// <summary>
    /// Represents the response spectrum function in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class ResponseSpectrum : CSiApiBase
    {
        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseSpectrum"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public ResponseSpectrum(CSiApiSeed seed) : base(seed) { }


        #endregion   

        #region Methods: File & User
        /// <summary>
        /// This function retrieves the definition of a response spectrum function from file.
        /// </summary>
        /// <param name="name">The name of a defined response spectrum function specified to be from a text file.</param>
        /// <param name="fileName">The full path of the text file containing the function data.</param>
        /// <param name="headerLinesSkip">The number of header lines in the text file to be skipped before starting to read function data.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= DampRatio &lt; 1.</param>
        /// <param name="valueType">Type of the value used in the file.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void GetFromFile(string name,
            ref string fileName,
            ref int headerLinesSkip,
            ref double dampingRatio,
            ref eFileValueType valueType)
        {
            int csiValueType = 0;

            // TODO: What if file path is invalid? Other ways this may fail?
            _callCode = _sapModel.Func.FuncRS.GetFromFile(name, ref fileName, ref headerLinesSkip, ref dampingRatio, ref csiValueType);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            valueType = (eFileValueType)csiValueType;
        }

        /// <summary>
        /// This function defines a response spectrum function from file.
        /// </summary>
        /// <param name="name">The name of an existing or new function. 
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="fileName">The full path of the text file containing the function data.</param>
        /// <param name="headerLinesSkip">The number of header lines in the text file to be skipped before starting to read function data.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= DampRatio &lt; 1.</param>
        /// <param name="valueType">Type of the value used in the file.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void SetFromFile(string name,
            string fileName,
            int headerLinesSkip,
            double dampingRatio,
            eFileValueType valueType)
        {
            // TODO: What if file path is invalid? Other ways this may fail?
            _callCode = _sapModel.Func.FuncRS.SetFromFile(name, fileName, headerLinesSkip, dampingRatio, (int)valueType);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        /// <summary>
        /// This function retrieves the definition of a user defined response spectrum function.
        /// </summary>
        /// <param name="name">The name of a user defined response spectrum function.</param>
        /// <param name="periods">The frequency in Hz for each data point. [cyc/s].</param>
        /// <param name="values">The function value for each data point.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void GetUser(string name,
            ref double[] periods,
            ref double[] values,
            ref double dampingRatio)
        {
            int numberOfItems = 0;

            _callCode = _sapModel.Func.FuncRS.GetUser(name, ref numberOfItems, ref periods, ref values, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function defines a user response spectrum function.
        /// </summary>
        /// <param name="name">The name of an existing or new function. 
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="periods">The frequency in Hz for each data point. [cyc/s].</param>
        /// <param name="values">The function value for each data point.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= DampRatio &lt; 1.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException">
        /// </exception>
        public void SetUser(string name,
            double[] periods,
            double[] values,
            double dampingRatio)
        {
            if (periods.Length != values.Length)
            {
                throw new CSiException("Frequencies and values are of unequal numbers. \nFrequency has " +
                                       periods.Length + " entries, while Values has " + values.Length + " entries.");
            }
            int numberOfItems = periods.Length;

            _callCode = _sapModel.Func.FuncRS.SetUser(name, numberOfItems, ref periods, ref values, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion

        #region Methods: By Code        
        /// <summary>
        /// This function retrieves the definition of an AASHTO2006 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an AASHTO2006 response spectrum function.</param>
        /// <param name="A">The acceleration coefficient, A.</param>
        /// <param name="soilProfileType">The soil profile type.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetAASHTO2006(string name,
            ref double A,
            ref eSiteClass_AASHTO_2006 soilProfileType,
            ref double dampingRatio)
        {
            int csiSoilProfileType = 0;

            _callCode = _sapModel.Func.FuncRS.GetAASHTO2006(name, ref A, ref csiSoilProfileType, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            soilProfileType = (eSiteClass_AASHTO_2006)csiSoilProfileType;
        }

        /// <summary>
        /// This function defines an AASHTO2006 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an AASHTO2006 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="A">The acceleration coefficient, A.</param>
        /// <param name="soilProfileType">The soil profile type.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetAASHTO2006(string name,
            double A,
            eSiteClass_AASHTO_2006 soilProfileType,
            double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetAASHTO2006(name, A, (int)soilProfileType, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the definition of an AASHTO 2007 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an AASHTO 2007 response spectrum function.</param>
        /// <param name="seismicCoefficientOption">The seismic coefficient option.</param>
        /// <param name="latitude">The latitude for which the seismic coefficients are obtained. <para/> 
        /// These items are used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_AASHTO_2007.SsAndS1FromUSGSLatLong"/>.</param>
        /// <param name="longitude">The longitude for which the seismic coefficients are obtained. <para/>
        /// These items are used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_AASHTO_2007.SsAndS1FromUSGSLatLong"/>.</param>
        /// <param name="zipCode">The zip code for which the seismic coefficients are obtained. <para/>
        /// This item is used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_AASHTO_2007.SsAndS1FromUSGSZipCode"/>.</param>
        /// <param name="Ss">The design spectral acceleration at short periods, Ss.<para/> 
        /// These items are used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_AASHTO_2007.SsAndS1UserDefined"/>.</param>
        /// <param name="S1">The design spectral acceleration at a one second period, S1.<para/> 
        /// These items are used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_AASHTO_2007.SsAndS1UserDefined"/>.</param>
        /// <param name="PGA">The design spectral peak ground acceleration.<para/> 
        /// These items are used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_AASHTO_2007.SsAndS1UserDefined"/>.</param>
        /// <param name="siteClass">The site class.</param>
        /// <param name="Fa">The site coefficients Fa. <para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_AASHTO_2007.F"/>.</param>
        /// <param name="Fv">The site coefficients Fv.  <para/>
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_AASHTO_2007.F"/>.</param>
        /// <param name="Fpga">The site peak ground acceleration.<para/>
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_AASHTO_2007.F"/>.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetAASHTO2007(string name,
            ref eSeismicCoefficient_AASHTO_2007 seismicCoefficientOption,
            ref double latitude,
            ref double longitude,
            ref string zipCode,
            ref double Ss,
            ref double S1,
            ref double PGA,
            ref eSiteClass_AASHTO_2007 siteClass,
            ref double Fa,
            ref double Fv,
            ref double Fpga,
            ref double dampingRatio)
        {
            int csiSeismicCoefficient = 0;
            int csiSiteClass = 0;

            _callCode = _sapModel.Func.FuncRS.GetAASHTO2007(name, ref csiSeismicCoefficient, ref latitude, ref longitude, ref zipCode, ref Ss, ref S1, ref PGA, ref csiSiteClass, ref Fa, ref Fv, ref Fpga, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            seismicCoefficientOption = (eSeismicCoefficient_AASHTO_2007) csiSeismicCoefficient;
            siteClass = (eSiteClass_AASHTO_2007)csiSiteClass;
        }

        /// <summary>
        /// This function defines an AASHTO 2007 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an AASHTO 2007 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="seismicCoefficientOption">The seismic coefficient option.</param>
        /// <param name="latitude">The latitude for which the seismic coefficients are obtained. <para/> 
        /// These items are used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_AASHTO_2007.SsAndS1FromUSGSLatLong"/>.</param>
        /// <param name="longitude">The longitude for which the seismic coefficients are obtained. <para/>
        /// These items are used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_AASHTO_2007.SsAndS1FromUSGSLatLong"/>.</param>
        /// <param name="zipCode">The zip code for which the seismic coefficients are obtained. <para/>
        /// This item is used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_AASHTO_2007.SsAndS1FromUSGSZipCode"/>.</param>
        /// <param name="Ss">The design spectral acceleration at short periods, Ss.<para/> 
        /// These items are used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_AASHTO_2007.SsAndS1UserDefined"/>.</param>
        /// <param name="S1">The design spectral acceleration at a one second period, S1.<para/> 
        /// These items are used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_AASHTO_2007.SsAndS1UserDefined"/>.</param>
        /// <param name="PGA">The design spectral peak ground acceleration.<para/> 
        /// These items are used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_AASHTO_2007.SsAndS1UserDefined"/>.</param>
        /// <param name="siteClass">The site class.</param>
        /// <param name="Fa">The site coefficients Fa. <para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_AASHTO_2007.F"/>.</param>
        /// <param name="Fv">The site coefficients Fv.  <para/>
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_AASHTO_2007.F"/>.</param>
        /// <param name="Fpga">The site peak ground acceleration.<para/>
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_AASHTO_2007.F"/>.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetAASHTO2007(string name,
            eSeismicCoefficient_AASHTO_2007 seismicCoefficientOption,
            double latitude,
            double longitude,
            string zipCode,
            double Ss,
            double S1,
            double PGA,
            eSiteClass_AASHTO_2007 siteClass,
            double Fa, 
            double Fv, 
            double Fpga,
            double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetAASHTO2007(name, (int)seismicCoefficientOption, latitude, longitude, zipCode, Ss, S1, PGA, (int)siteClass, Fa, Fv, Fpga, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the definition of an AS 1170 2007 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an AS 1170 2007 response spectrum function.</param>
        /// <param name="siteClass">The site class.</param>
        /// <param name="kp">The probability factor, kp.</param>
        /// <param name="Z">The hazard factor, Z.</param>
        /// <param name="Sp">The structural performance factor, Sp.</param>
        /// <param name="u">The structural ductility factor, u.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetAS11702007(string name,
            ref eSiteClass_AS_1170_2007 siteClass,
            ref double kp,
            ref double Z,
            ref double Sp,
            ref double u,
            ref double dampingRatio)
        {
            int csiSiteClass = 0;

            _callCode = _sapModel.Func.FuncRS.GetAS11702007(name, ref csiSiteClass, ref kp, ref Z, ref Sp, ref u, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            siteClass = (eSiteClass_AS_1170_2007) csiSiteClass;
        }

        /// <summary>
        /// This function defines an AS 1170 2007 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an AS 1170 2007 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="siteClass">The site class.</param>
        /// <param name="kp">The probability factor, kp.</param>
        /// <param name="Z">The hazard factor, Z.</param>
        /// <param name="Sp">The structural performance factor, Sp.</param>
        /// <param name="u">The structural ductility factor, u.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetAS11702007(string name,
            eSiteClass_AS_1170_2007 siteClass,
            double kp,
            double Z,
            double Sp,
            double u,
            double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetAS11702007(name, (int)siteClass, kp, Z, Sp, u, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the definition of a BOCA96 response spectrum function.
        /// </summary>
        /// <param name="name">The name of a BOCA96 response spectrum function.</param>
        /// <param name="Aa">The effective peak acceleration, Aa.</param>
        /// <param name="Av">The effective peak velocity, Av.</param>
        /// <param name="S">The soil profile coefficient, S.</param>
        /// <param name="R">The response modification factor, R.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetBOCA96(string name,
            ref double Aa,
            ref double Av,
            ref double S,
            ref double R,
            ref double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.GetBOCA96(name, ref Aa, ref Av, ref S, ref R, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function defines a BOCA96 response spectrum function.
        /// </summary>
        /// <param name="name">The name of a BOCA9 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="Aa">The effective peak acceleration, Aa.</param>
        /// <param name="Av">The effective peak velocity, Av.</param>
        /// <param name="S">The soil profile coefficient, S.</param>
        /// <param name="R">The response modification factor, R.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetBOCA96(string name,
            double Aa,
            double Av,
            double S,
            double R,
            double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetBOCA96(name, Aa, Av, S, R, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the definition of a Chinese 2010 response spectrum function.
        /// </summary>
        /// <param name="name">The name of a Chinese 2010 response spectrum function.</param>
        /// <param name="alphaMax">The maximum influence factor.</param>
        /// <param name="SI">The seismic intensity.</param>
        /// <param name="Tg">The characteristic ground period, Tg > 0.1. [s].</param>
        /// <param name="PTDF">The period time discount factor.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetChinese2010(string name,
            ref double alphaMax,
            ref eSeismicIntensity_Chinese_2010 SI,
            ref double Tg,
            ref double PTDF,
            ref double dampingRatio)
        {
            int csiSeismicIntensity = 0;

            _callCode = _sapModel.Func.FuncRS.GetChinese2010(name, ref alphaMax, ref csiSeismicIntensity, ref Tg, ref PTDF, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            SI = (eSeismicIntensity_Chinese_2010) csiSeismicIntensity;
        }

        /// <summary>
        /// This function defines a Chinese 2010 response spectrum function.
        /// </summary>
        /// <param name="name">The name of a Chinese 2010 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="alphaMax">The maximum influence factor.</param>
        /// <param name="SI">The seismic intensity.</param>
        /// <param name="Tg">The characteristic ground period, Tg > 0.1. [s].</param>
        /// <param name="PTDF">The period time discount factor.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetChinese2010(string name,
            double alphaMax,
            eSeismicIntensity_Chinese_2010 SI,
            double Tg,
            double PTDF,
            double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetChinese2010(name, alphaMax, (int)SI, Tg, PTDF, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the definition of a CJJ 166-2011 response spectrum function.
        /// </summary>
        /// <param name="name">The name of a CJJ 166-2011 response spectrum function.</param>
        /// <param name="direction">The response spectrum direction.</param>
        /// <param name="peakAcceleration">The peak acceleration, A.</param>
        /// <param name="Tg">The characteristic ground period , Tg > 0.1. [s].</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetCJJ1662011(string name,
            ref eSpectrumDirection_CJJ_166_2011 direction,
            ref double peakAcceleration,
            ref double Tg,
            ref double dampingRatio)
        {
            int csiDirection = 0;

            _callCode = _sapModel.Func.FuncRS.GetCJJ1662011(name, ref csiDirection, ref peakAcceleration, ref Tg, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            direction = (eSpectrumDirection_CJJ_166_2011) csiDirection;
        }

        /// <summary>
        /// This function defines a CJJ 166-2011 response spectrum function.
        /// </summary>
        /// <param name="name">The name of a CJJ 166-2011 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="direction">The response spectrum direction.</param>
        /// <param name="peakAcceleration">The peak acceleration, A.</param>
        /// <param name="Tg">The characteristic ground period , Tg > 0.1. [s].</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetCJJ1662011(string name,
            eSpectrumDirection_CJJ_166_2011 direction,
            double peakAcceleration,
            double Tg,
            double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetCJJ1662011(name, (int)direction, peakAcceleration, Tg, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the definition of a EuroCode8 response spectrum function.
        /// </summary>
        /// <param name="name">The name of a EuroCode8 response spectrum function.</param>
        /// <param name="AG">The design ground acceleration, Ag.</param>
        /// <param name="S">The subsoil class.</param>
        /// <param name="n">The damping correction factor, n, where n >= 0.7.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetEurocode8(string name,
            ref double AG,
            ref eSiteClass_Eurocode_8 S,
            ref double n,
            ref double dampingRatio)
        {
            int csiSubsoilClass = 0;

            _callCode = _sapModel.Func.FuncRS.GetEuroCode8(name, ref AG, ref csiSubsoilClass, ref n, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            S = (eSiteClass_Eurocode_8) csiSubsoilClass;
        }

        /// <summary>
        /// This function defines a EuroCode8 response spectrum function.
        /// </summary>
        /// <param name="name">The name of a EuroCode8 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="AG">The design ground acceleration, Ag.</param>
        /// <param name="S">The subsoil class.</param>
        /// <param name="n">The damping correction factor, n, where n >= 0.7.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetEurocode8(string name,
            double AG,
            eSiteClass_Eurocode_8 S,
            double n,
            double dampingRatio)
        {
            if (n < 0.7) { n = 0.7;}

            _callCode = _sapModel.Func.FuncRS.SetEuroCode8(name, AG, (int)S, n, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the definition of a Eurocode 8 2004 response spectrum function.
        /// </summary>
        /// <param name="name">The name of a Eurocode 8 2004 response spectrum function.</param>
        /// <param name="country">The country for which the Nationally Determined Parameters (NDPs) are specified.</param>
        /// <param name="direction">The ground motion direction.</param>
        /// <param name="spectrumType">The spectrum type.</param>
        /// <param name="groundType">The ground type. <para/> 
        /// This item only applies when the <paramref name="direction"/> = <see cref="eSpectrumDirection_Eurocode_8_2004.Horizontal"/>.</param>
        /// <param name="ag">The design ground acceleration in g, ag.</param>
        /// <param name="S">The soil factor, S.<para/> 
        /// This item only applies when the <paramref name="direction"/> = <see cref="eSpectrumDirection_Eurocode_8_2004.Horizontal"/>.</param>
        /// <param name="AvgOverAg">The vertical ground acceleration divided by the horizontal ground acceleration, Avg/Ag.<para/> 
        /// This item only applies when the <paramref name="direction"/> = <see cref="eSpectrumDirection_Eurocode_8_2004.Vertical"/>.</param>
        /// <param name="Tb">The lower limit of period of the constant spectral acceleration branch, Tb.</param>
        /// <param name="Tc">The upper limit of period of the constant spectral acceleration branch, Tc.</param>
        /// <param name="Td">The period defining the start of the constant displacement range, Td.</param>
        /// <param name="beta">The lower bound factor, Beta.</param>
        /// <param name="q">The behavior factor, q.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetEurocode82004(string name,
            ref eParameters_Eurocode_8_2004 country,
            ref eSpectrumDirection_Eurocode_8_2004 direction,
            ref eSpectrumType_Eurocode_8_2004 spectrumType,
            ref eSiteClass_Eurocode_8_2004 groundType,
            ref double ag,
            ref double S,
            ref double AvgOverAg,
            ref double Tb,
            ref double Tc,
            ref double Td,
            ref double beta,
            ref double q,
            ref double dampingRatio)
        {
            int csiCountry = 0;
            int csiDirection = 0;
            int csiSpectrumType = 0;
            int csiGroundType = 0;

            _callCode = _sapModel.Func.FuncRS.GetEurocode82004_1(name, ref csiCountry, ref csiDirection, ref csiSpectrumType, ref csiGroundType, ref ag, ref S, ref AvgOverAg, ref Tb, ref Tc, ref Td, ref beta, ref q, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            country = (eParameters_Eurocode_8_2004)csiCountry;
            direction = (eSpectrumDirection_Eurocode_8_2004)csiDirection;
            spectrumType = (eSpectrumType_Eurocode_8_2004)csiSpectrumType;
            groundType = (eSiteClass_Eurocode_8_2004)csiGroundType;
        }

        /// <summary>
        /// This function defines a Eurocode 8 2004 response spectrum function.
        /// </summary>
        /// <param name="name">The name of a Eurocode 8 2004 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="country">The country for which the Nationally Determined Parameters (NDPs) are specified.</param>
        /// <param name="direction">The ground motion direction.</param>
        /// <param name="spectrumType">The spectrum type.</param>
        /// <param name="groundType">The ground type. <para/> 
        /// This item only applies when the <paramref name="direction"/> = <see cref="eSpectrumDirection_Eurocode_8_2004.Horizontal"/>.</param>
        /// <param name="ag">The design ground acceleration in g, ag.</param>
        /// <param name="S">The soil factor, S.<para/> 
        /// This item only applies when the <paramref name="direction"/> = <see cref="eSpectrumDirection_Eurocode_8_2004.Horizontal"/>.</param>
        /// <param name="AvgOverAg">The vertical ground acceleration divided by the horizontal ground acceleration, Avg/Ag.<para/> 
        /// This item only applies when the <paramref name="direction"/> = <see cref="eSpectrumDirection_Eurocode_8_2004.Vertical"/>.</param>
        /// <param name="Tb">The lower limit of period of the constant spectral acceleration branch, Tb.</param>
        /// <param name="Tc">The upper limit of period of the constant spectral acceleration branch, Tc.</param>
        /// <param name="Td">The period defining the start of the constant displacement range, Td.</param>
        /// <param name="beta">The lower bound factor, Beta.</param>
        /// <param name="q">The behavior factor, q.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetEurocode82004(string name,
            eParameters_Eurocode_8_2004 country,
            eSpectrumDirection_Eurocode_8_2004 direction,
            eSpectrumType_Eurocode_8_2004 spectrumType,
            eSiteClass_Eurocode_8_2004 groundType,
            double ag,
            double S,
            double AvgOverAg,
            double Tb,
            double Tc,
            double Td,
            double beta,
            double q,
            double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetEurocode82004_1(name, (int)country, (int)direction, (int)spectrumType, (int)groundType, ag, S, AvgOverAg, Tb, Tc, Td, beta, q, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the definition of a JTG B02-2013 response spectrum function.
        /// </summary>
        /// <param name="name">The name of a JTG B02-2013 response spectrum function.</param>
        /// <param name="direction">The response spectrum direction.</param>
        /// <param name="peakAcceleration">The peak acceleration, A.</param>
        /// <param name="Tg">The characteristic ground period, Tg > 0.1. [s].</param>
        /// <param name="Ci">The importance coefficient.</param>
        /// <param name="Cs">The site soil coefficient.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetJTGB022013(string name,
            ref eSpectrumDirection_JTG_B02_2013 direction,
            ref double peakAcceleration,
            ref double Tg,
            ref double Ci,
            ref double Cs,
            ref double dampingRatio)
        {
            int csiDirection = 0;

            _callCode = _sapModel.Func.FuncRS.GetJTGB022013(name, ref csiDirection, ref peakAcceleration, ref Tg, ref Ci, ref Cs, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            direction = (eSpectrumDirection_JTG_B02_2013)csiDirection;
        }

        /// <summary>
        /// This function defines a JTG B02-2013 response spectrum function.
        /// </summary>
        /// <param name="name">The name of a JTG B02-2013 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="direction">The response spectrum direction.</param>
        /// <param name="peakAcceleration">The peak acceleration, A.</param>
        /// <param name="Tg">The characteristic ground period, Tg > 0.1. [s].</param>
        /// <param name="Ci">The importance coefficient.</param>
        /// <param name="Cs">The site soil coefficient.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetJTGB022013(string name,
            eSpectrumDirection_JTG_B02_2013 direction,
            double peakAcceleration,
            double Tg,
            double Ci,
            double Cs,
            double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetJTGB022013(name, (int)direction, peakAcceleration, Tg, Ci, Cs, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the definition of an IBC2003 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an IBC2003 response spectrum function.</param>
        /// <param name="Sds">The design spectral acceleration at short periods, Sds.</param>
        /// <param name="Sd1">The design spectral acceleration at a one second period, Sd1.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetIBC2003(string name,
            ref double Sds,
            ref double Sd1,
            ref double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.GetIBC2003(name, ref Sds, ref Sd1, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function defines an IBC2003 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an IBC2003 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="Sds">The design spectral acceleration at short periods, Sds.</param>
        /// <param name="Sd1">The design spectral acceleration at a one second period, Sd1.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetIBC2003(string name,
            double Sds,
            double Sd1,
            double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetIBC2003(name, Sds, Sd1, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the definition of an IBC2006 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an IBC2006 response spectrum function.</param>
        /// <param name="seismicCoefficientOption">The seismic coefficient option.</param>
        /// <param name="latitude">The latitude for which the seismic coefficients are obtained. <para/> 
        /// These items are used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_IBC_2006.SsAndS1FromUSGSLatLong"/>.</param>
        /// <param name="longitude">The longitude for which the seismic coefficients are obtained. <para/>
        /// These items are used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_IBC_2006.SsAndS1FromUSGSLatLong"/>.</param>
        /// <param name="zipCode">The zip code for which the seismic coefficients are obtained. <para/>
        /// This item is used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_IBC_2006.SsAndS1FromUSGSZipCode"/>.</param>
        /// <param name="Ss">The design spectral acceleration at short periods, Ss.<para/>
        /// This item is used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_IBC_2006.SsAndS1UserDefined"/>.</param>
        /// <param name="S1">The design spectral acceleration at a one second period, S1.<para/>
        /// This item is used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_IBC_2006.SsAndS1UserDefined"/>.</param>
        /// <param name="TL">The long-period transition period. [s].</param>
        /// <param name="siteClass">The site class.</param>
        /// <param name="Fa">The site coefficients Fa. <para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_IBC_2006.F"/>.</param>
        /// <param name="Fv">The site coefficients Fv.  <para/>
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_IBC_2006.F"/>.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetIBC2006(string name,
            ref eSeismicCoefficient_IBC_2006 seismicCoefficientOption,
            ref double latitude,
            ref double longitude,
            ref string zipCode,
            ref double Ss,
            ref double S1,
            ref double TL,
            ref eSiteClass_IBC_2006 siteClass,
            ref double Fa,
            ref double Fv,
            ref double dampingRatio)
        {
            int csiSeismicCoefficientOption = 0;
            int csiSiteClass = 0;

            _callCode = _sapModel.Func.FuncRS.GetIBC2006(name, ref csiSeismicCoefficientOption, ref latitude, ref longitude, ref zipCode, ref Ss, ref S1, ref TL, ref csiSiteClass, ref Fa, ref Fv, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            seismicCoefficientOption = (eSeismicCoefficient_IBC_2006)csiSeismicCoefficientOption;
            siteClass = (eSiteClass_IBC_2006)csiSiteClass;
        }

        /// <summary>
        /// This function defines an IBC2006 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an IBC2006 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="seismicCoefficientOption">The seismic coefficient option.</param>
        /// <param name="latitude">The latitude for which the seismic coefficients are obtained. <para/> 
        /// These items are used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_IBC_2006.SsAndS1FromUSGSLatLong"/>.</param>
        /// <param name="longitude">The longitude for which the seismic coefficients are obtained. <para/>
        /// These items are used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_IBC_2006.SsAndS1FromUSGSLatLong"/>.</param>
        /// <param name="zipCode">The zip code for which the seismic coefficients are obtained. <para/>
        /// This item is used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_IBC_2006.SsAndS1FromUSGSZipCode"/>.</param>
        /// <param name="Ss">The design spectral acceleration at short periods, Sds.<para/>
        /// This item is used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_IBC_2006.SsAndS1UserDefined"/>.</param>
        /// <param name="S1">The design spectral acceleration at a one second period, Sd1.<para/>
        /// This item is used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_IBC_2006.SsAndS1UserDefined"/>.</param>
        /// <param name="TL">The long-period transition period. [s].</param>
        /// <param name="siteClass">The site class.</param>
        /// <param name="Fa">The site coefficients Fa. <para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_IBC_2006.F"/>.</param>
        /// <param name="Fv">The site coefficients Fv.  <para/>
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_IBC_2006.F"/>.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetIBC2006(string name,
            eSeismicCoefficient_IBC_2006 seismicCoefficientOption,
            double latitude,
            double longitude,
            string zipCode,
            double Ss,
            double S1,
            double TL,
            eSiteClass_IBC_2006 siteClass,
            double Fa,
            double Fv,
            double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetIBC2006(name, (int)seismicCoefficientOption, latitude, longitude, zipCode, Ss, S1, TL, (int)siteClass, Fa, Fv, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        /// <summary>
        /// This function retrieves the definition of an IS1893-2002 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an IS1893-2002 response spectrum function.</param>
        /// <param name="Z">The seismic zone factor, Z.</param>
        /// <param name="S">The soil type.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetIS18932002(string name,
            ref double Z,
            ref eSiteClass_IS_1893_2002 S,
            ref double dampingRatio)
        {
            int csiSoilType = 0;

            _callCode = _sapModel.Func.FuncRS.GetIS18932002(name, ref Z, ref csiSoilType, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            S = (eSiteClass_IS_1893_2002)csiSoilType;
        }

        /// <summary>
        /// This function defines an IS1893-2002 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an IS1893-2002 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="Z">The seismic zone factor, Z.</param>
        /// <param name="S">The soil type.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetIS18932002(string name,
            double Z,
            eSiteClass_IS_1893_2002 S,
            double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetIS18932002(name, Z, (int)S, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the definition of an Italian 3274 response spectrum function4.
        /// </summary>
        /// <param name="name">The name of an Italian 3274 response spectrum function.</param>
        /// <param name="g">The peak ground acceleration.</param>
        /// <param name="seismicIntensity">The seismic intensity.</param>
        /// <param name="q">The structure factor.</param>
        /// <param name="level">The spectral level, direction and building type.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetItalian3274(string name,
            ref double g,
            ref eSiteClass_Italian_3274 seismicIntensity,
            ref double q,
            ref eLevel_Italian_3274 level,
            ref double dampingRatio)
        {
            int csiSeismicIntensity = 0;
            double csiLevel = 0;

            _callCode = _sapModel.Func.FuncRS.GetItalian3274(name, ref g, ref csiSeismicIntensity, ref q, ref csiLevel, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            seismicIntensity = (eSiteClass_Italian_3274)csiSeismicIntensity;
            level = (eLevel_Italian_3274)csiLevel;
        }

        /// <summary>
        /// This function defines an Italian 3274 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an Italian 3274 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="g">The peak ground acceleration.</param>
        /// <param name="seismicIntensity">The seismic intensity.</param>
        /// <param name="q">The structure factor.</param>
        /// <param name="level">The spectral level, direction and building type.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetItalian3274(string name,
            double g,
            eSiteClass_Italian_3274 seismicIntensity,
            double q,
            eLevel_Italian_3274 level,
            double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetItalian3274(name, g, (int)seismicIntensity, q, (double)level, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the definition of an NBCC2015 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an NBCC2015 response spectrum function.</param>
        /// <param name="PGA">The peak ground acceleration.</param>
        /// <param name="S02">The spectral acceleration at a 0.2 second period.</param>
        /// <param name="S05">The spectral acceleration at a 0.5 second period.</param>
        /// <param name="S1">The spectral acceleration at a 1 second period.</param>
        /// <param name="S2">The spectral acceleration at a 2 second period.</param>
        /// <param name="S5">The spectral acceleration at a 5 second period.</param>
        /// <param name="S10">The spectral acceleration at a 10 second period.</param>
        /// <param name="siteClass">The site class.</param>
        /// <param name="F02">The site coefficient at a 0.2 second period.<para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NBCC_2015.F"/>.</param>
        /// <param name="F05">The site coefficient at a 0.5 second period.<para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NBCC_2015.F"/>.</param>
        /// <param name="F1">The site coefficient at a 1 second period.<para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NBCC_2015.F"/>.</param>
        /// <param name="F2">The site coefficient at a 2 second period.<para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NBCC_2015.F"/>.</param>
        /// <param name="F5">The site coefficient at a 5 second period.<para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NBCC_2015.F"/>.</param>
        /// <param name="F10">The site coefficient at a 10 second period.<para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NBCC_2015.F"/>.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetNBCC2015(string name,
            ref double PGA,
            ref double S02,
            ref double S05,
            ref double S1,
            ref double S2,
            ref double S5,
            ref double S10,
            ref eSiteClass_NBCC_2015 siteClass,
            ref double F02,
            ref double F05,
            ref double F1,
            ref double F2,
            ref double F5,
            ref double F10,
            ref double dampingRatio)
        {
            int csiSiteClass = 0;

            _callCode = _sapModel.Func.FuncRS.GetNBCC2015(name, ref PGA, ref S02, ref S05, ref S1, ref S2, ref S5, ref S10, ref csiSiteClass, ref F02, ref F05, ref F1, ref F2, ref F5, ref F10, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            siteClass = (eSiteClass_NBCC_2015)csiSiteClass;
        }

        /// <summary>
        /// This function retrieves the definition of an NBCC2015 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an NBCC2015 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="PGA">The peak ground acceleration.</param>
        /// <param name="S02">The spectral acceleration at a 0.2 second period.</param>
        /// <param name="S05">The spectral acceleration at a 0.5 second period.</param>
        /// <param name="S1">The spectral acceleration at a 1 second period.</param>
        /// <param name="S2">The spectral acceleration at a 2 second period.</param>
        /// <param name="S5">The spectral acceleration at a 5 second period.</param>
        /// <param name="S10">The spectral acceleration at a 10 second period.</param>
        /// <param name="siteClass">The site class.</param>
        /// <param name="F02">The site coefficient at a 0.2 second period.<para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NBCC_2015.F"/>.</param>
        /// <param name="F05">The site coefficient at a 0.5 second period.<para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NBCC_2015.F"/>.</param>
        /// <param name="F1">The site coefficient at a 1 second period.<para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NBCC_2015.F"/>.</param>
        /// <param name="F2">The site coefficient at a 2 second period.<para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NBCC_2015.F"/>.</param>
        /// <param name="F5">The site coefficient at a 5 second period.<para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NBCC_2015.F"/>.</param>
        /// <param name="F10">The site coefficient at a 10 second period.<para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NBCC_2015.F"/>.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetNBCC2015(string name,
            double PGA,
            double S02,
            double S05,
            double S1,
            double S2,
            double S5,
            double S10,
            eSiteClass_NBCC_2015 siteClass,
            double F02,
            double F05,
            double F1,
            double F2,
            double F5,
            double F10,
            double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetNBCC2015(name, PGA, S02, S05, S1, S2, S5, S10, (int)siteClass, F02, F05, F1, F2, F5, F10, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function defines an NBCC2010 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an NBCC2010 response spectrum function.</param>
        /// <param name="PGA">The peak ground acceleration.</param>
        /// <param name="S02">The spectral acceleration at a 0.2 second period.</param>
        /// <param name="S05">The spectral acceleration at a 0.5 second period.</param>
        /// <param name="S1">The spectral acceleration at a 1 second period.</param>
        /// <param name="S2">The spectral acceleration at a 2 second period.</param>
        /// <param name="siteClass">The site class.</param>
        /// <param name="Fa">The site coefficient at a 0.2 second period.<para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NBCC_2010.F"/>.</param>
        /// <param name="Fv">The site coefficient at a 0.5 second period.<para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NBCC_2010.F"/>.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetNBCC2010(string name,
            ref double PGA,
            ref double S02,
            ref double S05,
            ref double S1,
            ref double S2,
            ref eSiteClass_NBCC_2010 siteClass,
            ref double Fa,
            ref double Fv,
            ref double dampingRatio)
        {
            int csiSiteClass = 0;

            _callCode = _sapModel.Func.FuncRS.GetNBCC2010(name, ref PGA, ref S02, ref S05, ref S1, ref S2, ref csiSiteClass, ref Fa, ref Fv, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            siteClass = (eSiteClass_NBCC_2010)csiSiteClass;
        }

        /// <summary>
        /// This function defines an NBCC2010 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an NBCC2010 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="PGA">The peak ground acceleration.</param>
        /// <param name="S02">The spectral acceleration at a 0.2 second period.</param>
        /// <param name="S05">The spectral acceleration at a 0.5 second period.</param>
        /// <param name="S1">The spectral acceleration at a 1 second period.</param>
        /// <param name="S2">The spectral acceleration at a 2 second period.</param>
        /// <param name="siteClass">The site class.</param>
        /// <param name="Fa">The site coefficient at a 0.2 second period.<para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NBCC_2010.F"/>.</param>
        /// <param name="Fv">The site coefficient at a 0.5 second period.<para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NBCC_2010.F"/>.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetNBCC2010(string name,
            double PGA,
            double S02,
            double S05,
            double S1,
            double S2,
            eSiteClass_NBCC_2010 siteClass,
            double Fa,
            double Fv,
            double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetNBCC2010(name, PGA, S02, S05, S1, S2, (int)siteClass, Fa, Fv, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the definition of an NBCC2005 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an NBCC2005 response spectrum function.</param>
        /// <param name="PGA">The peak ground acceleration.</param>
        /// <param name="S02">The spectral acceleration at a 0.2 second period.</param>
        /// <param name="S05">The spectral acceleration at a 0.5 second period.</param>
        /// <param name="S1">The spectral acceleration at a 1 second period.</param>
        /// <param name="S2">The spectral acceleration at a 2 second period.</param>
        /// <param name="siteClass">The site class.</param>
        /// <param name="Fa">The site coefficient at a 0.2 second period.<para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NBCC_2005.F"/>.</param>
        /// <param name="Fv">The site coefficient at a 0.5 second period.<para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NBCC_2005.F"/>.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetNBCC2005(string name,
            ref double PGA,
            ref double S02,
            ref double S05,
            ref double S1,
            ref double S2,
            ref eSiteClass_NBCC_2005 siteClass,
            ref double Fa,
            ref double Fv,
            ref double dampingRatio)
        {
            int csiSiteClass = 0;

            _callCode = _sapModel.Func.FuncRS.GetNBCC2005(name, ref PGA, ref S02, ref S05, ref S1, ref S2, ref csiSiteClass, ref Fa, ref Fv, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            siteClass = (eSiteClass_NBCC_2005)csiSiteClass;
        }

        /// <summary>
        /// This function defines an NBCC2005 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an NBCC2005 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="PGA">The peak ground acceleration.</param>
        /// <param name="S02">The spectral acceleration at a 0.2 second period.</param>
        /// <param name="S05">The spectral acceleration at a 0.5 second period.</param>
        /// <param name="S1">The spectral acceleration at a 1 second period.</param>
        /// <param name="S2">The spectral acceleration at a 2 second period.</param>
        /// <param name="siteClass">The site class.</param>
        /// <param name="Fa">The site coefficient at a 0.2 second period.<para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NBCC_2005.F"/>.</param>
        /// <param name="Fv">The site coefficient at a 0.5 second period.<para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NBCC_2005.F"/>.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetNBCC2005(string name,
            double PGA,
            double S02,
            double S05,
            double S1,
            double S2,
            eSiteClass_NBCC_2005 siteClass,
            double Fa,
            double Fv,
            double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetNBCC2005(name, PGA, S02, S05, S1, S2, (int)siteClass, Fa, Fv, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function defines an NBCC95 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an NBCC95 response spectrum function.</param>
        /// <param name="ZVR">The zonal velocity ratio.</param>
        /// <param name="ZA">The acceleration-related seismic zone.</param>
        /// <param name="Zv">The velocity-related seismic zone.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetNBCC95(string name,
            ref double ZVR,
            ref int ZA,
            ref int Zv,
            ref double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.GetNBCC95(name, ref ZVR, ref ZA, ref Zv, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function defines an NBCC95 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an NBCC95 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="ZVR">The zonal velocity ratio.</param>
        /// <param name="ZA">The acceleration-related seismic zone.</param>
        /// <param name="Zv">The velocity-related seismic zone.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetNBCC95(string name,
            double ZVR,
            int ZA,
            int Zv,
            double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetNBCC95(name, ZVR, ZA, Zv, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the definition of a NCHRP 2007 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an NCHRP 2007 response spectrum function.</param>
        /// <param name="seismicCoefficientOption">The seismic coefficient option.</param>
        /// <param name="latitude">The latitude for which the seismic coefficients are obtained. <para/> 
        /// These items are used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_NCHRP_2007.SsAndS1FromUSGSLatLong"/>.</param>
        /// <param name="longitude">The longitude for which the seismic coefficients are obtained. <para/>
        /// These items are used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_NCHRP_2007.SsAndS1FromUSGSLatLong"/>.</param>
        /// <param name="zipCode">The zip code for which the seismic coefficients are obtained. <para/>
        /// This item is used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_NCHRP_2007.SsAndS1FromUSGSZipCode"/>.</param>
        /// <param name="Ss">The design spectral acceleration at short periods, Ss.<para/>
        /// This item is used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_NCHRP_2007.SsAndS1UserDefined"/>.</param>
        /// <param name="S1">The design spectral acceleration at a one second period, S1.<para/>
        /// This item is used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_NCHRP_2007.SsAndS1UserDefined"/>.</param>
        /// <param name="siteClass">The site class.</param>
        /// <param name="Fa">The site coefficients Fa. <para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NCHRP_2007.F"/>.</param>
        /// <param name="Fv">The site coefficients Fv.  <para/>
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NCHRP_2007.F"/>.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetNCHRP2007(string name,
            ref eSeismicCoefficient_NCHRP_2007 seismicCoefficientOption,
            ref double latitude,
            ref double longitude,
            ref string zipCode,
            ref double Ss,
            ref double S1,
            ref eSiteClass_NCHRP_2007 siteClass,
            ref double Fa,
            ref double Fv,
            ref double dampingRatio)
        {
            int csiSeismicCoefficientOption = 0;
            int csiSiteClass = 0;

            _callCode = _sapModel.Func.FuncRS.GetNCHRP2007(name, ref csiSeismicCoefficientOption, ref latitude, ref longitude, ref zipCode, ref Ss, ref S1, ref csiSiteClass, ref Fa, ref Fv, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            seismicCoefficientOption = (eSeismicCoefficient_NCHRP_2007)csiSeismicCoefficientOption;
            siteClass = (eSiteClass_NCHRP_2007)csiSiteClass;
        }

        /// <summary>
        /// This function defines a NCHRP 2007 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an NCHRP 2007 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="seismicCoefficientOption">The seismic coefficient option.</param>
        /// <param name="latitude">The latitude for which the seismic coefficients are obtained. <para/> 
        /// These items are used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_NCHRP_2007.SsAndS1FromUSGSLatLong"/>.</param>
        /// <param name="longitude">The longitude for which the seismic coefficients are obtained. <para/>
        /// These items are used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_NCHRP_2007.SsAndS1FromUSGSLatLong"/>.</param>
        /// <param name="zipCode">The zip code for which the seismic coefficients are obtained. <para/>
        /// This item is used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_NCHRP_2007.SsAndS1FromUSGSZipCode"/>.</param>
        /// <param name="Ss">The design spectral acceleration at short periods, Ss.<para/>
        /// This item is used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_NCHRP_2007.SsAndS1UserDefined"/>.</param>
        /// <param name="S1">The design spectral acceleration at a one second period, S1.<para/>
        /// This item is used only when <paramref name="seismicCoefficientOption"/> = <see cref="eSeismicCoefficient_NCHRP_2007.SsAndS1UserDefined"/>.</param>
        /// <param name="siteClass">The site class.</param>
        /// <param name="Fa">The site coefficients Fa. <para/> 
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NCHRP_2007.F"/>.</param>
        /// <param name="Fv">The site coefficients Fv.  <para/>
        /// These items are used only when <paramref name="siteClass"/> = <see cref="eSiteClass_NCHRP_2007.F"/>.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetNCHRP2007(string name,
            eSeismicCoefficient_NCHRP_2007 seismicCoefficientOption,
            double latitude,
            double longitude,
            string zipCode,
            double Ss,
            double S1,
            eSiteClass_NCHRP_2007 siteClass,
            double Fa,
            double Fv,
            double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetNCHRP2007(name, (int)seismicCoefficientOption, latitude, longitude, zipCode, Ss, S1, (int)siteClass, Fa, Fv, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function defines an NEHRP97 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an NEHRP97 response spectrum function.</param>
        /// <param name="Ss">The design spectral acceleration at short periods, Sds.</param>
        /// <param name="S1">The design spectral acceleration at a one second period, Sd1.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetNEHRP97(string name,
            ref double Ss,
            ref double S1,
            ref double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.GetNEHRP97(name, ref Ss, ref S1, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function defines a NEHRP97 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an NEHRP97 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="Ss">The design spectral acceleration at short periods, Sds.</param>
        /// <param name="S1">The design spectral acceleration at a one second period, Sd1.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetNEHRP97(string name,
            double Ss,
            double S1,
            double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetNEHRP97(name, Ss, S1, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// The name of an NTC2008 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an NTC2008  response spectrum function.</param>
        /// <param name="parametersOption">The option for defining the parameters.</param>
        /// <param name="latitude">The latitude for which the parameters are obtained. <para/> 
        /// These items are used only when <paramref name="parametersOption"/> = <see cref="eParameters_NTC_2008.ByLatLong"/>.</param>
        /// <param name="longitude">The longitude for which the parameters are obtained. <para/>
        /// These items are used only when <paramref name="parametersOption"/> = <see cref="eParameters_NTC_2008.ByLatLong"/>.</param>
        /// <param name="island">The island. <para/>
        /// This item is used only when <paramref name="parametersOption"/> = <see cref="eParameters_NTC_2008.ByIsland"/>.</param>
        /// <param name="limitState">The limit state.</param>
        /// <param name="usageClass">The usage class.</param>
        /// <param name="nominalLife">The nominal life to be considered.</param>
        /// <param name="peakAcceleration">The peak ground acceleration, ag/g.</param>
        /// <param name="F0">The magnitude factor, F0.</param>
        /// <param name="Tcs">The reference period, Tc* [s].</param>
        /// <param name="spectrumType">The type of spectrum to consider.</param>
        /// <param name="soilType">The subsoil type.</param>
        /// <param name="topography">The topography type.</param>
        /// <param name="hRatio">The ratio for the site altitude at the base of the hill to the height of the hill.</param>
        /// <param name="damping">The damping, in percent. 
        /// This is only applicable for <paramref name="spectrumType"/> = <see cref="eSpectrumType_NTC_2008.ElasticHorizontal"/> or <see cref="eSpectrumType_NTC_2008.ElasticVertical"/>.</param>
        /// <param name="q">The behavior correction factor. 
        /// This is only applicable for <paramref name="spectrumType"/> = <see cref="eSpectrumType_NTC_2008.DesignHorizontal"/> or <see cref="eSpectrumType_NTC_2008.DesignVertical"/>.</param>
        /// <exception cref="CSiException"></exception>
        public void GetNTC2008(string name,
            ref eParameters_NTC_2008 parametersOption,
            ref double latitude,
            ref double longitude,
            ref eIsland_NTC_2008 island,
            ref eLimitState_NTC_2008 limitState,
            ref eUsageClass_NTC_2008 usageClass,
            ref double nominalLife,
            ref double peakAcceleration,
            ref double F0,
            ref double Tcs,
            ref eSpectrumType_NTC_2008 spectrumType,
            ref eSiteClass_NTC_2008 soilType,
            ref eTopography_NTC_2008 topography,
            ref double hRatio,
            ref double damping,
            ref double q)
        {
            int csiParametersOption = 0;
            int csiIsland = 0;
            int csiLimitState = 0;
            int csiUsageClass = 0;
            int csiSpectrumType = 0;
            int csiSoilType = 0;
            int csiTopography = 0;

            _callCode = _sapModel.Func.FuncRS.GetNTC2008(name, ref csiParametersOption, ref latitude, ref longitude, ref csiIsland, ref csiLimitState, ref csiUsageClass, ref nominalLife, ref peakAcceleration,
                ref F0, ref Tcs, ref csiSpectrumType, ref csiSoilType, ref csiTopography, ref hRatio, ref damping, ref q);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            parametersOption = (eParameters_NTC_2008)csiParametersOption;
            island = (eIsland_NTC_2008)csiIsland;
            limitState = (eLimitState_NTC_2008)csiLimitState;
            usageClass = (eUsageClass_NTC_2008)csiUsageClass;
            spectrumType = (eSpectrumType_NTC_2008)csiSpectrumType;
            soilType = (eSiteClass_NTC_2008)csiSoilType;
            topography = (eTopography_NTC_2008)csiTopography;
        }

        /// <summary>
        /// This function defines a NTC2008 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an NTC2008  response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="parametersOption">The option for defining the parameters.</param>
        /// <param name="latitude">The latitude for which the parameters are obtained. <para/> 
        /// These items are used only when <paramref name="parametersOption"/> = <see cref="eParameters_NTC_2008.ByLatLong"/>.</param>
        /// <param name="longitude">The longitude for which the parameters are obtained. <para/>
        /// These items are used only when <paramref name="parametersOption"/> = <see cref="eParameters_NTC_2008.ByLatLong"/>.</param>
        /// <param name="island">The island. <para/>
        /// This item is used only when <paramref name="parametersOption"/> = <see cref="eParameters_NTC_2008.ByIsland"/>.</param>
        /// <param name="limitState">The limit state.</param>
        /// <param name="usageClass">The usage class.</param>
        /// <param name="nominalLife">The nominal life to be considered.</param>
        /// <param name="peakAcceleration">The peak ground acceleration, ag/g.</param>
        /// <param name="F0">The magnitude factor, F0.</param>
        /// <param name="Tcs">The reference period, Tc* [s].</param>
        /// <param name="spectrumType">The type of spectrum to consider.</param>
        /// <param name="soilType">The subsoil type.</param>
        /// <param name="topography">The topography type.</param>
        /// <param name="hRatio">The ratio for the site altitude at the base of the hill to the height of the hill.</param>
        /// <param name="damping">The damping, in percent. 
        /// This is only applicable for <paramref name="spectrumType"/> = <see cref="eSpectrumType_NTC_2008.ElasticHorizontal"/> or <see cref="eSpectrumType_NTC_2008.ElasticVertical"/>.</param>
        /// <param name="q">The behavior correction factor. 
        /// This is only applicable for <paramref name="spectrumType"/> = <see cref="eSpectrumType_NTC_2008.DesignHorizontal"/> or <see cref="eSpectrumType_NTC_2008.DesignVertical"/>.</param>
        /// <exception cref="CSiException"></exception>
        public void SetNTC2008(string name,
            eParameters_NTC_2008 parametersOption,
            double latitude,
            double longitude,
            eIsland_NTC_2008 island,
            eLimitState_NTC_2008 limitState,
            eUsageClass_NTC_2008 usageClass,
            double nominalLife,
            double peakAcceleration,
            double F0,
            double Tcs,
            eSpectrumType_NTC_2008 spectrumType,
            eSiteClass_NTC_2008 soilType,
            eTopography_NTC_2008 topography,
            double hRatio,
            double damping,
            double q)
        {
            _callCode = _sapModel.Func.FuncRS.SetNTC2008(name, (int)parametersOption, latitude, longitude, (int)island, (int)limitState, (int)usageClass, nominalLife, peakAcceleration,
                F0, Tcs, (int)spectrumType, (int)soilType, (int)topography, hRatio, damping, q);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the definition of an NZS 1170 2004 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an NZS 1170 2004 response spectrum function.</param>
        /// <param name="siteClass">The site class.</param>
        /// <param name="Z">The hazard factor, Z.</param>
        /// <param name="R">The return period factor, R.</param>
        /// <param name="distanceToFault">Distance to the fault in km, used to calculate the near fault factor.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetNZS11702004(string name,
            ref eSiteClass_NZS_1170_2004 siteClass,
            ref double Z,
            ref double R,
            ref double distanceToFault,
            ref double dampingRatio)
        {
            int csiSiteClass = 0;

            _callCode = _sapModel.Func.FuncRS.GetNZS11702004(name, ref csiSiteClass, ref Z, ref R, ref distanceToFault, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            siteClass = (eSiteClass_NZS_1170_2004)csiSiteClass;
        }

        /// <summary>
        /// This function defines an NZS 1170 2004 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an NZS 1170 2004 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="siteClass">The site class.</param>
        /// <param name="Z">The hazard factor, Z.</param>
        /// <param name="R">The return period factor, R.</param>
        /// <param name="distanceToFault">Distance to the fault in km, used to calculate the near fault factor.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetNZS11702004(string name,
            eSiteClass_NZS_1170_2004 siteClass,
            double Z,
            double R,
            double distanceToFault,
            double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetNZS11702004(name, (int)siteClass, Z, R, distanceToFault, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the definition of an NZS4203-1992 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an NZS4203-1992 response spectrum function.</param>
        /// <param name="scalingFactor">The scaling factor (Sm * Sp * R * Z * L).</param>
        /// <param name="subsoilCategory">The subsoil category.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetNZS42031992(string name,
            ref double scalingFactor,
            ref eSiteClass_NZS_4203_1992 subsoilCategory,
            ref double dampingRatio)
        {
            int csiSubsoilCategory = 0;

            _callCode = _sapModel.Func.FuncRS.GetNZS42031992(name, ref scalingFactor, ref csiSubsoilCategory, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            subsoilCategory = (eSiteClass_NZS_4203_1992)csiSubsoilCategory;
        }

        /// <summary>
        /// This function defines an NZS4203-1992 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an NZS4203-1992 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="scalingFactor">The scaling factor (Sm * Sp * R * Z * L).</param>
        /// <param name="subsoilCategory">The subsoil category.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetNZS42031992(string name,
            double scalingFactor,
            eSiteClass_NZS_4203_1992 subsoilCategory,
            double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetNZS42031992(name, scalingFactor, (int)subsoilCategory, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the definition of a SP 14.13330.2014 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an SP 14.13330.2014 response spectrum function.</param>
        /// <param name="direction">The direction and structure type for which the response spectrum is generated.</param>
        /// <param name="regionSeismicity">The region seismicity of the construction site.</param>
        /// <param name="soilCategory">The soil category.</param>
        /// <param name="K0Factor">The K0Factor, 0 &lt; K0 &lt;= 2.0. 
        /// This is only applicable when <paramref name="direction"/> = <see cref="eSpectrumDirection_SP_14_13330_2014.BuildingHorizontal"/> or <see cref="eSpectrumDirection_SP_14_13330_2014.BridgeHorizontal"/>.</param>
        /// <param name="K1Factor">The K1Factor, 0 &lt; K0 &lt;= 1.0.</param>
        /// <param name="KPsiFactor">The KPsiFactor, 0.5 &lt; K0 &lt;= 1.5. 
        /// This is only applicable when <paramref name="direction"/> = <see cref="eSpectrumDirection_SP_14_13330_2014.BuildingHorizontal"/> or <see cref="eSpectrumDirection_SP_14_13330_2014.BridgeHorizontal"/>.</param>
        /// <param name="isSoilNonlinear">True: Nonlinear soil deformation should be accounted for. 
        /// This is only applicable when <paramref name="direction"/> = <see cref="eSpectrumDirection_SP_14_13330_2014.BuildingHorizontal"/> or <see cref="eSpectrumDirection_SP_14_13330_2014.BuildingVertical"/> for buildings and <paramref name="soilCategory"/> = <see cref="eSiteClass_SP_14_13330_2014.III"/> or <see cref="eSiteClass_SP_14_13330_2014.IV"/>.</param>
        /// <param name="ASoil">The nonlinear soil deformation factor, 0 &lt; a_soil &lt;= 1.0. 
        /// This is only applicable when <paramref name="isSoilNonlinear"/> = True, <paramref name="direction"/> = <see cref="eSpectrumDirection_SP_14_13330_2014.BuildingHorizontal"/> or <see cref="eSpectrumDirection_SP_14_13330_2014.BuildingVertical"/> for buildings and <paramref name="soilCategory"/> = <see cref="eSiteClass_SP_14_13330_2014.III"/> or <see cref="eSiteClass_SP_14_13330_2014.IV"/>.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetSP14133302014(string name,
            ref eSpectrumDirection_SP_14_13330_2014 direction,
            ref eSeismicIntensity_SP_14_13330_2014 regionSeismicity,
            ref eSiteClass_SP_14_13330_2014 soilCategory,
            ref double K0Factor,
            ref double K1Factor,
            ref double KPsiFactor,
            ref bool isSoilNonlinear,
            ref double ASoil,
            ref double dampingRatio)
        {
            int csiDirection = 0;
            int csiRegionSeismicity = 0;
            int csiSoilCategory = 0;

            _callCode = _sapModel.Func.FuncRS.GetSP14133302014(name, ref csiDirection, ref csiRegionSeismicity, ref csiSoilCategory, ref K0Factor, ref K1Factor, ref KPsiFactor, ref isSoilNonlinear, ref ASoil, ref dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            direction = (eSpectrumDirection_SP_14_13330_2014)csiDirection;
            regionSeismicity = (eSeismicIntensity_SP_14_13330_2014)csiRegionSeismicity;
            soilCategory = (eSiteClass_SP_14_13330_2014)csiSoilCategory;
        }

        /// <summary>
        /// This function retrieves the definition of a SP 14.13330.2014 response spectrum function.
        /// </summary>
        /// <param name="name">The name of an SP 14.13330.2014 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="direction">The direction and structure type for which the response spectrum is generated.</param>
        /// <param name="regionSeismicity">The region seismicity of the construction site.</param>
        /// <param name="soilCategory">The soil category.</param>
        /// <param name="K0Factor">The K0Factor, 0 &lt; K0 &lt;= 2.0. 
        /// This is only applicable when <paramref name="direction"/> = <see cref="eSpectrumDirection_SP_14_13330_2014.BuildingHorizontal"/> or <see cref="eSpectrumDirection_SP_14_13330_2014.BridgeHorizontal"/>.</param>
        /// <param name="K1Factor">The K1Factor, 0 &lt; K0 &lt;= 1.0.</param>
        /// <param name="KPsiFactor">The KPsiFactor, 0.5 &lt; K0 &lt;= 1.5. 
        /// This is only applicable when <paramref name="direction"/> = <see cref="eSpectrumDirection_SP_14_13330_2014.BuildingHorizontal"/> or <see cref="eSpectrumDirection_SP_14_13330_2014.BridgeHorizontal"/>.</param>
        /// <param name="isSoilNonlinear">True: Nonlinear soil deformation should be accounted for. 
        /// This is only applicable when <paramref name="direction"/> = <see cref="eSpectrumDirection_SP_14_13330_2014.BuildingHorizontal"/> or <see cref="eSpectrumDirection_SP_14_13330_2014.BuildingVertical"/> for buildings and <paramref name="soilCategory"/> = <see cref="eSiteClass_SP_14_13330_2014.III"/> or <see cref="eSiteClass_SP_14_13330_2014.IV"/>.</param>
        /// <param name="ASoil">The nonlinear soil deformation factor, 0 &lt; a_soil &lt;= 1.0. 
        /// This is only applicable when <paramref name="isSoilNonlinear"/> = True, <paramref name="direction"/> = <see cref="eSpectrumDirection_SP_14_13330_2014.BuildingHorizontal"/> or <see cref="eSpectrumDirection_SP_14_13330_2014.BuildingVertical"/> for buildings and <paramref name="soilCategory"/> = <see cref="eSiteClass_SP_14_13330_2014.III"/> or <see cref="eSiteClass_SP_14_13330_2014.IV"/>.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampingRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetSP14133302014(string name,
            eSpectrumDirection_SP_14_13330_2014 direction,
            eSeismicIntensity_SP_14_13330_2014 regionSeismicity,
            eSiteClass_SP_14_13330_2014 soilCategory,
            double K0Factor,
            double K1Factor,
            double KPsiFactor,
            bool isSoilNonlinear,
            double ASoil,
            double dampingRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetSP14133302014(name, (int)direction, (int)regionSeismicity, (int)soilCategory, K0Factor, K1Factor, KPsiFactor, isSoilNonlinear, ASoil, dampingRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the definition of a UBC94 response spectrum function.
        /// </summary>
        /// <param name="name">The name of a UBC97 response spectrum function.</param>
        /// <param name="Z">The seismic zone factor, Z.</param>
        /// <param name="S">This is 1, 2 or 3, indicating the soil type.</param>
        /// <param name="dampRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetUBC94(string name,
            double Z,
            int S,
            double dampRatio)
        {
            _callCode = _sapModel.Func.FuncRS.GetUBC94(name, ref Z, ref S, ref dampRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function defines a UBC94 response spectrum function.
        /// </summary>
        /// <param name="name">The name of a UBC97 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="Z">The seismic zone factor, Z.</param>
        /// <param name="S">This is 1, 2 or 3, indicating the soil type.</param>
        /// <param name="dampRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetUBC94(string name,
            double Z,
            int S,
            double dampRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetUBC94(name, Z, S, dampRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        /// <summary>
        /// This function retrieves the definition of a UBC97 response spectrum function.
        /// </summary>
        /// <param name="name">The name of a UBC97 response spectrum function.</param>
        /// <param name="Ca">The seismic coefficient, Ca.</param>
        /// <param name="Cv">The seismic coefficient, Cv.</param>
        /// <param name="dampRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void GetUBC97(string name,
            ref double Ca,
            ref double Cv,
            ref double dampRatio)
        {
            _callCode = _sapModel.Func.FuncRS.GetUBC97(name, ref Ca, ref Cv, ref dampRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function defines a UBC97 response spectrum function.
        /// </summary>
        /// <param name="name">The name of a UBC97 response spectrum function. <para/>
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="Ca">The seismic coefficient, Ca.</param>
        /// <param name="Cv">The seismic coefficient, Cv.</param>
        /// <param name="dampRatio">The damping ratio for the function, 0 &lt;= <paramref name="dampRatio"/> &lt; 1.</param>
        /// <exception cref="CSiException"></exception>
        public void SetUBC97(string name,
            double Ca,
            double Cv,
            double dampRatio)
        {
            _callCode = _sapModel.Func.FuncRS.SetUBC97(name, Ca, Cv, dampRatio);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion
    }
}
