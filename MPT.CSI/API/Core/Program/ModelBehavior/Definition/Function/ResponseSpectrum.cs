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
        /// <param name="numberOfItems">The number of frequency and value pairs defined.</param>
        /// <param name="periods">The frequency in Hz for each data point. [cyc/s].</param>
        /// <param name="values">The function value for each data point.</param>
        /// <param name="dampingRatio">The damping ratio for the function, 0 &lt;= DampRatio &lt; 1.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void GetUser(string name,
            ref int numberOfItems,
            ref double[] periods,
            ref double[] values,
            ref double dampingRatio)
        {
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

        public void GetAASHTO2006(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetAASHTO2006();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetAASHTO2006(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetAASHTO2006();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetAASHTO2007(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetAASHTO2007();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetAASHTO2007(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetAASHTO2007();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetAS11702007(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetAS11702007();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetAS11702007(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetAS11702007();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetBOCA96(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetBOCA96();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetBOCA96(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetBOCA96();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetChinese2010(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetChinese2010();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetChinese2010(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetChinese2010();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetCJJ1662011(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetCJJ1662011();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetCJJ1662011(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetCJJ1662011();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetEurocode8(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetEuroCode8();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetEurocode8(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetEuroCode8();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetEurocode82001(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetEurocode82001_1();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetEurocode82001(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetEurocode82001_1();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetJTGB022013(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetJTGB022013();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetJTGB022013(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetJTGB022013();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetIBC2003(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetIBC2003();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetIBC2003(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetIBC2003();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetIS18932002(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetIS18932002();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetIS18932002(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetIS18932002();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetItalian3274(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetItalian3274();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetItalian3274(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetItalian3274();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetNBCC2015(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetNBCC2015();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetNBCC2015(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetNBCC2015();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetNBCC2010(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetNBCC2010();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetNBCC2010(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetNBCC2010();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetNBCC2005(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetNBCC2005();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetNBCC2005(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetNBCC2005();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetNBCC95(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetNBCC95();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetNBCC95(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetNBCC95();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetNCHRP2007(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetNCHRP2007();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetNCHRP2007(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetNCHRP2007();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetNEHRP97(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetNEHRP97();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetNEHRP97(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetNEHRP97();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetNTC2008(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetNTC2008();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetNTC2008(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetNTC2008();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetNZS11702004(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetNZS11702004();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetNZS11702004(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetNZS11702004();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetNZS42031992(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetNZS42031992();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetNZS42031992(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetNZS42031992();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetSP14133302014(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetSP14133302014();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetSP14133302014(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetSP14133302014();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetUBC94(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetUBC94();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetUBC94(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetUBC94();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        public void GetUBC97(ref string param)
        {
            //_callCode = _sapModel.Func.FuncRS.GetUBC97();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        public void SetUBC97(string param)
        {
            //_callCode = _sapModel.Func.FuncRS.SetUBC97();
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion
    }
}
