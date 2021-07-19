using System;
using System.Collections.Generic;

namespace Sugar.NetCore
{
    public class NetEnum
    {
        /// <summary>
        /// 将当前枚举实例转为int32（Converts the current enumeration instance to int）
        /// </summary>
        /// <param name="value">枚举</param>
        public static int ToInt32(Enum value)
        {
            return value.ToInt32();
        }
        /// <summary>
        /// 获取特性 (DisplayAttribute) 的说明，如果未使用该特性，则返回String.Empty（Gets the description of the attribute (displayattribute); if not used, returns String.Empty）
        /// </summary>
        /// <param name="value">枚举</param>
        /// <returns></returns>
        public static string GetDescription(Enum value)
        {
            return value.GetDescription();
        }
        /// <summary>
        /// 获取枚举项
        /// </summary>
        /// <typeparam name="T">枚举泛型</typeparam>
        /// <returns></returns>
        public static List<EnumItem> GetItems<T>() where T : Enum
        {
            var items = new List<EnumItem>();
            var values = Enum.GetValues(typeof(T));
            foreach (var value in values)
            {
                var item = new EnumItem();

                var type = Enum.GetUnderlyingType(value.GetType());

                item.Key = value.ToString();
                switch (type.FullName)
                {
                    case "System.Byte":
                        item.Value = Convert.ToByte(value);
                        break;
                    case "System.SByte":
                        item.Value = Convert.ToSByte(value);
                        break;
                    case "System.Int16":
                        item.Value = Convert.ToInt16(value);
                        break;
                    case "System.UInt16":
                        item.Value = Convert.ToUInt16(value);
                        break;
                    case "System.Int32":
                        item.Value = Convert.ToInt32(value);
                        break;
                    case "System.UInt32":
                        item.Value = Convert.ToUInt32(value);
                        break;
                    case "System.Int64":
                        item.Value = Convert.ToInt64(value);
                        break;
                    case "System.UInt64":
                        item.Value = Convert.ToUInt64(value);
                        break;
                    default:
                        throw new ArgumentException("枚举数据类型无效，枚举数据类型仅允许：byte、sbyte、short、ushort、int、uint、long、ulong");
                }

                item.Desction = ((T)value).GetDescription();

                items.Add(item);
            }
            return items;
        }
    }
}
