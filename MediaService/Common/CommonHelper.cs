using System.Security.Cryptography;
using System.Text;

namespace MediaService.Common
{
    public class CommonHelper
    {
        /// <summary>
        /// 对字符串加密
        /// </summary>
        /// <param name="passwordAndSalt"></param>
        /// <returns></returns>
        public static string EncryptPassword(string passwordAndSalt)
        {
            MD5 md5 = MD5.Create();
            byte[] passwordAndSaltBytes = System.Text.Encoding.UTF8.GetBytes(passwordAndSalt);
            byte[] hs = md5.ComputeHash(passwordAndSaltBytes);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hs)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

    }
}
