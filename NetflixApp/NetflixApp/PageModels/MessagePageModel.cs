using NetflixApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace NetflixApp.PageModels
{
    public class MessagePageModel : BasePageModel
    {
        #region Properties
        private readonly IAuthenticationService _authenticationService;

        private bool _isSuccessPage;

        public bool IsSuccessPage
        {
            get { return _isSuccessPage; }
            set => SetProperty(ref _isSuccessPage, value);
        }

        private string _successBodyMessage;

        public string SuccessBodyMessage
        {
            get { return _successBodyMessage; }
            set => SetProperty(ref _successBodyMessage, value);
        }

        private string _iconMessage;

        public string IconMessage
        {
            get { return _iconMessage; }
            set => SetProperty(ref _iconMessage, value);
        }
        #endregion

        public Command SignoutCommand { get; }

        public MessagePageModel()
        {
            SignoutCommand = new Command(async () =>
            {

            });
        }

        public override async void Init(object initData)
        {
            base.Init(initData);
            if(initData != null) 
            {
                var email = initData as string;
                _isSuccessPage = true;
                try
                {
                    IconMessage = "Account created";
                    SuccessBodyMessage = $"Congratulations! We just sent an email to {email}. Please check your inbox to learn more. As a Netflix member, you can watch unlimited TV programmes and films on the mobile app and all your other devices.";
                    return;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            SuccessBodyMessage = "Go to your email address to finish signing up. As a Netflix member, you can watch unlimited TV programmes and films on the mobile app and all your other devices.";
            _isSuccessPage = false;
        }
    }
}
