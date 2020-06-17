using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidemicPlatformAPI_V3.Contexts;
using EpidemicPlatformAPI_V3.Models;
using EpidemicPlatformAPI_V3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EpidemicPlatformAPI_V3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService userService;
        private readonly PlatformContext platformContext;

        public UserController(PlatformContext context)
        {
            this.platformContext = context;
            userService = new UserService(context);
        }

        //注册接口
        [HttpPost]
        [Route("register")]
        public ActionResult<ReturnMessage> Register(User user)
        {
            ReturnMessage returnMessage = new ReturnMessage();
            try
            {
                userService.Register(user);
            }
            catch (Exception ex)
            {
                returnMessage.Ret = ex.InnerException.Message;
                return returnMessage;
            }

            returnMessage.Ret = "register successfully";
            return returnMessage;
        }


        //登录接口
        [HttpPost]
        [Route("logIn")]
        public ActionResult<ReturnMessage> LogIn(LogIn logIn)
        {
            return userService.LogIn(logIn);
        }

        //根据用户名获取用户信息
        [HttpGet]
        [Route("getUserByName")]
        public ActionResult<User> GetUserByName(string name)
        {
            return userService.GetUserByName(name);
        }

        //修改用户信息

        [HttpPost]
        [Route("userChange")]
        public ActionResult<ReturnMessage> UserChange(User user)
        {
            ReturnMessage returnMessage = new ReturnMessage();
            try 
            {
                userService.UserChange(user);
            }
            catch (Exception ex)
            {
                returnMessage.Ret = ex.InnerException.Message;
                return returnMessage;
            }

            returnMessage.Ret = "user change successfully";
            return returnMessage;
        }
        //修改密码
        [HttpGet]
        [Route("changePassword")]
        public ReturnMessage ChangePassword(string name,string pwd)
        {
            ReturnMessage returnMessage = new ReturnMessage();
            try
            {
                userService.ChangePassword(name, pwd);
            }
            catch (Exception ex)
            {
                returnMessage.Ret = ex.InnerException.Message;
                return returnMessage;
            }

            return returnMessage;
        }
    }
}