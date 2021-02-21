using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ArandaSoftwareData.Helpers
{
   public  class Encrypt
    {
        public static string GenSHA256(string str)
        {
            SHA256 Sha = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = Sha.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }

            return sb.ToString();
        }
    }
}
