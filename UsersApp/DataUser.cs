using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp
{
    public class DataUser
    {
        private string login = "";
        private string password = "";
        private string repPassword = "";
        private string email = "";

        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string RepPassword { get => repPassword; set => repPassword = value; }
        public string Email { get => email; set => email = value; }
    }
}
