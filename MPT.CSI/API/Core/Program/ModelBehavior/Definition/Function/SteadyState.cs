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
    /// Represents the steady state function in the application.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class SteadyState : CSiApiBase
    {

        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="SteadyState"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public SteadyState(CSiApiSeed seed) : base(seed) { }


        #endregion

        #region Methods: File & User
        /// <summary>
        /// This function retrieves the definition of a steady state function from file.
        /// </summary>
        /// <param name="name">The name of a defined steady state function specified to be from a text file.</param>
        /// <param name="fileName">The full path of the text file containing the function data.</param>
        /// <param name="headerLinesSkip">The number of header lines in the text file to be skipped before starting to read function data.</param>
        /// <param name="prefixCharactersSkip">The number of prefix characters to be skipped on each line in the text file.</param>
        /// <param name="pointsPerLine">The number of function points included on each text file line.</param>
        /// <param name="valueType">Type of the value used in the file.</param>
        /// <param name="freeFormat">True: Data is provided in a free format. It is 
        /// False: It is in a fixed format.</param>
        /// <param name="numberFixed">The number of characters per item.
        /// This item applies only when the <paramref name="freeFormat"/> item is False. </param>
        /// <param name="frequencyTypeInFile">The frequency type in the file.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void GetFromFile(string name,
            ref string fileName,
            ref int headerLinesSkip,
            ref int prefixCharactersSkip,
            ref int pointsPerLine,
            ref eFileValueType valueType,
            ref bool freeFormat,
            ref int numberFixed,
            ref eFrequencyType frequencyTypeInFile)
        {
            int csiValueType = 0;
            int csiFrequencyTypeInFile = 0;

            // TODO: What if file path is invalid? Other ways this may fail?
            _callCode = _sapModel.Func.FuncSS.GetFromFile(name, ref fileName, ref headerLinesSkip, ref prefixCharactersSkip, ref pointsPerLine, ref csiValueType, ref freeFormat, ref numberFixed, ref csiFrequencyTypeInFile);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            valueType = (eFileValueType)csiValueType;
            frequencyTypeInFile = (eFrequencyType)csiFrequencyTypeInFile;
        }

        /// <summary>
        /// This function defines a steady state function from file.
        /// </summary>
        /// <param name="name">The name of an existing or new function. 
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="fileName">The full path of the text file containing the function data.</param>
        /// <param name="headerLinesSkip">The number of header lines in the text file to be skipped before starting to read function data.</param>
        /// <param name="prefixCharactersSkip">The number of prefix characters to be skipped on each line in the text file.</param>
        /// <param name="pointsPerLine">The number of function points included on each text file line.</param>
        /// <param name="valueType">Type of the value used in the file.</param>
        /// <param name="freeFormat">True: Data is provided in a free format. It is 
        /// False: It is in a fixed format.</param>
        /// <param name="numberFixed">The number of characters per item.
        /// This item applies only when the <paramref name="freeFormat"/> item is False. </param>
        /// <param name="frequencyTypeInFile">The frequency type in the file.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void SetFromFile(string name,
            string fileName,
            int headerLinesSkip,
            int prefixCharactersSkip,
            int pointsPerLine,
            eFileValueType valueType,
            bool freeFormat,
            int numberFixed = 10,
            eFrequencyType frequencyTypeInFile = eFrequencyType.HZ)
        {
            // TODO: What if file path is invalid? Other ways this may fail?
            _callCode = _sapModel.Func.FuncSS.SetFromFile(name, fileName, headerLinesSkip, prefixCharactersSkip, pointsPerLine, (int)valueType, freeFormat, numberFixed, (int)frequencyTypeInFile);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        /// <summary>
        /// This function retrieves the definition of a user defined steady state function.
        /// </summary>
        /// <param name="name">The name of a user defined steady state function.</param>
        /// <param name="numberOfItems">The number of frequency and value pairs defined.</param>
        /// <param name="frequencies">The frequency in Hz for each data point. [cyc/s].</param>
        /// <param name="values">The function value for each data point.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException"></exception>
        public void GetUser(string name,
            ref int numberOfItems,
            ref double[] frequencies,
            ref double[] values)
        {
            _callCode = _sapModel.Func.FuncSS.GetUser(name, ref numberOfItems, ref frequencies, ref values);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function defines a user steady state function.
        /// </summary>
        /// <param name="name">The name of an existing or new function. 
        /// If this is an existing function, that function is modified; otherwise, a new function is added.</param>
        /// <param name="frequencies">The frequency in Hz for each data point. [cyc/s].</param>
        /// <param name="values">The function value for each data point.</param>
        /// <exception cref="MPT.CSI.API.Core.Support.CSiException">
        /// </exception>
        public void SetUser(string name,
            double[] frequencies,
            double[] values)
        {
            if (frequencies.Length != values.Length)
            {
                throw new CSiException("Frequencies and values are of unequal numbers. \nFrequency has " +
                                       frequencies.Length + " entries, while Values has " + values.Length + " entries.");
            }
            int numberOfItems = frequencies.Length;

            _callCode = _sapModel.Func.FuncSS.SetUser(name, numberOfItems, ref frequencies, ref values);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        #endregion
    }
}
