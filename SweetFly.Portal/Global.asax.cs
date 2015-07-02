using SweetFly.Infrastructure.Plumbing;
using SweetFly.Interceptors.DelegatingHandlers;
using SweetFly.Job;
using SweetFly.Model.Entities;
using SweetFly.Model.Entities.Cmr.cn;
using SweetFly.Model.Entities.SweetFly;
using SweetFly.Repository.NHibernate;
using SweetFly.Utility;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Routing;

namespace SweetFly.Portal
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //注册区域
            AreaRegistration.RegisterAllAreas();

            //注册路由
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //注册Filters
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            //设置视图格式
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            //设置API返回格式
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            //注册Log4Net
            LogUtility.Register(Server.MapPath("~/config/log4net.xml"));

            //注册NHibernate
            NSessionFactoryManager.GetInstance(NSessionFactoryManager.SessionFactory.SweetFly)
                .Register(Server.MapPath("~/config/hibernate/sweetFly.cfg.xml"), typeof(Product).Assembly);
            NSessionFactoryManager.GetInstance(NSessionFactoryManager.SessionFactory.Cmrcn)
                .Register(Server.MapPath("~/config/hibernate/cmrcn.cfg.xml"), typeof(ExamItem).Assembly);

            //注册Castle
            WindsorUtility.Instance.Register();

            //注册ControllerFactory
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory());
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorApiControllerActivator());

            //注册处理程序
            GlobalConfiguration.Configuration.MessageHandlers.Add(new TraceHandler());
            //config.EnableSystemDiagnosticsTracing();

#if !DEBUG
            //启动计划任务
            QuartzUtility.GetInstance().Start(Server.MapPath("~/config/Cmr.Crawler.xml"));
#endif
        }

        protected void Application_Error()
        {
            var ex = Server.GetLastError();
            var logger = LogUtility.GetInstance().GetLog("Web");

            string msg = string.Format("URL:[{0}], Method:[{1}], IP:[{2}], Agent:[{3}]; 未捕获异常", Request.RawUrl, Request.RequestType, Request.UserHostAddress, Request.UserAgent);

            logger.Fatal(msg, ex);
        }
    }
}