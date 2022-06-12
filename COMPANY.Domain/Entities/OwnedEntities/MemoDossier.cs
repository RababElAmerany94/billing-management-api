namespace COMPANY.Domain.Entities.OwnedEntities
{
    using COMPANY.Domain.Entities.Parameters;

    public class MemoDossier : Memo
    {
        public string Name { get; set; }

        public CategoryDocuments Category { get; set; }
    }
}
