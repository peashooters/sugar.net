using System;

namespace Sugar.NetCore.NetCoreUnit
{
    public class NetRMBUnitTest : DefaultUnitTest
    {
        public override void Test()
        {
            //decimal
            var @decimal = 9999999999999999999999999.99m;
            var strText = NetRMB.ToChineseText(@decimal);
            Console.WriteLine(strText);
            var strValue = "9090909090909090909090909.99";
            strText = NetRMB.ToChineseText(strValue);
            Console.WriteLine(strText);

            var @int32 = (int)999999999;
            strText = NetRMB.ToChineseText(@int32);
            Console.WriteLine(strText);

            var @int64 = 999999999;
            strText = NetRMB.ToChineseText(@int64);
            Console.WriteLine(strText);

        }
    }
}
