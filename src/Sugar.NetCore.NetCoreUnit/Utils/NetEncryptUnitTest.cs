using System;

namespace Sugar.NetCore.NetCoreUnit
{
    public class NetEncryptUnitTest : DefaultUnitTest
    {
        public override void Test()
        {
            //单元测试启动配置
            var value = "123456";

            Console.WriteLine("MD5To16：{0}", NetEncrypt.MD5To16(value));
            Console.WriteLine("MD5To32：{0}", NetEncrypt.MD5To32(value));
        }
    }
}
