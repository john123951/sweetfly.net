/***********************************************************************
 * Module:  LoginInfo.cs
 * Author:  Sweet
 * Purpose: Definition of the Class LoginInfo
 ***********************************************************************/

using System;
using NHibernate.Mapping.Attributes;

namespace SweetFly.Model.Entities.SweetFly
{
    /// <summary>
    /// µÇÂ¼ÓÃ»§
    /// </summary>
    [Class(Table = "LoginInfo")]
    public class LoginInfo
    {
        [Id(0, Name = "Id", TypeType = typeof(int))]
        [Column(1, Name = "Id", Unique = true, NotNull = true)]
        [Generator(2, Class = "native")]
        public virtual int Id { set; get; }

        [Property]
        public virtual string UserName { set; get; }

        [Property]
        public virtual string Password { set; get; }

        [Property]
        public virtual DateTime LastLoginTime { set; get; }

        [Property]
        public virtual DateTime CreateTime { set; get; }

        [Property]
        public virtual DateTime ModifyTime { set; get; }

        [Property]
        public virtual bool DelFlag { set; get; }

    }
}
