using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UsercСhanges
{
    public class UserManagerSQLite
    {
        ApplicationContext db = new ApplicationContext();
        public ObservableCollection<DataUser> DataUsersSQLite { get; set; }

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
            string login = $"SELECT * FROM DataUsersSQLite WHERE Login= '{dataUsersRegistration.Login}'";
            int count = 0;

            using (var connection = new SqliteConnection("Data Source=helloapp.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(login, connection);
                command.CommandText= login;
                command.Connection =connection;

                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    count++;
                }
                if (count == 0)
                {
                    DataUser newUser = new DataUser();
                    newUser.Login = dataUsersRegistration.Login;
                    newUser.HashPassword = HashingService.HashingService.HashPassword(dataUsersRegistration.Password);
                    newUser.Email = dataUsersRegistration.Email;

                    //Сохранение в SQLite.
                    db.DataUsersSQLite.Add(newUser);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        // Проверка в окне авторизации, существует ли пользователь с введёнными данными.
        public bool AuthorizationUser(DataUserRegOrAuth dataUserAuthorization)
        {
            string login = $"SELECT * FROM DataUsersSQLite WHERE Login= '{dataUserAuthorization.Login}'AND HashPassword = '{HashingService.HashingService.HashPassword(dataUserAuthorization.Password)}'";
            int count = 0;

            using (var connection = new SqliteConnection("Data Source=helloapp.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(login, connection);
                command.CommandText= login;
                command.Connection =connection;

                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    count++;
                }
                if (count == 0)
                {
                    return false;
                }
                return true;
            }
        }
    
        public void LoadUsers()
        {
            db.Database.EnsureCreated();
            db.DataUsersSQLite.Load();
            DataUsersSQLite = db.DataUsersSQLite.Local.ToObservableCollection();
        }
    }
}
