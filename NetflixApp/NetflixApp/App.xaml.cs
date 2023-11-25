using FreshMvvm;
using NetflixApp.Models;
using NetflixApp.PageModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetflixApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var page = FreshPageModelResolver.ResolvePageModel<OnboardingPageModel>();

            var navigation = new FreshNavigationContainer(page);

            MainPage = navigation;
         }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
