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
using static System.Windows.Data.Binding;
using System.ComponentModel;

namespace UsersApp
{
    public partial class AuthorizationWindow : Window
    {
        private UserManager userManager = new UserManager();
     
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
            DataUserRegOrAuth dataUserAuthorization = (DataUserRegOrAuth)this.Resources["dataUserAuthorizationXAML"];

            dataUserAuthorization.Password = PasswordAuthorization.Password;

            if (userManager.AuthorizationUser(dataUserAuthorization))
            {
                MessageBox.Show("login is successful", "Message");
            }
            else
            {
                MessageBox.Show("The user is not registered or password was entered incorrectly", "Message");
            }
        }
    }
}
