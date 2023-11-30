using Xamarin.Forms.Xaml;

namespace NetflixApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPopupPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        public SplashPopupPage()
        {
            InitializeComponent();
        }
    }
}