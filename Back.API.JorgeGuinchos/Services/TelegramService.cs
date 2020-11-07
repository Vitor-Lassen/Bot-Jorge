using Back.API.JorgeGuinchos.Interface;
using Back.API.JorgeGuinchos.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.API.JorgeGuinchos.Services
{
    public class TelegramService : IMessageService
    {
        private readonly IRestClient _restClient;
        public TelegramService()
        {
            _restClient = new RestClient("https://api.telegram.org/bot1425119210:AAEhJJFMM041J8wELbMKCUawCaG0U-8cewk/");
        }

        public bool SendMessages(IList<string> messages, Chat chat)
        { 

            foreach (var message in messages)
            {
                var request = new RestRequest("sendMessage", Method.POST);
                request.AddJsonBody(new { chat_id = chat.Id, text = message });
                _restClient.Execute(request);
            }
            return true;
        }
    }
}
