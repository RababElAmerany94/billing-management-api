namespace COMPANY.Application.Services.DataService.CalculationService
{
    using COMPANY.Application.Models.GeneralModels.CalculationModels;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums;
    using Inova.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// a class describe implements of <see cref="ICalculationService"/>
    /// </summary>
    [Inject(typeof(ICalculationService), ServiceLifetime.Singleton)]
    public class CalculationService : ICalculationService
    {
        /// <summary>
        /// calculation price HT
        /// </summary>
        /// <param name="priceTTC">the price in TTC</param>
        /// <param name="tva">the value of TVA</param>
        /// <returns>the price hors tax</returns>
        public decimal PriceHT(decimal priceTTC, double tva)
        {
            return priceTTC / (1 + ((decimal)tva / 100));
        }

        /// <summary>
        /// calculation price TTC
        /// </summary>
        /// <param name="priceHT">priceTTC the price in HT</param>
        /// <param name="tva">the value of TVA</param>
        /// <returns></returns>
        public decimal PriceTTC(decimal priceHT, double tva)
        {
            return priceHT * (1 + (decimal)tva / 100);
        }

        /// <summary>
        /// total hors tax articles
        /// </summary>
        /// <param name="article">the article</param>
        public decimal TotalHTArticle(Article article)
        {
            if (article.Remise > 0)
            {
                switch (article.RemiseType)
                {
                    case RemiseType.Percent:
                        return ((article.PrixHT - (article.PrixHT * article.Remise) / 100) * article.Qte);
                    case RemiseType.Currency:
                        return ((article.PrixHT - article.Remise) * article.Qte);
                    default:
                        return ((article.PrixHT - article.Remise) * article.Qte);
                }
            }
            else
            {
                return (article.PrixHT * article.Qte);
            }
        }

        /// <summary>
        /// total ttc article
        /// </summary>
        /// <param name="article">the article</param>
        /// <returns></returns>
        public decimal TotalTTCArticle(Article article)
        {
            var totalHT = TotalHTArticle(article);
            return totalHT * (article.TVA / 100) + totalHT;
        }

        /// <summary>
        /// total hors tax articles
        /// </summary>
        /// <param name="articles">the list of articles</param>
        /// <returns>return total hors tax</returns>
        public decimal TotalHt(List<Article> articles)
        {
            return articles.Sum(x => x.TotalHT);
        }

        /// <summary>
        /// total hors tax with discount
        /// </summary>
        /// <param name="globalTotalHT">the global total HT</param>
        /// <param name="remiseGlobal">the value of discount</param>
        /// <param name="typeRemiseGlobal">the type of discount</param>
        /// <returns>return total with discount</returns>
        public decimal TotalHtRemise(decimal globalTotalHT, decimal remiseGlobal, RemiseType typeRemiseGlobal)
        {
            if (typeRemiseGlobal == RemiseType.Currency)
                return (globalTotalHT - remiseGlobal);
            else
                return (globalTotalHT - (globalTotalHT * (remiseGlobal / 100)));
        }

        /// <summary>
        /// calculation ventilation remise
        /// </summary>
        /// <param name="articles">the list of articles</param>
        /// <param name="globalTotalHT">the global total HT</param>
        /// <param name="discountGlobal">the value of discount global</param>
        /// <param name="typeRemiseGlobal">the type of discount global</param>
        /// <returns></returns>
        public List<CalculationTvaModel> CalculationVentilationRemise(List<Article> articles, decimal globalTotalHT, decimal discountGlobal, RemiseType typeRemiseGlobal)
        {
            // init variable
            var calculationTvas = new List<CalculationTvaModel>();
            var groupTva = articles.GroupBy(e => e.TVA).Select(e => e.FirstOrDefault().TVA).ToList();

            // foreach groups tva
            foreach (var tva in groupTva)
            {
                // Init calculation tva
                CalculationTvaModel calculationTva = new CalculationTvaModel()
                {
                    TotalHT = 0,
                    TotalTTC = 0,
                    TotalTVA = 0,
                    TVA = tva,
                };

                // select produit that they have this tva
                var articlesHasTva = articles.Where(x => x.TVA == tva);

                // sum of produits HT
                var sumTotalHtProduits = articlesHasTva.Sum(x => x.TotalHT);

                // if discount in currency
                if (typeRemiseGlobal == RemiseType.Currency)
                {
                    var percent = (sumTotalHtProduits / globalTotalHT);
                    calculationTva.TotalHT = sumTotalHtProduits - percent * discountGlobal;
                    calculationTva.TotalTVA = calculationTva.TotalHT * (tva / 100);
                    calculationTva.TotalTTC = calculationTva.TotalTVA + calculationTva.TotalHT;
                }
                else
                {
                    calculationTva.TotalHT = sumTotalHtProduits - ((sumTotalHtProduits * discountGlobal) / 100);
                    calculationTva.TotalTVA = calculationTva.TotalHT * (tva / 100);
                    calculationTva.TotalTTC = calculationTva.TotalTVA + calculationTva.TotalHT;
                }

                // push in array
                calculationTvas.Add(calculationTva);
            };

            return calculationTvas;
        }

        /// <summary>
        /// Calculation of total TTC
        /// </summary>
        /// <param name="globalTotalHT">the global total HT</param>
        /// <param name="globalTotalHTRemise">the total global HT with discount</param>
        /// <param name="calculationTva">the list of calculation ventilation remise</param>
        /// <param name="remiseGlobal">the global value of discount</param>
        /// <returns>return total TTC</returns>
        public decimal TotalTTC(decimal globalTotalHT, decimal globalTotalHTRemise, List<CalculationTvaModel> calculationTva, decimal remiseGlobal)
        {
            var sumTVA = calculationTva.Sum(e => e.TotalTVA);

            if (remiseGlobal > 0)
                return (globalTotalHTRemise + sumTVA);
            else
                return (globalTotalHT + sumTVA);
        }

        /// <summary>
        /// the calculation general
        /// </summary>
        /// <param name="articles">the list of produits</param>
        /// <param name="remiseGlobal">the value of discount global</param>
        /// <param name="typeRemiseGlobal">the type of discount global</param>
        /// <returns>general calculation</returns>
        public CalculationResultModel CalculationGeneral(List<Article> articles, decimal remiseGlobal, RemiseType typeRemiseGlobal)
        {
            foreach (var article in articles)
            {
                article.TotalHT = TotalHTArticle(article);
                article.TotalTTC = TotalTTCArticle(article);
            };

            var totalHT = TotalHt(articles);
            var calculationTva = CalculationVentilationRemise(articles, totalHT, remiseGlobal, typeRemiseGlobal);
            var totalHtRemise = TotalHtRemise(totalHT, remiseGlobal, typeRemiseGlobal);
            var totalTTC = TotalTTC(totalHT, totalHtRemise, calculationTva, remiseGlobal);

            var result = new CalculationResultModel()
            {
                Articles = articles,
                TotalHT = totalHT,
                CalculationTvas = calculationTva,
                TotalHTRemise = totalHtRemise,
                TotalTTC = totalTTC
            };

            return result;
        }

        /// <summary>
        /// the total HT of articles accounting
        /// </summary>
        /// <param name="prixTotalHTArticles">the sum HT of articles</param>
        /// <param name="globalTotalWithoutRemise">the total global HT without discount</param>
        /// <param name="globalRemise">the global discount</param>
        /// <param name="discountType">the type of discount</param>
        /// <returns></returns>
        public decimal TotalHTArticlesComptabilite(decimal prixTotalHTArticles, decimal globalTotalWithoutRemise, decimal globalRemise, RemiseType remiseType)
        {
            if (globalRemise > 0)
            {
                if (remiseType == RemiseType.Currency)
                    return prixTotalHTArticles - ((prixTotalHTArticles / globalTotalWithoutRemise) * globalRemise);
                else
                    return prixTotalHTArticles - ((globalRemise * prixTotalHTArticles) / 100);
            }
            else
                return prixTotalHTArticles;
        }
    }
}
