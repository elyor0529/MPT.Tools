using System;

namespace MPT.CSI.API.Core.Support
{
    /// <summary>
    /// Exception thrown when a CSi API function fails to return 0 indicating success.
    /// </summary>
    public class CSiReservedNameException : Exception
    {
        public CSiReservedNameException() { }

        public CSiReservedNameException(string message) : base(message) { }
    }
}
