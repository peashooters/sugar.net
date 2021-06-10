using System;

namespace Sugar.NetCore
{
    public class SugarException : Exception
    {
        /// <summary>
        /// 初始化Sugar.NetCore.SugarException类的新实例（Initializes a new instance of the Sugar.NetCore.SugarException class）
        /// </summary>
        public SugarException() : base() { }
        /// <summary>
        /// 使用指定的错误消息初始化Sugar.NetCore.SugarException类的新实例（ Initializes a new instance of the Sugar.NetCore.SugarException class with a specified error message）
        /// </summary>
        /// <param name="message">异常消息（The message that describes the error）</param>
        public SugarException(string message) : base(message) { }
        /// <summary>
        /// 初始化Sugar.NetCore.SugarException类的新实例，其中包含指定的错误消息和对导致此异常的内部异常的引用（Initializes a new instance of the Sugar.NetCore.SugarException class with a specified error message and a reference to the inner exception that is the cause of this exception）
        /// </summary>
        /// <param name="message">异常消息（The error message that explains the reason for the exception）</param>
        /// <param name="innerException">内部异常实例（The exception that is the cause of the current exception, or a null reference if no inner exception is specified）</param>
        public SugarException(string message, Exception innerException) : base(message, innerException) { }
    }
}
