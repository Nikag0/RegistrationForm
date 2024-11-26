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
using static UsersApp.Window2;

namespace UsersApp
{

    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        public static UserManager userManager = new UserManager();

        public static DataUser dataUser = new DataUser();

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            dataUser.LoginRegistration = LoginRegistration.Text;
            dataUser.PasswordRegistration = PasswordRegistration.Password;
            dataUser.RepPasswordRegistration = RepPasswordRegistration.Password;
            dataUser.EmailRegistration = EmailRegistration.Text;

            HashingService hashingService = new HashingService();
            if (hashingService.VerifyPassword(dataUser.PasswordRegistration, dataUser.RepPasswordRegistration) == false)
            {
                return;
            }

            int error = userManager.Register(dataUser);
            switch (error)
            {
                case 1:
                    MessageBox.Show("There are less than 5 characters in a line", "Message");
                    break;
                case 2:
                    MessageBox.Show("Email was entered incorrectly", "Message");
                    break;
                case 3:
                    MessageBox.Show("This login or Email is already registered", "Message");
                    break;
                case 0:
                    MessageBox.Show("Registrations is done", "Message");
                    this.Close();
                    break;
            }

        }

    }

}



