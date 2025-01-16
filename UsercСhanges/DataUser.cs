using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UsercСhanges
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
