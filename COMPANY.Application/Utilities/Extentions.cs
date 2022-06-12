namespace COMPANY.Application
{
    using COMPANY.Application.Models.GeneralModels.BodiesModels.MailModels;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Attribute;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Entities.OwnedEntities;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Extentions
    {
        /// <summary>
        /// we use this method to register all Services
        /// </summary>
        /// <param name="services">the DI Service collection</param>
        public static void RegiseterApplicationDataServices(this IServiceCollection services)
        {

        }

        /// <summary>
        /// rounding number decimal
        /// </summary>
        /// <param name="number">the number</param>
        /// <returns>number formated</returns>
        public static decimal RoundingDecimal(this decimal number)
        {
            try
            {
                var rouding = string.Format("{0:0.00}", number);
                return decimal.Parse(rouding);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// recored the history when add new entity
        /// </summary>
        /// <param name="userId">the id of the user who made the change</param>
        /// <returns>the string value of the history object</returns>
        public static ICollection<ChangesHistory> RecoredAddNewItemHistory(string userId)
        {
            return new List<ChangesHistory>
            {
                // add the a new history record
                new ChangesHistory
                {
                    UserId = userId,
                    Action = ChangesHistoryType.Added,
                    ChangeDate = DateTime.Now,
                    Fields = null,
                }
            };
        }

        /// <summary>
        /// record the update history and add it to the history object
        /// </summary>
        /// <param name="historique">the history object of the entity</param>
        /// <param name="userId">the id of the user who made the change</param>
        /// <param name="changesResult">the list of change result</param>
        /// <returns>the new version history object</returns>
        public static ICollection<ChangesHistory> RecoredUpdateOperation(ICollection<ChangesHistory> historique, string userId, List<ChangedFields> changesResult)
        {
            // get the history list
            var changesHistoriesList = historique.ToList();

            // add the a new ChangesHistory record
            changesHistoriesList.Insert(0, new ChangesHistory
            {
                UserId = userId,
                Action = ChangesHistoryType.Updated,
                ChangeDate = DateTime.Now,
                Fields = changesResult
            });

            // save the history with the new values
            return changesHistoriesList;
        }

        /// <summary>
        /// a method to detect the fields that has been changed
        /// </summary>
        /// <typeparam name="T">the type of the entities to compare</typeparam>
        /// <param name="origin">the original entity</param>
        /// <param name="current">the new entity</param>
        /// <returns></returns>
        public static List<ChangedFields> GetChangedFields<T>(T origin, T current)
        {
            var changesList = new List<ChangedFields>();

            foreach (var property in typeof(T).GetProperties())
            {
                var oldvalue = property.GetValue(origin);
                var newvalue = property.GetValue(current);

                if (Equals(oldvalue, newvalue) || ShouldIgnore(property))
                    continue;

                changesList.Add(new ChangedFields()
                {
                    FieldName = GetPropertyName(property),
                    Before = oldvalue is null ? "" : oldvalue.ToString(),
                    After = newvalue is null ? "" : newvalue.ToString(),
                    IsComplexType = IsComplexType(property)
                });
            }

            return changesList;
        }

        /// <summary>
        /// update email field of facture 
        /// </summary>
        /// <param name="documentComptable">the facture of</param>
        /// <param name="mailModel">the mail model</param>
        /// <param name="userId">the id of curent user</param>
        /// <returns>a email json</returns>
        public static ICollection<MailHistoryModel> UpdateFactureEmailField(this DocumentComptable documentComptable, MailModel mailModel, string userId)
        {
            // the list of emails
            var emails = documentComptable.Emails;

            // check is emails is null
            if (emails is null)
                emails = new List<MailHistoryModel>();

            // build a mail history model
            var mailHistoryModel = new MailHistoryModel()
            {
                Body = mailModel.Body,
                DateCreation = DateTime.Now,
                Subject = mailModel.Subject,
                UserId = userId,
                EmailTo = mailModel.EmailTo
            };

            // push a mail history model
            emails.Add(mailHistoryModel);

            // serialize object
            return emails;
        }

        /// <summary>
        /// build address format ansroute
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static string BuildAddressPhrase(this Address address)
        {
            if (address is null)
                return string.Empty;

            var words = new List<string>() {
                address.Adresse,
                address.ComplementAdresse,
                $"{address.Ville} {address.CodePostal}",
                $"{address.Departement}  {address.Pays}"
            };

            return words.Where(e => e.IsValid()).Aggregate((i, j) => $"{i}{Environment.NewLine}{j}");
        }

        /// <summary>
        /// build address phrase
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static string BuildAddressFormatAnsroute(this Address address)
        {
            if (address is null)
                return string.Empty;

            var words = new List<string>() {
                address.Adresse,
                address.ComplementAdresse,
                address.CodePostal,
                address.Ville,
                address.Departement,
                address.Pays
            };

            return string.Join(" ", words.Where(e => e.IsValid()));
        }

        /// <summary>
        /// retrieve description of property
        /// </summary>
        /// <param name="property">the property to be checked</param>
        /// <returns>true or false</returns>
        public static string DescriptionAttribute(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<DescriptionAttribute>()
                .SingleOrDefault()?.Message ?? "";
        }

        #region private methods

        /// <summary>
        /// check if the given property should be ignored
        /// </summary>
        /// <param name="property">the property to be checked</param>
        /// <returns>true or false</returns>
        private static bool ShouldIgnore(System.Reflection.PropertyInfo property)
        {
            var complexTypeAttribute = property
               .GetCustomAttributes(typeof(IgnorePropertyAttribute), true)
               .FirstOrDefault();

            if (complexTypeAttribute is null)
                return false;

            return true;
        }

        /// <summary>
        /// get the proper name of the property
        /// </summary>
        /// <param name="property">the property info object</param>
        /// <returns>a string value that represent the name of the property</returns>
        private static string GetPropertyName(System.Reflection.PropertyInfo property)
        {
            var propertyName = property.Name;

            var propertyNameAttribute = property
                .GetCustomAttributes(typeof(PropertyNameAttribute), true)
                .FirstOrDefault() as PropertyNameAttribute;

            if (!(propertyNameAttribute is null))
                propertyName = propertyNameAttribute.PropertyName;

            return propertyName;
        }

        /// <summary>
        /// check if the property is a complex type that is built using JSON, it checks the existence 
        /// of the ComplexType Attribute on the property
        /// </summary>
        /// <param name="property">the property to check</param>
        /// <returns>true if complex type</returns>
        private static bool IsComplexType(System.Reflection.PropertyInfo property)
        {
            var complexTypeAttribute = property
               .GetCustomAttributes(typeof(ComplexTypeAttribute), true)
               .FirstOrDefault();

            if (!(complexTypeAttribute is null))
                return true;

            return false;
        }

        #endregion

    }
}
