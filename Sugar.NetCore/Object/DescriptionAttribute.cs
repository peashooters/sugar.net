#if NETSTANDARD1_0 || NETSTANDARD1_1 || NETSTANDARD1_2 || NETSTANDARD1_3 || NETSTANDARD1_4 || NETSTANDARD1_5 || NETSTANDARD1_6
using System;

namespace Sugar.NetCore
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class DescriptionAttribute : Attribute
    {
        /// <summary>
        /// 描述文本（The description text）
        /// </summary>
        private string description;
        /// <summary>
        /// 指定System.ComponentModel.DescriptionAttribute的默认值，该值为空字符串。此静态字段是只读的（Specifies the default value for the System.ComponentModel.DescriptionAttribute,which is an empty string (""). This static field is read-only）
        /// </summary>
        public static readonly DescriptionAttribute Default = new DescriptionAttribute();
        /// <summary>
        /// 初始化System.ComponentModel.DescriptionAttribute类的新实例（Initializes a new instance of the System.ComponentModel.DescriptionAttribute class with no parameters）
        /// </summary>
        public DescriptionAttribute() : this(string.Empty)
        {
        }
        /// <summary>
        /// 初始化System.ComponentModel.DescriptionAttribute类的新实例（Initializes a new instance of the System.ComponentModel.DescriptionAttribute class with a description）
        /// </summary>
        /// <param name="description">描述文本（The description text）</param>
        public DescriptionAttribute(string description)
        {
            this.description = description;
        }
        /// <summary>
        /// 获取存储在此属性中的描述（Gets the description stored in this attribute）
        /// </summary>
        public virtual string Description
        {
            get
            {
                return this.DescriptionValue;
            }
        }
        /// <summary>
        /// 获取或设置存储为描述的字符串（Gets or sets the string stored as the description）
        /// </summary>
        protected string DescriptionValue
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }
        /// <summary>
        /// （Returns whether the value of the given object is equal to the current System.ComponentModel.DescriptionAttribute）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            var descriptionAttribute = obj as DescriptionAttribute;

            return descriptionAttribute != null && descriptionAttribute.Description == this.Description;
        }
        /// <summary>
        /// （Returns the hash code for this instance）
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.Description.GetHashCode();
        }
        /// <summary>
        ///  （Returns a value indicating whether this is the default System.ComponentModel.DescriptionAttribute instance）   
        /// </summary>
        /// <returns></returns>
        public bool IsDefaultAttribute()
        {
            return this.Equals(DescriptionAttribute.Default);
        }
    }
}
#endif