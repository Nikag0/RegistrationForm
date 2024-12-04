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
        private UserManager userManagerAuthorization = new UserManager();
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            userManagerAuthorization.LoadUsers();

            if (userManagerAuthorization.UserIsRegistred(LoginAuthorization.Text, PasswordAuthorization.Password) == false)
            {
                return;
            }
        }
    }
}
