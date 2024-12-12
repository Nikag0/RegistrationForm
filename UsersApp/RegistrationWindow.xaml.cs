using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme;
using static System.Net.Mime.MediaTypeNames;
using static UsersApp.RegistrationWindow;

namespace UsersApp
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow(UserManager userManager)
        {
            InitializeComponent();
            userRegistrate = userManager;
        }
        private UserManager userRegistrate = new UserManager();

        private void ButtonSignUpClick(object sender, RoutedEventArgs e)
        {
            DataUserRegOrAuth dataUsersRegistration = new DataUserRegOrAuth();

            dataUsersRegistration.Login = LoginRegistration.Text;
            dataUsersRegistration.Password = PasswordRegistration.Password;
            dataUsersRegistration.RepPassword = RepPasswordRegistration.Password;
            dataUsersRegistration.Email = EmailRegistration.Text;

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
                    this.Close();
                    break;
            }
        }

        private void ButtonBackClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
