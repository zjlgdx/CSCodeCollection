// -----------------------------------------------------------------------
// <copyright file="EncryptUtil.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace SymmetricCryptography
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SymmetricCryptographyUtil
    {
        private string myData = "hello";
        private string myPassword = "OpenSesame";
        private byte[] cipherText;
        private byte[] salt = { 0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x5, 0x4, 0x3, 0x2, 0x1, 0x0 };

        private byte[] symmetricEncryption()
        {
            var key = new Rfc2898DeriveBytes(myPassword, salt);
            // Encrypt the data.
            var algorithm = new RijndaelManaged();
            algorithm.Key = key.GetBytes(16);
            algorithm.IV = key.GetBytes(16);
            var sourceBytes = new System.Text.UnicodeEncoding().GetBytes(myData);
            using (var sourceStream = new MemoryStream(sourceBytes))
            using (var destinationStream = new MemoryStream())
            using (var crypto = new CryptoStream(sourceStream,
                                                algorithm.CreateEncryptor(),
                                                CryptoStreamMode.Read))
            {
                moveBytes(crypto, destinationStream);
                cipherText = destinationStream.ToArray();
            }
            //return String.Format(
            //   "Data:{0}{1}Encrypted and Encoded:{2}",
            //   myData, Environment.NewLine,
            //   Convert.ToBase64String(cipherText));

            return cipherText;
        }

        public string SymmetricEncryptionResult()
        {
            return Convert.ToBase64String(symmetricEncryption());
        }

        private void moveBytes(Stream source, Stream dest)
        {
            byte[] bytes = new byte[2048];
            var count = source.Read(bytes, 0, bytes.Length);
            while (0 != count)
            {
                dest.Write(bytes, 0, count);
                count = source.Read(bytes, 0, bytes.Length);
            }
        }

        public string symmetricDecryption()
        {
            if (cipherText == null)
            {
                throw new Exception("Encrypt Data First!");
            }
            var key = new Rfc2898DeriveBytes(myPassword, salt);
            // Try to decrypt, thus showing it can be round-tripped.
            var algorithm = new RijndaelManaged();
            algorithm.Key = key.GetBytes(16);
            algorithm.IV = key.GetBytes(16);
            using (var sourceStream = new MemoryStream(cipherText))
            using (var destinationStream = new MemoryStream())
            using (var crypto = new CryptoStream(sourceStream,
                                                algorithm.CreateDecryptor(),
                                                CryptoStreamMode.Read))
            {
                moveBytes(crypto, destinationStream);
                var decryptedBytes = destinationStream.ToArray();
                var decryptedMessage = new UnicodeEncoding().GetString(
                   decryptedBytes);
                return decryptedMessage;
            }
        }
    }
}
