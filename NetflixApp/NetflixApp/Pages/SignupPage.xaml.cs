using FormsControls.Base;
using Xamarin.Forms.Xaml;

namespace NetflixApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : AnimationPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            EmailAddress.EntryLabelFocused();
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            checkbox.IsChecked = !checkbox.IsChecked;
        }
    }
}