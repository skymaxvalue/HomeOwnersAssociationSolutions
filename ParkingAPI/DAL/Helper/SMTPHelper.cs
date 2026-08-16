using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helper
{
    public class Attachment
    {
        public int EmailId { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentType { get; set; }
        public byte[] Content { get; set; }

    }
    public static class SMTPHelper
    {
        static bool enableSsl;
        static string smtpHost;
        static string smtpPort;
        static string fromMailId;
        static string smtpUserId;
        static string smtpPassword;
        static SmtpClient smtpClient;
        static SMTPHelper()
        {

            enableSsl = true;
            bool.TryParse(ConfigurationHelper.GetConfig("Parkingconfig:Email:SmtpEnableSsl"), out enableSsl);
            smtpHost = ConfigurationHelper.GetConfig("Parkingconfig:Email:SmtpHost");
            smtpPort = ConfigurationHelper.GetConfig("Parkingconfig:Email:SmtpPort");

            fromMailId = ConfigurationHelper.GetConfig("Parkingconfig:Email:FromMailId");
            smtpUserId = ConfigurationHelper.GetConfig("Parkingconfig:Email:SmtpUserId");
            smtpPassword = ConfigurationHelper.GetConfig("Parkingconfig:Email:SmtpPassword");

            smtpClient = new SmtpClient();
            smtpClient.EnableSsl = enableSsl;
            smtpClient.Host = smtpHost;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            if (!string.IsNullOrEmpty(smtpPort))
                smtpClient.Port = int.Parse(smtpPort);

            if (!string.IsNullOrEmpty(smtpUserId))
                smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential(smtpUserId, smtpPassword);

        }
        public static async Task<bool> SendEmail(string toAddrCsv, string ccAddrCsv, string bccAddrCsv, string replyAddrCsv, string subject, string body, int emaillogid, List<Attachment> files = null, bool isBodyHtml = true)
        {
            var result = false;
            MailMessage mailMessage = null;

            try
            {
                string mediaType = isBodyHtml ? MediaTypeNames.Text.Html : MediaTypeNames.Text.Plain;

                var alterView = AlternateView.CreateAlternateViewFromString(body, System.Text.Encoding.Default, mediaType);

                mailMessage = new MailMessage();
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.AlternateViews.Add(alterView);
                mailMessage.IsBodyHtml = isBodyHtml;
                
                string FromEmailDisplayName = Convert.ToString(ConfigurationHelper.GetConfig("FromEmailDisplayName"));
                mailMessage.From = new MailAddress(fromMailId, FromEmailDisplayName);

                if (toAddrCsv != null)
                {
                    foreach (var item in toAddrCsv.Split(','))
                        if (!string.IsNullOrEmpty(item))
                            mailMessage.To.Add(item);
                }

                if (ccAddrCsv != null)
                {
                    foreach (var item in ccAddrCsv.Split(','))
                        if (!string.IsNullOrEmpty(item))
                            mailMessage.CC.Add(item);

                }

                if (bccAddrCsv != null)
                {
                    foreach (var item in bccAddrCsv.Split(','))
                        if (!string.IsNullOrEmpty(item))
                            mailMessage.Bcc.Add(item);
                }

                if (replyAddrCsv != null)
                {
                    foreach (var item in replyAddrCsv.Split(','))
                        if (!string.IsNullOrEmpty(item))
                            mailMessage.ReplyToList.Add(item);
                }
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file.Content.Length > 0)
                        {
                            var fileDetails = GetFileContentType(file.AttachmentType);
                            var fileBinary = new MemoryStream(file.Content);
                            fileBinary.Seek(0, SeekOrigin.Begin);
                            var mailAttachment = new System.Net.Mail.Attachment(fileBinary, file.AttachmentName + "." + Convert.ToString(fileDetails[0]).ToLower(), Convert.ToString(fileDetails[1]));
                            mailAttachment.ContentDisposition.DispositionType = DispositionTypeNames.Attachment;
                            mailMessage.Attachments.Add(mailAttachment);
                        }
                    }
                }

                smtpClient.Send(mailMessage);
                result = true;
                //.EmailLog(0, "", "1", "Sent", emaillogid, "");

            }
            catch (SmtpException sx)
            {
                //.EmailLog(0, "", "SMTP-Failed", .InnerException(sx), emaillogid, "");
                //Console.WriteLine("Error SMTP {0} ", sx);
            }
            catch (Exception ex)
            {
                //EmailLog(0, "", "Code Block-Failed", InnerException(ex), emaillogid, "");
                //Console.WriteLine("Error  {0} ", ex);
            }
            finally
            {
                if (mailMessage != null) mailMessage.Dispose();
            }

            return result;

        }
        static string[] GetFileContentType(string fileRelativePath)
        {
            try
            {
                string[] fileDetails = new string[2];

                fileDetails[0] = fileRelativePath.Substring(fileRelativePath.LastIndexOf('.') + 1, (fileRelativePath.Length - (fileRelativePath.LastIndexOf('.') + 1)));
                switch (fileDetails[0].ToLower())
                {
                    case "pdf":
                        fileDetails[1] = "application/pdf";
                        break;
                    case "avi":
                        fileDetails[1] = "video/avi";
                        break;
                    case "flv":
                        fileDetails[1] = "video/flv";
                        break;
                    case "mkv":
                        fileDetails[1] = "video/mkv";
                        break;
                    case "mp4":
                        fileDetails[1] = "video/mp4";
                        break;
                    case "jpeg":
                        fileDetails[1] = "image/jpeg";
                        break;
                    case "jpg":
                        fileDetails[1] = "image/jpg";
                        break;
                    case "png":
                        fileDetails[1] = "image/png";
                        break;
                    case "gif":
                        fileDetails[1] = "image/gif";
                        break;
                    case "doc":
                        fileDetails[1] = "application/msword";
                        break;
                    case "docx":
                        fileDetails[1] = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                        break;
                    case "xls":
                        fileDetails[1] = "application/vnd.ms-excel";
                        break;
                    case "xlsx":
                        fileDetails[1] = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        break;
                }
                return fileDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
