namespace Sugar.NetCore.NetUnit
{
    /// <summary>
    /// 单元测试基类
    /// </summary>
    public abstract class DefaultUnitTest
    {
        /// <summary>
        /// 单元测试主体
        /// </summary>
        public abstract void Test();
        /// <summary>
        /// 单元测试启动配置
        /// </summary>
        public virtual void Setup()
        {
        }
        /// <summary>
        /// 单元测试执行
        /// </summary>
        public virtual void Start()
        {
            Setup();
            Test();
        }
    }
}
