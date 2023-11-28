using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NetflixApp.PageModels
{
    public class SigninPageModel : BasePageModel
    {
        public Command NavigationBackCommand { get; }

        public SigninPageModel()
        {
            NavigationBackCommand = new Command(() =>
            {
                CoreMethods.PopPageModel();
            });
        }
    }
}
