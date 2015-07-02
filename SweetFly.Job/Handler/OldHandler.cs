using Ivony.Html;
using Ivony.Html.Parser;
using SweetFly.BusinessLogic.contract.Cmr.cn;
using SweetFly.Model.Entities.Cmr.cn;
using SweetFly.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SweetFly.Utility.Extentions;

namespace SweetFly.Job.Handler
{
    /// <summary>
    /// 旧版页面的处理类
    /// 例如：
    /// http://learning.cmr.com.cn/subject/stupage/InstantRnd.asp?CID=00480001
    /// </summary>
    public class OldHandler : ExamItemHandler
    {
        public IItemTypeService ItemTypeService = WindsorUtility.Instance.Resolve<IItemTypeService>();

        public override IList<ExamItem> Process(string strResponse, int moduleId)
        {
            var result = new List<ExamItem>();
            if (string.IsNullOrEmpty(strResponse)) { return result; }

            var document = new JumonyParser().Parse(strResponse);

            //所有题目
            var dataTable = document.Descendants("body>div>table").ElementAt(1);
            var AllTrs = dataTable.Elements("tr");
            var htmlExamItems = AllTrs.Where(x => x.InnerHtml().Contains("【"));

            foreach (var item in htmlExamItems)
            {
                var model = BuildEntity(moduleId, item);
                if (model == null) { continue; }

                result.Add(model);
            }
            if (htmlExamItems.Count() > result.Count)
            {
                string msg = string.Format("Html:[{0}]个，解析：[{1}]个。", result.Count, htmlExamItems.Count());
                WriteLog(strResponse, msg);
            }

            return result;
        }

        private ExamItem BuildEntity(int moduleId, IHtmlElement item)
        {
            try
            {
                var id_element = item.FindFirst(@"tr[valign]>td");

                var match = Regex.Match(id_element.InnerText(), @"\d+");

                int id = Convert.ToInt32(match.Value.Trim());
                string title = id_element.NextElement().InnerText().Trim().RemoveHtml().RemoveHtmlEncode();
                string answer = item.FindFirst("div[id]").InnerText().Trim().RemoveHtmlEncode();
                string examType = item.PreviousElement().Descendants("td")
                                                        .ElementAt(1)
                                                        .InnerText().Trim().RemoveHtml().RemoveHtmlEncode();

                if (answer.StartsWith("答案："))
                {
                    answer = answer.Substring(3).Trim();
                }

                var itemType = ItemTypeService.GetByText(examType);
                if (itemType == null)
                {
                    logger.Info(string.Format("未匹配的题目类别[{0}],ExamId=[{1}]", examType, id));
                }

                var model = new ExamItem()
                {
                    Id = id,
                    Title = title,
                    Answer = answer,
                    OriginalHtml = item.InnerHtml(),
                    Module_Id = moduleId,
                    ItemType = itemType != null ? itemType.Id : 0,
                    CreateTime = DateTime.Now,
                    DelFlag = false
                };
                return model;
            }
            catch (Exception ex)
            {
                WriteLog(item.ToString(), ex.Message);
                throw;
            }
        }
    }
}