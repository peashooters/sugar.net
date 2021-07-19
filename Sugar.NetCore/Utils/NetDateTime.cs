using System;

namespace Sugar.NetCore
{
    /// <summary>
    /// 时间帮助类（DateTime Helper）
    /// </summary>
    public class NetDateTime
    {
        #region ====属性（property）
        /// <summary>
        /// 时间戳起始时间
        /// </summary>
        private static readonly DateTime _unix_init_time = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        #endregion

        /// <summary>
        /// 时间转为时间戳（datetime to timestamp）
        /// </summary>
        /// <param name="value">时间</param>
        /// <param name="unit">单位</param>
        /// <returns></returns>
        public static long ToTimeStamp(DateTime value, TimeStampUnit unit = TimeStampUnit.Second)
        {
            return value.ToUtcTimeStamp(unit);
        }
        /// <summary>
        /// 时间戳转为时间（timestamp to datetime）
        /// </summary>
        /// <param name="value">时间戳</param>
        /// <returns></returns>
        public static DateTime ToDateTime(long value)
        {
#if NETSTANDARD1_0 || NETSTANDARD1_1 || NETSTANDARD1_2 || NETSTANDARD1_3 || NETSTANDARD1_4 || NETSTANDARD1_5 || NETSTANDARD1_6
            var localInitTime = _unix_init_time.ToLocalTime();
#else
            var localInitTime = TimeZoneInfo.ConvertTimeFromUtc(_unix_init_time, TimeZoneInfo.Local);
#endif
            var timestamp = value.ToString();

            if (timestamp.Length == 10)
                return localInitTime.AddSeconds(value);
            else
                return localInitTime.AddMilliseconds(value);
        }
        /// <summary>
        /// 时间戳转为时间（timestamp to datetime）
        /// </summary>
        /// <param name="value">时间戳</param>
        /// <returns></returns>
        public static DateTime ToDateTime(string value)
        {
            return ToDateTime(Convert.ToInt64(value));
        }
    }
}