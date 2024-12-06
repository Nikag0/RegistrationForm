using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp
{
    public class DataUserRegistration : DataUser
    {
        private string hashRepPassword = "";
        private string email = "";

        public string HashRepPassword { get => hashRepPassword; set => hashRepPassword = value; }
        public string Email { get => email; set => email = value; }
    }
}
