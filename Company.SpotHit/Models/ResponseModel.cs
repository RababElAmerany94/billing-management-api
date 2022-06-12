namespace Company.SpotHit.Models
{
    using Company.SpotHit.Enums;
    using Company.SpotHit.Utilities;
    using System.Collections.Generic;
    using System.Linq;

    public class ResponseModel
    {
        public ResultType Resultat { get; set; }
        public string Id { get; set; }
        public string Erreurs { get; set; }

        public bool IsSuccess
            => Resultat == ResultType.Success;

        public IEnumerable<string> GetErrors()
        {
            if (string.IsNullOrEmpty(Erreurs) || IsSuccess)
                return default;

            var result = Erreurs
                .Split(',')
                .Select(e => e.ToEnum<SpotHitErrors>())
                .Select(e => e.DescriptionAttribute());

            return result;
        }
    }
}
