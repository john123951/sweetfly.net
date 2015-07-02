using NHibernate.Mapping.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweetFly.Model.Entities.Cmr.cn
{
    /// <summary>
    /// 科目
    /// </summary>
    [Class]
    public class Subject
    {
        [Id(0, Name = "Id", TypeType = typeof(int))]
        [Column(1, Name = "Id", Unique = true, NotNull = true)]
        [Generator(2, Class = "native")]
        public virtual int Id { get; set; }

        /// <summary>
        /// 科目名称
        /// </summary>
        [Property]
        public virtual string Name { get; set; }

        /// <summary>
        /// 科目名称的拼音简拼
        /// </summary>
        [Property]
        public virtual string PyShort { get; set; }

        /// <summary>
        /// 科目做作业Url
        /// </summary>
        [Property]
        public virtual string HomeworkUrl { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Property]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        [Property]
        public virtual bool DelFlag { get; set; }
    }
}