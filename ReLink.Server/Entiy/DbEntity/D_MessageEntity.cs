using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReLink.Server.Entiy.DbEntity
{
    public class D_MessageEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }

        public int GroupId { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Massage { get; set; }
    }
}
