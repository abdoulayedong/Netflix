using FluentValidation.Results;
using NetflixApp.Services;
using NetflixApp.Validators;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NetflixApp.PageModels
{
    public class CheckEmailPageModel : BasePageModel
    {

        #region Properties
        private readonly IAuthenticationService _authenticationService;
       
        private string _emailAddress;
        public string EmailAddress
        {
            get { return _emailAddress; }
            set => SetProperty(ref _emailAddress, value);
        }

        private bool CallValidator { get; set; } = false;

        private CheckEmailValidator validator = new CheckEmailValidator();

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set => SetProperty(ref _errorMessage, value);
        }
        #endregion

        #region Commands
        public Command NavigationBackCommand { get; }
        public Command GetStartedCommand { get; }
        public Command ValidationCommand { get; }
        #endregion
        public CheckEmailPageModel()
        {
            _authenticationService = DependencyService.Get<IAuthenticationService>();

            GetStartedCommand = new Command(async () =>
            {
                IsBusy = true;
                CallValidator = true;
                ValidationCommand.Execute(null);

                if(!string.IsNullOrEmpty(ErrorMessage) || !string.IsNullOrWhiteSpace(ErrorMessage))
                {
                    IsBusy = false;
                    return;
                }

                string loginResponse = await _authenticationService.LoginWithEmailAndPassword(EmailAddress, "secret");
                if(loginResponse == "Exist")
                {
                    await CoreMethods.PopPageModel();
                    await CoreMethods.PushPageModel<SigninPageModel>(data: EmailAddress);
                }
                if(loginResponse == "Not Exist")
                {
                    await CoreMethods.PopPageModel();
                    await CoreMethods.PushPageModel<SignupPageModel>(data: EmailAddress);
                }
                IsBusy = false;
            });

            ValidationCommand = new Command(
                execute: () =>
                {
                    try
                    {
                        EmailAddress = EmailAddress.Trim();
                    }
                    catch (NullReferenceException e)
                    {
                        Debug.WriteLine(e.StackTrace);
                        Debug.WriteLine(e.Message);
                    }
                    ValidationResult results = validator.Validate(this);
                    if (results.IsValid)
                    {
                        ErrorMessage = "";
                    }
                    else
                    {
                        ErrorMessage = results.Errors.First().ErrorMessage;
                    }
                },
                canExecute: () =>
                {
                    return CallValidator;
                }
                );

            NavigationBackCommand = new Command(async() =>
            {
                await CoreMethods.PopPageModel();
            });
        }
    }
}
