using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Sugar.NetCore
{
    class Document
    {
        public void Example()
        {
            var value = "sugar.net";
            //将当字符串为null时，转为string.Empty
            var empty = NetString.ToEmptyIfNull(value);
            //将当字符串为string.Empty时，转为null
            var nullValue = NetString.ToNullIfEmpty(value);
            //判断字符串是否存在任何值
            var hasAnyValue = NetString.HasAnyValue(value);
            //替换首个字符
            var first = NetString.ReplaceFirst(value, "s", "a");
            //替换结尾字符
            var last = NetString.ReplaceLast(value, "t", "a");

            //生成一个GUID
            var guid = NetString.GUID;
            //生成一个UNID（除去短横线的GUID）
            var unid = NetString.UNID;
            //生成一个1到10位的随机字符串（含有数字、英文、特殊字符）
            var randomString1 = NetString.RandomString(1, 10, StringRandomRule.Normal);
            //生成一个1到10位的随机字符串（仅含英文）
            var randomString2 = NetString.RandomString(1, 10, StringRandomRule.Characters);
            //生成一个1到10位的随机字符串（仅含数字）
            var randomString3 = NetString.RandomString(1, 10, StringRandomRule.Number);
            //生成一个1到10位的随机字符串（含有数字、英文）
            var randomString4 = NetString.RandomString(1, 10, StringRandomRule.NumbersAndCharacters);
            //生成10位随机字符串（含有数字、英文、特殊字符）
            var randomString5 = NetString.RandomString(10, StringRandomRule.Normal);
            //生成10位随机字符串（含有数字、英文、特殊字符）
            var randomString6 = NetString.RandomString(10, StringRandomRule.Normal);
            //生成10位随机字符串（仅含数字）
            var randomNumber1 = NetString.RandomNumber(10);
            //生成1到10位随机字符串（仅含数字）
            var randomNumber2 = NetString.RandomNumber(1, 10);
            //生成10位随机字符串（仅含英文）
            var randomCharacters1 = NetString.RandomCharacters(10);
            //生成1到10位随机字符串（仅含英文）
            var randomCharacters = NetString.RandomCharacters(1, 10);

            //转为Base64编码字符串
            var base64 = NetString.ToBase64(value);
            //转为Base64编码字符串（指定编码字符集）
            var gbkBase64 = NetString.ToBase64(value, System.Text.Encoding.GetEncoding("GBK"));
            //从base64字符串转回
            var output = NetString.FromBase64(base64);
            //从base64字符串转回（指定编码字符集）
            var gbkOutput = NetString.FromBase64(gbkBase64, System.Text.Encoding.GetEncoding("GBK"));

            //ip转为Int64
            value = "192.168.1.1";
            var number1 = NetString.ToInt64FromIp(value);
            //int64转回ip
            var ipNumber1 = (long)2130706433;
            var ipValue1 = NetString.ToIpFromInt64(ipNumber1);
            //ip转为UInt32
            value = "192.168.1.1";
            var number2 = NetString.ToUInt32FromIp(value);
            //int64转回ip
            var ipNumber2 = (uint)2130706433;
            var ipValue2 = NetString.ToIpFromInt64(ipNumber2);
        }
    }
}
