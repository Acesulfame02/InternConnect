using InternConnect.Models;
using InternConnect.Services;
using System.Windows.Input;
using System.ComponentModel;
using CommunityToolkit.Maui.Views;
using InternConnect.PageUtils;

namespace InternConnect.ViewModels
{
    public class AuthenticationViewModel : INotifyPropertyChanged
    {
        private readonly FirebaseAuthenticationService _firebaseAuthentication;
        public ICommand SignInWithEmailBtn { get; }
        public ICommand SignUpWithEmailBtn { get; }
        public ICommand SignInWithGoogleBtn { get; }
        public ICommand SignUpWithGoogleBtn { get; }
        public ICommand GotoSignUpPageBtn { get; }
        public ICommand GotoSignInPageBtn { get; }
        // PropertyChanged Event for MVVM Binding
        public event PropertyChangedEventHandler? PropertyChanged;

        // Authentication Model for binding
        private AuthModel _authModel;
        public AuthModel AuthModel
        {
            get => _authModel;
            set
            {
                _authModel = value;
                OnPropertyChanged(nameof(AuthModel));
            }
        }

        // Constructor
        public AuthenticationViewModel()
        {
            _authModel = new AuthModel();
            _firebaseAuthentication = new FirebaseAuthenticationService();

            // Initialize Commands
            SignInWithEmailBtn = new Command(async () => await SignInWithEmailAsync());
            SignUpWithEmailBtn = new Command(async () => await SignUpWithEmailAsync());
            SignInWithGoogleBtn = new Command(async () => await SignInWithGoogleAsync());
            SignUpWithGoogleBtn = new Command(async () => await SignUpWithGoogleAsync()); 
            GotoSignUpPageBtn = new Command(async () => await GotoSignUpPageAsync());
            GotoSignInPageBtn = new Command(async () => await GotoSignInPageAsync());
        }

        // Method for signing in with email and password
        private async Task SignInWithEmailAsync()
        {
            try
            {
                // Perform sign in
                var client = await _firebaseAuthentication.AuthTappedAsync();
                var userCredential = await client.SignInWithEmailAndPasswordAsync(AuthModel.Username, AuthModel.Password);

                // Store user details
                var user = userCredential.User;
                Preferences.Set("IsLoggedIn", true);
                Preferences.Set("UserEmail", user.Info.Email);
                // Check if the user exists in the database
                var firestoreService = new FirestoreAndFirestorageService();
                var userExists = await firestoreService.CheckIfUserExistsAsync(user.Info.Email);

                if (!userExists)
                {
                    // Show Profile Popup before navigating to HomePage
                    var profilePopup = new ProfileAuthUtil
                    {
                        ProfileModel = new ProfileModel
                        {
                            Username = user.Uid,
                            Email = user.Info.Email
                        }
                    };
                    if (App.Current?.MainPage != null)
                    {
                        await App.Current.MainPage.ShowPopupAsync(profilePopup);
                    }
                }
                else
                {
                    // Navigate to HomePage if the user exists
                    await Shell.Current.GoToAsync("//HomePage");
                }
            }
            catch (Exception ex)
            {
                if (App.Current?.MainPage != null)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
                }
                throw;
            }
        }

        private async Task SignUpWithEmailAsync()
        {
            try
            {
                // Perform sign in
                var client = await _firebaseAuthentication.AuthTappedAsync();
                var userCredential = await client.CreateUserWithEmailAndPasswordAsync(AuthModel.Username, AuthModel.Password);

                // Store user details
                var user = userCredential.User;
                Preferences.Set("IsLoggedIn", true);
                Preferences.Set("UserEmail", user.Info.Email);

                // Navigate to MainPage
                await Shell.Current.GoToAsync("//MainPage");
            }
            catch (Exception ex)
            {
                if (App.Current?.MainPage != null)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
                }
                throw;
            }
        }

        // Method for signing in with Google
        private async Task SignInWithGoogleAsync()
        {
            if (App.Current?.MainPage != null)
            {
                await App.Current.MainPage.DisplayAlert("Feature Coming Soon", "Google Sign-In will be available in future updates.", "OK");
                await Shell.Current.GoToAsync("//MainPage");
            }
            await Shell.Current.GoToAsync("//MainPage");
        }

        // Method for signing up with Google
        private async Task SignUpWithGoogleAsync()
        {
            if (App.Current?.MainPage != null)
            {
                await App.Current.MainPage.DisplayAlert("Feature Coming Soon", "Google Sign-In will be available in future updates.", "OK");
                await Shell.Current.GoToAsync("//MainPage");
            }
            await Shell.Current.GoToAsync("//MainPage");
        }

        // Navigate to Sign-Up Page
        private async Task GotoSignUpPageAsync()
        {
            await Shell.Current.GoToAsync("//SignUpPage");
        }

        private async Task GotoSignInPageAsync()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }

        // PropertyChanged Notification
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
