// File:    RoleInfo.cs
// Author:  Sweet
// Created: 2014年3月7日 10:02:26
// Purpose: Definition of Class RoleInfo

using System;

/// 角色信息表
public class RoleInfo
{
   public int id;
   public string name;
   public string description;
   public DateTime createTime;
   public short delFlag;
   
   public System.Collections.Generic.List<LoginInfo> loginInfo;
   
   /// <summary>
   /// Property for collection of LoginInfo
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<LoginInfo> LoginInfo
   {
      get
      {
         if (loginInfo == null)
            loginInfo = new System.Collections.Generic.List<LoginInfo>();
         return loginInfo;
      }
      set
      {
         RemoveAllLoginInfo();
         if (value != null)
         {
            foreach (LoginInfo oLoginInfo in value)
               AddLoginInfo(oLoginInfo);
         }
      }
   }
   
   /// <summary>
   /// Add a new LoginInfo in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddLoginInfo(LoginInfo newLoginInfo)
   {
      if (newLoginInfo == null)
         return;
      if (this.loginInfo == null)
         this.loginInfo = new System.Collections.Generic.List<LoginInfo>();
      if (!this.loginInfo.Contains(newLoginInfo))
      {
         this.loginInfo.Add(newLoginInfo);
         newLoginInfo.RoleInfo = this;
      }
   }
   
   /// <summary>
   /// Remove an existing LoginInfo from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveLoginInfo(LoginInfo oldLoginInfo)
   {
      if (oldLoginInfo == null)
         return;
      if (this.loginInfo != null)
         if (this.loginInfo.Contains(oldLoginInfo))
         {
            this.loginInfo.Remove(oldLoginInfo);
            oldLoginInfo.RoleInfo = null;
         }
   }
   
   /// <summary>
   /// Remove all instances of LoginInfo from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllLoginInfo()
   {
      if (loginInfo != null)
      {
         System.Collections.ArrayList tmpLoginInfo = new System.Collections.ArrayList();
         foreach (LoginInfo oldLoginInfo in loginInfo)
            tmpLoginInfo.Add(oldLoginInfo);
         loginInfo.Clear();
         foreach (LoginInfo oldLoginInfo in tmpLoginInfo)
            oldLoginInfo.RoleInfo = null;
         tmpLoginInfo.Clear();
      }
   }

}