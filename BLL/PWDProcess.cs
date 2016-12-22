using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace BLL
{
    public class PWDProcess
    {
        public static string MD5Encrypt(string p, string key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(p);
            des.Key = ASCIIEncoding.ASCII.GetBytes(key);
            des.IV = ASCIIEncoding.ASCII.GetBytes(key);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms,des.CreateEncryptor(),CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}",b);
            }
            ret.ToString();
            return ret.ToString();
        }
        public static string CreateKey(string inputStr)
        {
            StringBuilder sb = new StringBuilder();
            string str = "VDF45BSDFB455";
            if (inputStr.Length >= 9)
            {
                for (int i = 0; i < 8; i++)
                {
                    sb.Append(str[Convert.ToInt32(inputStr[i].ToString())]);
                }
                return sb.ToString();
            }
            else
            {
                return "845GSFG4";
            }
        }
    }
}
