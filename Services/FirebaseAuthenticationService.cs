using Firebase.Auth.Providers;
using Firebase.Auth;

namespace InternConnect.Services
{
    public class FirebaseAuthenticationService
    {
        private readonly string webApiKey = "AIzaSyCRx-W015fwqu--v23IfiCyqvjjQ92YNj8";
        private readonly string authDomain = "intern.connect.learn";
        public async Task<FirebaseAuthClient> AuthTappedAsync()
        {
            try
            {
                var config = new FirebaseAuthConfig
                {
                    ApiKey = webApiKey,
                    AuthDomain = authDomain,
                    Providers = new FirebaseAuthProvider[]
                    {
                        new GoogleProvider().AddScopes("email"),
                        new EmailProvider()
                    }
                };

                var client = await Task.Run(() => new FirebaseAuthClient(config));

                if (client == null)
                {
                    throw new NullReferenceException("FirebaseAuthClient initialization failed.");
                }

                return client;
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
    }
}
