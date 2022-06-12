namespace COMPANY.Application.Services.MailService
{
    using COMPANY.Application.Models.BusinessEntitiesModels.ConfigMessagerieModels;
    using COMPANY.Application.Models.GeneralModels.MailModels;
    using System.Threading.Tasks;

    /// <summary>
    /// the base interface for all Mail services
    /// </summary>
    public interface IMailService
    {
        /// <summary>
        /// send mail
        /// </summary>
        /// <param name="parameters">the parameters of mail</param>
        /// <param name="configs">the configuration of mail</param>
        /// <returns></returns>
        Task SendEmail(MailParamsModel parameters, ConfigMessagerieModel configs);
    }
}
