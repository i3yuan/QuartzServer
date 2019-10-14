using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleQuartz
{
    class Program
    {
        /// <summary>
        /// 入口服务
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Run();
            Console.ReadKey();
        }


        /// <summary>
        /// 任务调度的使用过程
        /// </summary>
        /// <returns></returns>
        public async static Task Run()
        {
            // 1.创建scheduler的引用
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            IScheduler sched = await schedFact.GetScheduler();
            

            //2.启动 scheduler
            await sched.Start();

            // 3.创建 job
            IJobDetail job = JobBuilder.Create<ConsoleJob>()
                    .WithIdentity("job1", "group1")
                    .Build();

            // 4.创建 trigger （创建 trigger 触发器）
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")  //触发器 组
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever())
                .Build();

            // 5.使用trigger规划执行任务job （使用触发器规划执行任务）
            await sched.ScheduleJob(job, trigger);
        }
    }
}
