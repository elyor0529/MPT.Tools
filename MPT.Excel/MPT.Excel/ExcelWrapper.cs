namespace MPT.Excel
{
    using System;
    using System.Runtime.InteropServices;
    using Excel = Microsoft.Office.Interop.Excel;      //Microsoft Excel 14 object in references-> COM tab

    using Coding;

    public static class ExcelWrapper
    {
        // Regarding COMException swallowed:

        private const string VBA_E_IGNORE = "0x800AC472";
        // HRESULT: 0x800AC472 is the VBA_E_IGNORE error that is returned whenever an object model call is invoked while the property browser is suspended. 
        // This can occur when clicking around in Excel when the API is called.
        // See: https://social.msdn.microsoft.com/Forums/vstudio/en-US/9168f9f2-e5bc-4535-8d7d-4e374ab8ff09/hresult-800ac472-from-set-operations-in-excel?forum=vsto

        public const string OBJECT_REQUIRED = "0x800A01A8";
        // HRESULT: 0x800A01A8
        // This can occur when closing Excel while the API is still being called.
        // See: https://social.technet.microsoft.com/Forums/office/en-US/43041fcd-2f67-43d4-913b-5681c584ab67/keep-getting-error-message-exception-from-hresult-0x800a01a8-when-opening-spreadsheets-on?forum=officeitpro

        public static Excel.Workbook AppWorkbooksOpen(Excel.Application application, string path, int attempts = 10000, int intervalMS = 100)
        {
            return Retry.NotNull(() => Try(() => application.Workbooks.Open(path)), new TimeSpan(intervalMS), attempts);
        }


        public static void RangeClear(Excel.Range range, int attempts = 10000, int intervalMS = 100)
        {
            Retry.DoTrue(() => TryBool(() => range.Clear()), new TimeSpan(intervalMS), attempts);
        }


        public static void RangeClearContents(Excel.Range range, int attempts = 10000, int intervalMS = 100)
        {
            Retry.DoTrue(() => TryBool(() => range.ClearContents()), new TimeSpan(intervalMS), attempts);
        }

        public static void RangeCopyEntireRowAttempts(Excel.Range range, int rowCopyOffset = 0, int attempts = 10000, int intervalMS = 100)
        {
            Excel.Range rangeNext = Retry.NotNull(() => Try(() => range.Offset[rowCopyOffset].EntireRow), new TimeSpan(intervalMS), attempts);
            Retry.DoTrue(() => TryBool(() => range.Copy(rangeNext)), new TimeSpan(intervalMS), attempts);
        }

        public static void RangeWriteValue(Excel.Range range, string value, int attempts = 10000, int intervalMS = 100)
        {
            Retry.DoTrue(() => TryBool(() => assignValue(range, value)), new TimeSpan(intervalMS), attempts);
        }

        private static void assignValue(Excel.Range range, string value)
        {
            range.Value = value;
        }



        public static T Try<T>(Func<T> action)
        {
            try
            {
                return action();
            }
            catch (COMException eCom)
            {
                if (eCom.Message.Contains(VBA_E_IGNORE))
                {
                    Console.WriteLine(eCom.Message);
                    return default(T);
                }
                else if(eCom.Message.Contains(OBJECT_REQUIRED))
                {
                    throw eCom;
                }
                throw eCom;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static bool TryBool<T>(Func<T> action)
        {
            try
            {
                action();
                return true;
            }
            catch (COMException eCom)
            {
                if (eCom.Message.Contains(VBA_E_IGNORE))
                {
                    Console.WriteLine(eCom.Message);
                    return false;
                }
                else if (eCom.Message.Contains(OBJECT_REQUIRED))
                {
                    throw eCom;
                }
                throw eCom;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static bool TryBool(Action action)
        {
            try
            {
                action();
                return true;
            }
            catch (COMException eCom)
            {
                if (eCom.Message.Contains(VBA_E_IGNORE))
                {
                    Console.WriteLine(eCom.Message);
                    return false;
                }
                else if (eCom.Message.Contains(OBJECT_REQUIRED))
                {
                    throw eCom;
                }
                throw eCom;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
