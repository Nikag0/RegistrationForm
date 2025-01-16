using System.Windows;
using UsercСhanges;

namespace UsersApp
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow(UserManager userManager)
        {
            InitializeComponent();
            ViewModelRegistration viewModelRegistrationWindow = new ViewModelRegistration(userManager);
            this.DataContext = viewModelRegistrationWindow;
        }

        //private void ButtonBackClick(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}
    }
}
