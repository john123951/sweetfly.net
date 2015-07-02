// File:    CmrUser.cs
// Author:  Administrator
// Created: 2014年4月20日 10:43:19
// Purpose: Definition of Class CmrUser

using NHibernate.Mapping.Attributes;
using System;

namespace SweetFly.Model.Entities.Cmr.cn
{
    /// <summary>
    /// 记录的人大账号信息
    /// </summary>
    [Class]
    public class CmrUser
    {
        [Id(0, Name = "Id", TypeType = typeof(int))]
        [Column(1, Name = "Id", Unique = true, NotNull = true)]
        [Generator(2, Class = "native")]
        public virtual int Id { get; set; }

        /// <summary>
        /// 人大登陆用户名
        /// </summary>
        [Property]
        public virtual string UserName { get; set; }

        /// <summary>
        /// 人大登陆密码
        /// </summary>
        [Property]
        public virtual string Password { get; set; }

        /// <summary>
        /// 使用软件次数
        /// </summary>
        [Property]
        public virtual int UseTimes { get; set; }

        /// <summary>
        /// 最后一次登陆人大时间
        /// </summary>
        [Property]
        public virtual DateTime LastUseTime { get; set; }

        [Property]
        public virtual bool DelFlag { get; set; }

        [Property]
        public virtual DateTime CreateTime { get; set; }
    }
}