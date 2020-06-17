using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidemicPlatformAPI_V3.Contexts;
using EpidemicPlatformAPI_V3.Models;
using EpidemicPlatformAPI_V3.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EpidemicPlatformAPI_V3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private MessageService messageService;

        public MessageController(PlatformContext context)
        {
            messageService = new MessageService(context);
        }

        [HttpPost]
        [Route("sendFirstRequest")]
        public ActionResult<ReturnMessage> SendFirstRequest(FirstRequest firstRequest)
        {
            ReturnMessage returnMessage = new ReturnMessage();
            try
            {
                messageService.SendFirstRequest(firstRequest);
            }
            catch (Exception ex)
            {
                returnMessage.Ret = ex.InnerException.Message;
                return returnMessage;
            }

            returnMessage.Ret = "successfully";
            return returnMessage;
        }

        [HttpPost]
        [Route("sendSecondRequest")]
        public ActionResult<ReturnMessage> SendSecondRequest(SecondAndThirdRequest secondRequest)
        {
            ReturnMessage returnMessage = new ReturnMessage();
            try
            {
                messageService.SendSecondRequest(secondRequest);
            }
            catch (Exception ex)
            {
                returnMessage.Ret = ex.InnerException.Message;
                return returnMessage;
            }
            returnMessage.Ret = "successfully";
            return returnMessage;
        }

        [HttpPost]
        [Route("sendThirdRequest")]
        public ActionResult<ReturnMessage> SendThirdRequest(SecondAndThirdRequest thirdRequest)
        {
            ReturnMessage returnMessage = new ReturnMessage();
            try
            {
                messageService.SendThirdRequest(thirdRequest);
            }
            catch (Exception ex)
            {
                returnMessage.Ret = ex.InnerException.Message;
                return returnMessage;
            }
            returnMessage.Ret = "successfully";
            return returnMessage;
        }

        [HttpGet]
        [Route("confirm")]
        public ActionResult<ReturnMessage> Confirm(int MessageId)
        {
            ReturnMessage returnMessage = new ReturnMessage();
            try
            {
                messageService.Confirm(MessageId);
            }
            catch (Exception ex)
            {
                returnMessage.Ret = ex.InnerException.Message;
                return returnMessage;
            }

            returnMessage.Ret = "Successfully";
            return returnMessage;
        }

        [HttpGet]
        [Route("getExchangeBySupplyId")]
        public ActionResult<List<Exchange>> GetExchangeBySupplyId(int id)
        {
            return messageService.GetExchangeBySupplyId(id);
        }

        [HttpGet]
        [Route("getExchangeByNeedId")]
        public ActionResult<List<Exchange>> GetExchangeByNeedId(int id)
        {
            return messageService.GetExchangeByNeedId(id);
        }

        [HttpGet]
        [Route("getSentMessage")]
        public ActionResult<List<Message>> GetSentMessage(string name)
        {
            return messageService.GetSentMessage(name);
        }
        [HttpGet]
        [Route("getReceiveMessageUnHandled")]
        public ActionResult<List<Message>> GetReceiveMessageUnHandled(string name)
        {
            return messageService.GetReceiveMessageUnHandled(name);
        }

        [HttpGet]
        [Route("getReceiveMessageHandled")]
        public ActionResult<List<Message>> GetReceiveMessageHandled(string name)
        {
            return messageService.GetReceiveMessageHandled(name);
        }
    }
}