using SweetFly.BusinessLogic.contract.Cmr.cn;
using SweetFly.Infrastructure.ApiServices;
using SweetFly.Infrastructure.Configs;
using SweetFly.Model.ApiControllers.BaseApiController;
using SweetFly.Model.ApiControllers.BaseApiController.Enums;
using SweetFly.Model.ApiControllers.Cmr.Requests;
using SweetFly.Model.Entities.Cmr.cn;
using SweetFly.Utility;
using SweetFly.Utility.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;

namespace SweetFly.ApiControllers
{
    /// <summary>
    /// 人大作业助手API
    /// </summary>
    public class CmrController : BaseApiController
    {
        public ISubjectService SubjectService { get; set; }

        public ISubjectModuleService SubjectModuleService { get; set; }

        public IExamItemService ExamItemService { get; set; }

        public ICmrUserService CmrUserService { get; set; }

        protected override int ProductId
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// 返回指定题目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiResponse<ExamItem> Find(int id)
        {
            var model = ExamItemService.GetEntityById(id);

            var result = new ApiResponse<ExamItem>()
            {
                Result = model
            };

            if (model != null)
            {
                result.Success();
            }
            else
            {
                result.Failed(ResultEnum.NoData);
            }

            return result;
        }

        /// <summary>
        /// 查询多个题目答案
        /// </summary>
        /// <param name="request">查询条件</param>
        /// <returns></returns>
        [HttpPost]
        public ApiResponse<List<ExamItem>> FindList(FindListRequest request)
        {
            var model = ExamItemService.GetEntitiesByIds(request.Ids);

            var result = new ApiResponse<List<ExamItem>>()
            {
                Result = model
            };

            if (model != null)
            {
                result.Success();
            }
            else
            {
                result.Failed(ResultEnum.NoData);
            }

            return result;
        }

        /// <summary>
        /// 返回所有可用的科目
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ApiResponse<List<Subject>> GetSubjects()
        {
            return SubjectService.LoadAllSubjects();
        }

        /// <summary>
        /// 返回指定科目下所有模块
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiResponse<List<SubjectModule>> GetSubjectModules(int id)
        {
            return SubjectModuleService.LoadModulesBySubjectId(id);
        }

        /// <summary>
        /// 统计用户的人大账号信息
        /// </summary>
        /// <param name="value">RSA加密后的用户信息</param>
        /// <returns></returns>
        [HttpPost]
        public ApiResponse<bool> UploadInfo(UploadInfoRequestDto request)
        {
            if (request == null || string.IsNullOrEmpty(request.Data))
            {
                return new ApiResponse<bool>().Failed(ResultEnum.ParameterError);
            }

            //私钥解密
            var rsa = new RSA();
            var filePath = HttpContext.Server.MapPath(WebConfig.GetInstance().RSAPrivateKeyFile);
            string strDecrypt = rsa.Decrypt(request.Data, File.ReadAllText(filePath));

            //Json反序列化
            var dataObj = JsonUtility.Deserialize<UploadInfoRequest>(strDecrypt);

            if (string.IsNullOrEmpty(dataObj.AuthorizationString) || false == dataObj.AuthorizationString.Trim().StartsWith("Basic "))
            {
                return new ApiResponse<bool>().Failed(ResultEnum.ParameterError);
            }

            //提取用户名和密码
            string strBase64 = dataObj.AuthorizationString.Substring(6);
            var src = Base64Encrypt.DecryptString(strBase64);

            var userAndPwd = src.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            if (userAndPwd.Length != 2)
            {
                return new ApiResponse<bool>().Failed(ResultEnum.ParameterError);
            }

            //持久化数据
            var model = new CmrUser()
            {
                UserName = userAndPwd[0].Trim(),
                Password = userAndPwd[1].Trim()
            };

            var result = CmrUserService.SaveOrUpdate(model);
            return result;
        }
    }
}