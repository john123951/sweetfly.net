// File:    RoleInfo.cs
// Author:  Sweet
// Created: 2014年3月7日 10:02:26
// Purpose: Definition of Class RoleInfo

using System;
using NHibernate.Mapping.Attributes;

namespace SweetFly.Model.Entities.SweetFly.Security
{

    /// <summary>
    /// 角色信息表
    /// </summary>
    [Class]
    public class RoleInfo
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