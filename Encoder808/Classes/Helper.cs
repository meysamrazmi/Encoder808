using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encoder808.Classes
{
    public class Helper
    {
        private static Random random = new Random();
        private static int length = 6;
        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static byte[] EncryptData(byte[] data, string password)
        {
            try
            {
                SymmetricAlgorithm _algorithm = new RijndaelManaged();
                GetKey(password, ref _algorithm);

                ICryptoTransform encryptor = _algorithm.CreateEncryptor();

                byte[] cryptoData = encryptor.TransformFinalBlock(data, 0, data.Length);
                _algorithm.Dispose();
                encryptor.Dispose();
                return cryptoData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static byte[] DecryptData(byte[] cryptoData, string password)
        {
            try
            {
                SymmetricAlgorithm _algorithm = new RijndaelManaged();

                GetKey(password,ref _algorithm);

                ICryptoTransform decryptor = _algorithm.CreateDecryptor();

                byte[] data = decryptor.TransformFinalBlock(cryptoData, 0, cryptoData.Length);
                _algorithm.Dispose();
                decryptor.Dispose();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static void GetKey(string password,ref SymmetricAlgorithm _algorithm)
        {
            byte[] salt = new byte[8];

            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);

            int length = Math.Min(passwordBytes.Length, salt.Length);

            for (int i = 0; i < length; i++)
                salt[i] = passwordBytes[i];

            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt);

            _algorithm.Key = key.GetBytes(_algorithm.KeySize / 8);
            _algorithm.IV = key.GetBytes(_algorithm.BlockSize / 8);

        }
    }
}
