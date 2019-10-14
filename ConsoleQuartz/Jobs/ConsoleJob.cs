using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleQuartz
{
    /// <summary>
    /// 实现IJob,Execute方法里编写要处理的业务逻辑
    /// </summary>
    public class ConsoleJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Console.Out.WriteLineAsync($"ConsoleJob执行工作 在当前时间{DateTime.Now}--上一次执行时间：{DateTime.Now.AddSeconds(-5)}");
        }
    }
}