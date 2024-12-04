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

        public List<DataUser> DataUsersList = new List<DataUser>();

        HashingService hashing = new HashingService();

        // Валидация данных в окне регистрации.
        public bool DataValitation(string login, string password, string repPassword, string email)
        {
            var patternEmail = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            var patternPassword = new Regex(@"^(?=.{6,16}$)(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9]).*$");

            if (login.Length < 5)
            {
                MessageBox.Show("login must be longer than 5 characters.");
                return false;
            }
            if (!patternPassword.IsMatch(password))
            {
                MessageBox.Show("Password must be longer than 6 characters and contain lowercase and uppercase letters, a numeric value and special character.", "Message");
                return false;
            }
            else if (password != repPassword)
            {
                MessageBox.Show("Passwords don't match", "Message");
                return false;
            }
            if (!patternEmail.IsMatch(email))
            {
                MessageBox.Show("Email was entered incorrectly", "Message");
                return false;
            }
            return true;
        }

        // Проверка в окне регистрации, существует ли пользователь с введёнными данными.
        public bool AlreadyRegistred(string login, string password, string email)
        {
            var foundUser = DataUsersList.FirstOrDefault(user => user.Login == login || user.Login == login);

            if (foundUser != null)
            {
                MessageBox.Show("This login or email is already registered", "Message");
                return false;

            }
            else
            {
                DataUser newuser = new DataUser();
                newuser.Login = login;
                newuser.Password = password;
                newuser.Email = email;

                DataUsersList.Add(newuser);
                SaveUsers();
                MessageBox.Show("Registrations is done", "Message");
                return true;
            }
        }

        // Проверка в окне авторизации, существует ли пользователь с введёнными данными.
        public bool UserIsRegistred(string login, string password)
        {

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("No login or password has been entered", "Message");
                return false;
            }

            var foundUser = DataUsersList.FirstOrDefault(user => user.Login == login && user.Password == hashing.HashPassword(password));

            if (foundUser != null)
            {
                MessageBox.Show("login is successful", "Message");
                return true;
            }
            else
            {
                MessageBox.Show("The user is not registered or password was entered incorrectly", "Message");
                return false;
            }
        }

        public void SaveUsers()
        {
            using (StreamWriter writer = new StreamWriter(Path))
            {
                foreach (var user in DataUsersList)
                {
                    // Запись данных одного объекта в строку
                    string line = $"{user.Login};{user.Password};{user.Email}";
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
                DataUser user = new DataUser();
                user.Login = data[0];     // login
                user.Password = data[1];  // Hashpassword
                user.Email = data[2];     // email
                DataUsersList.Add(user);
            }
        }
    }
}
