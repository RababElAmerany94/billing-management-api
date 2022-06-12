namespace Company.SpotHit.Models
{
    using Company.SpotHit.Enums;
    using Newtonsoft.Json;

    public class SendSMS
    {
        /// <summary>
        /// clé API d'identification
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; private set; }

        /// <summary>
        /// Limité à 160 caractères (ou voir paramètre smslong).
        /// Attention : Les caractères |, ^, €, }, {, [, ~,] et \ comptent doubles.
        /// Dans une requête de type GET, utiliser le caractère \n pour effectuer un retour à la ligne.
        /// Les caractères %0A, <br>, <br />, <br/> et \n sont automatiquement remplacés par un retour à la ligne.
        /// SMS Personnalisé : { Nom de la colonne}, exemple : {Nom}
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Liste de numéros de vos destinataires (tableau ou séparé par un retour à la ligne ou une virgule)
        /// ex : +33600000000,003360-00-00-00 , 6 00 00 00 00
        /// </summary>
        [JsonProperty("destinataires")]
        public string Destinataires { get; set; }

        /// <summary>
        /// Optionnel
        /// 11 caractères maximum(espaces inclus)
        /// Si vide, l'expéditeur de votre SMS sera un numéro court à 5 chiffres auxquels vos destinataires peuvent répondre.
        /// L’expéditeur doit comporter un minimum de 3 caractères pour être personnalisé et ne doit pas commencer par plus de 3 chiffres consécutifs avant la première lettre.
        /// L'affichage de l'expéditeur dépend du type de téléphone. Par exemple, sur certains iPhone les espaces sont supprimés.Par ailleurs, les accents et caractères spéciaux ne sont jamais pris en compte.
        /// France métropolitaine
        /// L'opérateur NRJ Mobile ne prend pas en compte les expéditeurs personnalisés, ils seront automatiquement remplacés par un numéro court. Afin d'éviter toute confusion pour vos destinataires, il est préférable de préciser le nom de votre boutique également dans le corps du message.
        /// International
        /// Certains pays n'acceptent pas la personnalisation de l'expéditeur.Il est fortement conseillé de prendre contact avec nous afin de connaître les spécificités de chaque pays concerné.
        /// Les destinataires ne pourront pas répondre au SMS lors d'envois hors France & DOM-TOM.
        /// </summary>
        [JsonProperty("expediteur")]
        public string Expediteur { get; set; }

        /// <summary>
        /// Optionnel
        /// Date d'envoi du message (format timestamp)
        /// Si aucune date n'est entrée ou si celle-ci précède la date actuelle, le message sera envoyé immédiatement
        /// </summary>
        [JsonProperty("date")]
        public long? Date { get; set; }

        /// <summary>
        /// Optional
        /// Si égal à "1", autorise l'envoi de SMS supérieur à 160 caractères. Un SMS vous sera facturé tous les 153 caractères.
        /// Exemple : pour un message de 300 caractères à 1000 destinataires, 2000 SMS vous seront débités.
        /// Maximum 5 SMS concaténés (soit 765 caractères).
        /// </summary>
        [JsonProperty("smslong")]
        public Option? SmsLong { get; set; }

        /// <summary>
        /// Optional
        /// Permet de vérifier la taille du SMS long envoyé.
        /// Vous devez envoyer le nombre de SMS concaténés comme valeur.
        /// Si notre compteur nous indique un nombre différent, votre message sera rejeté.
        /// </summary>
        [JsonProperty("smslongnbr")]
        public int? SmsLongNbr { get; set; }

        /// <summary>
        /// Optional
        /// Si égal à "1", tronque automatiquement le message à 160 caractères.
        /// </summary>
        [JsonProperty("tronque")]
        public Option? Tronque { get; set; }

        /// <summary>
        /// optional
        /// - si égal à "auto", conversion de votre message en UTF-8 
        /// (il est conseillé de convertir votre message en UTF-8 dans votre application cependant si votre message 
        /// reste coupé après un caractère accentué, vous pouvez activer ce paramètre).
        /// - si égal à "ucs2", conversion de votre message en unicode
        /// (cous pouvez utiliser des caractères supplémentaires comme « ê » qui n'est pas pris en compte en SMS standard, 
        /// ainsi qu'inclure des emojis.Attention : Le nombre de caractères est limité à 70, et 67 en SMS Long.)
        /// </summary>
        [JsonProperty("encodage")]
        public string Encodage { get; set; }

        /// <summary>
        /// optional
        /// Cette information non visible par les destinataires vous permet d’identifier 
        /// votre campagne (maximum 255 caractères).
        /// </summary>
        [JsonProperty("nom")]
        public string Nom { get; set; }

        /// <summary>
        /// optional
        /// Permet la sélection de contacts déjà enregistrés sur le compte client
        /// see options <see cref="DestiantairesTypes"/>
        /// </summary>
        [JsonProperty("destinataires_type")]
        public string DestinatairesType { get; set; }

        /// <summary>
        /// optional 
        /// Adresse URL de votre serveur pour la réception en "push" des statuts après l'envoi. 
        /// Vous devez déjà avoir une adresse paramétrée sur votre compte pour activer les retours "push". 
        /// Si ce paramètre est renseigné, cette URL sera appelée pour cet envoi sinon l'adresse du compte est utilisée.
        /// </summary>
        [JsonProperty("url")]
        public string URL { get; set; }

        /// <summary>
        /// optional
        /// obligatoire pour l'envoi échelonné
        /// Date de début d'envoi des messages (format timestamp)
        /// </summary>
        [JsonProperty("date_debut")]
        public long? DateDebut { get; set; }

        /// <summary>
        /// optional
        /// obligatoire pour l'envoi échelonné
        /// Date de fin d'envoi des messages (format timestamp)
        /// </summary>
        [JsonProperty("date_fin")]
        public long? DateFin { get; set; }

        /// <summary>
        /// optional
        /// obligatoire pour l'envoi échelonné
        /// Heure(s) d'envois
        /// Tableau avec 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19
        /// La campagne sera fractionnée proportionnellement aux nombres de créneaux 
        /// entre le jour et l'heure de démarrage, et le jour et l'heure de fin souhaitée.
        /// </summary>
        [JsonProperty("creneaux")]
        public Creneaux[] Creneaux { get; set; }

        /// <summary>
        /// Optionnel, obligatoire pour l'envoi échelonné
        /// 1,2,3,4 ou 6
        /// Nombre d'envoi(s) par heure
        /// </summary>
        [JsonProperty("creneaux_heure")]
        public CreneauxHeure? CreneauxHeure { get; set; }

        /// <summary>
        /// optional
        /// obligatoire pour l'envoi échelonné
        /// Tableau avec 1,2,3,4,5,6
        /// Jours d'envoi (1 représentant lundi). Pas d'envoi le dimanche.
        /// </summary>
        [JsonProperty("jours")]
        public Days? Jours { get; set; }

        /// <summary>
        /// optional
        /// permet de modifier le fuseau horaire.
        /// Par défaut : Europe/Paris
        /// <see cref="Enums.Timezone"/>
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        public void SetApiKet(string key)
        {
            Key = key;
        }
    }
}
