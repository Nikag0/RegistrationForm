﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager
{
    public class DataUserRegOrAuth : DataUser
    {
        private string password = "";
        private string repPassword = "";

        public string Password { get => password; set => password = value; }
        public string RepPassword { get => repPassword; set => repPassword = value; }
    }
}