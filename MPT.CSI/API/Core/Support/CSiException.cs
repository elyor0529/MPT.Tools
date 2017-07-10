using System;

namespace MPT.CSI.API.Core.Support
{
    /// <summary>
    /// Exception thrown when a CSi API function fails to return 0 indicating success.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class CSiException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSiException"/> class.
        /// </summary>
        public CSiException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSiException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CSiException(string message) : base(message) {}
    }
}
