using System;
using System.Text;

namespace Sugar.NetCore
{
    /// <summary>
    /// 字符串扩展（String Extension）
    /// </summary>
    public static class ExtString
    {
        /// <summary>
        /// 如果当前字符串实例为null，则将其转换为string.Empty（If the current string instance is null, it is converted to string.Empty）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static string ToEmptyIfNull(this String value)
        {
            return string.IsNullOrWhiteSpace(value) ? string.Empty : value;
        }
        /// <summary>
        /// 如果当前字符串实例为空白字符串，则将其转换为null（If the current string instance is whitespace or empty, it is converted to null）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static string ToNullIfEmpty(this String value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }
        /// <summary>
        /// 指示当前字符串实例是null、空还是仅由空格字符组成（Indicates whether the current string instance is null, empty, or only composed of space characters）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this String value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
        /// <summary>
        /// 指示当前字符串中是否存在任何值（Indicates whether any value exists in the current string）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static bool HasAnyValue(this String value)
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
        public static string ReplaceFirst(this String value,string oldValue, string newValue)
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
        public static string ReplaceLast(this String value, string oldValue, string newValue)
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
