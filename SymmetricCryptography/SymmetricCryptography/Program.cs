using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymmetricCryptography
{
    class Program
    {
        static void Main(string[] args)
        {
            SymmetricCryptographyUtil encryptUtil = new SymmetricCryptographyUtil();
            var encryptResult = encryptUtil.SymmetricEncryptionResult();
           var decryResult = encryptUtil.symmetricDecryption();
        }
    }
}
