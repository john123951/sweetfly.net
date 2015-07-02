using System.ComponentModel;

namespace SweetFly.Model.ApiControllers.BaseApiController.Enums
{
    /// <summary>
    /// 操作结果
    /// </summary>
    public enum ResultEnum
    {
        [Description("未知错误")]
        UnknowError = 0,

        [Description("操作成功")]
        Success = 1,

        [Description("未授权访问")]
        UnAuthorized = 401,

        [Description("参数错误")]
        ParameterError = 100,

        [Description("格式错误")]
        FormatError = 101,

        [Description("数据为空")]
        NoData = 10
    }
}