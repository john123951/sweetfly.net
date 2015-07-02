using Quartz;
using Quartz.Impl;
using SweetFly.Job.Configs;
using SweetFly.Job.JobItems;
using SweetFly.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweetFly.Job
{
    public class QuartzUtility
    {

        #region 构造函数
        private QuartzUtility() { }
        public static QuartzUtility GetInstance()
        {
            return new QuartzUtility();
        }
        #endregion

        protected IScheduler Scheduler
        {
            get
            {
                return StdSchedulerFactory.GetDefaultScheduler();
            }
        }


        public void Start(string configFile)
        {
            if (Scheduler.IsStarted) { return; }

            //读取配置文件
            CmrConfig.Register(configFile);

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<CmrcnCrawlerJob>()
                .WithIdentity("CmrcnCrawlerJob", "group1")
                .Build();

            // Trigger the job to run now, and then repeat every 8 hours
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInMinutes(1)
                    //.WithIntervalInHours(8)
                    .RepeatForever())
                //.WithDailyTimeIntervalSchedule(x => x 
                //    .OnEveryDay()
                //    .WithIntervalInHours(1)
                //    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(8, 7))          //记录一下，尝试一下Utc时间
                //    .EndingDailyAfterCount(4)
                //    .WithMisfireHandlingInstructionFireAndProceed()
                //)
                .Build();

            // Tell quartz to schedule the job using our trigger
            Scheduler.ScheduleJob(job, trigger);

            Scheduler.Start();
        }

        public void Shutdown()
        {
            Scheduler.Shutdown();
        }

    }
}
