using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Dekart.LazyNet.SQLBackup2Remote.Helpers
{
    public static class SendMail
    {
        static int _errorCounter;

        public static void Send(string smtpServer, int smtpPort, bool smtpAuth, bool smtpUseSsl, string smtpUser, string smtpPassword, string[] to, string subject, string body, string fromAddress, string fromName,
            bool sendSyncronously = false,
            List<Attachment> attachments = null,
            MailPriority priority = MailPriority.Normal)
        {
            if ((to == null) || (to.Length == 0)) return;

            subject = subject.Replace(Environment.NewLine, " ");
            subject = Regex.Replace(subject, @"[\x00-\x1f]", " ");
            body = body.Replace("[comment]", "<blockquote style='border-left:2px solid #aaa;margin-left:5px;padding-left:5px;'>");
            body = body.Replace("[/comment]", "</blockquote>");
            var mail = new AsyncSendMail(smtpServer, smtpAuth, smtpUser, smtpPassword, smtpPort, smtpUseSsl, to, fromAddress, fromName, subject, body, null, false, attachments, true, priority);
            if (!sendSyncronously)
            {
                mail.SendAsynchronously(SendErrorHandler);
            }
            else
            {
                mail.SendSynchronously();
            }
        }

        static void SendErrorHandler(Exception ex)
        {
            _errorCounter++;
            if (_errorCounter <= 10)
                return;
            const string report = "Error while sending emails. Please make sure you have specified the correct SMTP server settings.'";
            WinHelper.LogException(report, ex.InnerException);
            _errorCounter = 0;
        }
    }

    public class AsyncSendMail
    {
        static readonly object LockObject = new object();
        static readonly List<UnsentMsg> FailedMessagesList = new List<UnsentMsg>();
        // ReSharper disable UnusedMember.Local
        static readonly Timer ResendTimer = new Timer(ResendFailed, null, 10000, 1800000);
        // ReSharper restore UnusedMember.Local

        readonly List<Attachment> _attachments;
        readonly string _body;
        readonly string _fromEmail;
        readonly string _fromName;
        readonly bool _htmlBody;
        readonly string[] _recipients;
        readonly string _replyto;
        readonly bool _separateEmailToEachRecipient;
        readonly bool _smtpAuthentication;
        readonly string _smtpLogin;
        readonly string _smtpPassword;
        readonly int _smtpPort;
        readonly string _smtpServerAddress;
        readonly bool _smtpUseSsl;
        readonly string _subject;
        readonly MailPriority _priority;

        public AsyncSendMail(string smtpServerAddress, bool smtpAuthentication, string smtpLogin, string smtpPassword, int smtpPort, bool smtpUseSsl, string[] recipients, string from, string fromName, string subject, string body, string replyto, bool htmlBody,
            List<Attachment> attachments = null,
            bool separateEmailToEachRecipient = true,
            MailPriority priority = MailPriority.Normal)
        {
            _smtpServerAddress = smtpServerAddress;
            _smtpAuthentication = smtpAuthentication;
            _smtpLogin = smtpLogin;
            _smtpPassword = smtpPassword;
            _smtpUseSsl = smtpUseSsl;
            _recipients = recipients;
            _subject = subject;
            _fromEmail = from;
            _fromName = fromName;
            _body = body;
            _smtpPort = smtpPort;
            _replyto = replyto;
            _htmlBody = htmlBody;
            _attachments = attachments;
            _separateEmailToEachRecipient = separateEmailToEachRecipient;
            _priority = priority;
        }

        MailMessage ConstructMailMessage(string[] recipients)
        {
            if (!MailAddressTryParse(_fromEmail, _fromName))
            {
                return null;
            }
            if (recipients.Length == 0)
            {
                return null;
            }
            var message = new MailMessage();
            foreach (var str in recipients)
            {
                if ((str.Trim().Length != 0) && MailAddressTryParse(str))
                {
                    message.To.Add(str);
                }
            }
            if (message.To.Count == 0)
            {
                return null;
            }
            message.From = !string.IsNullOrEmpty(_fromName)
                               ? new MailAddress(_fromEmail, _fromName)
                               : new MailAddress(_fromEmail);
            message.Subject = _subject;
            message.SubjectEncoding = Encoding.UTF8;
            message.BodyEncoding = Encoding.UTF8;
            message.Headers.Add("X-Mailer", ConstStrings.ApplicationCaption);
            message.Priority = _priority;

            var item = AlternateView.CreateAlternateViewFromString(TextHelper.StripHTML(_body).Trim(), null, "text/plain");
            message.AlternateViews.Add(item);
            if (_htmlBody)
            {
                var view2 = AlternateView.CreateAlternateViewFromString(_body, null, "text/html");
                message.AlternateViews.Add(view2);
            }
            if (_attachments != null)
            {
                foreach (var attachment in _attachments)
                {
                    message.Attachments.Add(attachment);
                }
            }
            if (!string.IsNullOrWhiteSpace(_replyto) && MailAddressTryParse(_replyto))
            {
                message.ReplyToList.Add(new MailAddress(_replyto));
            }
            return message;
        }

        static bool MailAddressTryParse(string address, string displayName = null)
        {
            try
            {
                var mailAddress = displayName == null ? new MailAddress(address) : new MailAddress(address, displayName);
                return mailAddress.Address != string.Empty;
            }
            catch
            {
                return false;
            }
        }

        static void ResendFailed(object state)
        {
            lock (LockObject)
            {
                for (var i = FailedMessagesList.Count - 1; i >= 0; i--)
                {
                    var msg = FailedMessagesList[i];
                    using (var client = new SmtpClient())
                    {
                        if (msg.SmtpAuthentication)
                        {
                            client.Credentials = new NetworkCredential(msg.SmtpLogin, msg.SmtpPassword);
                        }
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.Host = msg.SmtpServerAddress;
                        client.Port = msg.SmtpPort;
                        client.EnableSsl = msg.SmtpUseSsl;
                        try
                        {
                            client.Send(msg.Message);
                        }
                        catch (Exception exception)
                        {
                            msg.NumberOfFailures++;
                            if (msg.NumberOfFailures > 5)
                            {
                                var ex = new Exception($"Error sending email from server (tried 5 times!) {msg.SmtpServerAddress}, port {msg.SmtpPort}, login {msg.SmtpLogin}", exception);
                                WinHelper.LogException("", ex);
                                FailedMessagesList.RemoveAt(i);
                            }
                        }
                    }
                }
            }
        }

        public void SendAsynchronously(ErrorCallback onError = null)
        {
            new Thread(() => SendThreadProc(onError)) { Priority = ThreadPriority.Normal }.Start();
        }

        void SendEmailsInternal(string[] recipients, ErrorCallback onError = null, bool calledAsynchronously = false)
        {
            var message = ConstructMailMessage(recipients);
            if (message == null) return;

            using (var client = new SmtpClient())
            {
                if (_smtpAuthentication)
                {
                    client.Credentials = new NetworkCredential(_smtpLogin, _smtpPassword);
                }
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Host = _smtpServerAddress;
                client.Port = _smtpPort;
                client.EnableSsl = _smtpUseSsl;
                ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) => true;
                try
                {
                    client.Send(message);
                }
                catch (Exception exception)
                {
                    if (!calledAsynchronously)
                    {
                        var ex = new Exception($"Error sending email from server {_smtpServerAddress}, port {_smtpPort}, login {_smtpLogin}", exception);
                        WinHelper.LogException("", ex);
                        throw;
                    }
                    var item = new UnsentMsg(message, _smtpServerAddress, _smtpLogin, _smtpPassword, _smtpPort, _smtpAuthentication, _smtpUseSsl);
                    lock (LockObject)
                    {
                        FailedMessagesList.Add(item);
                    }
                    onError?.Invoke(exception);
                }
                client.Dispose();
            }
        }

        public void SendSynchronously()
        {
            if (!_separateEmailToEachRecipient)
            {
                SendEmailsInternal(_recipients);
            }
            else
            {
                foreach (var str in _recipients)
                {
                    SendEmailsInternal(new[] { str });
                }
            }
        }

        void SendThreadProc(ErrorCallback onError = null)
        {
            if (!_separateEmailToEachRecipient)
            {
                SendEmailsInternal(_recipients, onError, true);
            }
            else
            {
                foreach (string str in _recipients)
                {
                    SendEmailsInternal(new[] { str }, onError, true);
                }
            }
        }

        public delegate void ErrorCallback(Exception ex);

        class UnsentMsg
        {
            public UnsentMsg(MailMessage message, string smtpServerAddress, string smtpLogin, string smtpPassword, int smtpPort, bool smtpAuthentication, bool smtpUseSsl)
            {
                SmtpServerAddress = smtpServerAddress;
                SmtpAuthentication = smtpAuthentication;
                SmtpLogin = smtpLogin;
                SmtpPassword = smtpPassword;
                SmtpUseSsl = smtpUseSsl;
                SmtpPort = smtpPort;
                Message = message;
            }

            public MailMessage Message { get; }

            public int NumberOfFailures { get; set; }

            public bool SmtpAuthentication { get; }

            public string SmtpLogin { get; }

            public string SmtpPassword { get; }

            public int SmtpPort { get; }

            public string SmtpServerAddress { get; }

            public bool SmtpUseSsl { get; }
        }
    }

}
