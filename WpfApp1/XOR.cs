using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class XOR
    {
        /// <summary>
        /// Шифрует строку методом XOR с циклическим использованием ключа.
        /// Результат возвращается в Base64, чтобы его можно было безопасно хранить и передавать как строку.
        /// </summary>
        /// <param name="text">Исходный текст.</param>
        /// <param name="key">Ключ шифрования.</param>
        /// <returns>Зашифрованная строка в формате Base64.</returns>
        /// <exception cref="ArgumentNullException">Если text или key равны null.</exception>
        /// <exception cref="ArgumentException">Если text или key пустые.</exception>
        public static string XorEncrypt(string text, string key)
        {
            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] encryptedBytes = XorEncrypt(textBytes, keyBytes);

            return Convert.ToBase64String(encryptedBytes);
        }

        /// <summary>
        /// Расшифровывает строку, зашифрованную методом XOR и закодированную в Base64.
        /// </summary>
        /// <param name="cipherText">Зашифрованная строка в формате Base64.</param>
        /// <param name="key">Ключ шифрования.</param>
        /// <returns>Исходный текст.</returns>
        /// <exception cref="ArgumentNullException">Если cipherText или key равны null.</exception>
        /// <exception cref="ArgumentException">Если cipherText или key пустые.</exception>
        /// <exception cref="FormatException">Если cipherText не является корректной строкой Base64.</exception>
        public static string XorDecrypt(string cipherText, string key)
        {
            if (cipherText is null)
                throw new ArgumentNullException(nameof(cipherText));
            if (key is null)
                throw new ArgumentNullException(nameof(key));
            if (cipherText.Length == 0)
                throw new ArgumentException("Cipher text cannot be empty.", nameof(cipherText));
            if (key.Length == 0)
                throw new ArgumentException("Key cannot be empty.", nameof(key));

            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] decryptedBytes = XorEncrypt(cipherBytes, keyBytes);

            return Encoding.UTF8.GetString(decryptedBytes);
        }

        /// <summary>
        /// Шифрует или расшифровывает бинарные данные методом XOR.
        /// XOR является симметричным, поэтому один и тот же метод используется для обеих операций.
        /// </summary>
        /// <param name="data">Исходные данные.</param>
        /// <param name="key">Ключ шифрования.</param>
        /// <returns>Результат XOR-операции.</returns>
        /// <exception cref="ArgumentNullException">Если data или key равны null.</exception>
        /// <exception cref="ArgumentException">Если key пустой.</exception>
        public static byte[] XorEncrypt(byte[] data, byte[] key)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));
            if (key is null)
                throw new ArgumentNullException(nameof(key));
            if (key.Length == 0)
                throw new ArgumentException("Key cannot be empty.", nameof(key));

            byte[] result = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (byte)(data[i] ^ key[i % key.Length]);
            }

            return result;
        }
    }
}
