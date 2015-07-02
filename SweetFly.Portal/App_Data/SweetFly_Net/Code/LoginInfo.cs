// File:    LoginInfo.cs
// Author:  Sweet
// Created: 2014年3月7日 10:02:26
// Purpose: Definition of Class LoginInfo

using System;

/// 用户信息表
public class LoginInfo
{
   public int id;
   public string userName;
   public string password;
   public DateTime lastLoginTime;
   public DateTime createTime;
   public DateTime modifyTime;
   public short delFlag;
   
   public LoginInfoDetail loginInfoDetail;
   public System.Collections.Generic.List<AuthInfo> authInfo;
   
   /// <summary>
   /// Property for collection of AuthInfo
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<AuthInfo> AuthInfo
   {
      get
      {
         if (authInfo == null)
            authInfo = new System.Collections.Generic.List<AuthInfo>();
         return authInfo;
      }
      set
      {
         RemoveAllAuthInfo();
         if (value != null)
         {
            foreach (AuthInfo oAuthInfo in value)
               AddAuthInfo(oAuthInfo);
         }
      }
   }
   
   /// <summary>
   /// Add a new AuthInfo in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddAuthInfo(AuthInfo newAuthInfo)
   {
      if (newAuthInfo == null)
         return;
      if (this.authInfo == null)
         this.authInfo = new System.Collections.Generic.List<AuthInfo>();
      if (!this.authInfo.Contains(newAuthInfo))
      {
         this.authInfo.Add(newAuthInfo);
         newAuthInfo.LoginInfo = this;
      }
   }
   
   /// <summary>
   /// Remove an existing AuthInfo from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveAuthInfo(AuthInfo oldAuthInfo)
   {
      if (oldAuthInfo == null)
         return;
      if (this.authInfo != null)
         if (this.authInfo.Contains(oldAuthInfo))
         {
            this.authInfo.Remove(oldAuthInfo);
            oldAuthInfo.LoginInfo = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of AuthInfo from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllAuthInfo()
   {
      if (authInfo != null)
      {
         System.Collections.ArrayList tmpAuthInfo = new System.Collections.ArrayList();
         foreach (AuthInfo oldAuthInfo in authInfo)
            tmpAuthInfo.Add(oldAuthInfo);
         authInfo.Clear();
         foreach (AuthInfo oldAuthInfo in tmpAuthInfo)
            oldAuthInfo.LoginInfo = null;
         tmpAuthInfo.Clear();
      }
   }
   public RoleInfo roleInfo;
   
   /// <summary>
   /// Property for RoleInfo
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public RoleInfo RoleInfo
   {
      get
      {
         return roleInfo;
      }
      set
      {
         if (this.roleInfo == null || !this.roleInfo.Equals(value))
         {
            if (this.roleInfo != null)
            {
               RoleInfo oldRoleInfo = this.roleInfo;
               this.roleInfo = null;
               oldRoleInfo.RemoveLoginInfo(this);
            }
            if (value != null)
            {
               this.roleInfo = value;
               this.roleInfo.AddLoginInfo(this);
            }
         }
      }
   }

}