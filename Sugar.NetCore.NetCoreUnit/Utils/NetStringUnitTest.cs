using System;

namespace Sugar.NetCore.NetCoreUnit
{
    public class NetStringUnitTest : DefaultUnitTest
    {
        public override void Test()
        {
            //单元测试启动配置
            string value = null;
            Console.WriteLine("测试value为：(null)");
            Console.WriteLine("ToEmptyIfNull：{0}", NetString.ToEmptyIfNull(value));
            Console.WriteLine("ToNullIfEmpty：{0}", NetString.ToNullIfEmpty(value));
            Console.WriteLine("HasAnyValue：{0}", NetString.HasAnyValue(value));

            value = "    ";
            Console.WriteLine("ToEmptyIfNull：{0}", NetString.ToEmptyIfNull(value));
            Console.WriteLine("ToNullIfEmpty：{0}", NetString.ToNullIfEmpty(value));
            Console.WriteLine("HasAnyValue：{0}", NetString.HasAnyValue(value));
            value = "aaaabaaaabaaaabaaaab";
            Console.WriteLine($"测试value为：({value})");
            Console.WriteLine($"ReplaceFirst：({value.ReplaceFirst("a", "c")})");
            Console.WriteLine($"ReplaceLast：({value.ReplaceLast("a", "c")})");


            Console.WriteLine();
            Console.WriteLine("GUID：{0}", NetString.GUID);
            Console.WriteLine("UNID：{0}", NetString.UNID);
            Console.WriteLine("RandomString（Normal）：{0}", NetString.RandomString(1, 10, StringRandomRule.Normal));
            Console.WriteLine("RandomString（Characters）：{0}", NetString.RandomString(1, 10, StringRandomRule.Characters));
            Console.WriteLine("RandomString（Number）：{0}", NetString.RandomString(1, 10, StringRandomRule.Number));
            Console.WriteLine("RandomString（NumbersAndCharacters）：{0}", NetString.RandomString(1, 10, StringRandomRule.NumbersAndCharacters));
            Console.WriteLine("RandomString（Normal）：{0}", NetString.RandomString(10, StringRandomRule.Normal));
            Console.WriteLine();
            Console.WriteLine("RandomNumber（10）：{0}", NetString.RandomNumber(10));
            Console.WriteLine("RandomNumber（1-10）：{0}", NetString.RandomNumber(1, 10));
            Console.WriteLine("RandomCharacters（10）：{0}", NetString.RandomCharacters(10));
            Console.WriteLine("RandomCharacters（1-10）：{0}", NetString.RandomCharacters(1, 10));

            value = "测试字符串";
            var utf8Base64 = NetString.ToBase64(value);
            //var defaultBase64 = NetString.ToBase64(value, System.Text.Encoding.Default);
            var gbkBase64 = NetString.ToBase64(value, System.Text.Encoding.GetEncoding("GBK"));
            var gb2312Base64 = NetString.ToBase64(value, System.Text.Encoding.GetEncoding("GB2312"));
            Console.WriteLine();
            Console.WriteLine("ToBase64：{0}", utf8Base64);
            //Console.WriteLine("ToBase64（Encoding.Default）：{0}", defaultBase64);
            Console.WriteLine("ToBase64（GBK）：{0}", gbkBase64);
            Console.WriteLine("ToBase64（GB2312）：{0}", gb2312Base64);

            Console.WriteLine("FromBase64：{0}", NetString.FromBase64(utf8Base64));
            //Console.WriteLine("FromBase64（Encoding.Default）：{0}", NetString.FromBase64(defaultBase64, System.Text.Encoding.Default));
            Console.WriteLine("FromBase64（GBK）：{0}", NetString.FromBase64(gbkBase64, System.Text.Encoding.GetEncoding("GBK")));
            Console.WriteLine("FromBase64（GB2312）：{0}", NetString.FromBase64(gb2312Base64, System.Text.Encoding.GetEncoding("GB2312")));


            value = "192.168.1.1";
            var lip = NetString.ToInt64FromIp(value);
            Console.WriteLine("ToInt64FromIp：{0}", lip);
            Console.WriteLine("ToIpFromInt64：{0}", NetString.ToIpFromInt64(lip));


            value = "192.168.1.1";
            var uip = NetString.ToUInt32FromIp(value);
            Console.WriteLine("ToInt64FromIp：{0}", uip);
            Console.WriteLine("ToIpFromInt64：{0}", NetString.ToIpFromUInt32(uip));
        }
    }
}
