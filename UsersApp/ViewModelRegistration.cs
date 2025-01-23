using UsercСhanges;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;


namespace UsersApp
{
    public class ViewModelRegistration
    {
        private DataUserRegOrAuth dataUsersRegistration = new DataUserRegOrAuth();
        private UserManagerSQLite userRegistrate = new UserManagerSQLite();

        public ViewModelRegistration(UserManagerSQLite userManager)
        {
            this.userRegistrate = userManager;
        }

        public DataUserRegOrAuth DataUsersRegistration
        {
            get => dataUsersRegistration;
            set
            {
                dataUsersRegistration = value;
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
    }
}
