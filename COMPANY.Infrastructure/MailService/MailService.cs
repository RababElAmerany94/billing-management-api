namespace COMPANY.Infrastructure.MailService
{
    using Application.Services.MailService;
    using COMPANY.Application.Models.BusinessEntitiesModels.ConfigMessagerieModels;
    using COMPANY.Application.Models.GeneralModels.MailModels;
    using Company.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using System.Net.Mime;
    using System.Threading.Tasks;

    /// <summary>
    /// the implementation of IMailService
    /// </summary>
    [Inject(typeof(IMailService), ServiceLifetime.Singleton)]
    public class MailService : IMailService
    {
        private readonly ILogger<MailService> _logger;

        public MailService(ILogger<MailService> _logger)
        {
            this._logger = _logger;
        }

        /// <summary>
        /// send mail
        /// </summary>
        /// <param name="mailParams">the parameters of mail</param>
        /// <param name="configMessagerie">the configuration of mail</param>
        /// <returns></returns>
        public async Task SendEmail(MailParamsModel mailParams, ConfigMessagerieModel configMessagerie)
        {
            try
            {
                // a instance of SMTP client
                var client = new SmtpClient(configMessagerie.Server, configMessagerie.Port);

                // credentials
                client.Credentials = new NetworkCredential(configMessagerie.Username, configMessagerie.Password);

                // enable SSL if user choose
                client.EnableSsl = configMessagerie.Ssl;

                // build a mail message
                MailMessage mailMessage = new MailMessage();

                // is html
                mailMessage.IsBodyHtml = true;

                // mail from
                mailMessage.From = new MailAddress(configMessagerie.Username);

                // add receivers
                foreach (var mail in mailParams.MessageTo)
                {
                    mailMessage.To.Add(mail);
                }

                // subject
                mailMessage.Subject = mailParams.Subject;

                // body
                mailMessage.Body = mailParams.Content;

                // add attachments file
                foreach (AttachmentModel attachmentModel in mailParams.Attachments)
                {
                    MemoryStream streamBitmap = new MemoryStream(attachmentModel.File);

                    var mail = new MailMessage();
                    var imageToInline = new LinkedResource(streamBitmap, MediaTypeNames.Application.Pdf);
                    imageToInline.ContentId = attachmentModel.Name;

                    Attachment attachment = new Attachment(imageToInline.ContentStream, imageToInline.ContentType);
                    attachment.Name = attachmentModel.Name;
                    attachment.TransferEncoding = TransferEncoding.Base64;
                    mailMessage.Attachments.Add(attachment);
                }

                // add CC
                foreach (var mail in mailParams.CC)
                    mailMessage.CC.Add(mail);

                // add BCC
                foreach (var mail in mailParams.BCC)
                    mailMessage.Bcc.Add(mail);

                // send email
                await client.SendMailAsync(mailMessage);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error send email because of ([exception])", ex.Message);
            }
        }
    }
}
