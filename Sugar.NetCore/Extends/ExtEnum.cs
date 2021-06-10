using System;
using System.Reflection;

namespace Sugar.NetCore
{
    /// <summary>
    /// 枚举扩展（Enum Extension）
    /// </summary>
    public static class ExtEnum
    {
        /// <summary>
        /// 将当前枚举实例转为int32（Converts the current enumeration instance to int）
        /// </summary>
        /// <param name="value">枚举</param>
        public static int ToInt32(this Enum value)
        {
            var type = Enum.GetUnderlyingType(value.GetType());

            if (!type.FullName.Equals("System.Int32", StringComparison.OrdinalIgnoreCase))
                throw new SugarException($"无法将{type.FullName}转为System.Int32（Unable to convert {type.FullName} to System.Int32）");
   
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// 获取特性 (DisplayAttribute) 的说明，如果未使用该特性，则返回String.Empty（Gets the description of the attribute (displayattribute); if not used, returns String.Empty）
        /// </summary>
        /// <param name="value">枚举</param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
#if NET40
            var member = value.GetType().GetField(value.ToString());
#else
            var member = value.GetType().GetRuntimeField(value.ToString());
#endif
            if (member == null) return string.Empty;
#if NETSTANDARD1_0 || NETSTANDARD1_1 || NETSTANDARD1_2 || NETSTANDARD1_3 || NETSTANDARD1_4 || NETSTANDARD1_5 || NETSTANDARD1_6
            var attrs = (Sugar.NetCore.DescriptionAttribute[])member.GetCustomAttributes(typeof(Sugar.NetCore.DescriptionAttribute), false);
#else
            var attrs = (System.ComponentModel.DescriptionAttribute[])member.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false) as System.ComponentModel.DescriptionAttribute[];
#endif
            return (attrs != null && attrs.Length > 0) ? attrs[0].Description : string.Empty;
        }
    }
}
