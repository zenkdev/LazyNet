using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;

namespace Dekart.LazyNet.Helpers
{
    public sealed class DownloadInfo : IDisposable
    {
        private ICredentials _credentials;
        private bool _disposed;
        private long _length;
        private IWebProxy _proxy;
        private WebResponse _response;
        private long _start;
        private Stream _stream;

        public DownloadInfo()
        {
            // Set the default web proxy
            _proxy = WebRequest.DefaultWebProxy;
        }

        ~DownloadInfo()
        {
            if (_stream != null)
                _stream.Dispose();
        }

        private void CheckDisposed()
        {
            if (Disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }

        /// <summary>
        /// Releases the resources, other than memory, that are used by the <see cref="DownloadInfo"/>. 
        /// </summary>
        /// <param name="disposing"><b>true</b> to release both managed and unmanaged resources; <b>false</b> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    if (_stream != null && _stream != Stream.Null)
                    {
                        _stream.Close();
                    }

                    if (_response != null)
                    {
                        _response.Close();
                    }
                }

                // There are no unmanaged resources to release, but
                // if we add them, they need to be released here.
            }
            _disposed = true;
        }

        private long GetFileSize(Uri url)
        {
            long size;
            using (var r = GetRequest(url).GetResponse())
                size = r.ContentLength;
            return size;
        }

        private WebRequest GetRequest(Uri url)
        {
            var request = WebRequest.Create(url);

            if (request is HttpWebRequest)
            {
                request.Credentials = Credentials;
            }
            request.Proxy = Proxy;
            return request;
        }

        private void ValidateResponse(WebResponse response, Uri url)
        {
            if (response.GetType() == typeof(HttpWebResponse))
            {
                var httpResponse = (HttpWebResponse)response;

                // If it's an HTML page, it's probably an error page. Tag this
                // out to enable downloading of HTML pages.
                if (!DownloadHtmlPages && httpResponse.ContentType.Contains("text/html") || httpResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ArgumentException(string.Format(CultureInfo.CurrentUICulture, "Could not download {0} - a web page was returned from the web server.", url));
                }
            }
            else if (response.GetType() == typeof(FtpWebResponse))
            {
                var ftpResponse = (FtpWebResponse)response;
                if (ftpResponse.StatusCode == FtpStatusCode.ConnectionClosed)
                    throw new ArgumentException(String.Format(CultureInfo.CurrentUICulture, "Could not download {0} - FTP server closed the connection.", url));
            }
        }

        /// <summary>
        /// Gets or sets the network credentials used for authenticating the the request with the Internet resource.
        /// </summary>
        /// <value>The <see cref="ICredentials"/> containing the authentication credentials associated with the request. 
        /// The default value is a <see langword="null"/>.</value>
        /// <remarks>The <see cref="Credentials"/> property contains the authentication credentials required to access
        /// the Internet resource..
        /// </remarks>
        public ICredentials Credentials
        {
            get
            {
                CheckDisposed();
                return _credentials;
            }
            set
            {
                CheckDisposed();
                _credentials = value;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the provider is disposed.
        /// </summary>
        /// <value><b>true</b> if the object is disposed; otherwise, <b>false</b>. </value>
        public bool Disposed
        {
            get
            {
                lock (this)
                {
                    return _disposed;
                }
            }
        }

        /// <summary>
        /// Gets the underlying <see cref="System.IO.Stream"/> associated with the download.
        /// </summary>
        /// <value>A <see cref="System.IO.Stream"/> or a <see cref="System.IO.Stream.Null"/>.</value>
        public Stream DownloadStream
        {
            get
            {
                CheckDisposed();
                if (_start == _length)
                {
                    return Stream.Null;
                }

                return _stream ?? (_stream = _response.GetResponseStream());
            }
        }

        /// <summary>
        /// Gets a value indicating if download progress information is able to be determined.
        /// </summary>
        /// <value>A <see cref="System.Boolean"/> value indicating if the progress information can be determined.</value>
        public bool IsProgressKnown
        {
            get
            {
                // If the size of the remote url is -1, that means we
                // couldn't determine it, and so we don't know
                // progress information.
                CheckDisposed();
                return _length > -1;
            }
        }

        /// <summary>
        /// Gets the size of the current file.
        /// </summary>
        /// <value>The size of the current file.</value>
        /// <remarks>This property value is a <see langword="null"/> if the file system containing the file does not support this information.</remarks>
        public long Length
        {
            get
            {
                CheckDisposed();
                return _length;
            }
        }


        /// <summary>
        /// Разрешено скачивать html страницы.
        /// </summary>
        public bool DownloadHtmlPages { get; set; }

        /// <summary>
        /// Gets or sets proxy information for the request.
        /// </summary>
        public IWebProxy Proxy
        {
            get
            {
                CheckDisposed();
                return _proxy;
            }
            set
            {
                CheckDisposed();
                _proxy = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="System.Net.WebResponse"/> associated with the download.
        /// </summary>
        /// <value>The <see cref="System.Net.WebResponse"/> associated with the download.</value>
        public WebResponse Response
        {
            get
            {
                CheckDisposed();
                return _response;
            }
        }

        /// <summary>
        /// Gets the starting byte offset in the destination file.
        /// </summary>
        /// <value>A <see cref="Int64"/> value indicating the starting offset in the destination file.</value>
        public long StartPoint
        {
            get
            {
                CheckDisposed();
                return _start;
            }
        }

        /// <summary>
        /// Close the underlying <see cref="System.Net.WebResponse"/>.
        /// </summary>
        public void Close()
        {
            Dispose(true);

            // Take ourself off the finalization queue to prevent
            // finalization from executing a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by the <see cref="DownloadInfo"/>.
        /// </summary>
        public void Dispose()
        {
            Close();
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="DownloadInfo"/> class.
        /// </summary>
        /// <param name="url">The <see cref="Uri"/> of the file to be downloaded.</param>
        /// <param name="destintationFolder">The destination folder for the download.</param>
        /// <returns>A <see cref="DownloadInfo"/> that contains the information for the file to be downloaded.</returns>
        public void Initialize(Uri url, string destintationFolder)
        {
            CheckDisposed();
            var urlSize = GetFileSize(url);
            _length = urlSize;

            var req = GetRequest(url);
            _response = req.GetResponse();

            // Check to make sure the response isn't an error. If it is this method
            // will throw exceptions.
            ValidateResponse(_response, url);

            // Take the name of the file given to use from the web server.
            var fileName = Path.GetFileName(_response.ResponseUri.ToString());
            Debug.Assert(fileName != null, "fileName != null");
            var downloadTo = Path.Combine(destintationFolder, fileName);

            // If we don't know how big the file is supposed to be,
            // we can't resume, so delete what we already have if something is on disk already.
            if (!IsProgressKnown && File.Exists(downloadTo))
            {
                File.Delete(downloadTo);
            }

            if (IsProgressKnown && File.Exists(downloadTo))
            {
                // We only support resuming on http requests
                if (!(Response is HttpWebResponse))
                {
                    File.Delete(downloadTo);
                }
                else
                {
                    // Try and start where the file on disk left off
                    _start = new FileInfo(downloadTo).Length;

                    // If we have a file that's bigger than what is online, then something 
                    // strange happened. Delete it and start again.
                    if (_start > urlSize)
                    {
                        File.Delete(downloadTo);
                    }
                    else if (_start < urlSize)
                    {
                        // Try and resume by creating a new request with a new start position
                        _response.Close();
                        req = GetRequest(url);
                        ((HttpWebRequest)req).AddRange((int)_start);
                        _response = req.GetResponse();

                        if (((HttpWebResponse)Response).StatusCode != HttpStatusCode.PartialContent)
                        {
                            // They didn't support our resume request. 
                            File.Delete(downloadTo);
                            _start = 0;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Provides data for the event.
    /// </summary>
    public class FileDownloadCompletedEventArgs : EventArgs
    {
    }

    /// <summary>
    /// Download a file from a URI.
    /// </summary>
    public class FileDownloader
    {
        /// <summary>
        /// Represents the method that will handle the <see cref="FileDownloader.DownloadCompleted"/> event of a <see cref="FileDownloader"/> download request.
        /// </summary>
        /// <remarks>When you create a <see cref="System.EventHandler"/> delegate, you identify the method that 
        /// will handle the event. To associate the event with your event handler, add an instance of the delegate
        /// to the event. The event handler is called whenever the event occurs, unless you remove the delegate.
        /// For more information about event handler delegates, see Events and Delegates.</remarks>
        public event EventHandler<FileDownloadCompletedEventArgs> DownloadCompleted;

        /// <summary>
        /// Represents the method that will handle the <see cref="FileDownloader.DownloadProgressChanged"/> event of a <see cref="FileDownloader"/> download request.
        /// </summary>
        /// <remarks>When you create a <see cref="System.EventHandler"/> delegate, you identify the method that 
        /// will handle the event. To associate the event with your event handler, add an instance of the delegate
        /// to the event. The event handler is called whenever the event occurs, unless you remove the delegate.
        /// For more information about event handler delegates, see Events and Delegates.</remarks>
        public event EventHandler<FileDownloadProgressChangedEventArgs> DownloadProgressChanged;

        /// <summary>
        /// Represents the method that will handle the <see cref="FileDownloader.DownloadStatusChanged"/> event of a <see cref="FileDownloader"/> download request.
        /// </summary>
        /// <remarks>When you create a <see cref="System.EventHandler"/> delegate, you identify the method that 
        /// will handle the event. To associate the event with your event handler, add an instance of the delegate
        /// to the event. The event handler is called whenever the event occurs, unless you remove the delegate.
        /// For more information about event handler delegates, see Events and Delegates.</remarks>
        public event EventHandler<FileDownloadStatusChangedEventArgs> DownloadStatusChanged;

        private const int BlockSize = 1024;

        private bool _cancelled;

        private void OnDownloadCompleted()
        {
            if (DownloadCompleted != null)
            {
                var downloadCompleteEventArgs = new FileDownloadCompletedEventArgs();
                DownloadCompleted(this, downloadCompleteEventArgs);
            }
        }

        private void OnDownloadProgressChanged(long totalDownloaded, long totalBytesToReceive)
        {
            if (DownloadProgressChanged != null)
            {
                var eventArgs = new FileDownloadProgressChangedEventArgs(totalDownloaded, totalBytesToReceive);
                DownloadProgressChanged(this, eventArgs);
            }
        }

        private void OnDownloadStatusChanged(string message)
        {
            if (DownloadStatusChanged != null)
            {
                var eventArgs = new FileDownloadStatusChangedEventArgs(message);
                DownloadStatusChanged(this, eventArgs);
            }
        }

        /// <summary>
        /// Gets or sets the network credentials used for authenticating the the request with the Internet resource.
        /// </summary>
        /// <value>The <see cref="ICredentials"/> containing the authentication credentials associated with the request. 
        /// The default value is a <see langword="null"/>.</value>
        /// <remarks>The <see cref="Credentials"/> property contains the authentication credentials required to access
        /// the Internet resource..
        /// </remarks>
        public ICredentials Credentials { get; set; }

        /// <summary>
        /// Gets the name of the destination file.
        /// </summary>
        /// <value>A <see cref="String"/> containing the destination file name.</value>
        /// <remarks>The <see cref="DownloadingTo"/> property will be <see langword="null"/> until a download
        /// request has successfully contacted the server and has begun downloading the file.</remarks>
        public string DownloadingTo { get; private set; }

        /// <summary>
        /// Gets or sets proxy information for the request.
        /// </summary>
        public IWebProxy Proxy { get; set; }

        /// <summary>
        /// Разрешено скачивать html страницы.
        /// </summary>
        public bool DownloadHtmlPages { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileDownloader"/> class.
        /// </summary>
        public FileDownloader()
        {
            // Set the default web proxy
            Proxy = WebRequest.DefaultWebProxy;
        }

        /// <summary>
        /// Begin downloading the file at the specified url, and save it to the current folder.
        /// </summary>
        /// <param name="url">The <see cref="Uri"/> of the file to be downloaded.</param>
        public void Download(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }

            Download(new Uri(url), String.Empty);
        }

        /// <summary>
        /// Begin downloading the file at the specified url, and save it to the current folder.
        /// </summary>
        /// <param name="url">The <see cref="Uri"/> of the file to be downloaded.</param>
        /// <param name="destinationFolder">The output destination for the file.</param>
        public void Download(string url, string destinationFolder)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }

            if (destinationFolder == null)
            {
                throw new ArgumentNullException("destinationFolder");
            }

            Download(new Uri(url), destinationFolder);
        }

        /// <summary>
        /// Begin downloading the file at the specified url, and save it to the current folder.
        /// </summary>
        /// <param name="url">The <see cref="Uri"/> of the file to be downloaded.</param>
        public void Download(Uri url)
        {

            Download(url, String.Empty);
        }

        /// <summary>
        /// Begin downloading the file at the specified url, and save it to the given folder.
        /// </summary>
        /// <param name="url">The <see cref="Uri"/> of the file to be downloaded.</param>
        /// <param name="destinationFolder">The output destination for the file.</param>
        public void Download(Uri url, string destinationFolder)
        {
            if (destinationFolder == null)
                throw new ArgumentNullException("destinationFolder");

            _cancelled = false;

            using (var downloadInfo = new DownloadInfo())
            {
                downloadInfo.Proxy = Proxy;
                downloadInfo.Credentials = Credentials;
                downloadInfo.DownloadHtmlPages = DownloadHtmlPages;
                downloadInfo.Initialize(url, destinationFolder);

                // Find out the name of the file that the web server gave us.
                var destFileName = Path.GetFileName(downloadInfo.Response.ResponseUri.ToString());
                DownloadingTo = Path.GetFullPath(Path.Combine(destinationFolder, destFileName));

                OnDownloadStatusChanged(string.Format(CultureInfo.CurrentUICulture, "Downloading file to {0}.", DownloadingTo));

                //var fs = File.Create(DownloadingTo);
                //fs.Close();

                // create the download buffer
                var buffer = new byte[BlockSize];

                // update how many bytes have already been read
                var totalDownloaded = downloadInfo.StartPoint;

                using (var stream = File.Open(DownloadingTo, FileMode.Append, FileAccess.Write))
                {
                    int readCount;
                    while ((readCount = downloadInfo.DownloadStream.Read(buffer, 0, BlockSize)) > 0)
                    {
                        // break on cancel
                        if (_cancelled)
                        {
                            downloadInfo.Close();
                            OnDownloadStatusChanged("Download was cancelled.");
                            break;
                        }

                        // update total bytes read
                        totalDownloaded += readCount;

                        // save block to end of file
                        stream.Write(buffer, 0, readCount);

                        // send progress info
                        if (downloadInfo.IsProgressKnown)
                        {
                            OnDownloadProgressChanged(totalDownloaded, downloadInfo.Length);
                        }
                    }
                }
            }

            OnDownloadCompleted();
        }
    }

    /// <summary>
    /// Provides data for the event. 
    /// </summary>
    public class FileDownloadProgressChangedEventArgs : EventArgs
    {
        readonly long _bytesReceived;
        readonly long _totalBytesToReceive;
        readonly int _progressPercentage;

        internal FileDownloadProgressChangedEventArgs(long bytesReceived, long totalBytesToReceive)
        {
            _bytesReceived = bytesReceived;
            _totalBytesToReceive = totalBytesToReceive;
            _progressPercentage = (int)((((double)bytesReceived) / totalBytesToReceive) * 100);
        }

        /// <summary>
        /// Gets the number of bytes received.
        /// </summary>
        /// <value>An <see cref="Int64"/> value that indicates the number of bytes received.</value>
        /// <remarks>To determine what percentage of the transfer has occurred, use the <see cref="ProgressPercentage"/> property.</remarks>
        public long BytesReceived
        {
            get
            {
                return _bytesReceived;
            }
        }

        /// <summary>
        /// Gets the total number of bytes to be received. 
        /// </summary>
        /// <value>An <see cref="Int64"/> value that indicates the number of bytes that will be received.</value>
        /// <remarks>To determine the number of bytes already received, use the <see cref="BytesReceived"/> property.
        /// To determine what percentage of the transfer has occurred, use the <see cref="ProgressPercentage"/> property.
        /// </remarks>
        public long TotalBytesToReceive
        {
            get
            {
                return _totalBytesToReceive;
            }
        }


        /// <summary>
        /// Gets the task progress percentage. 
        /// </summary>
        /// <value>A percentage value indicating the task progress.</value>
        /// <remarks>The <see cref="ProgressPercentage"/> property determines what percentage of a task has been completed.</remarks>
        public int ProgressPercentage
        {
            get
            {
                return _progressPercentage;
            }
        }
    }

    /// <summary>
    /// Provides data for the  event.
    /// </summary>
    public class FileDownloadStatusChangedEventArgs : EventArgs
    {
        readonly string _message;

        internal FileDownloadStatusChangedEventArgs(string message)
        {
            _message = message;
        }

        /// <summary>
        /// Gets the status message.
        /// </summary>
        /// <value>A <see cref="String"/> value indicating the status message.</value>
        public string Message
        {
            get
            {
                return _message;
            }
        }
    }

}
