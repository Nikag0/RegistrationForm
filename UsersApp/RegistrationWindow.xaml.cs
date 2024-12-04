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
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            userManager.LoadUsers();
        }

        private UserManager userManager = new UserManager();
        private DataUser dataUser = new DataUser();
        private HashingService hashingService = new HashingService();

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (userManager.DataValitation(LoginRegistration.Text, PasswordRegistration.Password, RepPasswordRegistration.Password, EmailRegistration.Text) == false)
            {
                return;
            }

            if (userManager.AlreadyRegistred(LoginRegistration.Text, hashingService.HashPassword(PasswordRegistration.Password), EmailRegistration.Text) == false)
            {
                return;
            }
            else
            {
                this.Close();
            }
        }
    }
}
