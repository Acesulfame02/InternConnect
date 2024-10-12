using InternConnect.Models;
using InternConnect.Services;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace InternConnect.PageUtilsViewModel
{
    public class ProfileUtilViewModel : INotifyPropertyChanged
    {
        public Action ClosePopupAction { get; set; }  // This action will be set in the popup

        public ICommand SaveProfileBtn { get; }

        private readonly FirestoreAndFirestorageService _firestoreService;
        private ProfileModel _profileModel;

        public event PropertyChangedEventHandler? PropertyChanged;

        // Country codes for the Picker
        public ObservableCollection<string> CountryCodes { get; }

        private string _selectedCountryCode = "+260";  // Default to +260

        public string SelectedCountryCode
        {
            get => _selectedCountryCode;
            set
            {
                _selectedCountryCode = value;
                OnPropertyChanged(nameof(SelectedCountryCode));
            }
        }

        public ProfileModel ProfileModel
        {
            get => _profileModel;
            set
            {
                _profileModel = value;
                OnPropertyChanged(nameof(ProfileModel));
            }
        }

        public ProfileUtilViewModel()
        {
            _firestoreService = new FirestoreAndFirestorageService();
            _profileModel = new ProfileModel();
            SaveProfileBtn = new Command(async () => await SaveProfileAsync());
            ClosePopupAction = async () => await SaveProfileAsync();

            // Initialize country codes (you can add more)
            CountryCodes = new ObservableCollection<string>
        {
            "+260",  // Zambia
            "+1",    // USA
            "+44",   // UK
            "+91"    // India
        };
        }

        // Save profile to Realtime Database
        private async Task SaveProfileAsync()
        {
            // Concatenate the selected country code with the phone number
            ProfileModel.PhoneNumber = $"{SelectedCountryCode}{ProfileModel.PhoneNumber}";

            // Save the profile data in Realtime Database
            await _firestoreService.SaveUserProfileAsync(_profileModel);

            // Trigger the popup closure after saving
            ClosePopupAction?.Invoke();  // Call the close action if it exists
        }

        // PropertyChanged Notification
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
