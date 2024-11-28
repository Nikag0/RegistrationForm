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

        public static DataUser dataUser = new DataUser();
        public static DataСorrectness dataСorrectness = new DataСorrectness();
        public static HashingService hashingService = new HashingService();


        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            dataUser.LoginRegistration = LoginRegistration.Text;
            dataUser.PasswordRegistration = PasswordRegistration.Password;
            dataUser.RepPasswordRegistration = RepPasswordRegistration.Password;
            dataUser.EmailRegistration = EmailRegistration.Text;
            

            if (dataСorrectness.DataValitation(LoginRegistration.Text, PasswordRegistration.Password, RepPasswordRegistration.Password, EmailRegistration.Text) == false)
            {
                return;
            }

            if (dataСorrectness.AlreadyRegistred(dataUser) == false)
            {
                return;
            }
            else
            {
                dataUser.SaveUsers();
                this.Close();
            }
        }
    }
}



