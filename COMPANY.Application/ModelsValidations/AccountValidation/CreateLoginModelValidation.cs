namespace COMPANY.Application.Models.Validations
{
    using Application.Services.AuthService;
    using FluentValidation;
    using FluentValidation.Validators;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateLoginModelValidation : AbstractValidator<CreateLoginModel>
    {
        private readonly IAccountService accountService;

        public CreateLoginModelValidation(IAccountService accountService)
        {
            this.accountService = accountService;

            RuleFor(e => e.UserName)
                .NotNull().WithMessage("Nom de utilisateur est requis")
                .NotEmpty().WithMessage("Nom de utilisateur est requis")
                .CustomAsync(UserNameShouldBeUniqueAsync);
        }

        private async Task UserNameShouldBeUniqueAsync(string propToValidate, CustomContext validationContext, CancellationToken cancellationToken)
        {
            if (!(await accountService.IsUserNameUniqueAsync(propToValidate)).Value)
            {
                validationContext.AddFailure("the given userName is already exist!");
            }
        }
    }
}
