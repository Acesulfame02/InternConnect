using InternConnect.ViewModels;

namespace InternConnect.Pages;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
        InitializeComponent();
        BindingContext = new AuthenticationViewModel();
    }
}