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
using WindowQuartz.Helper;

namespace WindowQuartz.Jobs
{
    public class Jobs
    {
        public static void Config(IScheduler jobs)
        {
            jobs.AddJob<SyncJob>();
        }
    }
}
