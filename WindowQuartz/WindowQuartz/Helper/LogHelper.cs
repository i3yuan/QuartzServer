/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：Window服务基于Quartz.Net组件实现定时任务调度（二）                                                    
*│　作    者：艾三元(https://i3yuan.cnblogs.com/)                                                          
*│　创建时间：2019-08-11 16:43:28                           
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowQuartz.Helper
{
    public class LogHelper
    {
        private static string lockKey = "lock";
        public static void SaveLog(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ex.Message);
            sb.AppendLine(ex.StackTrace);
            sb.AppendLine(ex.Source);

            SaveLog("错误日志", sb.ToString());
        }
        public static void SaveLog(String logName, string msg, params string[] para)
        {
            try
            {
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\errlogs\\"))
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\errlogs\\");

                }

                DateTime now = DateTime.Now;
                String LogFile = AppDomain.CurrentDomain.BaseDirectory + "\\errlogs\\" + logName + "_" + now.ToString("yyyy-MM-dd") + ".log";
                lock (lockKey)
                {
                    using (FileStream fs = new FileStream(LogFile, FileMode.Append, FileAccess.Write))
                    {
                        byte[] datetimefile = Encoding.Default.GetBytes(logName + "_" + now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":\r\n");
                        fs.Write(datetimefile, 0, datetimefile.Length);
                        if (!String.IsNullOrEmpty(msg))
                        {
                            byte[] data = Encoding.Default.GetBytes(string.Format(msg, para) + "\r\n==========================================\r\n");
                            fs.Write(data, 0, data.Length);
                        }
                        fs.Flush();
                    }
                }
            }
            catch
            { }
        }
    }
}
