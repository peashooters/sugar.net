namespace Sugar.NetCore
{
    /// <summary>
    /// 枚举项
    /// </summary>
    public class EnumItem
    {
        /// <summary>  
        /// 枚举的描述  
        /// </summary>  
        public string Desction { set; get; }
        /// <summary>  
        /// 枚举名称  
        /// </summary>  
        public string Key { set; get; }
        /// <summary>  
        /// 枚举对象的值
        /// </summary>  
        public dynamic Value { set; get; }
    }
}
