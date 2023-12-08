using FluentValidation;
using NetflixApp.PageModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetflixApp.Validators
{
    public class SignupValidator : AbstractValidator<SignupPageModel>
    {
        public SignupValidator()
        {
            RuleFor(x => x.EmailAddress)
                .NotNull()
                .WithMessage("{PropertyName} is required.");

            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");

            RuleFor(x => x.EmailAddress)
                .MinimumLength(5)
                .WithMessage("{PropertyName} should be between 5 and 50 characters.");

            RuleFor(x => x.EmailAddress)
                .MaximumLength(50)
                .WithMessage("{PropertyName} should be between 5 and 50 characters.");

            RuleFor(x => x.EmailAddress)
                .Matches("^\\S+@\\S+\\.\\S+$")
                .WithMessage("Please enter a valid {PropertyName}.");

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("Password is required.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.");

            RuleFor(x => x.Password)
                .MinimumLength(6)
                .WithMessage("Password should be between 6 and 60 caracters long.");

            RuleFor(x => x.Password)
                .MaximumLength(60)
                .WithMessage("Password should be between 6 and 60 caracters long.");
        }
    }
}
