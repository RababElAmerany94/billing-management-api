namespace COMPANY.Application.Models.BusinessEntitiesModels.NumerotationModels
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities;

    /// <summary>
    /// the <see cref="Numerotation"/> Update Model
    /// </summary>
    public class NumerotationUpdateModel : NumerotationCreateModel, IEntityUpdateModel<Numerotation>
    {
        /// <summary>
        /// update the numerotation from the current model
        /// </summary>
        /// <param name="numerotation">the numerotation to be updated</param>
        public void Update(Numerotation numerotation)
        {
            numerotation.Root = Root;
            numerotation.DateFormat = DateFormat;
            numerotation.Counter = Counter;
            numerotation.CounterLength = CounterLength;
            numerotation.Type = Type;
        }

    }
}
