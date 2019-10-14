/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：Window服务基于Quartz.Net组件实现定时任务调度（二）                                                    
*│　作    者：艾三元(https://i3yuan.cnblogs.com/)                                                          
*│　创建时间：2019-08-11 16:43:28                           
*└──────────────────────────────────────────────────────────────┘
*/
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowQuartz.Helper
{
    public static class JobHelper
    {
        public static void AddJob<T>(this IScheduler scheduler) where T : IJob
        {
            var type = typeof(T);
            object[] objAttrs = type.GetCustomAttributes(typeof(InvokeAttribute), true);
            if (objAttrs.Length > 0)
            {
                if (objAttrs[0] is InvokeAttribute attr)
                {
                    IJobDetail job = JobBuilder.Create<T>().WithIdentity(attr.Name, attr.Group).Build();
                    ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create()
                        .StartAt(DateTime.Parse(attr.Begin))                                //设置任务开始时间    
                        .WithSimpleSchedule(x => x.WithIntervalInSeconds(attr.Interval)     //循环的时间
                        .RepeatForever())
                        .Build();
                    scheduler.ScheduleJob(job, trigger);
                }
            }
        }
    }
}
