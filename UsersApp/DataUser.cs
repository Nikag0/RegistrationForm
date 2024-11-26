using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp
{
    public class DataUser
    {
        private string loginRegistration = "";
        private string passwordRegistration = "";
        private string repPasswordRegistration = "";
        private string emailRegistration = "";
        private string loginAuthorization = "";
        private string passwordAuthorization = "";
        private string hashPassword = "";

        public string LoginRegistration { get => loginRegistration; set => loginRegistration = value; }
        public string PasswordRegistration { get => passwordRegistration; set => passwordRegistration = value; }
        public string RepPasswordRegistration { get => repPasswordRegistration; set => repPasswordRegistration = value; }
        public string EmailRegistration { get => emailRegistration; set => emailRegistration = value; }
        public string LoginAuthorization { get => loginAuthorization; set => loginAuthorization = value; }
        public string PasswordAuthorization { get => passwordAuthorization; set => passwordAuthorization = value; }
        public string HashPassword { get => hashPassword; set => hashPassword = value; }
    }
}
 