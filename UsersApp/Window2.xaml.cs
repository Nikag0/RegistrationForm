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
            userManager.LoadUsers();
        }

        private UserManager userManager = new UserManager(); 

        private DataUser dataUser = new DataUser();
        private void ButtonClick(object sender, RoutedEventArgs e)
        {

            dataUser.Login = TextBoxLogin.Text;
            dataUser.Password = TextBoxPassword.Password;
            dataUser.RepPassword = TextBoxRepPassword.Password;
            dataUser.Email = TextBoxEmail.Text;


            int error = userManager.Register(dataUser);
            switch (error)
            {
                case 1:
                    MessageBox.Show("There are less than 5 characters in a line", "Message");
                    break;
                case 2:
                    MessageBox.Show("Passwords don't match", "Message");
                    break;
                case 3:
                    MessageBox.Show("Email was entered incorrectly", "Message");
                    break;
                case 4:
                    MessageBox.Show("This login or Email is already registered", "Message");
                    break;
                case 0:
                    userManager.SaveUsers();
                    break;
            }


        }
            /*  public void MarkInvalid(Control control)
  {
      control.ToolTip = "Minimum of 5 characters";
      control.Background = Brushes.DarkRed;
  }

  public void MarkCorrect(Control control)
  {
      control.ToolTip = "";
      control.Background = Brushes.Transparent;
  }*/

        }

    }



