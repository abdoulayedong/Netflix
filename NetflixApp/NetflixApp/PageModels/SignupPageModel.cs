using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NetflixApp.PageModels
{
    public class SignupPageModel : BasePageModel
    {
        public Command NavigateToSigninCommand { get; }

        
        public SignupPageModel()
        {
            NavigateToSigninCommand = new Command(async () =>
            {
                await CoreMethods.PushPageModel<SigninPageModel>();
            });
        }
    }
}
