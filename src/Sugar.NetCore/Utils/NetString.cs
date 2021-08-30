using System;
using System.Text;

namespace Sugar.NetCore
{
    /// <summary>
    /// 字符串帮助类（String Helper）
    /// </summary>
    public class NetString
    {
        #region ====属性（property）
        /// <summary>
        /// 数字
        /// </summary>
        private const string _number = "1234567890";
        /// <summary>
        /// 英文
        /// </summary>
        private const string _character = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        /// <summary>
        /// 特殊字符
        /// </summary>
        private const string _special_characters = "~!@#$%^&*()_+`-={}|:<>?[];',./\"\\";
        #endregion

        /// <summary>
        /// GUID（Globally Unique Identifier）
        /// </summary>
        public static string GUID
        {
            get
            {
                return System.Guid.NewGuid().ToString();
            }
        }
        /// <summary>
        /// UNID，没有分隔符的GUID（Globally Unique Identifier，No Separator）
        /// </summary>
        public static string UNID
        {
            get
            {
                return System.Guid.NewGuid().ToString().Replace("-", "");
            }
        }

        #region ====随机字符串（RandomString）
        /// <summary>
        /// 生成随机字符串（Generate random strings）
        /// </summary>
        /// <param name="minlength">最小长度</param>
        /// <param name="maxlength">最大长度</param>
        /// <param name="rule">生成规则</param>
        /// <returns></returns>
        public static string RandomString(int minlength, int maxlength, StringRandomRule rule = StringRandomRule.Normal)
        {
            var seed = new StringBuilder();

            if (minlength > maxlength)
                throw new ArgumentOutOfRangeException(null,"“minlength”不能大于“maxlength”（'minlength' cannot be greater than 'maxlength'）");
            
            switch (rule)
            {
                case StringRandomRule.Number:
                    seed.Append(_number);
                    break;
                case StringRandomRule.Characters:
                    seed.Append(_character);
                    break;
                case StringRandomRule.NumbersAndCharacters:
                    seed.Append(_number);
                    seed.Append(_character);
                    break;
                default:
                    seed.Append(_number);
                    seed.Append(_character);
                    seed.Append(_special_characters);
                    break;
            }

            var builder = new StringBuilder();
            var seedString = seed.ToString();
            var random = new Random(Guid.NewGuid().GetHashCode());

            int length = minlength;
            if (minlength != maxlength)
                length = random.Next(minlength, maxlength + 1);

            for (int index = 0; index < length; index++)
            {
                var charIndex = random.Next(0, seedString.Length);
                builder.Append(seedString.Substring(charIndex, 1));
            }

            return builder.ToString();
        }
        /// <summary>
        /// 生成随机字符串（Generate random strings）
        /// </summary>
        /// <param name="length">长度</param>
        /// <param name="rule">生成规则</param>
        /// <returns></returns>
        public static string RandomString(int length, StringRandomRule rule = StringRandomRule.Normal)
        {
            return RandomString(length, length, rule);
        }
        /// <summary>
        /// 生成随机数字（Generate random numbers）
        /// </summary>
        /// <param name="minlength">最小长度</param>
        /// <param name="maxlength">最大长度</param>
        /// <returns></returns>
        public static string RandomNumber(int minlength, int maxlength)
        {
            return RandomString(minlength, maxlength, StringRandomRule.Number);
        }
        /// <summary>
        /// 生成随机数字（Generate random numbers）
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string RandomNumber(int length)
        {
            return RandomString(length, length, StringRandomRule.Number);
        }
        /// <summary>
        /// 生成随机英文字符（Generate random characters）
        /// </summary>
        /// <param name="minlength">最小长度</param>
        /// <param name="maxlength">最大长度</param>
        /// <returns></returns>
        public static string RandomCharacters(int minlength, int maxlength)
        {
            return RandomString(minlength, maxlength, StringRandomRule.Characters);
        }
        /// <summary>
        /// 生成随机英文字符（Generate random characters）
        /// </summary>
        /// <param name="length">长度</param>
        public static string RandomCharacters(int length)
        {
            return RandomString(length, length, StringRandomRule.Characters);
        }
        #endregion

        #region ====字符串转换
        /// <summary>
        /// 使用utf8编码格式将字符串转换为Base64字符串（Converts a string to a Base64 string using utf8 encoding format）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static string ToBase64(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }
        /// <summary>
        /// 使用指定的编码格式将字符串转换为Base64字符串（Converts a string to a Base64 string using the specified encoding format）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string ToBase64(string value, Encoding encoding)
        {
            var bytes = encoding.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }
        /// <summary>
        /// 如果当前字符串实例为null，则将其转换为string.Empty（If the current string instance is null, it is converted to string.Empty）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static string ToEmptyIfNull(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? string.Empty : value;
        }
        /// <summary>
        /// IP地址转换为Int64（From IP address to Int64）
        /// </summary>
        /// <param name="value">ip</param>
        /// <returns></returns>
        public static long ToInt64FromIp(string value)
        {
            var hosts = value.Split('.');

            if (hosts.Length != 4)
                throw new ArgumentOutOfRangeException("IP地址格式错误（IP address format error）");

            var number = Convert.ToInt64(hosts[0]) << 24 | Convert.ToInt64(hosts[1]) << 16 | Convert.ToInt64(hosts[2]) << 8 | Convert.ToInt64(hosts[3]);

            return number;
        }
        /// <summary>
        /// Int64转换为IP地址（From Int64 to IP address）
        /// </summary>
        /// <param name="value">ip</param>
        /// <returns></returns>
        public static string ToIpFromInt64(long value)
        {
            var builder = new StringBuilder();
            builder.Append(value >> 0x18 & 0xff).Append(".");
            builder.Append(value >> 0x10 & 0xff).Append(".");
            builder.Append(value >> 0x8 & 0xff).Append(".");
            builder.Append(value & 0xff);
            return builder.ToString();
        }
        /// <summary>
        /// IP地址转换为UInt32（From IP address to UInt32）
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static uint ToUInt32FromIp(string value)
        {
            var hosts = value.Split('.');

            if (hosts.Length != 4)
                throw new ArgumentOutOfRangeException("IP地址格式错误（IP address format error）");

            var number = 0xFFFFFF00 | byte.Parse(hosts[3]);
            number = number & 0xFFFF00FF | (uint.Parse(hosts[2]) << 0x8);
            number = number & 0xFF00FFFF | (uint.Parse(hosts[1]) << 0x10);
            number = number & 0x00FFFFFF | (uint.Parse(hosts[0]) << 0x18);
            return number;
        }
        /// <summary>
        /// UInt32转换为IP地址（From UInt32 to IP address）
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToIpFromUInt32(uint value)
        {
            var builder = new StringBuilder();
            builder.Append((value & 0xFF000000) >> 0x18).Append(".");
            builder.Append((value & 0x00FF0000) >> 0x10).Append(".");
            builder.Append((value & 0x0000FF00) >> 0x8).Append(".");
            builder.Append(value & 0x000000FF);
            return builder.ToString();
        }
        /// <summary>
        /// 如果当前字符串实例为空白字符串，则将其转换为null（If the current string instance is whitespace or empty, it is converted to null）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static string ToNullIfEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }
        /// <summary>
        /// 使用utf8编码格式将Base64字符串转换为字符串（Convert Base64 string to string using utf8 encoding format）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static string FromBase64(string value)
        {
            var bytes = Convert.FromBase64String(value);
#if NETSTANDARD1_0 || NETSTANDARD1_1 || NETSTANDARD1_2
            return Encoding.UTF8.GetString(bytes,0,bytes.Length);
#else
            return Encoding.UTF8.GetString(bytes);
#endif
        }
        /// <summary>
        /// 使用指定的编码格式将Base64字符串转换为字符串（Converts a Base64 string to a string using the specified encoding format）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string FromBase64(string value, Encoding encoding)
        {
            var bytes = Convert.FromBase64String(value);
#if NETSTANDARD1_0 || NETSTANDARD1_1 || NETSTANDARD1_2
            return encoding.GetString(bytes, 0, bytes.Length);
#else
            return encoding.GetString(bytes);
#endif
        }
        #endregion

        /// <summary>
        /// 指示当前字符串中是否存在任何值（Indicates whether any value exists in the current string）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static bool HasAnyValue(string value)
        {
            return value != null && value.Length != 0;
        }
        /// <summary>
        /// 返回一个新字符串，其中指定的Unicode字符在此实例中的第一个匹配项被另一个指定的Unicode字符替换（Returns a new string in which the first occurrence of the specified Unicode character in this instance is replaced by another specified Unicode character）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="oldValue">要替换的Unicode字符（The Unicode character to be replaced）</param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string ReplaceFirst(string value, string oldValue, string newValue)
        {
            var index = value.IndexOf(oldValue);
            if (index < 0) return value;

            var builder = new StringBuilder(value.Length - oldValue.Length + newValue.Length);
            builder.Append(value.Substring(0, index));
            builder.Append(newValue);
            builder.Append(value.Substring(index + oldValue.Length, value.Length - index - oldValue.Length));

            return builder.ToString();
        }
        /// <summary>
        /// 返回一个新字符串，其中指定的Unicode字符在此实例中的最后一个匹配项被另一个指定的Unicode字符替换（Returns a new string in which the last occurrence of the specified Unicode character in this instance is replaced by another specified Unicode character）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="oldValue">要替换的Unicode字符（The Unicode character to be replaced）</param>
        /// <param name="newValue">用于替换第一个匹配oldchar的Unicode字符（The Unicode character used to replace the first matching oldchar）</param>
        /// <returns></returns>
        public static string ReplaceLast(string value, string oldValue, string newValue)
        {
            var index = value.LastIndexOf(oldValue);
            if (index < 0) return value;

            var builder = new StringBuilder(value.Length - oldValue.Length + newValue.Length);
            builder.Append(value.Substring(0, index));
            builder.Append(newValue);
            builder.Append(value.Substring(index + oldValue.Length, value.Length - index - oldValue.Length));

            return builder.ToString();
        }
    }
}
