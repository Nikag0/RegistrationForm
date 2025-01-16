using System.Windows;

namespace UsersApp
{
    public partial class AuthorizationWindow : Window
    {
        private ViewModelAuthorization viewModelAuthorizatiomWindow = new ViewModelAuthorization();
        public AuthorizationWindow()
        {
            InitializeComponent();
            this.DataContext = viewModelAuthorizatiomWindow;
        }
    }
}