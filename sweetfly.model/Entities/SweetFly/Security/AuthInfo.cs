// File:    AuthInfo.cs
// Author:  Sweet
// Created: 2014��3��7�� 10:02:26
// Purpose: Definition of Class AuthInfo

using System;
using NHibernate.Mapping.Attributes;

namespace SweetFly.Model.Entities.SweetFly.Security
{
    /// <summary>
    /// �û�--��Ʒ ��ϵ��
    /// </summary>
    [Class]
    public class AuthInfo
    {
        [Id(0, TypeType = typeof(int))]
        [Column(1, Name = "Id", Unique = true, NotNull = true)]
        [Generator(2, Class = "native")]
        public virtual int Id { set; get; }

        [Property(Column = "Login_Id")]
        public virtual int LoginId { set; get; }

        [Property(Column = "Pro_Id")]
        public virtual int ProId { set; get; }

        [Property]
        public virtual DateTime ExpireTime { set; get; }
    }
}