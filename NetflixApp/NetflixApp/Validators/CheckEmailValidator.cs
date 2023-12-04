using FluentValidation;
using NetflixApp.PageModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetflixApp.Validators
{
    public class CheckEmailValidator : AbstractValidator<CheckEmailPageModel>
    {
        public CheckEmailValidator() 
        {
            RuleFor(x => x.EmailAddress)
                .NotNull()
                .WithMessage("{PropertyName} is required");

            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

            RuleFor(x => x.EmailAddress)
                .MinimumLength(5)
                .WithMessage("{PropertyName} should be between 5 and 50 characters.");

            RuleFor(x => x.EmailAddress)
                .MaximumLength(50)
                .WithMessage("{PropertyName} should be between 5 and 50 characters.");

            RuleFor(x => x.EmailAddress)
                .Matches("^\\S+@\\S+\\.\\S+$")
                .WithMessage("Please enter a valid {PropertyName}");
        }
    }
}
