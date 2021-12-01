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

        /// <summary>
        /// 获取当月第一天（Get the first day of the month）
        /// </summary>
        /// <param name="value">时间</param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfMonth(DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1);
        }
        /// <summary>
        /// 获取当月最后一天（Get the last day of the month）
        /// </summary>
        /// <param name="value">时间</param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(DateTime value)
        {
            var firstDayOfMonth = new DateTime(value.Year, value.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            return lastDayOfMonth;
        }
        /// <summary>
        /// 获取当周第一天（Get the first day of the week）
        /// </summary>
        /// <param name="value">时间</param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfWeek(DateTime value)
        {
            var week = Convert.ToInt32(value.DayOfWeek);
            week = (week == 0 ? (7 - 1) : (week - 1));
            var firstDayOfWeek = value.AddDays((-1) * week);
            return new DateTime(firstDayOfWeek.Year, firstDayOfWeek.Month, firstDayOfWeek.Day);
        }
        /// <summary>
        /// 获取当周最后一天（Get the last day of the week）
        /// </summary>
        /// <param name="value">时间</param>
        /// <returns></returns>
        public static DateTime GetLastDayOfWeek(DateTime value)
        {
            var week = Convert.ToInt32(value.DayOfWeek);
            week = week == 0 ? (7 - week) : week;
            var lastDayOfWeek = value.AddDays(7 - week);
            return new DateTime(lastDayOfWeek.Year, lastDayOfWeek.Month, lastDayOfWeek.Day);
        }

    }
}