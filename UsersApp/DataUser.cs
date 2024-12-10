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
        private string hashPassword = "";
        private string email = "";

        public string Login { get => login; set => login = value; }
        public string HashPassword { get => hashPassword; set => hashPassword = value; }
        public string Email { get => email; set => email = value; }
    }
}
 