using System;
using System.ComponentModel;

namespace Sugar.NetCore.NetCoreUnit
{
    public class NetEnumUnitTest : DefaultUnitTest
    {
        public override void Test()
        {
            //单元测试启动配置
            //ToInt
            Console.WriteLine("ToInt32：{0}", NetEnum.ToInt32(AreYouOK.Yes));
            //GetDescription
            Console.WriteLine("GetDescription：{0}", NetEnum.GetDescription(AreYouOK.Yes));
            //GetDescription
            var items = NetEnum.GetItems<AreYouOK>();
        }
    }

    #region ====测试枚举（test enum）
    public enum AreYouOK : int
    {
        [Description("No, I'm not happy")]
        No = 0,
        [Description("Yes, I'm happy")]
        Yes = 1,
    }
    #endregion
}
