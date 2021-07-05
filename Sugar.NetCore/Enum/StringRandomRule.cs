namespace Sugar.NetCore
{
    /// <summary>
    /// 字符串随机规则（String Random Rule）
    /// </summary>
    public enum StringRandomRule
    {
        /// <summary>
        /// 由数字、英文字符、特殊字符组成随机字符串（Numbers And Characters And Special characters）
        /// </summary>
        Normal,
        /// <summary>
        /// 由数字组成随机字符串（Number）
        /// </summary>
        Number,
        /// <summary>
        /// 由英文字符组成随机字符串（Characters）
        /// </summary>
        Characters,
        /// <summary>
        /// 由数字、英文字符组成随机字符串（Numbers And Characters）
        /// </summary>
        NumbersAndCharacters,
    }
}
