using System;

namespace Sugar.NetCore.NetUnit
{
    public class NetDateTimeUnitTest : DefaultUnitTest
    {
        public override void Test()
        {
            //单元测试启动配置
            var datetime = DateTime.Now;
            var timestamp = "1625221744928";
            //ToTimeStamp
            Console.WriteLine("ToTimeStamp（Second）：{0}", NetDateTime.ToTimeStamp(datetime));
            Console.WriteLine("ToTimeStamp（Millisecond）：{0}", NetDateTime.ToTimeStamp(datetime, TimeStampUnit.MilliSecond));
            //ToDateTime
            Console.WriteLine("ToDateTime：{0}", NetDateTime.ToDateTime(timestamp));
            //Get
            Console.WriteLine("GetFirstDayOfWeek：{0}", NetDateTime.GetFirstDayOfWeek(datetime));
            Console.WriteLine("GetLastDayOfWeek：{0}", NetDateTime.GetLastDayOfWeek(datetime));
            Console.WriteLine("GetFirstDayOfMonth：{0}", NetDateTime.GetFirstDayOfMonth(datetime));
            Console.WriteLine("GetLastDayOfMonth：{0}", NetDateTime.GetLastDayOfMonth(datetime));
        }
    }
}
