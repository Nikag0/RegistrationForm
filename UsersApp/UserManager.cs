using System;
using System.Data;
using System.IO;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Diagnostics.Eventing.Reader;
using MaterialDesignColors;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UsersApp
{
    public class UserManager 
    {
        private string path = "Data.txt";

        public string Path { get => path; set => path = value; }

        string patternPas = @"(?<=;)(.*?)(?=;)";
        string patternLog = @"(.*?)(?=;)";

        public List<string> dataUsersList = new List<string>();

        HashingService hashing = new HashingService();

        public int Register(DataUser dataUser) // существует ли уже пользователь с таким именем, и если нет, добавляет его в список
        {
            if (dataUser.EmailRegistration.Length < 5 || dataUser.LoginRegistration.Length < 5)
            {
                return 1;
            }

            if (!dataUser.EmailRegistration.Contains("@") || !dataUser.EmailRegistration.Contains("."))
            {
                return 2;
            }

            if (dataUsersList.Count == 0) // проверка, на пустой лист
            {
                dataUsersList.Add(dataUser.LoginRegistration + ";" + hashing.HashPassword(dataUser.PasswordRegistration) + ";" + dataUser.EmailRegistration);
                SaveUsers();
                return 0;
            }

            foreach (string str in dataUsersList)
            {
                Match log = Regex.Match(str, patternLog);

                if (dataUser.LoginRegistration == log.Value)
                {
                    return 3;
                }

            }

            dataUsersList.Add(dataUser.LoginRegistration + ";" + hashing.HashPassword(dataUser.PasswordRegistration) + ";" + dataUser.EmailRegistration);
            SaveUsers();
            return 0;
        }

       public void SaveUsers() //  сохранение пользователей из листа в файл
        {
            File.WriteAllLines(Path, dataUsersList);
        }

        public void LoadUsers() // загрузку пользователей из файла в лист
        {
            dataUsersList = File.ReadAllLines(Path).ToList();
        }

      public bool Login(DataUser dataUser) // проверяет, существует ли пользователь с введёнными данными и возвращает результат
      {
            foreach (string str in dataUsersList)
            {
                Match log = Regex.Match(str, patternLog);
                Match pas = Regex.Match(str, patternPas);

                if (dataUser.LoginAuthorization == log.Value && hashing.HashPassword(dataUser.PasswordAuthorization) == pas.Value) // Если лог и хэш пароля совпадают,
                {
                    return true;
                }            

            }
            return false;
      }

    }
}
