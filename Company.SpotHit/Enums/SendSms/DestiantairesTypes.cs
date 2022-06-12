namespace Company.SpotHit.Enums
{
    public class DestiantairesTypes
    {
        /// <summary>
        /// sélection de tous les contacts du compte.
        /// </summary>
        public static string All = "all";

        /// <summary>
        /// sélection de tous les contacts des groupes fournis dans le champs « destinataires » 
        /// (un tableau contenant les identifiants des groupes est requis)
        /// </summary>
        public static string Groupe = "groupe";

        /// <summary>
        /// permet d'ajouter des données personnalisées aux « destinataires » pour les utiliser 
        /// dans votre message (exemple : "Bonjour {nom} {prenom}"), pour ce faire il faut que 
        /// le champs « destinataires » soit un tableau de cette forme : 
        /// array(
        ///     "+33600000001" => array("nom" => "Nom 1", "prenom" => "Prénom 1"), 
        ///     "+33600000002" => array("nom" => "Nom 2", "prenom" => "Prénom 2") ...
        /// )
        /// </summary>
        public static string Datas = "datas ";
    }
}
