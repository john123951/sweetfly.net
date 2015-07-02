using SweetFly.Utility;
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Sweet.Cmr.GenerateXml
{
    using Sweet.Cmr.GenerateXml.Handlers;
    using System.Diagnostics;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int subjectId = 0;
            int typeId = 0;
            string url = @"http://learning.cmr.com.cn/student/acourse/HomeworkCenter/Modelzhlx.asp?CourseID=bk044a";
            const string encoding = "GB2312";
            const string fileName = "output.xml";

            Console.Write("SubjectId:");
            string strModuleId = Console.ReadLine();
            subjectId = int.Parse(strModuleId);

            Console.Write("Url:");
            url = Console.ReadLine();

            Console.Write("Type(1-Normal;2-Old):");
            string strTypeId = Console.ReadLine();
            typeId = int.Parse(strTypeId);

            CmrClient client = new CmrClient();

            GenerateNormalHandler.setModules(client.GetSubjectModules(subjectId));

            string strResponse = HttpUtility.Get(url, Encoding.GetEncoding(encoding), x =>
                {
                    x.Headers["Authorization"] = "Basic am9objEyMzk1Mjpzd2VldDEyMw==";
                });

            GenerateHandler handler = HandlerFactory.CreateHandler(typeId);
            var list = handler.Process(strResponse, subjectId);

            using (var fsWrite = File.Create(fileName))
            {
                var xs = new XmlSerializer(list.GetType());
                xs.Serialize(fsWrite, list);
            }

            Process.Start(fileName);
            Console.WriteLine("OK:" + fileName);
            Console.ReadKey();
        }
    }
}