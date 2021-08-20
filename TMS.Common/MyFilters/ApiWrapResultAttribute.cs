using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Common.MyFilters
{
    //对webAPI结果值进行统一包装
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method)]
    public class ApiWrapResultAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //模型验证
            if (!context.ModelState.IsValid)
            {
                throw new ApplicationException(context.ModelState.Values.First(x => x.Errors.Count > 0).Errors[0].ErrorMessage);
            }
            base.OnActionExecuting(context);
        }

        /// <summary>
        /// 处理正常返回的结果对象，进行统一json格式包装
        /// 异常只能交由ExceptionFilterAttribute去处理
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result != null)
            {
                var result = context.Result as ObjectResult;
                JsonResult newresult;
                if (context.Result is ObjectResult)
                {
                    newresult = new JsonResult(new { code = 200, msg = "成功", body = result.Value });
                }
                else if (context.Result is EmptyResult)
                {
                    newresult = new JsonResult(new { code = 500, msg = "失败", body = new { } });
                }
                else
                {
                    throw new Exception($"未经处理的Result类型：{context.Result.GetType().Name}");
                }
                context.Result = newresult;
            }
            base.OnActionExecuted(context);
        }
    }
}
