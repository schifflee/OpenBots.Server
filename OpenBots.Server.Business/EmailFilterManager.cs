using OpenBots.Server.Model.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OpenBots.Server.Business
{
    public class EmailFilterManager
    {
        public List<EmailFilter> Filters { get; set; }
   
        public bool IsAllowed(string emailAddress)
        {
            if (!string.IsNullOrEmpty(emailAddress) || !emailAddress.Contains("@") || Filters != null)
                return false;

            string emailDomain = emailAddress.Split('@')[1].ToLowerInvariant().Trim();

            if (string.IsNullOrEmpty(emailDomain))
                return false;


            IEnumerable<string> Whitelist = Filters.Where(f => f.FilterType.Equals(EmailFilterType.Whitelist)).Select( f => f.Name.ToLowerInvariant().Trim());
            IEnumerable<string> Blacklist = Filters.Where(f => f.FilterType.Equals(EmailFilterType.Blacklist)).Select(f => f.Name.ToLowerInvariant().Trim());

            if (Whitelist.Count() > 0)
            {
                if (Whitelist.Contains(emailDomain))
                    return true;
                else
                    return false;
            }
            if (Blacklist.Count() > 0)
            {
                if (Blacklist.Contains(emailDomain))
                    return false;
                else
                    return true;
            }

            return true;
        }
    }
}
