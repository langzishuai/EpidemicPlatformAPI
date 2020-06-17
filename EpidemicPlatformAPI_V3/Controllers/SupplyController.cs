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
    public class SupplyController : ControllerBase
    {
        private SupplyService supplyService;

        public SupplyController(PlatformContext context)
        {
            supplyService = new SupplyService(context);
        }

        //添加供给接口
        [HttpPost]
        [Route("addSupply")]
        public ActionResult<ReturnMessage> AddSupply(Supply supply)
        {
            ReturnMessage returnMessage = new ReturnMessage();
            try
            {
                supplyService.AddSupply(supply);

            }
            catch (Exception ex)
            {
                returnMessage.Ret = ex.InnerException.Message;
                return returnMessage;
            }
            returnMessage.Ret = "add supply successfully";
            return returnMessage;
        }

        //获取所有供给
        [HttpGet]
        [Route("getAllSupply")]
        public ActionResult<List<Supply>> GetAllSupply()
        {
            return supplyService.GetAllSupply();
        }

        //根据id返回供给
        [HttpGet]
        [Route("getSupplyById")]
        public ActionResult<Supply> GetSupplyById(int id)
        {
            return supplyService.GetSupplyById(id);
        }

        //按用户名获取供给
        [HttpGet]
        [Route("getSupplyByName")]
        public ActionResult<List<Supply>> GetSupplyByName(string name)
        {
            return supplyService.GetSupplyByName(name);
        }

        [HttpGet]
        [Route("needMatch")]
        public ActionResult<List<Supply>> NeedMatch(int id)
        {
            List<Supply> retList;
            try 
            {
                retList = supplyService.NeedMatch(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return new List<Supply>();
            }
            return retList;
        }
    }

}