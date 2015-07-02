using SweetFly.Model.ApiControllers.BaseApiController;
using SweetFly.Utility;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;

namespace Sweet.Cmr.GenerateXml
{
    using EntitySubjectModule = SweetFly.Model.Entities.Cmr.cn.SubjectModule;

    public class CmrClient
    {
        public async void GetSubjectModules(int subjectId, Action<List<EntitySubjectModule>> action)
        {
            string address = @"http://www.sweetfly.net/api/cmr/GetSubjectModules?id=" + subjectId;

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(address);
            List<EntitySubjectModule> contacts = await response.Content.ReadAsAsync<List<EntitySubjectModule>>();

            Console.WriteLine("Download complated");
            action(contacts);
        }

        public List<EntitySubjectModule> GetSubjectModules(int subjectId)
        {
            string address = @"http://www.sweetfly.net/api/cmr/GetSubjectModules?id=" + subjectId;

            var strResponse = HttpUtility.Get(address, Encoding.UTF8);

            var js = new JavaScriptSerializer();
            var result = js.Deserialize<ApiResponse<List<EntitySubjectModule>>>(strResponse);

            return result.Result;
        }
    }
}