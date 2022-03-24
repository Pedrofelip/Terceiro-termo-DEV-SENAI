﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_oneUp_webApi.Repository
{
    public class md5Hash
    {
        public static string CalculaHash(string Senha)
        {
            try
            {
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(Senha);
                byte[] hash = md5.ComputeHash(inputBytes);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}