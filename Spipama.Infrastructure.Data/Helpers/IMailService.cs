using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Infrastructure.Data.Helpers
{
    public interface IMailService
    {
        public Task SendEmail(string subject, string body, List<string> recipients, List<string> attachments = null);
    }
}
