﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Architecture_Reminder.Tools
{
    public static class Encrypting
    {
        public static byte[] ComputeHashCode(byte[] toBeHashed)
        {
            using (var md5 = SHA512.Create())
            {
                return md5.ComputeHash(toBeHashed);
            }
        }

        public static string Encrypt(string text)
        {
            var md5HashedMessage = ComputeHashCode(Encoding.UTF8.GetBytes(text));
            return Convert.ToBase64String(md5HashedMessage);
        }
    }
}
