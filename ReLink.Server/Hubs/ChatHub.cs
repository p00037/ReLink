using Microsoft.AspNetCore.SignalR;
using ReLink.Server.Dao;
using ReLink.Server.Entiy.DbEntity;
using System;
using System.Threading.Tasks;

namespace ReLink.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            try
            {
                //MessageId = 1,
                D_MessageEntity messageEntity = new D_MessageEntity() { GroupId = 1, UserName = user, Massage = message };
                DaoD_Message daoD_Message = new DaoD_Message();
                daoD_Message.Save(messageEntity);

                await Clients.All.SendAsync("ReceiveMessage", user, message);
            }
            catch(Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
}
