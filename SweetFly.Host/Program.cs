using SweetFly.Job;
using SweetFly.Model.Entities.Cmr.cn;
using SweetFly.Model.Entities.SweetFly;
using SweetFly.Repository.NHibernate;
using SweetFly.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetFly.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(File.Exists("config/log4net.xml"));
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //注册Log4Net
            LogUtility.Register(Path.Combine(baseDirectory, "config/log4net.xml"));

            //注册NHibernate
            NSessionFactoryManager.GetInstance(NSessionFactoryManager.SessionFactory.SweetFly)
                .Register("config/hibernate/sweetFly.cfg.xml", typeof(Product).Assembly);
            NSessionFactoryManager.GetInstance(NSessionFactoryManager.SessionFactory.Cmrcn)
                .Register("config/hibernate/cmrcn.cfg.xml", typeof(ExamItem).Assembly);

            //注册Castle
            WindsorUtility.Instance.Register();


            //启动计划任务
            QuartzUtility.GetInstance().Start(Path.Combine(baseDirectory, "config", "Cmr.Crawler.xml"));

            Console.WriteLine("开始执行");

            Console.ReadKey();
        }
    }
}
