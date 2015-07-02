/***********************************************************************
 * Module:  Product.cs
 * Author:  Sweet
 * Purpose: Definition of the Class Product
 ***********************************************************************/

using System;
using NHibernate.Mapping.Attributes;

namespace SweetFly.Model.Entities.SweetFly
{
    /// <summary>
    /// 产品信息
    /// </summary>
    [Class]
    public class Product
    {
        [Id(0, TypeType = typeof(int))]
        [Column(1, Name = "Id", Unique = true, NotNull = true)]
        [Generator(2, Class = "native")]
        public virtual int Id { set; get; }

        [Property]
        public virtual string Name { set; get; }

        [Property]
        public virtual string Description { set; get; }

        [Property]
        public virtual DateTime CreateTime { set; get; }

        [Property]
        public virtual bool DelFlag { set; get; }
    }
}