using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieShop.Services
{
    public class NullMailServices : IMailService
    {
        private readonly ILogger<NullMailServices> _logger;

        public NullMailServices(ILogger<NullMailServices> logger)
        {
            _logger = logger;
        }


       public void SendMessage(string to, string subject, string body)
        {
            _logger.LogInformation($"To: {to} Subject: {subject} Body: {body}");
        }
    }
}
