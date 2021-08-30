using System;

namespace Sugar.NetCore.NetCoreUnit
{
    public class ExtStringUnitTest : DefaultUnitTest
    {
        public override void Test()
        {
            string value = null;
            Console.WriteLine("测试value为：(null)");
            //ToEmptyIfNull、ToNullIfEmpty
            Console.WriteLine("ToEmptyIfNull：{0}", value.ToEmptyIfNull());
            Console.WriteLine("ToNullIfEmpty：{0}", value.ToNullIfEmpty());
            //IsNullOrWhiteSpace
            Console.WriteLine("IsNullOrWhiteSpace：{0}", value.IsNullOrWhiteSpace());
            //HasAnyValue
            Console.WriteLine("HasAnyValue：{0}", value.HasAnyValue());
            Console.WriteLine();

            value = "    ";
            Console.WriteLine($"测试value为：({value})");
            //ToEmptyIfNull、ToNullIfEmpty
            Console.WriteLine("ToEmptyIfNull：{0}", value.ToEmptyIfNull());
            Console.WriteLine("ToNullIfEmpty：{0}", value.ToNullIfEmpty());
            //IsNullOrWhiteSpace
            Console.WriteLine("IsNullOrWhiteSpace：{0}", value.IsNullOrWhiteSpace());
            //HasAnyValue
            Console.WriteLine("HasAnyValue：{0}", value.HasAnyValue());
            Console.WriteLine();

            //HasAnyValue
            value = "    a    ";
            Console.WriteLine($"测试value为：({value})");
            //ToEmptyIfNull、ToNullIfEmpty
            Console.WriteLine("ToEmptyIfNull：{0}", value.ToEmptyIfNull());
            Console.WriteLine("ToNullIfEmpty：{0}", value.ToNullIfEmpty());
            //IsNullOrWhiteSpace
            Console.WriteLine("IsNullOrWhiteSpace：{0}", value.IsNullOrWhiteSpace());
            //HasAnyValue
            Console.WriteLine("HasAnyValue：{0}", value.HasAnyValue());
            Console.WriteLine();

            //ReplaceFirst、ReplaceFirst
            value = "aaaabaaaabaaaabaaaab";
            Console.WriteLine($"测试value为：({value})");
            Console.WriteLine($"ReplaceFirst：({value.ReplaceFirst("a", "c")})");
            Console.WriteLine($"ReplaceLast：({value.ReplaceLast("a", "c")})");
        }
    }
}
