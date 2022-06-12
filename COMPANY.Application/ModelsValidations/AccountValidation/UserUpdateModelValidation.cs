namespace COMPANY.Application.Models.Validations
{
    using Application.Services.AuthService;
    using Application.Services.DataService;
    using COMPANY.Common.Helpers;
    using FluentValidation;
    using FluentValidation.Validators;
    using System.Threading;
    using System.Threading.Tasks;

    public class UserUpdateModelValidation : AbstractValidator<UserCreateModel>
    {
        private readonly IAccountService _accountService;
        private readonly IAgenceService _agenceService;

        public UserUpdateModelValidation(
            IAccountService accountService,
            IAgenceService agenceService)
        {
            _accountService = accountService;
            _agenceService = agenceService;
            
            RuleFor(e => e.AgenceId)
                .CustomAsync(IsAgenceExistAsync);
        }

        private async Task IsAgenceExistAsync(string propToValidate, CustomContext validationContext, CancellationToken cancellationToken)
        {
            if (propToValidate.IsValid())
            {
                var result = await _agenceService.IsAgenceExistAsync(propToValidate);

                if (!result.HasValue || !result.Value)
                    validationContext.AddFailure("Agence spécifié n'existe pas!");
            }
        }

        private async Task HasUniqueEmail(string propToValidate, CustomContext validationContext, CancellationToken cancellationToken)
        {
            var result = await _accountService.IsUserEmailUniqueAsync(propToValidate);

            if (!result.HasValue || !result.Value)
                validationContext.AddFailure("");
        }
    }
}
