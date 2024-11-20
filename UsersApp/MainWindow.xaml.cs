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

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            userManager.LoadUsers();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
        }

       private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataUser.LoginAuthorization = LoginAuthorization.Text;
            dataUser.PasswordAuthorization = PasswordAuthorization.Password;
            if (LoginAuthorization.Text == "" || PasswordAuthorization.Password == "")
            {
                MessageBox.Show("No login or password has been entered", "Message");
                return;
            }

            bool error = userManager.Login(dataUser);
            switch (error)
            {
                case false:
                    MessageBox.Show("The user is not registered or password was entered incorrectly", "Message");
                    break;
                case true:
                    MessageBox.Show("login is successful", "Message");
                    break;
            }
        }

    }
    }