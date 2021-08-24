using Autofac;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.Common.Jwt;
using TMS.Common.Log;
using TMS.Common.SQLInject;
using TMS.IRepository;
using TMS.IRepository.User;
using TMS.Repository.BasicInformation;
using TMS.Repository.CarRegistration;
using TMS.Repository.User;
using TMS.Service.BasicInformation;
using TMS.Service.CarRegistration;
using TMS.Service.User;

namespace TMS.API
{
    /// <summary>
    /// Startup 类
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 定义一个repository
        /// </summary>
        public static ILoggerRepository repository { get; set; }
        /// <summary>
        /// 注入
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration,IHostEnvironment env)
        {
            Configuration = configuration;

            #region 构造函数中初始化log4net
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();
            Configuration = builder.Build();
            repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            #endregion

        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            #region 注入Dapper配置
            //连接sqlserver
            services.AddDapper("SqlDb", m =>
            {
                m.ConnectionString = Configuration.GetConnectionString("SqlServer");
                m.DbType = DbStoreType.SqlServer;
            });
            #endregion

            #region 异常过滤器
            //添加单例类 上下文存取器
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //添加单例类 NLog帮助类
            services.AddSingleton<INLogHelper, NLogHelper>();

            //配置成全局的服务
            //模型视图控制器添加过滤器(CustomExceptionFilter)
            //AddControllers就是只添加控制器过滤器
            services.AddMvc(config => config.Filters.Add(typeof(CustomExceptionFilter)));
            #endregion

            #region SQL注入
            //控制器上加SQL注入过滤器
            services.AddControllers(options =>
            {
                options.Filters.Add<CustomSQLInjectFilter>();
            });

            //services.AddControllers();
            #endregion

            #region JWT配置
            //获取jwt配置项
            var jwtTokenConfig = Configuration.GetSection("JWTConfig").Get<JwtTokenConfig>();
            services.AddSingleton(jwtTokenConfig);

            //注册JwtTokenConfig配置服务
            services.Configure<JwtTokenConfig>(Configuration.GetSection("JWTConfig"));

            services.AddTransient<ITokenHelper, TokenHelper>();

            //配置身份认证服务
            services.AddAuthentication(opts =>
            {
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; //认证模式
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;    //质询模式
            })
            .AddJwtBearer(
                x =>
                {
                    //对JwtBearer进行配置
                    x.RequireHttpsMetadata = true;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters()
                    {
                        //Token验证参数
                        ValidateIssuer = true,  //是否验证Issuer
                        ValidIssuer = jwtTokenConfig.Issuer,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenConfig.IssuerSigningKey)),
                        ValidateAudience = true,
                        ValidAudience = jwtTokenConfig.Audience,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(1)  //对token过期时间验证的允许时间
                    };
                }
            );
            #endregion

            #region Swagger验证及配置
            //指定由Microsoft.AspNetCore.Mvc.mvcopions配置的运行时行为的版本兼容性。
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TMS.Api", Version = "v1", Description = "TMS.Api" });
                // 为 Swagger 设置xml文档注释路径
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // 添加控制器层注释，true表示显示控制器注释
                c.IncludeXmlComments(xmlPath, true);

                //开启Authorize权限按钮
                c.AddSecurityDefinition("JWTBearer", new OpenApiSecurityScheme()
                {
                    Description = "这是方式一(直接在输入框中输入认证信息，不需要在开头添加Bearer) ",
                    Name = "Authorization",         //jwt默认的参数名称
                    In = ParameterLocation.Header,  //jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                //定义JwtBearer认证方式二
                //options.AddSecurityDefinition("JwtBearer", new OpenApiSecurityScheme()
                //{
                //    Description = "这是方式二(JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）)",
                //    Name = "Authorization",//jwt默认的参数名称
                //    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                //    Type = SecuritySchemeType.ApiKey
                //});

                //声明一个Scheme，注意下面的Id要和上面AddSecurityDefinition中的参数name一致
                var scheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference()
                    {
                        Id = "JWTBearer",   //这个名字与上面的一样
                        Type = ReferenceType.SecurityScheme
                    }
                };
                //注册全局认证（所有的接口都可以使用认证）
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { scheme, Array.Empty<string>() }
                });
            });
            #endregion

            #region 跨域
            //添加cors 服务 配置跨域来处理
            services.AddCors(options => options.AddPolicy("cor",
            builder =>
            {
                builder.AllowAnyMethod()
                  .AllowAnyHeader()
                  .SetIsOriginAllowed(_ => true) // =AllowAnyOrigin()
                  .AllowCredentials();

            }));
            #endregion
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

            #region Log4Net
            var log = LogManager.GetLogger(repository.Name, typeof(Startup));
            #endregion

            #region Nlog
            ////添加NLog
            //loggerFactory.AddNLog();
            ////加载配置
            //NLog.LogManager.LoadConfiguration("NLog.config");
            ////调用自定义的中间件
            //app.UseLog();
            #endregion

            #region  Swagger环境
            //用于判断是开发环境还是运行环境，保护开发环境和正式环境的间隔
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TMS.Api v1"));
            }
            #endregion

            #region 使用注入内容
            //允许请求文件【上传】
            app.UseStaticFiles();

            app.UseHttpsRedirection();
            //路由
            app.UseRouting();
            //必须启用身份验证中间件
            app.UseAuthentication();
            //授权
            app.UseAuthorization();
            //配置Cors跨域
            app.UseCors("cor");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            #endregion
        }

        #region 使用AutoFac 依赖注入
        //ConfigureContainer是您可以直接注册的地方

        //使用AutoFac，他在ConfigureServices之后运行，因此

        //此处将覆盖在ConfigureServices中进行的注册。

        //不要建造容器：工厂会帮你完成的。
        /// <summary>
        /// ConfigureContainer是您可以直接注册的地方
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //在这里直接向AutoFac注册您自己的东西，不要
            //调用builder.Populate(),这发生在AutofacServiceProviderFactory中
            builder.RegisterAssemblyTypes(typeof(VehicleManagementRepository).Assembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(VehicleManagementService).Assembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
        }
        #endregion
    }
}
