using System;
using System.Security.Cryptography;
using System.Text;

namespace Restneer.Core.Infrastructure.Utility.Sha256
{
    public class Sha256Utility : ISha256Utility
    {
        public string Encrypt(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
