namespace COMPANY.Application.Models.Validations
{
    using Application.Services.AuthService;
    using Application.Services.DataService;
    using COMPANY.Common.Helpers;
    using FluentValidation;
    using FluentValidation.Validators;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// the account models validation
    /// </summary>
    public class UserCreateModelValidation : AbstractValidator<UserCreateModel>
    {
        private readonly IAccountService _accountService;
        private readonly IAgenceService _agenceService;

        public UserCreateModelValidation(
            IAccountService accountService,
            IAgenceService agenceService)
        {
            _accountService = accountService;
            _agenceService = agenceService;

            RuleFor(e => e.UserName)
                .NotNull().WithMessage("Nom de utilisateur est requis")
                .NotEmpty().WithMessage("Nom de utilisateur est requis")
                .CustomAsync(HasUniqueUserNameAsync);

            RuleFor(e => e.AgenceId)
                .CustomAsync(IsAgenceExistAsync);
        }

        private async Task IsAgenceExistAsync(string propToValidate, CustomContext validationContext, CancellationToken cancellationToken)
        {
            if (propToValidate.IsValid())
            {
                var result = await _agenceService.IsAgenceExistAsync(propToValidate);

                if (!result.HasValue || !result.Value)
                    validationContext.AddFailure("consessionnaire spécifié n'existe pas!");
            }
        }

        private async Task HasUniqueUserNameAsync(string propToValidate, CustomContext validationContext, CancellationToken cancellationToken)
        {
            var result = await _accountService.IsUserNameUniqueAsync(propToValidate);

            if (!result.Value)
                validationContext.AddFailure("le nom d'utilisateur est déjà pris");
        }

        private async Task HasUniqueEmail(string propToValidate, CustomContext validationContext, CancellationToken cancellationToken)
        {
            var result = await _accountService.IsUserEmailUniqueAsync(propToValidate);

            if (!result.Value)
                validationContext.AddFailure("");
        }
    }
}

