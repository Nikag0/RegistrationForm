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
        private string path = "Data.txt";
        private string loginRegistration = "";
        private string passwordRegistration = "";
        private string repPasswordRegistration = "";
        private string emailRegistration = "";
        private string loginAuthorization = "";
        private string passwordAuthorization = "";
        private string hashPassword = "";

        public string Path { get => path; set => path = value; }
        public string LoginRegistration { get => loginRegistration; set => loginRegistration = value; }
        public string PasswordRegistration { get => passwordRegistration; set => passwordRegistration = value; }
        public string RepPasswordRegistration { get => repPasswordRegistration; set => repPasswordRegistration = value; }
        public string EmailRegistration { get => emailRegistration; set => emailRegistration = value; }
        public string LoginAuthorization { get => loginAuthorization; set => loginAuthorization = value; }
        public string PasswordAuthorization { get => passwordAuthorization; set => passwordAuthorization = value; }
        public string HashPassword { get => hashPassword; set => hashPassword = value; }

        public List<string> dataUsersList = new List<string>();

        public void SaveUsers()
        {
            HashingService hashing = new HashingService();

            dataUsersList.Add(LoginRegistration + ";" + hashing.HashPassword(PasswordRegistration) + ";" + EmailRegistration);
            File.WriteAllLines(Path, dataUsersList);
        }

        public void LoadUsers()
        {
            dataUsersList = File.ReadAllLines(Path).ToList();
        }
    }
}
 