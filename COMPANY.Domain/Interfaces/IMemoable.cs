namespace COMPANY.Domain.Interfaces
{
    using COMPANY.Domain.Entities.OwnedEntities;
    using System.Collections.Generic;

    public interface IMemoable
    {
        ICollection<Memo> Memos { get; set; }
    }
}
