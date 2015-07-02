// File:    AuthInfo.cs
// Author:  Sweet
// Created: 2014年3月7日 10:02:26
// Purpose: Definition of Class AuthInfo

using System;

/// 用户--产品 关系表
public class AuthInfo
{
   public int id;
   public DateTime expireTime;
   
   public LoginInfo loginInfo;
   
   /// <summary>
   /// Property for LoginInfo
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public LoginInfo LoginInfo
   {
      get
      {
         return loginInfo;
      }
      set
      {
         if (this.loginInfo == null || !this.loginInfo.Equals(value))
         {
            if (this.loginInfo != null)
            {
               LoginInfo oldLoginInfo = this.loginInfo;
               this.loginInfo = null;
               oldLoginInfo.RemoveAuthInfo(this);
            }
            if (value != null)
            {
               this.loginInfo = value;
               this.loginInfo.AddAuthInfo(this);
            }
         }
      }
   }
   public Product product;
   
   /// <summary>
   /// Property for Product
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public Product Product
   {
      get
      {
         return product;
      }
      set
      {
         if (this.product == null || !this.product.Equals(value))
         {
            if (this.product != null)
            {
               Product oldProduct = this.product;
               this.product = null;
               oldProduct.RemoveAuthInfo(this);
            }
            if (value != null)
            {
               this.product = value;
               this.product.AddAuthInfo(this);
            }
         }
      }
   }

}