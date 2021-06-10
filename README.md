
# Sugar.NetCore(中文文档)

# 概述

> Sugar.NetCore是一个基于.NET Standard规范实现的工具类库，内部主要集成一些工具类（帮助类）、语法糖扩展代码，旨在替换繁琐的编程工具类库的编写。本项目在 [ZHI.ZSystem](https://github.com/peashooters/zhi)组件类库的基础上，做了更多的编程习惯上的思考，后续会加大更新力度，希望.NET/C#开发工程师们能够愉悦的使用本类库。

## 工作原理

Sugar.NetCore集成在编程工作中使用到的一些工具类（帮助类），对部分常用的类（例如:Sting、DateTime）做出函数扩展，开发者通过nuget引入Sugar.NetCore包后，便可以使用其中的各种工具类及扩展函数了。

## 为什么选择 Sugar.NetCore

.NET基础框架的开发工程师们似乎总是孜孜不倦的探讨.NET平台发展的新方向，短短十年之间.NET4.0已经完成到.NET5.0的升级。对于一些需要适应新平台版本的项目，我们不得不维护上了年纪的代码，以保证项目的稳定运行。在此过程中，我们会非常痛苦的发现，我们将部分系统组件编译为.NET5.0框架版本之后，将无法在.NET 4.0框架版本下运行，这令人感到十分痛苦。

Sugar.NetCore基于.NET Standard1.x、.NET Standard2.x、.NET 4.x等框架版本均做了语法编译，不管你使用哪个版本的.NET平台框架（.NET 4.0以下的除外），均可以放心使用其中的工具类。

## 版本支持

| .NET版本 | 是否支持 | 测试 		|
| ------- | -------- | ------- 	|
| .NET Framework4.0		| 支持 | 通过 	|
| .NET Framework4.5.x	| 支持 | 通过 	|
| .NET Framework4.6.x 	| 支持 | 通过 	|
| .NET Framework4.7.x 	| 支持 | 通过 	|
| .NET Framework4.8 	| 支持 | 通过 	|
| .NET Core 1.x | 支持 | 通过 |
| .NET Core 2.x | 支持 | 通过 |
| .NET Core 3.x | 支持 | 通过 |
| .NET 5.0 | 支持 | 通过		|
| .NET 6.x | 支持 |			|
| .NET Standard 1.x | 支持 | 通过 |
| .NET Standard 2.x | 支持 | 通过 |

## 案例语法

### 获取时间戳

``` cs
    static void Main(string[] args)
    {
		var datetime = new DateTime(1970, 1, 1, 8, 0, 0, DateTimeKind.Utc);
		var timestamp1 = datetime.ToUtcTimeStamp();//Second
		var timestamp2 = datetime.ToUtcTimeStamp(TimeStampUnit.MilliSecond);//MilliSecond
    }
```

### 替换匹配的第一个字符

``` cs
	static void Main(string[] args)
	{
		var value = "aaaabaaaabaaaabaaaa";
		var first = value.ReplaceFirst("b", "c");
		var last = value.ReplaceLast("b", "c");
	}
```

### 获取枚举描述

``` cs
	public enum AreYouHappy
	{
		[Description("No, I'm not happy")]
		No = 0,
		[Description("Yes, I'm happy")]
		Yes = 1,
	}
	
	static void Main(string[] args)
	{
		var description = AreYouHappy.Yes.GetDescription();
	}
```
