using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.Attributes;

namespace SweetFly.Model.Entities.Cmr.cn
{
    /// <summary>
    /// 科目下的模块
    /// </summary>
    [Class]
    public class SubjectModule
    {
        [Id(0, Name = "Id", TypeType = typeof(int))]
        [Column(1, Name = "Id", Unique = true, NotNull = true)]
        [Generator(2, Class = "native")]
        public virtual int Id { get; set; }

        [Property]
        public virtual int Subject_Id { get; set; }

        [Property]
        public virtual string Name { get; set; }

        [Property]
        public virtual DateTime CreateTime { get; set; }

        [Property]
        public virtual bool DelFlag { get; set; }
    }
}
