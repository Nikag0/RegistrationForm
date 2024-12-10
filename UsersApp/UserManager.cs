using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Xml.Linq;
using System;

namespace UsersApp
{
    public class UserManager
    {
        private string path = "Data.txt";
        public string Path { get => path; set => path = value; }

        private List<DataUser> dataUsersList = new List<DataUser>();

        // Валидация данных в окне регистрации.
        public int DataValitation(DataUserPass dataUsersRegistration)
        {
            var patternEmail = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            var patternPassword = new Regex(@"^(?=.{6,16}$)(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9]).*$");

            if (dataUsersRegistration.Login.Length < 5)
            {
                return 1;
            }
            if (!patternPassword.IsMatch(dataUsersRegistration.Password))
            {
                return 2;
            }
            else if (dataUsersRegistration.Password != dataUsersRegistration.RepPassword)
            {
                return 3;
            }
            if (!patternEmail.IsMatch(dataUsersRegistration.Email))
            {
                return 4;
            }
            return 0;
        }

        // Проверка в окне регистрации, существует ли пользователь с введёнными данными.
        public bool AlreadyRegistred(DataUserPass dataUsersRegistration)
        {
            bool foundUser = dataUsersList.Any(user => user.Login == dataUsersRegistration.Login || user.Login == dataUsersRegistration.Login);

            if (foundUser)
            {
                return false;
            }
            else
            {
                DataUser newuser = new DataUser();
                newuser.Login = dataUsersRegistration.Login;
                newuser.HashPassword = HashingService.HashPassword(dataUsersRegistration.Password);
                newuser.Email = dataUsersRegistration.Email;

                dataUsersList.Add(newuser);
                SaveUsers();
                return true;
            }
        }

        // Проверка в окне авторизации, существует ли пользователь с введёнными данными.
        public bool UserIsRegistred(DataUserPass dataUserLogin)
        {
            bool foundUser = dataUsersList.Any(user => user.Login == dataUserLogin.Login && user.HashPassword == HashingService.HashPassword(dataUserLogin.Password));

            if (foundUser)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SaveUsers()
        {
            using (StreamWriter writer = new StreamWriter(Path))
            {
                foreach (DataUser user in dataUsersList)
                {
                    string line = $"{user.Login};{user.HashPassword};{user.Email}";
                    writer.WriteLine(line);
                }
            }
        }

        public void LoadUsers()
        {
            dataUsersList.Clear();
            string[] dataString = File.ReadAllLines(Path);

            foreach (string str in dataString)
            {
                string[] data = str.Split(';');
                DataUser user = new DataUser();
                user.Login = data[0];           // login
                user.HashPassword = data[1];    // Hashpassword
                user.Email = data[2];           // email
                dataUsersList.Add(user);
            }
        }
    }
}
