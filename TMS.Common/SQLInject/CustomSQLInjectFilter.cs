using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using TMS.Common.Log.LogModel;

namespace TMS.Common.SQLInject
{
    //自定义SQL过滤器
    public class CustomSQLInjectFilter : ActionFilterAttribute
    {
        private readonly ILogger<CustomSQLInjectFilter> _logger;

        public CustomSQLInjectFilter(ILogger<CustomSQLInjectFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 控制器中加了该属性的方法中代码执行之前该方法。
        /// 代码执行之前执行该方法
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool result= SQLInjectionHelper.ValidUrlPostData(context.HttpContext);
            //判断是否包含SQL注入
            if (result)
            {
                int resultStatusCode = ResultCode.DATA_IS_WRONG;
                context.Result = new StatusCodeResult(resultStatusCode);
            }
        }
    }
}
