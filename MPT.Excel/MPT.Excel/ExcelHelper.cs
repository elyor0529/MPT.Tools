namespace MPT.Excel
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using Excel = Microsoft.Office.Interop.Excel;      //Microsoft Excel 14 object in references-> COM tab
    
    using MPT.Processor;

    public class ExcelHelper : IDisposable
    {
        private const string PROCESS_NAME = "EXCEL";

        private Excel.Application xlApp;
        private Excel.Workbook xlWorkbook;
        private Excel._Worksheet xlWorksheet;
        private Excel.Range xlRange;

        private bool attachedToProcess;
        private bool totalShutdown;

        public string Path { get; private set; }

        public List<Excel._Worksheet> Worksheets { get; private set; } = new List<Excel._Worksheet>();
        public List<Excel.Range> Ranges { get; private set; } = new List<Excel.Range>();
        public List<Excel.Name> Names { get; private set; } = new List<Excel.Name>();


        public ExcelHelper() { }

        public ExcelHelper(string path)
        {
            Path = path;
            string fileName = System.IO.Path.GetFileName(path);
            if (ProcessorLibrary.ProcessExists(PROCESS_NAME, fileName))
            {
                AttachToProcess(fileName);
                attachedToProcess = true;
            }
            else
            {
                Load(path);
            }
        }

        public void Load(string path)
        {
            Path = path;
            Dispose();

            //Create COM Objects. Create a COM object for everything that is referenced
            xlApp = new Excel.Application();
            Initialize(openWorkbook:true);
        }

        public void AttachToProcess(string fileName)
        {
            int processID = ProcessorLibrary.GetProcessID(PROCESS_NAME, fileName);
            if (processID != 0)
            {
                xlApp = ExcelInteropService.GetExcelInterop(processID);
                Initialize(openWorkbook: false);
                return;
            }
        }

        private void Initialize(bool openWorkbook)
        {
            if (xlApp == null) { return; }

            try
            {
                if (openWorkbook)
                {
                    xlWorkbook = ExcelWrapper.AppWorkbooksOpen(xlApp, Path);
                }
                else
                {
                    string fileName = System.IO.Path.GetFileName(Path);
                    foreach (Excel.Workbook workbook in xlApp.Workbooks)
                    {
                        if (workbook.Name == fileName)
                        {
                            xlWorkbook = workbook;
                            break;
                        }
                    }
                }
                
                if (xlWorkbook == null) { return; }
                foreach (Excel._Worksheet worksheet in xlWorkbook.Sheets)
                {
                    Worksheets.Add(worksheet);
                }

                foreach (Excel.Name name in xlWorkbook.Names)
                {
                    Names.Add(name);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }



        public List<string> RangeValues1D(string rangeName, bool includeNull = false)
        {
            List<string> rangeValues1D = new List<string>();
            if (xlWorkbook == null) { return rangeValues1D; }

                xlRange = GetRangeByName(rangeName);
            if (xlRange == null) return rangeValues1D;

            if (xlRange.Count > 1)
            {
                rangeValues1D = ConvertToStringList(xlRange.Cells.Value, includeNull);
            }
            else
            {
                rangeValues1D.Add((string)xlRange.Cells.Value);
            }

            return rangeValues1D;
        }

        public List<List<string>> RangeValuesBelowHeaderAndCorrespondingColumns(string headerRangeName, params string[] rangeNames)
        {
            List<List<string>> TotalList = new List<List<string>>();
            List<string> RangeValuesBelowHeader = new List<string>();
            if (xlWorkbook == null) { return TotalList; }

            TotalList.Add(RangeValuesBelowHeader);
            for (int i = 0; i < rangeNames.Length; i++)
            {
                TotalList.Add(new List<string>());
            }


            xlRange = GetRangeByName(headerRangeName);
            // Only do this to ranges that are single cells.
            if (xlRange == null || xlRange.Count > 1) return TotalList;

            int rowOffset = 1;
            string value = "";
            do
            {
                value = (string)xlRange.Offset[rowOffset].Cells.Value;
                if (!string.IsNullOrEmpty(value))
                {
                    RangeValuesBelowHeader.Add(value);
                    string[] correspondingValues = CorrespondingColumnValues(rowOffset, rangeNames);
                    for (int i = 0; i < rangeNames.Length; i++)
                    {
                        TotalList[i + 1].Add(correspondingValues[i]);
                    }
                }
                rowOffset++;
            } while (!string.IsNullOrEmpty(value));
          
            return TotalList;
        }

        public string[] CorrespondingColumnValues(int rowOffset, string[] rangeNames)
        {
            string[] values = new string[rangeNames.Length];
            if (xlWorkbook == null) { return values; }
            for (int i = 0; i < rangeNames.Length; i++)
            {
                Excel.Range xlRange = GetRangeByName(rangeNames[i]);
                if (xlRange != null && xlRange.Count == 1)
                {
                    values[i] = (string)xlRange.Offset[rowOffset].Cells.Value;
                }
                else
                {
                    values[i] = "";
                }
            }
            return values;
        }

        public List<string> RangeValuesBelowHeader(string headerRangeName)
        {
            List<string> RangeValuesBelowHeader = new List<string>();
            if (xlWorkbook == null) { return RangeValuesBelowHeader; }

            xlRange = GetRangeByName(headerRangeName);
            // Only do this to ranges that are single cells.
            if (xlRange == null || xlRange.Count > 1) return RangeValuesBelowHeader;
            
            int rowOffset = 1;
            string value = "";
            do
            {
                value = (string)xlRange.Offset[rowOffset].Cells.Value;
                if (!string.IsNullOrEmpty(value))
                {
                    RangeValuesBelowHeader.Add(value);
                }
                rowOffset++;
            } while (!string.IsNullOrEmpty(value));

            return RangeValuesBelowHeader;
        }

        public bool ExistOnSameRow(Dictionary<string, string> rangeNamesvalues)
        {
            if (xlWorkbook == null) { return false; }
            int rowOffset = 0;
            string value = "";
            do
            {
                rowOffset++;
                bool matchingRow = true;
                foreach (string rangeName in rangeNamesvalues.Keys)
                {
                    xlRange = GetRangeByName(rangeName);
                    // Only do this to ranges that are single cells.
                    if (xlRange == null || xlRange.Count > 1) return false;

                    if (string.Compare(rangeNamesvalues[rangeName], (string)xlRange.Offset[rowOffset].Cells.Value, ignoreCase: true) != 0)
                    {
                        matchingRow = false;
                        break;
                    }
                }
                if (matchingRow) { return true; }
            } while (!string.IsNullOrEmpty(value));

            return false;
        }

        public int GetRowOffsetLastFilled(string headerRangeName)
        {
            if (xlWorkbook == null) { return 0; }
            xlRange = GetRangeByName(headerRangeName);
            // Only do this to ranges that are single cells.
            if (xlRange == null || xlRange.Count > 1) return 0;

            int rowOffset = 0;
            string value = "";
            do
            {
                rowOffset++;
                value = (string)xlRange.Offset[rowOffset].Cells.Value;
            } while (!string.IsNullOrEmpty(value));

            return (rowOffset - 1);
        }

        public void ClearRow(string headerRangeName, int rowOffset)
        {
            if (xlWorkbook == null) { return; }
            xlRange = GetRangeByName(headerRangeName).Offset[rowOffset].EntireRow;
            ExcelWrapper.RangeClear(xlRange);
        }

        public void ClearRowContents(string headerRangeName, int rowOffset)
        {
            if (xlWorkbook == null) { return; }
            xlRange = GetRangeByName(headerRangeName).Offset[rowOffset].EntireRow;
            ExcelWrapper.RangeClearContents(xlRange);
        }

        public void DuplicateRowDown(string headerRangeName, int rowOffset)
        {
            if (xlWorkbook == null) { return; }
            xlRange = GetRangeByName(headerRangeName).Offset[rowOffset].EntireRow;
            ExcelWrapper.RangeCopyEntireRowAttempts(xlRange, rowCopyOffset: 1);
        }


        public void WriteValues(Dictionary<string, string> rangeNamesvalues, int rowOffset)
        {
            if (xlWorkbook == null) { return; }
            foreach (string rangeName in rangeNamesvalues.Keys)
            {
                WriteValue(rangeName, rangeNamesvalues[rangeName], rowOffset);
            }
        }

        public void WriteValue(string rangeName, string rangeValue, int rowOffset = 0)
        {
            if (xlWorkbook == null) { return; }
            xlRange = GetRangeByName(rangeName).Offset[rowOffset].Cells;
            // Only do this to ranges that are single cells.
            if (xlRange == null || xlRange.Count > 1) return;

            //xlRange.Value = rangeValue;
            ExcelWrapper.RangeWriteValue(xlRange, rangeValue);
        }

        public void Save(string saveAsName = "")
        {
            if (xlWorkbook == null) { return; }

            if(string.IsNullOrEmpty(saveAsName))
            {
                xlWorkbook.Save();
            }
            else
            {
                xlWorkbook.SaveAs(saveAsName);
            }
        }

        private Excel.Range GetRangeByName(string rangeName)
        {
            foreach (Excel.Name name in Names)
            {
                if (name.Name.CompareTo(rangeName) == 0)
                {
                    return name.RefersToRange;
                }
            }
            return null;
        }

        public void SetTotalShutdown()
        {
            totalShutdown = true;
        }
        public void Dispose()
        {            
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            if (xlRange != null) { Marshal.ReleaseComObject(xlRange); }
            if (xlWorksheet != null) { Marshal.ReleaseComObject(xlWorksheet); }

            foreach (Excel._Worksheet worksheet in Worksheets)
            {
                Marshal.ReleaseComObject(worksheet);
            }

            foreach (Excel.Name name in Names)
            {
                Marshal.ReleaseComObject(name);
            }

            foreach (Excel.Range range in Ranges)
            {
                Marshal.ReleaseComObject(range);
            }

            if (totalShutdown)
            {
                Marshal.ReleaseComObject(xlWorkbook);
                quitAndRelease();
            }
            else if (attachedToProcess && !totalShutdown)
            {
                attachedToProcess = false;
                xlWorkbook = null;
                xlApp = null;

                return;
            }
            else
            {
                //close and release
                if (xlWorkbook != null)
                {
                    xlWorkbook.Close();
                    Marshal.ReleaseComObject(xlWorkbook);
                }
                quitAndRelease();
            }
        }

        private void quitAndRelease()
        {
            if (xlApp != null)
            {
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
        }



        private List<string> ConvertToStringList(Array values, bool includeNull = false)
        {

            // create a new string array
            List<string> stringList = new List<string>();

            // loop through the 2-D System.Array and populate the 1-D String Array
            for (int i = 1; i <= values.Length; i++)
            {
                if (values.GetValue(i, 1) == null && includeNull)
                    stringList.Add("");
                else if (values.GetValue(i, 1) != null)
                    stringList.Add(values.GetValue(i, 1).ToString());
            }

            return stringList;
        }
    }
}
