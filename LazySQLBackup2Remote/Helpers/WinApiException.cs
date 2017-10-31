using System;

namespace Dekart.LazyNet.SQLBackup2Remote.Helpers
{
    /// <summary>WinApi exception</summary>
    public class WinApiException : Exception
    {
        /// <summary>ctor</summary>
        public WinApiException(int errorCode)
            : base($"WinApi exception. Error code:{errorCode}.")
        {
        }
    }
}