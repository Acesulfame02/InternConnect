using InternConnect.ViewModels;

namespace InternConnect.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new AuthenticationViewModel();
        }
    }

}
