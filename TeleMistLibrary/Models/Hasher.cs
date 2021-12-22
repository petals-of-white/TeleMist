using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TeleMistLibrary.Models
{
    public class Hasher
    {
        #region StrangeFunctions
        private static string GenerateHashString(HashAlgorithm algo, string text)
        {
            // знайдемо геш параметра text
            algo.ComputeHash(Encoding.UTF8.GetBytes(text));

            //візьмемо значення гешу в масиві байтів
            var result = algo.Hash;

            //повернемо шістнадцятковий рядок
            return string.Join(
                string.Empty, result.Select(x => x.ToString("x2")));
        }
        public static string MD5(string text)
        {
            var result = default(string);

            //використаємо
            using (var algo = new MD5CryptoServiceProvider())
            {
                result = GenerateHashString(algo, text);
            }
            return result;
        }
        public static string SHA1(string text)
        {
            var result = default(string);

            using (var algo = new SHA1Managed())
            {
                result = GenerateHashString(algo, text);
            }

            return result;
        }

        public static string SHA256(string text)
        {
            var result = default(string);

            using (var algo = new SHA256Managed())
            {
                result = GenerateHashString(algo, text);
            }

            return result;
        }

        public static string SHA384(string text)
        {
            var result = default(string);

            using (var algo = new SHA384Managed())
            {
                result = GenerateHashString(algo, text);
            }

            return result;
        }

        public static string SHA512(string text)
        {
            var result = default(string);

            using (var algo = new SHA512Managed())
            {
                result = GenerateHashString(algo, text);
            }

            return result;
        }
        #endregion


        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            // знайдемо геш параметра text
            md5.ComputeHash(Encoding.ASCII.GetBytes(text));

            //результат-геш 

            byte [] result = md5.Hash;

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
            {

                //що коїться
                stringBuilder.Append(result [i].ToString("x2"));

            }
            return stringBuilder.ToString();

        }
    }
}
