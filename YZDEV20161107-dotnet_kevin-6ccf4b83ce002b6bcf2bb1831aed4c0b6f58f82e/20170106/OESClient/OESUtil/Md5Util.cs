using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace OESUtil
{
    public class Md5Util
    {
        public static string EncryptStringWithMD5(string msg)
        {
            byte[] array = Encoding.UTF8.GetBytes(msg);
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] hashValue = provider.ComputeHash(array);
            return BitConverter.ToString(hashValue).Replace("-", "");
        }
    }
}
