namespace COMPANY.Domain.Entities.OwnedEntities
{
    public class PhotoDocument
    {
        /// <summary>
        /// the image name in server 
        /// </summary>
        public PieceJoin Image { get; set; }

        /// <summary>
        /// the commentaire of photo
        /// </summary>
        public string Commentaire { get; set; }
    }
}
