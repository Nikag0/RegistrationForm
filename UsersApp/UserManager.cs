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
using HashingService;

namespace UsersApp
{
    public class UserManager
    {
        private string path = "Data.txt";
        public string Path { get => path; set => path = value; }

        private List<DataUser> dataUsersList = new List<DataUser>();

        public int RegistrationUser(DataUserRegOrAuth dataUsersRegistration)
        {
            if (DataValitation(dataUsersRegistration) == 0)
            {
                if (IsUserRgistered(dataUsersRegistration))
                {
                    return 0;
                }
                else
                {
                    return 5;
                }
            }
            else return DataValitation(dataUsersRegistration);
        }

        // Валидация данных в окне регистрации.
        private int DataValitation(DataUserRegOrAuth dataUsersRegistration)
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
        private bool IsUserRgistered(DataUserRegOrAuth dataUsersRegistration)
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
                newuser.HashPassword = HashingService.HashingService.HashPassword(dataUsersRegistration.Password);
                newuser.Email = dataUsersRegistration.Email;

                dataUsersList.Add(newuser);
                SaveUsers();
                return true;
            }
        }

        // Проверка в окне авторизации, существует ли пользователь с введёнными данными.
        public bool AuthorizationUser(DataUserRegOrAuth dataUserAuthorization)
        {
            bool foundUser = dataUsersList.Any(user => user.Login == dataUserAuthorization.Login && user.HashPassword == HashingService.HashingService.HashPassword(dataUserAuthorization.Password));

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
