using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPT.Processor
{
    public static class ProcessorLibrary
    {    
        // TODO: For both process methods, confirm process is from specified path, if given.
        // See: http://stackoverflow.com/questions/5497064/c-how-to-get-the-full-path-of-running-process
        public static bool ProcessExists(string processName, string fileName)
        {
            //Is Excel open?
            if (Process.GetProcessesByName(processName).Length != 0)
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process process in processes)
                {
                    //Find the exact Excel instance
                    if (process.ProcessName.ToString() == processName && process.MainWindowTitle.Contains(fileName))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static int GetProcessID(string processName, string fileName)
        {
            //Is Excel open?
            if (Process.GetProcessesByName(processName).Length != 0)
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process process in processes)
                {
                    //Find the exact Excel instance
                    if (process.ProcessName.ToString() == processName && process.MainWindowTitle.Contains(fileName))
                    {
                        return process.Id;
                    }
                }
            }
            return 0;
        }
    }
}
