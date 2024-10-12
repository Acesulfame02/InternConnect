using InternConnect.PageUtilsViewModel;
using CommunityToolkit.Maui.Views;
using InternConnect.Models;
namespace InternConnect.PageUtils;

public partial class ProfileAuthUtil : Popup
{
    public ProfileModel ProfileModel { get; set; }
    public ProfileAuthUtil()
	{
		InitializeComponent();
		ProfileModel = new ProfileModel();
        var viewModel = new ProfileUtilViewModel();

        // Set the close action to close the popup and navigate to home
        viewModel.ClosePopupAction = async () =>
        {
            // Close the popup
            Close();

            // Navigate to the homepage
            await Shell.Current.GoToAsync("//HomePage");
        };

        BindingContext = viewModel;
    }
}