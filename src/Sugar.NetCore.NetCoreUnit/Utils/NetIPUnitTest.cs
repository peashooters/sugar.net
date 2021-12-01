using System;
using System.Collections.Generic;

namespace Sugar.NetCore.NetCoreUnit
{
    /// <summary>
    /// 关于IP的单元测试
    /// </summary>
    public class NetIPUnitTest : DefaultUnitTest
    {
        public override void Test()
        {
            //生成随机IP 并转换为数字
            var random = new Random();
            var ipArr = new List<string>();
            var numbers = new List<int>();
            for (int index = 0; index < 10; index++)
            {
                var host1 = random.Next(0, 256);
                var host2 = random.Next(0, 256);
                var host3 = random.Next(0, 256);
                var host4 = random.Next(0, 256);

                var ip = $"{host1}.{host2}.{host3}.{host4}";
                var number = NetString.ToInt32FromIp(ip);

                ipArr.Add(ip);
                numbers.Add(number);
            }

            var ipArrBackup = new List<string>();
            foreach (var number in numbers)
            {
                var ip = NetString.ToIpFromInt32(number);
                ipArrBackup.Add(ip);
            }
            //原始IP信息
            Console.WriteLine("原始IP信息：");
            foreach (var ip in ipArr)
            {
                Console.WriteLine(ip);
            }
            Console.WriteLine();
            //数字IP信息
            Console.WriteLine("数字IP信息：");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
            //字符IP信息
            Console.WriteLine("字符IP信息：");
            foreach (var ip in ipArrBackup)
            {
                Console.WriteLine(ip);
            }
        }
    }
}
