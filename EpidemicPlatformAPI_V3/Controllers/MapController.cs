using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EpidemicPlatformAPI_V3.Contexts;
using EpidemicPlatformAPI_V3.Models;
using EpidemicPlatformAPI_V3.Services;

namespace EpidemicPlatformAPI_V3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private MapService mapService;
        public MapController(PlatformContext context)
        {
            mapService = new MapService(context);
        }
        //上传地图数据到数据库
        [HttpGet]
        [Route("upData")]
        public ActionResult<ReturnMessage> UpData()
        {
            ReturnMessage returnMessage = new ReturnMessage();
            try
            {
                mapService.UpData();
            }
            catch (Exception ex)
            {
                returnMessage.Ret = ex.InnerException.Message;
                return returnMessage;
            }

            returnMessage.Ret = "Successful!";
            return returnMessage;
        }

        [HttpGet]
        [Route("getDays")]
        public ActionResult<List<string>> GetDays()
        {
            return mapService.GetDays();
        }

        [HttpGet]
        [Route("getNews")]
        public ActionResult<List<string>> GetNews()
        {
            return mapService.GetNews();
        }

        [HttpGet]
        [Route("getPeopleNum")]
        public ActionResult<List<List<int>>> GetPeopleNum()
        {
            return mapService.GetPeopleNum();
        }

        [HttpGet]
        [Route("getAllInformation")]
        public ActionResult<MapInformation> GetAllInformation()
        {
            MapInformation mapInformation = new MapInformation();
            try
            {
                mapInformation = mapService.GetAllInformation();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return mapInformation;
            }

            return mapInformation;
        }
    }
}