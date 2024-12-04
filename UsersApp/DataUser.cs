using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UsersApp
{
    public class DataUser
    {
        private string login = "";
        private string password = "";
        private string repPassword = "";
        private string email = "";
        private string hashPassword = "";

        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string RepPasswordn { get => repPassword; set => repPassword = value; }
        public string Email { get => email; set => email = value; }
        public string HashPassword { get => hashPassword; set => hashPassword = value; }
    }
}
 