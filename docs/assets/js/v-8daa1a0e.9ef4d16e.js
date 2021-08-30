(self.webpackChunkSugar_NetCore_Documents=self.webpackChunkSugar_NetCore_Documents||[]).push([[509],{6464:(n,s,a)=>{"use strict";a.r(s),a.d(s,{data:()=>e});const e={key:"v-8daa1a0e",path:"/",title:"首页",lang:"zh-CN",frontmatter:{home:!0,title:"首页",heroImage:"/images/logo.png",actions:[{text:"快速上手",link:"/zh/guide/",type:"primary"}],features:[{title:"简洁至上",details:"多维度简化代码行数，以更简短的代码完成更多的程序计算，带来极致开发体验"},{title:"版本兼容",details:"基于.NET Standard、.NET Framework、NET Core（.NET5）编译兼容版本，工程师免受版本兼容之苦"},{title:"代码开源",details:"Sugar.NetCore遵循MIT协议，代码在github、gitee均有开源地址，源码可供参考"}],footer:"MIT Licensed | Copyright © 2021-Sugar.NetCore"},excerpt:"",headers:[{level:3,title:"编程可以很简单",slug:"编程可以很简单",children:[]}],filePathRelative:"README.md",git:{}}},9633:(n,s,a)=>{"use strict";a.r(s),a.d(s,{default:()=>t});const e=(0,a(6252).uE)('<h3 id="编程可以很简单" tabindex="-1"><a class="header-anchor" href="#编程可以很简单" aria-hidden="true">#</a> 编程可以很简单</h3><div class="language-csharp ext-cs line-numbers-mode"><pre class="language-csharp"><code><span class="token comment">//引入这个命名空间</span>\n<span class="token keyword">using</span> <span class="token namespace">Sugar<span class="token punctuation">.</span>NetCore</span><span class="token punctuation">;</span>\n\n<span class="token keyword">public</span> <span class="token return-type class-name"><span class="token keyword">void</span></span> <span class="token function">Main</span><span class="token punctuation">(</span><span class="token punctuation">)</span>\n<span class="token punctuation">{</span>\n    <span class="token comment">//生成GUID</span>\n    <span class="token class-name"><span class="token keyword">var</span></span> guid <span class="token operator">=</span> NetString<span class="token punctuation">.</span>GUID<span class="token punctuation">;</span>\n    <span class="token comment">//生成UNID</span>\n    <span class="token class-name"><span class="token keyword">var</span></span> unid <span class="token operator">=</span> NetString<span class="token punctuation">.</span>UNID<span class="token punctuation">;</span>\n    <span class="token comment">//1-10位长度随机字符串</span>\n    <span class="token class-name"><span class="token keyword">var</span></span> randomString <span class="token operator">=</span> NetString<span class="token punctuation">.</span><span class="token function">RandomString</span><span class="token punctuation">(</span><span class="token number">1</span><span class="token punctuation">,</span> <span class="token number">10</span><span class="token punctuation">)</span><span class="token punctuation">;</span>\n    <span class="token comment">//1-10位长度随机数字</span>\n    <span class="token class-name"><span class="token keyword">var</span></span> randomNumber <span class="token operator">=</span> NetString<span class="token punctuation">.</span><span class="token function">RandomString</span><span class="token punctuation">(</span><span class="token number">1</span><span class="token punctuation">,</span> <span class="token number">10</span><span class="token punctuation">,</span> StringRandomRule<span class="token punctuation">.</span>Number<span class="token punctuation">)</span><span class="token punctuation">;</span>\n<span class="token punctuation">}</span>\n</code></pre><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br><span class="line-number">4</span><br><span class="line-number">5</span><br><span class="line-number">6</span><br><span class="line-number">7</span><br><span class="line-number">8</span><br><span class="line-number">9</span><br><span class="line-number">10</span><br><span class="line-number">11</span><br><span class="line-number">12</span><br><span class="line-number">13</span><br><span class="line-number">14</span><br></div></div>',2),t={render:function(n,s){return e}}}}]);