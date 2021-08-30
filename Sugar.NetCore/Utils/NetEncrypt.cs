#if NETSTANDARD1_3 || NETSTANDARD1_4 || NETSTANDARD1_5 || NETSTANDARD1_6 || NETSTANDARD2_0 || NETSTANDARD2_1 || NET40 || NET45 || NET46 || NET47 || NET48
using System.Security.Cryptography;
using System.Text;

namespace Sugar.NetCore
{
    /// <summary>
    /// 加密帮助类（Encrypt Helper）
    /// </summary>
    public class NetEncrypt
    {
#region ====private functions
        /// <summary>
        /// MD5计算指定字符串哈希值
        /// </summary>
        /// <param name="input"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private static byte[] MD5ComputeHash(string input, Encoding encoding = null)
        {

            //编码格式
            encoding = encoding ?? Encoding.UTF8;
            using (var provider = MD5.Create())
            {
                return provider.ComputeHash(encoding.GetBytes(input));
            }
        }
#endregion

#region ====MD5
        /// <summary>
        /// MD5加密字符串并得到16位的结果（MD5 encrypts the string and gets a 16 byte result）
        /// </summary>
        /// <param name="input">加密字符串</param>
        public static string MD5To16(string input)
        {
            var ciphertext = MD5To32(input);
            return ciphertext.Substring(8, 16);
        }
        /// <summary>
        /// MD5加密字符串并得到32位的结果（MD5 encrypts the string and gets a 32 byte result）
        /// </summary>
        /// <param name="input">加密字符串</param>
        public static string MD5To32(string input)
        {
            var bytes = MD5ComputeHash(input, Encoding.UTF8);
            var builder = new StringBuilder();
            foreach (var byteValue in bytes)
                builder.Append(byteValue.ToString("x2"));
            return builder.ToString();
        }
#endregion
    }
}
#endif