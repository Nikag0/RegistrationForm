using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UsercСhanges
{
    public class UserManagerSQLite
    {
        //ApplicationContext db = new ApplicationContext();

        ////public List<DataUser> DataUsersList = new List<DataUser>();

        //public int RegistrationUser(DataUserRegOrAuth dataUsersRegistration)
        //{
        //    int dataValidation = DataValitation(dataUsersRegistration);

        //    if (dataValidation == 0 && !CheckUserRgistered(dataUsersRegistration))
        //    {
        //        return 5;
        //    }
        //    return dataValidation;
        //}

        //// Валидация данных в окне регистрации.
        //private int DataValitation(DataUserRegOrAuth dataUsersRegistration)
        //{
        //    string patternEmail = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
        //    string patternPassword = @"^(?=.{6,16}$)(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9]).*$";

        //    if (dataUsersRegistration.Login.Length < 5)
        //    {
        //        return 1;
        //    }
        //    if (!Regex.IsMatch(dataUsersRegistration.Password, patternPassword))
        //    {
        //        return 2;
        //    }
        //    else if (dataUsersRegistration.Password != dataUsersRegistration.RepPassword)
        //    {
        //        return 3;
        //    }
        //    if (!Regex.IsMatch(dataUsersRegistration.Email, patternEmail))
        //    {
        //        return 4;
        //    }
        //    return 0;
        //}

        //// Проверка в окне регистрации, существует ли пользователь с введёнными данными.
        //private bool CheckUserRgistered(DataUserRegOrAuth dataUsersRegistration)
        //{
        //    string login = $"SELECT * FROM dataUsersSQLite WHERE Login= '{dataUsersRegistration.Login}'";

        //    using SqliteConnection connection = new SqliteConnection("Data Source=example.db");
        //    connection.Open();
        //    SqliteCommand command = new SqliteCommand(login, connection);
        //    command.CommandText = login;
        //    command.Connection = connection;

        //    SqliteDataReader reader = command.ExecuteReader();
        //    if (reader.Read())
        //    {
        //        return false;
        //    }
        //    DataUser newUser = new DataUser();
        //    newUser.Login = dataUsersRegistration.Login;
        //    newUser.HashPassword = HashingService.HashingService.HashPassword(dataUsersRegistration.Password);
        //    newUser.Email = dataUsersRegistration.Email;

        //    //Сохранение в SQLite.
        //    db.TenMillionPgSQL.Add(newUser);
        //    db.SaveChanges();
        //    return true;
        //}

        //// Проверка в окне авторизации, существует ли пользователь с введёнными данными.
        //public bool AuthorizationUser(DataUserRegOrAuth dataUserAuthorization)
        //{
        //    string loginAndHashPassword = $"SELECT * FROM TenMillionPgSQL WHERE Login= '{dataUserAuthorization.Login}'AND HashPassword = '{HashingService.HashingService.HashPassword(dataUserAuthorization.Password)}'";

        //    using SqliteConnection connection = new SqliteConnection("Data Source=example.db");
        //    connection.Open();
        //    SqliteCommand command = new SqliteCommand(loginAndHashPassword, connection);
        //    command.CommandText = loginAndHashPassword;
        //    command.Connection = connection;

        //    SqliteDataReader reader = command.ExecuteReader();
        //    if (reader.Read())
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public void SerializeXML()
        //{
        //    XmlSerializer xml = new XmlSerializer(typeof(DbSet<DataUser>));

        //    using (FileStream fs = new FileStream("Users.xml", FileMode.OpenOrCreate))
        //    xml.Serialize(fs, db.TenMillionPgSQL);
        //}
        ////public void SerializeBinary()
        ////{
        ////    #pragma warning disable SYSLIB0011 // Тип или член устарел
        ////    BinaryFormatter formatter = new BinaryFormatter();
        ////    #pragma warning restore SYSLIB0011 // Тип или член устарел

        ////    using (FileStream fs = new FileStream("UsersBin.dat", FileMode.OpenOrCreate))
        ////    formatter.Serialize(fs, DataUsersList);
        ////}

        ////public void PasToHash()
        ////{
        ////    using SqliteConnection users = new SqliteConnection("Data Source=dataUsersSQLite.db");
        ////    DataUsersList =  db.users.ToList();
        ////    foreach (DataUser u in DataUsersList)
        ////    {
        ////        u.HashPassword = HashingService.HashingService.HashPassword(u.Password);
        ////    }
        ////    //Сохранение в SQLite.
        ////    db.SaveChanges();
        ////}

        ////public void SaveUsers()
        ////{
        ////    using (StreamWriter writer = new StreamWriter("Data5.txt"))
        ////    {
        ////        foreach (DataUser user in DataUsersList)
        ////        {
        ////            string line = $"{user.Login};{user.HashPassword};{user.Email}";
        ////            writer.WriteLine(line);
        ////        }
        ////    }
        ////}

        //public void LoadUsers()
        //{
        //    db.TenMillionPgSQL.Load();
        //    //DataUsersList = db.users.ToList();
        //}
    }
}
