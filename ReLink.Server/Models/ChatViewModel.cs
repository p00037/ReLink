using ReLink.Server.Entiy.DbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReLink.Server.Models
{
    public class ChatViewModel
    {
        public string UserName { get; set; }

        public List<D_MessageEntity> MessageEntitys { get; set; } = new List<D_MessageEntity>();
    }
}
