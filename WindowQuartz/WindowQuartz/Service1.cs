/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：Window服务基于Quartz.Net组件实现定时任务调度（二）                                                    
*│　作    者：艾三元(https://i3yuan.cnblogs.com/)                                                          
*│　创建时间：2019-08-11 16:43:28                           
*└──────────────────────────────────────────────────────────────┘
*/
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WindowQuartz.Helper;

namespace WindowQuartz
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 服务启动
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            Run().GetAwaiter().GetResult();
            LogHelper.SaveLog("服务", "开始");
        }
        /// <summary>
        /// 服务停止
        /// </summary>
        protected override void OnStop()
        {
            try
            {
                if (scheduler != null)
                {
                    scheduler.Shutdown();
                }
            }
            catch (Exception ex)
            {
                LogHelper.SaveLog(ex);
            }
            LogHelper.SaveLog("服务", "结束");
        }

        IScheduler scheduler;
        private async Task Run()
        {
            try
            {
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                scheduler = await factory.GetScheduler();

                await scheduler.Start();
                Jobs.Jobs.Config(scheduler);
            }
            catch (SchedulerException ex)
            {
                LogHelper.SaveLog(ex);
            }

        }
    }
    public class InvokeAttribute : Attribute
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string Remark { get; set; }
        public string Begin { get; set; }
        public int Interval { get; set; }
    }

}
