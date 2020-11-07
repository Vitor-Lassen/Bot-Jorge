using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Back.API.JorgeGuinchos.DTO.Telegram;
using Back.API.JorgeGuinchos.Interface;
using Back.API.JorgeGuinchos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Back.API.JorgeGuinchos.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class WebhookController : Controller
    {
        private readonly ILogger<WebhookController> _logger;
        private readonly IBotService _botService;
        public WebhookController(ILogger<WebhookController> logger, 
                                 IBotService botService)
        {
            _logger = logger;
            _botService = botService;
        }

        [HttpGet]
        public IActionResult Up()
        {
            return Ok("It's work");
        }

        [HttpPost]
        public IActionResult Webhook([FromBody] TelegramReceivedDTO telegramReceivedDTO)
        {
            var chat = new Chat()
            {
                Id = telegramReceivedDTO.message.Chat.Id,
                Customer = $"{telegramReceivedDTO.message.Chat.FirstName} {telegramReceivedDTO.message.Chat.LastName}",
                UserName = telegramReceivedDTO.message.Chat.UserName
            };
            _botService.Call(telegramReceivedDTO.message.Text, chat);


            return Ok();
        }
    }
}
