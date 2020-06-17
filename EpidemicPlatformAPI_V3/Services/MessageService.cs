using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidemicPlatformAPI_V3.Models;
using EpidemicPlatformAPI_V3.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EpidemicPlatformAPI_V3.Services
{
    public class MessageService
    {
        private readonly PlatformContext platformContext;

        public MessageService(PlatformContext context)
        {
            this.platformContext = context;
        }

        public void SendFirstRequest(FirstRequest firstRequest)
        {
            Message newMessage = new Message();
            newMessage.Applicant = firstRequest.Applicant;
            newMessage.Recipient = firstRequest.Recipient;
            newMessage.SupplyId = firstRequest.SupplyId;
            newMessage.NeedId = firstRequest.NeedId;
            newMessage.Time = firstRequest.Time;
            newMessage.MessageType = "First";
            newMessage.MeaasgeState = "N";
            newMessage.Items = new List<Item>();
            for (int i = 0; i < firstRequest.Items.Count; i++)
                newMessage.Items.Add(new Item());
            for (int i = 0; i < firstRequest.Items.Count; i++)
            {
                newMessage.Items[i].ItemName = firstRequest.Items[i].ItemName;
                newMessage.Items[i].ItemCount = firstRequest.Items[i].ItemCount;
            }

            platformContext.Messages.Add(newMessage);
            for (int i = 0; i < firstRequest.Items.Count; i++)
            {
                Exchange exchange = new Exchange();
                exchange.Requestor = firstRequest.Applicant;
                exchange.Supplicant = firstRequest.Recipient;
                exchange.NeedId = firstRequest.NeedId;
                exchange.SupplyId = firstRequest.SupplyId;
                exchange.ItemName = firstRequest.Items[i].ItemName;
                exchange.ItemCount = Convert.ToString(firstRequest.Items[i].ItemCount);
                exchange.Type = "请求";
                exchange.Time = firstRequest.Time;
                platformContext.Exchanges.Add(exchange);
            }
            platformContext.SaveChanges();
        }

        public void SendSecondRequest(SecondAndThirdRequest secondRequest)
        {
            Message newMessage = new Message();
            newMessage.Applicant = secondRequest.Applicant;
            newMessage.Recipient = secondRequest.Recipient;
            newMessage.SupplyId = secondRequest.SupplyId;
            newMessage.NeedId = secondRequest.NeedId;
            newMessage.Time = secondRequest.Time;
            newMessage.MessageType = "Second";
            newMessage.MeaasgeState = "N";
            newMessage.Items = new List<Item>();
            for (int i = 0; i < secondRequest.Items.Count; i++)
                newMessage.Items.Add(new Item());
            for (int i = 0; i < secondRequest.Items.Count; i++)
            {
                newMessage.Items[i].ItemName = secondRequest.Items[i].ItemName;
                newMessage.Items[i].ItemCount = secondRequest.Items[i].ItemCount;
            }

            platformContext.Messages.Add(newMessage);

            var query = platformContext.Messages.Include("Items").FirstOrDefault(p => p.MessageId == secondRequest.TargetMessageId);
            if (query != null)
            {
                query.MeaasgeState = "Y";
            }

            var query_supply = platformContext.Supplies.Include("Items").FirstOrDefault(p => p.SupplyId == secondRequest.SupplyId);
            if (query_supply != null)
            {
                for (int i = 0; i < secondRequest.Items.Count; i++)
                {
                    for (int j = 0; j < query_supply.Items.Count; j++)
                    {
                        if (query_supply.Items[j].Name == secondRequest.Items[i].ItemName)
                        {
                            query_supply.Items[j].Count = query_supply.Items[j].Count - secondRequest.Items[i].ItemCount;

                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < secondRequest.Items.Count; i++)
            {
                Exchange exchange = new Exchange();
                exchange.Requestor = secondRequest.Applicant;
                exchange.Supplicant = secondRequest.Recipient;
                exchange.NeedId = secondRequest.NeedId;
                exchange.SupplyId = secondRequest.SupplyId;
                exchange.ItemName = secondRequest.Items[i].ItemName;
                exchange.ItemCount = Convert.ToString(secondRequest.Items[i].ItemCount);
                exchange.Type = "发货";
                exchange.Time = secondRequest.Time;
                platformContext.Exchanges.Add(exchange);
            }
            platformContext.SaveChanges();
        }

        public void SendThirdRequest(SecondAndThirdRequest thirdRequest)
        {
            Message newMessage = new Message();
            newMessage.Applicant = thirdRequest.Applicant;
            newMessage.Recipient = thirdRequest.Recipient;
            newMessage.SupplyId = thirdRequest.SupplyId;
            newMessage.NeedId = thirdRequest.NeedId;
            newMessage.Time = thirdRequest.Time;
            newMessage.MessageType = "Third";
            newMessage.MeaasgeState = "N";
            newMessage.Items = new List<Item>();
            for (int i = 0; i < thirdRequest.Items.Count; i++)
                newMessage.Items.Add(new Item());
            for (int i = 0; i < thirdRequest.Items.Count; i++)
            {
                newMessage.Items[i].ItemName = thirdRequest.Items[i].ItemName;
                newMessage.Items[i].ItemCount = thirdRequest.Items[i].ItemCount;
            }

            platformContext.Messages.Add(newMessage);

            var query = platformContext.Messages.Include("Items").FirstOrDefault(p => p.MessageId == thirdRequest.TargetMessageId);
            if (query != null)
            {
                query.MeaasgeState = "Y";
            }
            var query_need = platformContext.Needs.Include("Items").FirstOrDefault(p => p.NeedId == thirdRequest.NeedId);
            if (query_need != null)
            {
                for (int i = 0; i < thirdRequest.Items.Count; i++)
                {
                    for (int j = 0; j < query_need.Items.Count; j++)
                    {
                        if (query_need.Items[j].Name == thirdRequest.Items[i].ItemName)
                        {
                            query_need.Items[j].Count = query_need.Items[j].Count - thirdRequest.Items[i].ItemCount;

                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < thirdRequest.Items.Count; i++)
            {
                Exchange exchange = new Exchange();
                exchange.Requestor = thirdRequest.Applicant;
                exchange.Supplicant = thirdRequest.Recipient;
                exchange.NeedId = thirdRequest.NeedId;
                exchange.SupplyId = thirdRequest.SupplyId;
                exchange.ItemName = thirdRequest.Items[i].ItemName;
                exchange.ItemCount = Convert.ToString(thirdRequest.Items[i].ItemCount);
                exchange.Type = "完成";
                exchange.Time = thirdRequest.Time;
                platformContext.Exchanges.Add(exchange);
            }

            platformContext.SaveChanges();
        }
        public void Confirm(int MessageId)
        {
            var query = platformContext.Messages.Include("Items").FirstOrDefault(p => p.MessageId == MessageId);
            if (query != null)
            {
                query.MeaasgeState = "Y";
                platformContext.SaveChanges();
            }
        }

        public List<Exchange> GetExchangeBySupplyId(int id)
        {
            var query = platformContext.Exchanges.Where(p => p.SupplyId == id);

            return query.OrderBy(p=>p.Time).ToList<Exchange>();
        }

        public List<Exchange> GetExchangeByNeedId(int id)
        {
            var query = platformContext.Exchanges.Where(p => p.NeedId == id);

            return query.OrderBy(p=>p.Time).ToList<Exchange>();
        }

        public List<Message> GetSentMessage(string name)
        {
            var query = platformContext.Messages.Include("Items").Where(p => p.Applicant == name);

            return query.ToList<Message>();
        }

        public List<Message> GetReceiveMessageUnHandled(string name)
        {
            var query = platformContext.Messages.Include("Items").Where(p => p.Recipient == name && p.MeaasgeState == "N");

            return query.ToList<Message>();
        }

        public List<Message> GetReceiveMessageHandled(string name)
        {
            var query = platformContext.Messages.Include("Items").Where(p => p.Recipient == name && p.MeaasgeState == "Y");

            return query.ToList<Message>();
        }
    }
}
