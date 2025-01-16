using System.Runtime.CompilerServices;
using System.ComponentModel;
using UsercСhanges;
using System.Windows.Input;
using System.Windows;


namespace UsersApp
{
    public class ViewModelRegistration : INotifyPropertyChanged
    {
        private DataUserRegOrAuth dataUsersRegistration = new DataUserRegOrAuth();
        private UserManager userRegistrate = new UserManager();

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelRegistration(UserManager userManager)
        {
            this.userRegistrate = userManager;
        }

        // Правильно ли переносить INotifyPropertyChanged во вьюмодель?
        public string Login
        {
            get => dataUsersRegistration.Login;
            set
            {
                dataUsersRegistration.Login = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => dataUsersRegistration.Password;
            set
            {
                dataUsersRegistration.Password = value;
                OnPropertyChanged();
            }
        }

        public string RepPassword
        {
            get => dataUsersRegistration.RepPassword;
            set
            {
                dataUsersRegistration.RepPassword = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => dataUsersRegistration.Email;
            set
            {
                dataUsersRegistration.Email = value;
                OnPropertyChanged();
            }
        }

        public ICommand ButtonSignUpClick
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    int error = userRegistrate.RegistrationUser(dataUsersRegistration);

                    switch (error)
                    {
                        case 1:
                            MessageBox.Show("login must be longer than 5 characters.");
                            break;
                        case 2:
                            MessageBox.Show("Password must be longer than 6 characters and contain lowercase and uppercase letters, a numeric value and special character.", "Message");
                            break;
                        case 3:
                            MessageBox.Show("Passwords don't match", "Message");
                            break;
                        case 4:
                            MessageBox.Show("Email was entered incorrectly", "Message");
                            break;
                        case 5:
                            MessageBox.Show("This login or email is already registered", "Message");
                            break;
                        case 0:
                            MessageBox.Show("Registrations is done", "Message");
                            //this.Close();
                            break;
                    }
                });
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
