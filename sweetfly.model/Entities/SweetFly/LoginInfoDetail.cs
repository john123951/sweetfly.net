// File:    LoginInfoDetail.cs
// Author:  Sweet
// Created: 2014年3月7日 10:02:26
// Purpose: Definition of Class LoginInfoDetail

using System;
using NHibernate.Mapping.Attributes;

namespace SweetFly.Model.Entities.SweetFly
{
    /// <summary>
    /// 注册用户详情表
    /// </summary>
    [Class]
    public class LoginInfoDetail
    {
        [Id(0, TypeType = typeof(int))]
        [Column(1, Name = "Id", Unique = true, NotNull = true)]
        [Generator(2, Class = "native")]
        public virtual int Id { set; get; }

        [Property]
        public virtual DateTime RegTime { set; get; }

        [Property]
        public virtual string NativePwd { set; get; }

        [Property]
        public virtual string ImgUrl { set; get; }

        [Property]
        public virtual string RegIp { set; get; }

        [ManyToOne(Column = "Login_Id", Cascade = "all", Unique = true)]
        public virtual LoginInfo LoginInfo { set; get; }
    }

}