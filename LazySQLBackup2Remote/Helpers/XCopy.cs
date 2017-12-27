using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Dekart.LazyNet.SQLBackup2Remote.Helpers
{
    /// <summary>
    /// PInvoke wrapper for CopyEx
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/aa363852.aspx
    /// </summary>
    public class XCopy
    {
        public static void Copy(string source, string destination, bool overwrite, bool nobuffering, EventHandler<ProgressChangedEventArgs> onProgressChanged = null, EventHandler onCompleted = null)
        {
            new XCopy().CopyInternal(source, destination, overwrite, nobuffering, onProgressChanged, onCompleted);
        }

        private event EventHandler Completed;
        private event EventHandler<ProgressChangedEventArgs> ProgressChanged;

        private int _isCancelled;
        private int _filePercentCompleted;
        private string _source;
        private string _destination;

        private XCopy()
        {
            _isCancelled = 0;
        }

        private void CopyInternal(string source, string destination, bool overwrite, bool nobuffering, EventHandler<ProgressChangedEventArgs> onProgressChanged, EventHandler onCompleted)
        {
            try
            {
                var copyFileFlags = CopyFileFlags.COPY_FILE_RESTARTABLE;
                if (!overwrite)
                    copyFileFlags |= CopyFileFlags.COPY_FILE_FAIL_IF_EXISTS;

                if (nobuffering)
                    copyFileFlags |= CopyFileFlags.COPY_FILE_NO_BUFFERING;

                _source = source;
                _destination = destination;

                if (onProgressChanged != null)
                    ProgressChanged += onProgressChanged;

                if (onCompleted != null)
                    Completed += onCompleted;

                var result = CopyFileEx(_source, _destination, CopyProgressHandler, IntPtr.Zero, ref _isCancelled, copyFileFlags);
                if (!result)
                    throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            catch (Exception)
            {
                if (onProgressChanged != null)
                    ProgressChanged -= onProgressChanged;

                throw;
            }
        }

        private void OnProgressChanged(double percent)
        {
            // only raise an event when progress has changed
            if ((int)percent > _filePercentCompleted)
            {
                _filePercentCompleted = (int)percent;

                var handler = ProgressChanged;
                handler?.Invoke(this, new ProgressChangedEventArgs(_filePercentCompleted, null));
            }
        }

        private void OnCompleted()
        {
            var handler = Completed;
            handler?.Invoke(this, EventArgs.Empty);
        }

        #region PInvoke

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CopyFileEx(string lpExistingFileName, string lpNewFileName, CopyProgressRoutine lpProgressRoutine, IntPtr lpData, ref Int32 pbCancel, CopyFileFlags dwCopyFlags);

        // ReSharper disable InconsistentNaming
        private delegate CopyProgressResult CopyProgressRoutine(long TotalFileSize, long TotalBytesTransferred, long StreamSize, long StreamBytesTransferred, uint dwStreamNumber, CopyProgressCallbackReason dwCallbackReason, IntPtr hSourceFile, IntPtr hDestinationFile, IntPtr lpData);
        // ReSharper restore InconsistentNaming

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private enum CopyProgressResult : uint
        {
            PROGRESS_CONTINUE = 0,
            //PROGRESS_CANCEL = 1,
            //PROGRESS_STOP = 2,
            //PROGRESS_QUIET = 3
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private enum CopyProgressCallbackReason : uint
        {
            CALLBACK_CHUNK_FINISHED = 0x00000000,
            //CALLBACK_STREAM_SWITCH = 0x00000001
        }

        [Flags]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private enum CopyFileFlags : uint
        {
            COPY_FILE_FAIL_IF_EXISTS = 0x00000001,
            COPY_FILE_NO_BUFFERING = 0x00001000,
            COPY_FILE_RESTARTABLE = 0x00000002,
            //COPY_FILE_OPEN_SOURCE_FOR_WRITE = 0x00000004,
            //COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 0x00000008
        }

        private CopyProgressResult CopyProgressHandler(long total, long transferred, long streamSize, long streamByteTrans, uint dwStreamNumber,
                                                       CopyProgressCallbackReason reason, IntPtr hSourceFile, IntPtr hDestinationFile, IntPtr lpData)
        {
            if (reason == CopyProgressCallbackReason.CALLBACK_CHUNK_FINISHED)
                OnProgressChanged((transferred / (double)total) * 100.0);

            if (transferred >= total)
                OnCompleted();

            return CopyProgressResult.PROGRESS_CONTINUE;
        }

        #endregion

    }

}
