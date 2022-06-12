namespace COMPANY.Application.Services.DataService.CalculationService
{
    using System.Collections.Generic;
    using COMPANY.Application.Models.GeneralModels.CalculationModels;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums;

    /// <summary>
    /// a interface describe functionality of <see cref="CalculationService"/>
    /// </summary>
    public interface ICalculationService
    {
        /// <summary>
        /// calculation price HT
        /// </summary>
        /// <param name="priceTTC">the price in TTC</param>
        /// <param name="tva">the value of TVA</param>
        /// <returns>the price hors tax</returns>
        decimal PriceHT(decimal priceTTC, double tva);

        /// <summary>
        /// calculation price TTC
        /// </summary>
        /// <param name="priceHT">priceTTC the price in HT</param>
        /// <param name="tva">the value of TVA</param>
        /// <returns></returns>
        decimal PriceTTC(decimal priceHT, double tva);

        /// <summary>
        /// total hors tax articles
        /// </summary>
        /// <param name="article">the article</param>
        decimal TotalHTArticle(Article article);

        /// <summary>
        /// total ttc article
        /// </summary>
        /// <param name="article">the article</param>
        /// <returns></returns>
        decimal TotalTTCArticle(Article article);

        /// <summary>
        /// total hors tax articles
        /// </summary>
        /// <param name="articles">the list of articles</param>
        /// <returns>return total hors tax</returns>
        decimal TotalHt(List<Article> articles);

        /// <summary>
        /// total hors tax with discount
        /// </summary>
        /// <param name="globalTotalHT">the global total HT</param>
        /// <param name="remiseGlobal">the value of discount</param>
        /// <param name="typeRemiseGlobal">the type of discount</param>
        /// <returns>return total with discount</returns>
        decimal TotalHtRemise(decimal globalTotalHT, decimal remiseGlobal, RemiseType typeRemiseGlobal);

        /// <summary>
        /// calculation ventilation remise
        /// </summary>
        /// <param name="articles">the list of articles</param>
        /// <param name="globalTotalHT">the global total HT</param>
        /// <param name="discountGlobal">the value of discount global</param>
        /// <param name="typeRemiseGlobal">the type of discount global</param>
        /// <returns></returns>
        List<CalculationTvaModel> CalculationVentilationRemise(List<Article> articles, decimal globalTotalHT, decimal discountGlobal, RemiseType typeRemiseGlobal);

        /// <summary>
        /// Calculation of total TTC
        /// </summary>
        /// <param name="globalTotalHT">the global total HT</param>
        /// <param name="globalTotalHTRemise">the total global HT with discount</param>
        /// <param name="calculationTva">the list of calculation ventilation remise</param>
        /// <param name="remiseGlobal">the global value of discount</param>
        /// <returns>return total TTC</returns>
        decimal TotalTTC(decimal globalTotalHT, decimal globalTotalHTRemise, List<CalculationTvaModel> calculationTva, decimal remiseGlobal);

        /// <summary>
        /// the calculation general
        /// </summary>
        /// <param name="articles">the list of produit</param>
        /// <param name="remiseGlobal">the value of discount global</param>
        /// <param name="typeRemiseGlobal">the type of discount global</param>
        /// <returns>general calculation</returns>
        CalculationResultModel CalculationGeneral(List<Article> articles, decimal remiseGlobal, RemiseType typeRemiseGlobal);

        /// <summary>
        /// the total HT of articles accounting
        /// </summary>
        /// <param name="prixTotalHTArticles">the sum HT of articles</param>
        /// <param name="globalTotalWithoutRemise">the total global HT without discount</param>
        /// <param name="globalRemise">the global discount</param>
        /// <param name="discountType">the type of discount</param>
        /// <returns></returns>
        decimal TotalHTArticlesComptabilite(decimal prixTotalHTArticles,
                                            decimal globalTotalWithoutRemise,
                                            decimal globalRemise,
                                            RemiseType remiseType);
    }
}
