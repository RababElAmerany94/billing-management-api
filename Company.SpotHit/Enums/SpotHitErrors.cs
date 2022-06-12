namespace Company.SpotHit.Enums
{
    using Company.SpotHit.Attribute;

    public enum SpotHitErrors
    {
        [Description("Type de message non spécifié ou incorrect (paramètre 'type')")]
        MessageIcorrect = 1,

        [Description("Le message est vide")]
        EmptyMessage = 2,

        [Description("Le message contient plus de 160 caractères")]
        Plus160Charaters = 3,

        [Description("Aucun destinataire valide n'est renseigné")]
        EmptyRecipient = 4,

        [Description("Numéro interdit")]
        ProhibitedNumber = 5,

        [Description("Numéro de destinataire invalide")]
        InvalidRecipientNumber = 6,

        [Description("Votre compte n'a pas de formule définie")]
        YourAccountDoesNotHaveDefinedPlan = 7,

        [Description("SMS | L'expéditeur est invalide. / VOCAL | L'expéditeur est invalide. / EMAIL | L'e-mail d'expédition est invalide. / MMS | Le sujet contient plus de 16 caractères.")]
        SenderInvakid = 8,

        [Description("Le système a rencontré une erreur, merci de nous contacter.")]
        SystemHasEncountered = 9,

        [Description("Vous ne disposez pas d'assez de SMS pour effectuer cet envoi.")]
        DontHaveEnoughSmsToSend = 10,

        [Description("L'envoi des message est désactivé pour la démonstration.")]
        SendingMessagesDisabled = 11,

        [Description("Votre compte a été suspendu. Contactez-nous pour plus d'informations")]
        AccountSuspended1 = 12,

        [Description("Votre limite d'envoi paramétrée est atteinte. Contactez-nous pour plus d'informations.")]
        YourConfiguredSendingLimitHasBeenReached1 = 13,

        [Description("Votre limite d'envoi paramétrée est atteinte. Contactez-nous pour plus d'informations.")]
        YourConfiguredSendingLimitHasBeenReached2 = 14,

        [Description("Votre limite d'envoi paramétrée est atteinte. Contactez-nous pour plus d'informations.")]
        YourConfiguredSendingLimitHasBeenReached3 = 15,

        [Description("Le paramètre 'smslongnbr' n'est pas cohérent avec la taille du message envoyé.")]
        SmsLongNbrParameterNotConsistentWithSizeMessageSent = 16,

        [Description("L'expéditeur n'est pas autorisé.")]
        SenderNotAuthorized = 17,

        [Description("EMAIL | Le sujet est trop court.")]
        EmailSubjectTooShort = 18,

        [Description("EMAIL | L'email de réponse est invalide.")]
        ResponseEmailInvalid = 19,

        [Description("EMAIL | Le nom d'expéditeur est trop court.")]
        SenderNameShort = 20,

        [Description("Token invalide. Contactez-nous pour plus d'informations.")]
        TokenInvalid = 21,

        [Description("Durée du message non autorisée. Contactez-nous pour plus d'informations.")]
        MessageDurationNotAllowed = 22,

        [Description("Aucune date variable valide n'a été trouvée dans votre liste de destinataires.")]
        NoValidVariableDateFoundInYourRecipientList = 23,

        [Description("Votre campagne n'a pas été validée car il manque la mention « STOP » dans votre message. Pour rappel, afin de respecter les obligations légales de la CNIL, il est impératif d'inclure une mention de désinscription. Vous pouvez cliquer sur « Modifier la campagne » et cocher la mention STOP en bas du message.")]
        YourCampaignHasNotValidated = 24,

        [Description("Echelonnage : date de début vide")]
        EchelonnageDateDebutInvalid = 25,

        [Description("Echelonnage : date de fin vide")]
        EchelonnageDateFinInvalid = 26,

        [Description("Echelonnage : date de début plus tard que date de fin")]
        EchelonnageDateDebutLaterThanDateFin = 27,

        [Description("Echelonnage : aucun créneau disponible")]
        EchelonnageNoTimeSlotAvailable = 28,

        [Description("MMS : Le mot 'virtual' peut générer des anomalies dans le routage de vos messages. Nous vous invitons à utiliser un synonyme ou une autre écriture(Virtuel par exemple). Nous sommes en train de corriger cette anomalie, veuillez - nous excuser pour la gêne occasionnée.")]
        MmsWordVirtualCanGenerateAnomaliesInRoutingOfYourMessages = 29,

        [Description("Clé API non reconnue.")]
        ApiKeyNotRecognized = 30,

        [Description("Vous ne pouvez pas avoir d'emojis dans votre message.")]
        CannotHaveEmojisInYourMessage = 36,

        [Description("Vous devez ajouter une mention 'Stop' à votre SMS.")]
        MustAddStopMentionToYourSMS = 38,

        [Description("Une pièce jointe ne vous appartient pas.")]
        AnAttachmentDoesNotBelongToYou = 40,

        [Description("Une pièce jointe est invalide.")]
        AnAttachmentInvalid = 41,

        [Description("Ce produit n'est pas activé.")]
        ProductNotActivated = 45,

        [Description("Le fuseau horaire spécifié n'est pas valide.")]
        SpecifiedTimeZoneNotValid = 50,

        [Description("La date est déjà passé après calcule du fuseau horaire.")]
        DateAlreadyPassedAfterCalculatingTimeZone = 51,

        [Description("Vous avez atteint la limite maximale de 50 campagnes en brouillons. Si vous souhaitez en ajouter plus, merci de nous contacter.")]
        ReachedMaximumLimitOf50DraftCampaigns = 52,

        [Description("Nous limitons à 5 pièces jointes par campagne email.")]
        Limit5AttachmentsPerEmailCampaign = 53,

        [Description("Votre compte est suspendu.")]
        AccountSuspended2 = 99
    }
}
