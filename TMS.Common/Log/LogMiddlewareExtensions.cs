using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Common.Log
{
    /// <summary>
    /// 日志中间件扩展
    /// </summary>
    public static class LogMiddlewareExtensions
    {
        /// <summary>
        /// 使用日志中间件
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseLog(this IApplicationBuilder builder)
        {
            //使用日志中间件
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}
