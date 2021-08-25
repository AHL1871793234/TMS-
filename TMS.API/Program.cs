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
    /// Program��
    /// </summary>
    public class Program
    {
        /// <summary>
        /// �����������̣߳�
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            IHostBuilder hostBuilder = CreateHostBuilder(args);//����һ��IHostBuilderʵ��hostBuilder ������ͨ������
            IHost host = hostBuilder.Build();//Build()���и��������Գ�ʼ�������� ��ֻ�ܵ���һ��
            host.Run();//����Ӧ�ó�����ֹ�����̣߳�ֱ�������رա� 
                       //CreateHostBuilder(args).Build().Run();

            #region Log4Net����
            XmlConfigurator.Configure();

            ILog log = LogManager.GetLogger("test");

            log.Debug("������Ϣ");

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
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())//����ע��
                .ConfigureWebHostDefaults(webBuilder => 
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
