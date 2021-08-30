using System;
using System.Reflection;
using System.Text;

namespace Sugar.NetCore.NetCoreUnit
{
    class Program
    {
        static void Main(string[] args)
        {
            //注册编码提供程序
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //针对xxx进行单元测试
            var type = typeof(NetStringUnitTest);
            Console.WriteLine("执行单元测试：{0}", type.Name);
            Console.WriteLine();

#if NETCOREAPP1_0 || NETCOREAPP1_1
            var unitTestInstance = Assembly.Load(new AssemblyName(type.Namespace)).CreateInstance(type.FullName) as DefaultUnitTest;
#else
            var unitTestInstance = type.Assembly.CreateInstance(type.FullName) as DefaultUnitTest;
#endif
            //创建单元测试实例
            unitTestInstance.Start();
            //
            Console.WriteLine();
            Console.WriteLine("请按任意键继续...");
            Console.ReadKey();
        }
    }
}
