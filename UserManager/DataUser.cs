using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UserManager
{
    public class DataUser : INotifyPropertyChanged
    {
        private string login = "";
        private string hashPassword = "";
        private string email = "";

        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        public string HashPassword { get => hashPassword; set => hashPassword = value; }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
