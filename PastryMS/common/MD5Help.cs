using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;


namespace common
{
    public class MD5Help
    {
        public static string GenerateMD5(string txt)
        {
            using(MD5 mi = MD5.Create())
            {
                byte[] buffer = Encoding.Default.GetBytes(txt);
                byte[] newbuffer = mi.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder();
                for (int i = 0 ; i <newbuffer.Length; i++)
                {
                    sb.Append(newbuffer[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
