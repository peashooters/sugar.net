using System;

namespace Sugar.NetCore
{
    /// <summary>
    /// 时间扩展（DateTime Extension）
    /// </summary>
    public static class ExtDateTime
    {
        #region ====属性（property）
        /// <summary>
        /// 时间戳计算起始时间
        /// </summary>
        private static readonly DateTime _unix_init_time = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        #endregion

        /// <summary>
        /// 获取当前DateTime实例的时间戳（Gets the timestamp of the current time instance）
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit">精确单位</param>
        /// <returns></returns>
        public static long ToUtcTimeStamp(this DateTime value, TimeStampUnit unit = TimeStampUnit.Second)
        {
#if NETSTANDARD1_0 || NETSTANDARD1_1 || NETSTANDARD1_2 || NETSTANDARD1_3 || NETSTANDARD1_4 || NETSTANDARD1_5 || NETSTANDARD1_6
            var timespan = value.ToUniversalTime() - _unix_init_time;
#else
            var timespan = TimeZoneInfo.ConvertTimeToUtc(value) - _unix_init_time;
#endif
            if (unit == TimeStampUnit.Second)
                return Convert.ToInt64(timespan.TotalSeconds);
            else
                return Convert.ToInt64(timespan.TotalMilliseconds);
        }
    }
}
