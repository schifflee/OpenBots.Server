using OpenBots.Server.Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.Model.SystemConfiguration
{
    public class EmailLog : Entity
    {
        public Guid EmailAccountId { get; set; }
        public DateTime SentOnUTC { get; set; }
        public string EmailObjectJson { get; set; }
        public string SenderAddress { get; set; }
        public Guid? SenderUserId { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
    }
}