
namespace MPT.CSI.API.EndToEndTests.Core
{
    /// <exclude />
    public static class CSiData
    {
        public const string pathResources = @"C:\TFS\Regression Tester\Main\DLLs\MPT.Tools\MPT.CSI\API\MPT.CSI.API.EndToEndTests" + @"\Resources"; //Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Resources";
        public const string pathModelDemo = "Demo";
        public const string pathModelQuery = "Query";
        public const string pathModelSet = "Set";
        public const string pathModelSave = "Save";
        public const string pathModelSaveReadOnly = "SaveReadOnly";
#if BUILD_SAP2000v16
        public const string pathApp = @"";
        public const string extension = ".sdb";
#elif BUILD_SAP2000v17
        public const string pathApp = @"C:\Program Files (x86)\Computers and Structures\SAP2000 17\SAP2000.exe";
        public const string extension = ".sdb";
#elif BUILD_SAP2000v18
        public const string pathApp = @"";
        public const string extension = ".sdb";
#elif BUILD_SAP2000v19
        public const string pathApp = @"C:\Program Files (x86)\Computers and Structures\SAP2000 19\SAP2000.exe";
        public const string extension = ".sdb";
        public const string versionName = "19.2.1";
        public const double versionNumber = 19.21;
        public const string processName = "SAP2000";
#elif BUILD_CSiBridgev16
        public const string pathApp = @"";
        public const string extension = ".bdb";
#elif BUILD_CSiBridgev17
        public const string pathApp = @"";
        public const string extension = ".bdb";
#elif BUILD_CSiBridgev18
        public const string pathApp = @"";
        public const string extension = ".bdb";
#elif BUILD_CSiBridgev19
        public const string pathApp = @"";
        public const string extension = ".bdb";
#elif BUILD_ETABS2013
        public const string pathApp = @"";
        public const string extension = ".edb";
#elif BUILD_ETABS2015
        public const string pathApp = @"C:\Program Files (x86)\Computers and Structures\ETABS 2015\ETABS.exe";
        public const string extension = ".edb";
#elif BUILD_ETABS2016
        public const string pathApp = @"C:\Program Files (x86)\Computers and Structures\ETABS 2016\ETABS.exe";
        public const string extension = ".edb";
#endif
    }
}
