﻿using Ivony.Html;
using Ivony.Html.Parser;
using SweetFly.Job.Models.Cmr;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Sweet.Cmr.GenerateXml.Handlers
{
    public class GenOldHandler : GenerateHandler
    {
        public override List<SubjectModule> Process(string strResponse, int moduleId)
        {
            var list = new List<SubjectModule>();

            var document = new JumonyParser().Parse(strResponse);
            var trs = document.Descendants("tr[onmouseout]");
            foreach (IHtmlElement tr in trs)
            {
                string title = tr.FindFirst("td").InnerText();
                string href = tr.FindLast("td a").Attribute("href").Value();
                list.Add(new SubjectModule()
                {
                    Id = GetId(moduleId, title),
                    Handler = "SweetFly.Job.Handler.OldHandler,SweetFly.Job",
                    HtmlDataSource = new HtmlDataSource()
                    {
                        Encoding = "GB2312",
                        Uri = @"http://learning.cmr.com.cn/subject/stupage/" + href
                    }
                });
            }
            Console.WriteLine("{0} - {1}", trs.Count(), list.Count);

            return list;
        }
    }
}
