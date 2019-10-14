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
    [Invoke(Name = "SyncJob", Remark = "Quartz服务", Group = "Quartz服务管理", Begin = "2018-05-01 12:00:00", Interval = 5)]
    public class SyncJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                //每次执行 获取当前时间 输出当前时间
                //可以在这里编写每次定时执行需要的方法
                LogHelper.SaveLog("输出日志", "在当前时间:" + DateTime.Now + "--上一次执行时间：" + DateTime.Now.AddSeconds(-5));
            }
            catch (Exception ex)
            {
                LogHelper.SaveLog(ex);
            }

            return null;
        }
    }
}
