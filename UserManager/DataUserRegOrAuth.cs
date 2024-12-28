using System.ComponentModel;

namespace UserManager

{
    public class DataUserRegOrAuth : DataUser
    {
        private string password = "";
        private string repPassword = "";

        public string Password 
        { 
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }
        public string RepPassword 
        { 
            get => repPassword;
            set
            {
                repPassword = value;
                OnPropertyChanged();
            }
        }

    }
}
