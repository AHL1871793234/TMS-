using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NLog.Extensions.Hosting;
using log4net;
using log4net.Repository;
using log4net.Config;
using TMS.Common;

namespace TMS.API
{
    /// <summary>
    /// Program类
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 主函数（主线程）
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            IHostBuilder hostBuilder = CreateHostBuilder(args);//产生一个IHostBuilder实例hostBuilder ，创建通用主机
            IHost host = hostBuilder.Build();//Build()运行给定操作以初始化主机。 这只能调用一次
            host.Run();//运行应用程序并阻止调用线程，直至主机关闭。 
                       //CreateHostBuilder(args).Build().Run();

            #region Log4Net配置
            XmlConfigurator.Configure();

            ILog log = LogManager.GetLogger("test");

            log.Debug("调试信息");

            LogHelper.BuildLogEntity("",1,"");
            #endregion

        }

        /// <summary>
        /// IHostBuilder CreateHostBuilder
        /// </summary> 
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())//依赖注入
                .ConfigureWebHostDefaults(webBuilder => 
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
