using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UsercСhanges
{
    [Serializable]
    public class DataUser : INotifyPropertyChanged
    {
        private string password = "";
        private string login = "";
        private string hashPassword = "";
        private string email = "";

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }
        public int Id { get; set; }
        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }
        public string HashPassword { get => hashPassword; set => hashPassword = value; }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
