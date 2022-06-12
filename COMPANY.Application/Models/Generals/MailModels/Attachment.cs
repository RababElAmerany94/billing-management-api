namespace COMPANY.Application.Models.GeneralModels.MailModels
{
    /// <summary>
    /// a class describe attachment model
    /// </summary>
    public class AttachmentModel
    {
        /// <summary>
        /// the file in base64
        /// </summary>
        public byte[] File { get; set; }

        /// <summary>
        /// the name of file
        /// </summary>
        public string Name { get; set; }
    }
}
