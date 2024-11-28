using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
namespace UsersApp
{
    public class HashingService
    {
        // Хэширование пароля.
        public string HashPassword(string password)
        {
            // Здесь создается экземпляр класса SHA1, который является частью библитеки System.Security.Cryptography.
            //Использование блока using гарантирует, что ресурсы, выделенные под объект sha128, будут освобождены после завершения работы метода.
            using (var sha128 = SHA1.Create()) 
            {
                // Входная строка (password) преобразуется в массив байтов с помощью кодировки UTF-8.
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                // ComputeHash вычисляет хеш массива байт passwordBytes с использованием алгоритма SHA-1.
                byte[] hash = sha128.ComputeHash(passwordBytes);
                // Хэшированные данные представляют собой набор байтов, который неудобен для передачи или хранения в текстовом формате. Поэтому они конвертируются в строку формата Base64.
                return Convert.ToBase64String(hash);
            }
        }
    }
}
