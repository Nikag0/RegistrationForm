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
        private string loginAuthorization = "";
        private string passwordAuthorization = "";

        public string Login { get => login; set => login = value; }
        public string LoginAuthorization { get => loginAuthorization; set => loginAuthorization = value; }
        public string Password { get => password; set => password = value; }
        public string PasswordAuthorization { get => passwordAuthorization; set => passwordAuthorization = value; }
        public string RepPassword { get => repPassword; set => repPassword = value; }
        public string Email { get => email; set => email = value; }
    }
}
