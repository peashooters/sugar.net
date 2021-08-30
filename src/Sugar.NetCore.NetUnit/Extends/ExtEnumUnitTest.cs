using System;
using System.ComponentModel;
using Sugar.NetCore;

namespace Sugar.NetCore.NetUnit
{
    public class ExtEnumUnitTest : DefaultUnitTest
    {
        public override void Test()
        {
            //单元测试启动配置
            var iAmHappy = AreYouHappy.Yes;
            //ToInt
            Console.WriteLine("ToInt32：{0}", iAmHappy.ToInt32());
            //GetDescription
            Console.WriteLine("GetDescription：{0}", iAmHappy.GetDescription());
        }
    }

    #region ====测试枚举（test enum）
    public enum AreYouHappy
    {
        [Description("No, I'm not happy")]
        No = 0,
        [Description("Yes, I'm happy")]
        Yes = 1,
    }
    #endregion
}
