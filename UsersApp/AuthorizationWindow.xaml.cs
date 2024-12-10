using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class AuthorizationWindow : Window
    {
        UserManager userManager = new UserManager();
     
        public AuthorizationWindow()
        {
            InitializeComponent();
            userManager.LoadUsers();
        }

        private void ButtonCreateAccountClick(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow(userManager);
            registrationWindow.Show();
        }

        private void ButtonSignInClick(object sender, RoutedEventArgs e)
        {
            DataUserPass dataUserLogin = new DataUserPass();

            dataUserLogin.Login = LoginAuthorization.Text;
            dataUserLogin.Password = PasswordAuthorization.Password;

            userManager.LoadUsers();

            if (!userManager.UserIsRegistred(dataUserLogin))
            {
                MessageBox.Show("The user is not registered or password was entered incorrectly", "Message");
                return;
            }
            else
            {
                MessageBox.Show("login is successful", "Message");
            }
        }
    }
}
