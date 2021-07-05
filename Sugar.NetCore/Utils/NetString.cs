using System;
using System.Text;

namespace Sugar.NetCore
{
    public static class NetString
    {
        #region ====属性（property）
        /// <summary>
        /// 数字
        /// </summary>
        private const string _number = "1234567890";
        /// <summary>
        /// 英文
        /// </summary>
        private const string _character = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        /// <summary>
        /// 特殊字符
        /// </summary>
        private const string _special_characters = "~!@#$%^&*()_+`-={}|:<>?[];',./\"\\";
        #endregion

        /// <summary>
        /// GUID（Globally Unique Identifier）
        /// </summary>
        public static string GUID
        {
            get
            {
                return System.Guid.NewGuid().ToString();
            }
        }
        /// <summary>
        /// UNID，没有分隔符的GUID（Globally Unique Identifier，No Separator）
        /// </summary>
        public static string UNID
        {
            get
            {
                return System.Guid.NewGuid().ToString().Replace("-", "");
            }
        }
        /// <summary>
        /// 生成随机字符串（Generate random strings）
        /// </summary>
        /// <param name="minlength">最小长度</param>
        /// <param name="maxlength">最大长度</param>
        /// <param name="rule">生成规则</param>
        /// <returns></returns>
        public static string RandomString(int minlength, int maxlength, StringRandomRule rule = StringRandomRule.Normal)
        {
            var seed = new StringBuilder();

            if (minlength > maxlength)
                throw new ArgumentOutOfRangeException("“minlength”不能大于“maxlength”（'minlength' cannot be greater than 'maxlength'）");
            
            switch (rule)
            {
                case StringRandomRule.Number:
                    seed.Append(_number);
                    break;
                case StringRandomRule.Characters:
                    seed.Append(_character);
                    break;
                case StringRandomRule.NumbersAndCharacters:
                    seed.Append(_number);
                    seed.Append(_character);
                    break;
                default:
                    seed.Append(_number);
                    seed.Append(_character);
                    seed.Append(_special_characters);
                    break;
            }

            var builder = new StringBuilder();
            var seedString = seed.ToString();
            var random = new Random(Guid.NewGuid().GetHashCode());

            int length = minlength;
            if (minlength != maxlength)
                length = random.Next(minlength, maxlength + 1);

            for (int index = 0; index < length; index++)
            {
                var charIndex = random.Next(0, seedString.Length);
                builder.Append(seedString.Substring(charIndex, 1));
            }

            return builder.ToString();
        }
    }
}
