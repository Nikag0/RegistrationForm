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

        private User user = new User(); // создание объекта user класса User. Выделение памяти new и вызов конструктора

        private DataUser dataUser = new DataUser(); // создание объекта datauser класса DataUser. Выделение памяти new и вызов конструктора

        private void ButtonClick(object sender, RoutedEventArgs e)
        {

            dataUser.Login = TextBoxLogin.Text;
            dataUser.Password = TextBoxPassword.Password;
            dataUser.RepPassword = TextBoxRepPassword.Password;
            dataUser.Email = TextBoxEmail.Text;

            int error = user.Check(dataUser);
            switch (error)
            {
                case 1:
                    MessageBox.Show("There are less than 5 characters in a line", "Message");
                    break;
                case 2:
                    MessageBox.Show("Passwords don't match", "Message");
                    break;
                case 3:
                    MessageBox.Show("There are less than 5 characters in a line or entered incorrectly", "Message");
                    break;
                case 0:
                    user.Write(dataUser);
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



