using System;
using System.Text;

namespace Sugar.NetCore
{
    /// <summary>
    /// 人民币（RMB）
    /// </summary>
    public class NetRMB
    {
        #region ====属性（property）
        /// <summary>
        /// 中文（基础）数字
        /// </summary>
        private const string _chinese_numerals = "零壹贰叁肆伍陆柒捌玖";
        /// <summary>
        /// 中文数字单位
        /// </summary>
        private const string _chinese_numerals_unit = "元拾佰仟万拾佰仟亿拾佰仟兆拾佰仟万拾佰仟亿拾佰仟兆";
        /// <summary>
        /// 允许转换的最大值
        /// </summary>
        private const decimal MaxValue = 9999999999999999999999999.99m;
        /// <summary>
        /// 允许转换的最小值
        /// </summary>
        private const decimal MinValue = -9999999999999999999999999.99m;
        #endregion

        #region ====private functions
        /// <summary>
        /// 转换整数部分（Convert integer part）
        /// </summary>
        /// <param name="integer">整数</param>
        /// <returns></returns>
        private static string ConvertIntegerPart(string integer)
        {
            var length = integer.Length;    //总长度
            var currentLength = length;     //当前长度
            var zhNumber = string.Empty;    //数字
            var zhUnit = string.Empty;      //单位
            var builder = new StringBuilder();

            var index = 0;
            for (index = 0; index < length - 1; index++, currentLength--)
            {
                if (integer[index] != '0')
                {
                    zhNumber = ArabicNumeralsToChineseNumerals(integer[index]);
                    zhUnit = GetChineseNumeralsUnit(currentLength - 1);
                }
                else
                {
                    //万、亿、兆
                    if ((currentLength - 1) % 4 == 0)
                    {
                        zhNumber = "";
                        zhUnit = GetChineseNumeralsUnit(currentLength - 1);
                    }
                    else
                    {
                        zhUnit = string.Empty;
                        // 如果当前位是零，则需要判断它的下一位是否为零，再确定是否记录'零' 
                        if (integer[index + 1] != '0')
                        {
                            zhNumber = "零";
                        }
                        else
                        {
                            zhNumber = "";
                        }
                    }
                }
                builder.Append($"{zhNumber}{zhUnit}");
            }

            // 处理个位数据 
            if (integer[index] != '0')
                builder.Append(ArabicNumeralsToChineseNumerals(integer[index]));

            builder.Append("元");

            return FixUnit(builder.ToString());
        }
        /// <summary>
        /// 转换小数部分（Convert decimal part）
        /// </summary>
        /// <param name="decimalNumber">小数</param>
        /// <returns></returns>
        private static string ConvertDecimalPart(string decimalNumber)
        {
            var builder = new StringBuilder();

            if (decimalNumber == "0" || decimalNumber == "00") return "整";

            if (decimalNumber.Length > 1)
            {
                if (decimalNumber[0] == '0') //如果角位为零0.01
                {
                    builder.AppendFormat("{0}分", ArabicNumeralsToChineseNumerals(decimalNumber[1]));
                }
                else if (decimalNumber[1] == '0')
                {
                    builder.AppendFormat("{0}角整", ArabicNumeralsToChineseNumerals(decimalNumber[0]));
                }
                else
                {
                    builder.AppendFormat("{0}角", ArabicNumeralsToChineseNumerals(decimalNumber[0]));
                    builder.AppendFormat("{0}分", ArabicNumeralsToChineseNumerals(decimalNumber[1]));
                }
            }
            else
            {
                builder.AppendFormat("{0}角整", ArabicNumeralsToChineseNumerals(decimalNumber[0]));
            }

            return builder.ToString();
        }
        /// <summary>
        /// 阿拉伯（基础）数字转中文（基础）数字 （Arabic numerals To Chinese numerals）
        /// </summary>
        /// <param name="numerals">数字</param>
        /// <returns></returns>
        private static string ArabicNumeralsToChineseNumerals(char numerals)
        {
            return _chinese_numerals[numerals - '0'].ToString();
        }
        /// <summary>
        /// 获取中文数字单位
        /// </summary>
        /// <param name="digit">数字位</param>
        /// <returns></returns>
        private static string GetChineseNumeralsUnit(int digit)
        {
            return _chinese_numerals_unit[digit].ToString();
        }
        /// <summary>
        /// 单位调整
        /// </summary>
        /// <param name="numerals">数值</param>
        /// <returns></returns>
        private static string FixUnit(string numerals)
        {
            if (numerals.Contains("兆亿万"))
            {
                return numerals.Replace("兆亿万", "兆");
            }
            if (numerals.Contains("亿万"))
            {
                return numerals.Replace("亿万", "亿");
            }
            if (numerals.Contains("兆亿"))
            {
                return numerals.Replace("兆亿", "兆");
            }
            return numerals;
        }
        #endregion

        /// <summary>
        /// 转换成人民币大写形式（Convert to RMB in words）
        /// </summary>
        /// <param name="value">（数字）人民币</param>
        /// <returns></returns>
        public static string ToChineseText(decimal value)
        {
            if (value < MinValue || value > MaxValue)
                throw new ArgumentOutOfRangeException(null, $"数值超出可转换的范围（{MinValue}~{MaxValue}）(Number outside convertible range ({MinValue}~{MaxValue}))");

            var number = Math.Round(value, 2);
            var isminus = false;

            if (number == 0)
            {
                return "零元整";
            }
            else if (number < 0)   //如果是负数
            {
                isminus = true;
                number = Math.Abs(number);
            }
            else
            {
                isminus = false;
            }

            var numberString = number.ToString();
            var numberArray = numberString.Split('.');   // 分割为整数和小数
            
            var decimalNumber = string.Empty;               //小数部分 
            var integerNumber = string.Empty;               //整数部分
            var builder = new StringBuilder();              

            if (number >= 1m)
            {
                integerNumber = ConvertIntegerPart(numberArray[0]);
            }

            if (numberArray.Length > 1)
            {
                decimalNumber = ConvertDecimalPart(numberArray[1]);
            }
            else
            {
                decimalNumber = "整";
            }
            
            if (isminus == false) //是否负数
            {
                builder.Append($"{integerNumber}{decimalNumber}");
            }
            else
            {
                builder.Append($"负{integerNumber}{decimalNumber}");
            }
            return builder.ToString();
        }
        /// <summary>
        /// 转换成人民币大写形式（Convert to RMB in words）
        /// </summary>
        /// <param name="value">（数字）人民币</param>
        /// <returns></returns>
        public static string ToChineseText(int value)
        {
            return ToChineseText(Convert.ToDecimal(value));
        }
        /// <summary>
        /// 转换成人民币大写形式（Convert to RMB in words）
        /// </summary>
        /// <param name="value">（数字）人民币</param>
        /// <returns></returns>
        public static string ToChineseText(long value)
        {
            return ToChineseText(Convert.ToDecimal(value));
        }
        /// <summary>
        /// 转换成人民币大写形式（Convert to RMB in words）
        /// </summary>
        /// <param name="value">（数字）人民币</param>
        /// <returns></returns>
        public static string ToChineseText(string value)
        {
            return ToChineseText(Convert.ToDecimal(value));
        }
    }
}