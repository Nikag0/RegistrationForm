using System.Windows;
using UsercСhanges;

namespace UsersApp
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow(UserManagerSQLite userManager)
        {
            InitializeComponent();
            ViewModelRegistration viewModelRegistrationWindow = new ViewModelRegistration(userManager);
            this.DataContext = viewModelRegistrationWindow;
        }
    }
}
