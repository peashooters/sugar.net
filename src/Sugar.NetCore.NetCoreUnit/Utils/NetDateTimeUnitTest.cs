using System;

namespace Sugar.NetCore.NetCoreUnit
{
    public class NetDateTimeUnitTest : DefaultUnitTest
    {
        public override void Test()
        {
            //单元测试启动配置
            var datetime = DateTime.Now;
            var timestamp = "1625221744928";

            Console.WriteLine("ToTimeStamp（Second）：{0}", NetDateTime.ToTimeStamp(datetime));
            Console.WriteLine("ToTimeStamp（Millisecond）：{0}", NetDateTime.ToTimeStamp(datetime, TimeStampUnit.MilliSecond));

            //GetDescription
            Console.WriteLine("ToDateTime：{0}", NetDateTime.ToDateTime(timestamp));
        }
    }
}
