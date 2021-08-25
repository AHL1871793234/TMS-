using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Model.Entity;
using TMS.Service.User;
using TMS.Common.MD5Helper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Configuration;
using System.Text;
using System.Security.Claims;
using TMS.Common.Jwt;
using TMS.Model.ViewModel;
using ServiceStack.Redis;
using TMS.Common.Redis;

namespace TMS.API.Controllers.Setting
{
    /// <summary>
    /// 用户API
    /// </summary>
    [Route("UserAPI")]
    [ApiController]
    public class UserAPIController : Controller
    {
        ///用户服务
        public readonly IUserService _userService;
        /// <summary>
        ///Token启动服务
        /// </summary>
        public readonly ITokenHelper _tokenHelper;

        /// <summary>
        /// 构造函数进行注入
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="tokenHelper"></param>
        public UserAPIController(IUserService userService,ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">用户密码</param>
        /// <returns></returns>
        [Route(nameof(GetLogin)), HttpGet]//指定路由
        public IActionResult GetLogin(string userName, string userPwd)
        {
            try
            {
                //用户密码MD5加密处理
                userPwd = MD5Helper.Encrypt(userPwd);
                //获取用户信息
                UserModel userLogin = _userService.GetLogin(userName, userPwd);
                //判断用户名或密码是否为空
                if (userLogin != null)
                {
                    UserRoleMenuViewModel.UserId = userLogin.UserID;//获取当前登录的用户Id
                    //创建字典保存用户信息
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>
                    {
                        {"登录用户", userName},
                        {"登录时间",DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}
                    };
                    //（2） 后端：帮助类来生成JWT字符串，JWT字符串返回给浏览器
                    TnToken tnToken = _tokenHelper.CreateToken(keyValuePairs);

                    //生成全球唯一标识符
                    string guid = Guid.NewGuid().ToString();

                    //连接Redis
                    using (RedisClient redis = new RedisClient(ConfigHelperRedis._server, ConfigHelperRedis._port, ConfigHelperRedis._pwd, ConfigHelperRedis._db))
                    {
                        //设置刷新时间（大于过期时间）
                        redis.Set(guid, keyValuePairs, TimeSpan.FromMinutes
                            (10));
                    }

                    //返回对应状态值
                    return Ok(new { code = true, meta = 200, msg = "登录成功", name =userLogin.UserName, token = tnToken });
                }
                else
                {
                    //返回对应状态值
                    return Ok(new { code = false, meta = 500, msg = "登录失败" });
                }
            }
            //异常处理提示语
            catch (Exception)
            {
                return Ok(new { code = false, meta = 500, msg = "用户登录异常" });
            }
        }

        /// <summary>
        /// 刷新Token令牌
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [Route(nameof(RefreshToken)), HttpGet]
        public IActionResult RefreshToken(string guid)
        {
            Dictionary<string, string> keyValuePairs;
            //连接Redis
            using (RedisClient redis = new RedisClient(ConfigHelperRedis._server, ConfigHelperRedis._port, ConfigHelperRedis._pwd, ConfigHelperRedis._db))
            {
                //从Redis取出用户得信息
                keyValuePairs = redis.Get<Dictionary<string, string>>(guid);
            }
            //判断
            if (keyValuePairs==null)
            {
                return Ok(new { code = false, meta = 500, msg = "用户信息为空" });
            }

            //生成JWT字符串，JWT字符串返回给浏览器
            TnToken tnToken = _tokenHelper.CreateToken(keyValuePairs);

            return Ok(new { code = true, meta = 200, msg = "刷新成功",token= tnToken });

        }
    }
}
