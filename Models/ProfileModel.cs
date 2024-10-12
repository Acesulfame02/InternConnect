using System.ComponentModel;

namespace InternConnect.Models
{
    public class ProfileModel : INotifyPropertyChanged
    {
        private string _username = string.Empty;
        private string _email = string.Empty;
        private string _phoneNumber = string.Empty;
        private string _address = string.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                RaisePropertyChanged(nameof(Username));
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                RaisePropertyChanged(nameof(Email));
            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                RaisePropertyChanged(nameof(PhoneNumber));
            }
        }
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                RaisePropertyChanged(nameof(Address));
            }
        }
    }
}
