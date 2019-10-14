/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：Window服务基于Quartz.Net组件实现定时任务调度（二）                                                    
*│　作    者：艾三元(https://i3yuan.cnblogs.com/)                                                          
*│　创建时间：2019-08-11 16:43:28                           
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowQuartz
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
