using FluentValidation.Results;
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
        public string EmailAddress { get; set; }
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
            GetStartedCommand = new Command(async () =>
            {
                IsBusy = true;
                //await Task.Delay(3000);
                //CallValidator = true;
                //ValidationCommand.Execute(null);

                await CoreMethods.PushPageModel<SignupPageModel>();
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
