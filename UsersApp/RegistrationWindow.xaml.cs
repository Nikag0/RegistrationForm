using System.Windows;
using UsercСhanges;

namespace UsersApp
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow(UserManagerPGSQL userManager)
        //public RegistrationWindow(UserManager userManager)
        //public RegistrationWindow(UserManagerSQLite userManager)
        {
            InitializeComponent();
            ViewModelRegistration viewModelRegistrationWindow = new ViewModelRegistration(userManager);
            this.DataContext = viewModelRegistrationWindow;
        }
    }
}
