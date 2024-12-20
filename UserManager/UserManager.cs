using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HashingService;
namespace UserManager
{
    public class UserManager
    {
        private string path = "Data.txt";
        public string Path { get => path; set => path = value; }

        private List<DataUser> dataUsersList = new List<DataUser>();

        public int RegistrationUser(DataUserRegOrAuth dataUsersRegistration)
        {
            int dataValidation = DataValitation(dataUsersRegistration);

            if (dataValidation == 0 && !CheckUserRgistered(dataUsersRegistration))
            {
                return 5;
            }
            return dataValidation;
        }

        // Валидация данных в окне регистрации.
        private int DataValitation(DataUserRegOrAuth dataUsersRegistration)
        {
            string patternEmail = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
            string patternPassword = @"^(?=.{6,16}$)(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9]).*$";

            if (dataUsersRegistration.Login.Length < 5)
            {
                return 1;
            }
            if (!Regex.IsMatch(dataUsersRegistration.Password, patternPassword))
            {
                return 2;
            }
            else if (dataUsersRegistration.Password != dataUsersRegistration.RepPassword)
            {
                return 3;
            }
            if (!Regex.IsMatch(dataUsersRegistration.Email, patternEmail))
            {
                return 4;
            }
            return 0;
        }

        // Проверка в окне регистрации, существует ли пользователь с введёнными данными.
        private bool CheckUserRgistered(DataUserRegOrAuth dataUsersRegistration)
        {
            if (dataUsersList.Any(user => user.Login == dataUsersRegistration.Login || user.Email == dataUsersRegistration.Email))
            {
                return false;
            }

            DataUser newUser = new DataUser();
            newUser.Login = dataUsersRegistration.Login;
            newUser.HashPassword = HashingService.HashingService.HashPassword(dataUsersRegistration.Password);
            newUser.Email = dataUsersRegistration.Email;

            dataUsersList.Add(newUser);
            SaveUsers();
            return true;
        }

        // Проверка в окне авторизации, существует ли пользователь с введёнными данными.
        public bool AuthorizationUser(DataUserRegOrAuth dataUserAuthorization)
        {
            string hashPassword = HashingService.HashingService.HashPassword(dataUserAuthorization.Password);

            // return dataUsersList.Any(user => user.Login == dataUserAuthorization.Login && user.HashPassword == hashPassword);

            // поиск пользователя в листе, не используя Any.
            foreach (DataUser user in dataUsersList)
            {
                if (user.Login == dataUserAuthorization.Login && user.HashPassword == hashPassword)
                {
                    return true;
                }
            }
            return false;
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
