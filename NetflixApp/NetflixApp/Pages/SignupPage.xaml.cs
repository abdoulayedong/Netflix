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

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {

        }
    }
}