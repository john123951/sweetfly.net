using System;
using NHibernate.Mapping.Attributes;

namespace SweetFly.Model.Entities.Cmr.cn
{
    /// <summary>
    /// 题目
    /// </summary>
    [Class]
    public class ExamItem
    {
        /// <summary>
        /// 人大的主键标识
        /// </summary>
        [Id(0, Name = "Id", TypeType = typeof(int))]
        [Column(1, Name = "Id", Unique = true, NotNull = true)]
        public virtual int Id { get; set; }

        /// <summary>
        /// 属于哪个模块
        /// </summary>
        [Property]
        public virtual int Module_Id { get; set; }

        /// <summary>
        /// 题目类型
        /// </summary>
        [Property]
        public virtual int ItemType { get; set; }

        /// <summary>
        /// 题目标题
        /// </summary>
        [Property]
        public virtual string Title { get; set; }

        /// <summary>
        /// 答案
        /// </summary>
        [Property]
        public virtual string Answer { get; set; }

        /// <summary>
        /// 原始Html
        /// </summary>
        [Property]
        public virtual string OriginalHtml { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Property]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        [Property]
        public virtual bool DelFlag { get; set; }
    }
}
