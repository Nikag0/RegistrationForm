using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp
{
    public class DataUserPass : DataUser
    {
        private string password = "";
        private string repPassword = "";

        public string Password { get => password; set => password = value; }
        public string RepPassword { get => repPassword; set => repPassword = value; }
    }
}
