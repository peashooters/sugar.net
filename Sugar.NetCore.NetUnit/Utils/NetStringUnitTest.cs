using System;

namespace Sugar.NetCore.NetUnit
{
    public class NetStringUnitTest : DefaultUnitTest
    {
        public override void Test()
        {
            //单元测试启动配置
            //单元测试启动配置
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
        }
    }
}
