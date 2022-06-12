namespace COMPANY.Domain.Entities.OwnedEntities
{
    using System;
    using System.Collections.Generic;

    public class Memo
    {
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string Commentaire { get; set; }
        public List<PieceJoin> PieceJointes { get; set; }
    }

    public class PieceJoin
    {
        public string Type { get; set; }
        public string OrignalName { get; set; }
        public string Name { get; set; }
        public string File { get; set; }
    }
}