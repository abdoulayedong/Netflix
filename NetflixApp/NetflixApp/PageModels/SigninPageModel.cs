using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NetflixApp.PageModels
{
    public class SigninPageModel : BasePageModel
    {
        public Command NavigationBackCommand { get; }
        public Command SigninCommand { get; }
        public Command ForgotPasswordCommand { get; }
        public Command PrivacyPolicyCommand { get; }
        public Command TermsOfServiceCommand { get; }



        public SigninPageModel()
        {
            NavigationBackCommand = new Command(() =>
            {
                CoreMethods.PopPageModel();
            });

            SigninCommand = new Command(() =>
            {

            });



            ForgotPasswordCommand = new Command(async () =>
            {
                await Browser.OpenAsync("https://www.netflix.com/ga/loginhelp?fromApp=true&netflixsource=android");
            });

            PrivacyPolicyCommand = new Command(async () =>
            {
                await Browser.OpenAsync("https://policies.google.com/privacy");
            });

            TermsOfServiceCommand = new Command(async () =>
            {
                await Browser.OpenAsync("https://policies.google.com/terms");
            });
        }
    }
}
