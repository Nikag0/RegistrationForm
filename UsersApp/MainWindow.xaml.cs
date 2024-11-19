using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes; 

namespace UsersApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private UserManager userManager = new UserManager();

       // private DataUser dataUser = new DataUser();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
        }

       private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            /* bool error = userManager.Login(dataUser);
            switch (error)
            {
                case false:
                    MessageBox.Show("The user is not registered", "Message");
                    break;
                case true:
                    MessageBox.Show("login is successful", "Message");
                    break;
            }*/
        }

    }
    }