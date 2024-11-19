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

namespace UsersApp
{
    public class UserManager 
    {
        private string path = "Data.txt";

        public string Path { get => path; set => path = value; }

        public List<string> dataUsersList = new List<string>();

        public int Register(DataUser dataUser) // существует ли уже пользователь с таким именем, и если нет, добавляет его в список
        {
            if (dataUser.Login.Length < 5 || dataUser.Password.Length < 5 || dataUser.Email.Length < 5)
            {
                return 1;
            }

            else if (dataUser.Password != dataUser.RepPassword)
            {
                return 2;
            }

            if (!dataUser.Email.Contains("@") || !dataUser.Email.Contains("."))
            {
                return 3;
            }

            if (dataUsersList.Contains(dataUser.Login) )
            {
                return 4;
            }
            else
                dataUsersList.Add(dataUser.Login + ";" + dataUser.Password + ";" + dataUser.Email);

            return 0;
        }

       public void SaveUsers() //  сохранение пользователей из листа в файл
        {
            File.WriteAllLines(path, dataUsersList);
        }

        public void LoadUsers() // загрузку пользователей из файла в лист
        {
            dataUsersList = File.ReadAllLines(path).ToList();
        }

       /* public bool Login(DataUser dataUser) // проверяет, существует ли пользователь с введёнными данными и возвращает результат
          {
               if (dataUsersList.Contains(dataUser.Login) || dataUsersList.Contains(dataUser.Email)
            {
                return false;
            }
            else
                return true;
          } */

        /* public void Write(DataUser dataUser)
 {
     using (StreamWriter writer = new StreamWriter(path, true))
     writer.WriteLine(dataUser.Login + ";" + dataUser.Password + ";" + dataUser.Email);
 } */

    }
}
