using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RandomPasswordGenerator
{
    public static class Generator
    {
        private static readonly char[] chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!#$%&'()*+`-./".ToCharArray();
        public static string Generate(int size)
        {
            
            byte[] data = new byte[size * 10];

            using(RNGCryptoServiceProvider cryptoProvider = new RNGCryptoServiceProvider())
                cryptoProvider.GetBytes(data);

            StringBuilder stringBuilder = new StringBuilder(size);

            for (int i = 0; i < size; i++)
            {
                long random = BitConverter.ToUInt32(data, i * 10) % chars.Length;
                stringBuilder.Append(chars[random]); 
            }

            return stringBuilder.ToString();
        }
    }
}
