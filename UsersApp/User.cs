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

namespace UsersApp
{
    public class User // класс User отвечает за проверку и запись данных в окне Registration
    {
        private string path = "Data.txt"; // путь к файлу, в котором хранятся данные
        public string Path { get => path; set => path = value; }

        public int Check(DataUser dataUser)  
        {
            if (dataUser.Login.Length < 5)
            {
               return 1;
            }

            if (dataUser.Password.Length < 5)
            {
                return 1;
            }
            else if (dataUser.Password != dataUser.RepPassword)
            {
                return 2;
            }

            if (dataUser.Email.Length < 5 || !dataUser.Email.Contains("@") || !dataUser.Email.Contains("."))
            {
                return 3; 
            }

            return 0;
        }

        public void Write(DataUser dataUser) // Определение метода StreamWriterText. Тип приватности private - в рамках класса. Тип данных void - ничего не возвращает
        {
            List<string> people = new List<string>() { dataUser.Login, ";", dataUser.Password, ";", dataUser.Email, "\n" };
            using (StreamWriter writer = new StreamWriter(path, true))
                for (int i = 0; i < people.Count; i++)
                {
                    writer.Write(people[i],"");
                }
        }
        public void DataInList ()
        {

        }

    }
}
