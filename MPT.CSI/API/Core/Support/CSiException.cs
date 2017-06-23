using System;

namespace MPT.CSI.API.Core.Support
{
    /// <summary>
    /// Exception thrown when a CSi API function fails to return 0 indicating success.
    /// </summary>
    public class CSiException : Exception
    {
        public CSiException() { }

        public CSiException(string message) : base(message) {}
    }
}
