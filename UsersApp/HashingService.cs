using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
namespace UsersApp
{
    internal class HashingService
    {

        public string HashPassword(string password) // Хэширование пароля
        {
            using (var sha128 = SHA1.Create()) //десь создается экземпляр класса SHA1, который является частью библитеки System.Security.Cryptography.
                                               //Использование блока using гарантирует, что ресурсы, выделенные под объект sha128, будут освобождены после завершения работы метода.
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password); //Входная строка (password) преобразуется в массив байтов с помощью кодировки UTF-8
                byte[] hash = sha128.ComputeHash(passwordBytes); // ComputeHash вычисляет хеш массива байт passwordBytes с использованием алгоритма SHA-1
                return Convert.ToBase64String(hash); //Хэшированные данные представляют собой набор байтов, который неудобен для передачи или хранения в текстовом формате. Поэтому они конвертируются в строку формата Base64 
            }
        }

        public bool VerifyPassword(string password, string repPassword) //определяет валидность пароля, сравнивает его с повторенным.
        {
            var pattern = new Regex(@"^(?=.{6,16}$)(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9]).*$"); // от 6 до 16 символов, содержит строчные, прописные и цыифры\\\

            if (!pattern.IsMatch(password))
            {
                MessageBox.Show("Password must be longer than 6 characters and contain lowercase and uppercase letters, a numeric value and special character.", "Message");
                return false;
            }
            else if (password != repPassword)
            {
                MessageBox.Show("Passwords don't match", "Message");
                return false;
            }
            else
                return true;
        }
    }
}
