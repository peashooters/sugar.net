using System;

namespace Sugar.NetCore.NetUnit
{
    public class ExtDateTimeUnitTest : DefaultUnitTest
    {
        public override void Test()
        {
            //
            var datetime = new DateTime(1970, 1, 1, 8, 0, 0, DateTimeKind.Utc);
            //ToUtcTimeStamp
            Console.WriteLine($"ToUtcTimeStamp（Second）：{datetime.ToUtcTimeStamp()}");
            Console.WriteLine("ToUtcTimeStamp（Millisecond）：{0}", datetime.ToUtcTimeStamp(TimeStampUnit.MilliSecond));
        }
    }
}
