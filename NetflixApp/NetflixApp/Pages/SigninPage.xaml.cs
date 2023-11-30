using FormsControls.Base;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetflixApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SigninPage : AnimationPage
    {

        public SigninPage()
        {
            InitializeComponent();
        }

        public void LearnMore_Tapped(object sender, EventArgs e)
        {
            if (!Policy.IsVisible)
            {
                LearnMore.Text = LearnMore.Text.Remove(LearnMore.Text.IndexOf("Learn more"), "Learn more".Length);
                Policy.IsVisible = true;
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    Policy.Margin = new Thickness(5, 10);
                }
                else if (Device.Idiom == TargetIdiom.Tablet)
                {
                    Policy.Margin = new Thickness(90, 10);
                }
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            EmailAddress.EntryLabelFocused();
        }
    }
}