using SweetFly.Model.ApiControllers.BaseApiController.Enums;
using SweetFly.Utility.Extentions;

namespace SweetFly.Model.ApiControllers.BaseApiController
{
    public class ApiResponse<T>
    {
        /// <summary>
        /// 执行结果
        /// </summary>
        public ResultEnum ResultCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// 标记执行成功。
        /// </summary>
        public ApiResponse<T> Success()
        {
            this.ResultCode = ResultEnum.Success;
            this.Message = ResultEnum.Success.GetDescription();
            return this;
        }

        /// <summary>
        /// 标记为执行失败。
        /// </summary>
        /// <param name="status"></param>
        /// <param name="msg"></param>
        public ApiResponse<T> Failed(ResultEnum status, string msg)
        {
            this.ResultCode = status;
            this.Message = msg;
            return this;
        }

        public ApiResponse<T> Failed(ResultEnum status)
        {
            return Failed(status, status.GetDescription());
        }
    }
}
