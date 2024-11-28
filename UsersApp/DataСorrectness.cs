using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace UsersApp
{
    // Проверка на корректность данных в окнах регистрации и авторизации.
    public class DataСorrectness
    {
        string patternFindLog = @"(.*?)(?=;)";
        string patternFindPas = @"(?<=;)(.*?)(?=;)";
        string patternFindEmail = @".+?;.+?;(.+)";
        // Валидация данных в окне регистрации.
        public bool DataValitation(string login, string password,string repPassword, string email)
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
         public bool AlreadyRegistred(DataUser dataUser)
        {
            if (dataUser.dataUsersList.Count() == 0)
            {
                MessageBox.Show("Registrations is done", "Message");
                return true;
            } 

            foreach (string str in dataUser.dataUsersList)
            {

                Match log = Regex.Match(str, patternFindLog);
                Match email = Regex.Match(str, patternFindEmail);

                if (dataUser.LoginRegistration == log.Value)
                {
                    MessageBox.Show("This login is already registered", "Message");
                    return false;
                }

                if (dataUser.EmailRegistration == email.Groups[1].Value)
                {
                    MessageBox.Show("This Email is already registered", "Message");
                    return false;
                }

            }
            MessageBox.Show("Registrations is done", "Message");
            return true;
        }

        // Проверка в окне авторизации, существует ли пользователь с введёнными данными.
        public bool UserIsRegistred(DataUser dataUser)
        {

            if (string.IsNullOrEmpty(dataUser.LoginAuthorization) || string.IsNullOrEmpty(dataUser.PasswordAuthorization))
            {
                MessageBox.Show("No login or password has been entered", "Message");
                return false;
            }

            foreach (string str in dataUser.dataUsersList)
            {
                Match log = Regex.Match(str, patternFindLog);
                Match pas = Regex.Match(str, patternFindPas);

                HashingService hashing = new HashingService();

                if (dataUser.LoginAuthorization == log.Value && hashing.HashPassword(dataUser.PasswordAuthorization) == pas.Value)
                {
                    MessageBox.Show("login is successful", "Message");
                    return true;
                }
            }
            MessageBox.Show("The user is not registered or password was entered incorrectly", "Message");
            return false;
        }
    }
}
