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

        private List<DataUserRegistration> dataUsersList = new List<DataUserRegistration>();

        private HashingService hashing = new HashingService();

        // Валидация данных в окне регистрации.
        public int DataValitation(DataUserRegistration dataUsersRegistration)
        {
            var patternEmail = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            var patternPassword = new Regex(@"^(?=.{6,16}$)(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9]).*$");

            if (dataUsersRegistration.Login.Length < 5)
            {
                return 1;
            }
            if (!patternPassword.IsMatch(dataUsersRegistration.HashPassword))
            {
                return 2;
            }
            else if (dataUsersRegistration.HashPassword != dataUsersRegistration.HashRepPassword)
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
        public bool AlreadyRegistred(DataUserRegistration dataUserRegistration)
        {
            DataUser foundUser = dataUsersList.FirstOrDefault(user => user.Login == dataUserRegistration.Login || user.Login == dataUserRegistration.Login);

            if (foundUser != null)
            {
                return false;

            }
            else
            {
                DataUserRegistration newuser = new DataUserRegistration();
                newuser.Login = dataUserRegistration.Login;
                newuser.HashPassword = dataUserRegistration.HashPassword;
                newuser.Email = dataUserRegistration.Email;

                dataUsersList.Add(newuser);
                SaveUsers();
                return true;
            }
        }

        // Проверка в окне авторизации, существует ли пользователь с введёнными данными.
        public bool UserIsRegistred(DataUser dataUser)
        {
            DataUser foundUser = dataUsersList.FirstOrDefault(user => user.Login == dataUser.Login && user.HashPassword == dataUser.HashPassword);

            if (foundUser != null)
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
                foreach (DataUserRegistration user in dataUsersList)
                {
                    // Запись данных одного объекта в строку
                    string line = $"{user.Login};{user.HashPassword};{user.Email}";
                    writer.WriteLine(line); // Записываем строку в файл
                }
            }
        }

        public void LoadUsers()
        {
            string[] dataString = File.ReadAllLines(Path);

            foreach (string str in dataString)
            {
                string[] data = str.Split(';');
                DataUserRegistration user = new DataUserRegistration();
                user.Login = data[0];     // login
                user.HashPassword = data[1];  // Hashpassword
                user.Email = data[2];     // email
                dataUsersList.Add(user);
            }
        }
    }
}
