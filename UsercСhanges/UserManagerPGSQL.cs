using Npgsql;
using System.Text.RegularExpressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace UsercСhanges
{
    public class UserManagerPGSQL
    {
        ApplicationContext db = new ApplicationContext();
        Stopwatch sw = new Stopwatch();

        //public List<DataUser> DataUsersList = new List<DataUser>();
        private string connectionString = "Host=localhost;Port=5432;Database=TenMillionPgSQL; Username = postgres; Password=Nikago2280.";
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
            using (ApplicationContext db = new ApplicationContext())
            {
                var Log = db.TenMillionPgSQL.Where(p => p.Login == $"{dataUsersRegistration.Login}");
                if (Log.Any())
                    return false;
            }

            //string login = $@"SELECT * FROM ""TenMillionPgSQL"" WHERE ""Login"" = '{dataUsersRegistration.Login}'";

            //using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            //connection.Open();
            //NpgsqlCommand command1 = new NpgsqlCommand(login, connection);
            //command1.CommandText = login;
            //command1.Connection = connection;

            //NpgsqlDataReader reader = command1.ExecuteReader();
            //if (reader.Read())
            //{
            //    return false;
            //}

            DataUser newUser = new DataUser();
            newUser.Login = dataUsersRegistration.Login;
            newUser.HashPassword = HashingService.HashingService.HashPassword(dataUsersRegistration.Password);
            newUser.Email = dataUsersRegistration.Email;

            db.TenMillionPgSQL.Add(newUser);
            db.SaveChanges();
            return true;
        }


        // Проверка в окне авторизации, существует ли пользователь с введёнными данными.
        public bool AuthorizationUser(DataUserRegOrAuth dataUserAuthorization)
        {
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    var Log = db.TenMillionPgSQL.Where(p => p.Login == $"{dataUserAuthorization.Login}");
            //    var Hpas = db.TenMillionPgSQL.Where(p => p.HashPassword == $"{HashingService.HashingService.HashPassword(dataUserAuthorization.Password)}");
            //    if (Log.Any() && Hpas.Any())
            //        return false;
            //}

            string loginAndHashPassword = $@"SELECT * FROM ""TenMillionPgSQL"" WHERE ""Login"" = '{dataUserAuthorization.Login}' AND ""HashPassword"" = '{HashingService.HashingService.HashPassword(dataUserAuthorization.Password)}'";

            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(loginAndHashPassword, connection);
            command.CommandText = loginAndHashPassword;
            command.Connection = connection;

            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            return false;
        }

        //public void SerializeXML()
        //{
        //    XmlSerializer xml = new XmlSerializer(typeof(DbSet<DataUser>));

        //    using (FileStream fs = new FileStream("Users.xml", FileMode.OpenOrCreate))
        //        xml.Serialize(fs, db.TenMillionPgSQL);
        //}

        //public void SerializeBinary()
        //{
        //    #pragma warning disable SYSLIB0011 // Тип или член устарел
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    #pragma warning restore SYSLIB0011 // Тип или член устарел

        //    using (FileStream fs = new FileStream("UsersBin.dat", FileMode.OpenOrCreate))
        //    formatter.Serialize(fs, DataUsersList);
        //}

        //public void PasToHash()
        //{
        //    using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        //    foreach (DataUser u in db.TenMillionPgSQL)
        //    {
        //        u.HashPassword = HashingService.HashingService.HashPassword(u.Password);
        //    }
        //    db.SaveChanges();
        //}

        //public void SaveUsers()
        //{
        //    using (StreamWriter writer = new StreamWriter("Data5.txt"))
        //    {
        //        foreach (DataUser user in DataUsersList)
        //        {
        //            string line = $"{user.Login};{user.HashPassword};{user.Email}";
        //            writer.WriteLine(line);
        //        }
        //    }
        //}

        public void LoadUsers()
        {
            db.Database.EnsureCreated();
            //db.TenMillionPgSQL.Load();
            //DataUsersList = db.users.ToList();
        }
    }
}
