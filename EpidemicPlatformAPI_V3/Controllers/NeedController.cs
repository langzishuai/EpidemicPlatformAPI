using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidemicPlatformAPI_V3.Contexts;
using EpidemicPlatformAPI_V3.Models;
using EpidemicPlatformAPI_V3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EpidemicPlatformAPI_V3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeedController : ControllerBase
    {
        private NeedService needService;

        public  NeedController(PlatformContext context)
        {
            needService = new NeedService(context);
        }

        //添加需求接口
        [HttpPost]
        [Route("addNeed")]
        public ActionResult<ReturnMessage> AddNeed(Need need)
        {
            ReturnMessage returnMessage = new ReturnMessage();
            try
            {
                needService.AddNeed(need);
            }
            catch (Exception ex)
            {
                returnMessage.Ret = ex.InnerException.Message;
                return returnMessage;
            }
            return returnMessage;
        }

        //获取所有需求
        [HttpGet]
        [Route("getAllNeed")]
        public ActionResult<List<Need>> GetAllNeed()
        {
            return needService.GetAllNeed();
        }

        //根据id返回需求
        [HttpGet]
        [Route("getNeedById")]
        public ActionResult<Need> GetNeedById(int id)
        {
            return needService.GetNeedById(id);
        }

        //根据用户名返回需求
        [HttpGet]
        [Route("getNeedByName")]
        public ActionResult<List<Need>> GetNeedByName(string name)
        {
            return needService.GetNeedByName(name);
        }
    }
}