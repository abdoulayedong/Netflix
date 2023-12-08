using FluentValidation.Results;
using NetflixApp.Services;
using NetflixApp.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NetflixApp.PageModels
{
    public class SignupPageModel : BasePageModel
    {
        #region Properties
        private SignupValidator validator = new SignupValidator();
        private readonly IAuthenticationService _authenticationService;
        private string _emailAddress;

        public string EmailAddress
        {
            get { return _emailAddress; }
            set => SetProperty(ref _emailAddress, value);
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set => SetProperty(ref _password, value);
        }

        private string _emailAddressError;

        public string EmailAddressError
        {
            get { return _emailAddressError; }
            set => SetProperty(ref _emailAddressError, value);
        }

        private string _passwordError;

        public string PasswordError
        {
            get { return _passwordError; }
            set => SetProperty(ref _passwordError, value);
        }

        private string _warningMessage;
        public string WarningMessage
        {
            get { return _warningMessage; }
            set => SetProperty(ref _warningMessage, value);
        }

        private bool _isWarningPage;
        public bool IsWarningPage
        {
            get { return _isWarningPage; }
            set => SetProperty(ref _isWarningPage, value);
        }
        #endregion

        #region Commands
        public Command NavigateToSigninCommand { get; }
        public Command CreateAccountCommand { get; }
        public Command ValidateEmailAddressCommand { get; }
        public Command ValidatePasswordCommand { get; }
        #endregion

        public SignupPageModel()
        {
            _authenticationService = DependencyService.Get<IAuthenticationService>();
            
            NavigateToSigninCommand = new Command(async () =>
            {
                await CoreMethods.PushPageModel<SigninPageModel>();
            });

            CreateAccountCommand = new Command(async () =>
            {
                IsBusy = true;
                ValidateEmailAddressCommand.Execute(null); 
                ValidatePasswordCommand.Execute(null);

                if(PasswordError == "" && EmailAddressError == "")
                {
                    string signupResponse = "";
                    try
                    {
                        signupResponse = await _authenticationService.SignupWithEmailAndPassword(EmailAddress, Password);
                        if(signupResponse == "Exist")
                        {
                            WarningMessage = "it looks like that account already exists. Sign into that account or try using a different email address.";
                            IsWarningPage = true;
                        }else
                        {
                            await CoreMethods.PopToRoot(false);
                            await CoreMethods.PushPageModel<MessagePageModel>(EmailAddress);
                            Preferences.Set("EmailIsVerified", false);
                        }
                    }
                    catch (Exception)
                    {
                        WarningMessage = "Sorry, we are unable to complete the sign-up process now. Please try again later.";
                        IsWarningPage = true;
                    }
                }
                IsBusy = false;
            });

            ValidateEmailAddressCommand = new Command(async () =>
            {
                ValidationResult validationResult = await validator.ValidateAsync(this);
                var errors = validationResult.Errors;
                foreach( var error in errors )
                {
                    if(error.PropertyName == nameof(EmailAddress))
                    {
                        EmailAddressError = error.ErrorMessage;
                        return;
                    }
                }
                EmailAddressError = "";
            },
            canExecute: () =>
            {
                return true;
            });

            ValidatePasswordCommand = new Command(async () =>
            {
                ValidationResult validationResult = await validator.ValidateAsync(this);
                var errors = validationResult.Errors;
                foreach (var error in errors)
                {
                    if (error.PropertyName == nameof(Password))
                    {
                        PasswordError = error.ErrorMessage;
                        return;
                    }
                }
                PasswordError = "";
            },
            canExecute: () =>
            {
                return true;
            });
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            if(initData != null)
            {
                EmailAddress = initData.ToString();
            }
        }
    }
}
