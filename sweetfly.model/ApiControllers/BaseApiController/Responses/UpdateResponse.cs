namespace SweetFly.Model.ApiControllers.BaseApiController.Responses
{
    /// <summary>
    /// 检查升级的返回值
    /// </summary>
    public class UpdateResponse
    {
        /// <summary>
        /// 有可用升级
        /// </summary>
        public bool HadUpdate { get; set; }

        /// <summary>
        /// 必须立刻升级
        /// </summary>
        public bool Immediately { get; set; }

        /// <summary>
        /// 升级地址
        /// </summary>
        public string Url { get; set; }
    }
}
