using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sugar.NetCore.NetCoreUnit
{
    public class NetHttpUnitTest : DefaultUnitTest
    {
        public override void Test()
        {
            var text_1 = NetHttp.HttpGet("https://www.baidu.com");
            var text_2 = NetHttp.HttpPost("https://fanyi.baidu.com/sug", "kw=5", "application/x-www-form-urlencoded");
            var text_3 = NetHttp.HttpGetAsync("https://www.baidu.com");
            Thread.Sleep(2000);
            var text_4 = NetHttp.HttpPostAsync("https://fanyi.baidu.com/sug", "kw=5", "application/x-www-form-urlencoded");
            Thread.Sleep(2000);
        }
    }
}
