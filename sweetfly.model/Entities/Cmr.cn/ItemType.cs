using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.Attributes;

namespace SweetFly.Model.Entities.Cmr.cn
{
    /// <summary>
    /// 题目类型
    /// </summary>
    [Class]
    public class ItemType
    {
        [Id(0, Name = "Id", TypeType = typeof(int))]
        [Column(1, Name = "Id", Unique = true, NotNull = true)]
        [Generator(2, Class = "native")]
        public virtual int Id { get; set; }

        [Property]
        public virtual int Subject_Id { get; set; }

        [Property]
        public virtual string Text { get; set; }

    }
}
