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
using System.Windows.Threading;
using UserManager;

namespace UsersApp
{
    public partial class AuthorizationWindow : Window
    {
        private UserManager.UserManager userManager = new UserManager.UserManager();
        private DataUserRegOrAuth dataUserAuthorization = new DataUserRegOrAuth();
        private DispatcherTimer timer;
        private int timerNum = 0;

        public AuthorizationWindow()
        {
            InitializeComponent();
            this.DataContext = dataUserAuthorization;
            userManager.LoadUsers();
        }

        private void ButtonCreateAccountClick(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow(userManager);
            registrationWindow.Show();
        }
        private void ButtonSignInClick(object sender, RoutedEventArgs e)
        {
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

        private void ButtonTimer(object sender, RoutedEventArgs e)
        {
            if (timerNum == 0)
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += Timer_Tick;
                timer.Start();
                StartTimer.Content = "Stop timer";
            }
            else
            {
                timerNum = 0;
                timer.Stop();
                StartTimer.Content = "Reset and start timer";
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            timerNum++;
            Timer.Text = timerNum.ToString();
        }

        private void CheckBoxAuthorizationOn(object sender, RoutedEventArgs e)
        {
            LoginAuthorization.Text = "Stop Authorization";
            LoginAuthorization.IsEnabled = false;
            PasswordAuthorization.IsEnabled = false;
        }

        private void CheckBoxAuthorizationOff(object sender, RoutedEventArgs e)
        {
            LoginAuthorization.Text = "";
            LoginAuthorization.IsEnabled = true;
            PasswordAuthorization.IsEnabled = true;
        }
    }
}
