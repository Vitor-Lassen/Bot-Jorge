using Back.API.JorgeGuinchos.Enum;
using Back.API.JorgeGuinchos.Interface;
using Back.API.JorgeGuinchos.Models;
using Back.API.JorgeGuinchos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.API.JorgeGuinchos.Services
{
    public class BotService : IBotService
    {
        private readonly IMessageService _messageServices;
        public BotService(IMessageService messageServices)
        {
            _messageServices = messageServices;
        }
        public void Call(string message, Chat chat)
        {
            var resposta = TreatmentMessage(message, chat);

            _messageServices.SendMessages(resposta, chat);

        }

        private IList<string> TreatmentMessage(string message, Chat chat)
        {
            // logica do bot// 
            IList<string> messages = new List<string>();
            var data = UserFlowRepository.GetUserData(chat.Id, out var isNewConverstion);
            if (isNewConverstion)
            {
                data.CurrentOrderFlow = "1";
                data.Name = chat.UserName;
                messages.Add("Ola bem vindo ao Jorge Guinchos!!");
                messages.Add("Mostrando opções");

                return messages;
            }
            var flows = FlowRepositoy.GetFlow(data.CurrentOrderFlow);

            var selectedFlow = flows.Where(s => s.Aliases.Contains(message.ToLower())).FirstOrDefault();
            if (selectedFlow != null)
            {
                messages = selectedFlow.Responses;

                switch (selectedFlow.FlowCommandEnum) {
                    case FlowCommandEnum.GoToInto:
                        data.CurrentOrderFlow +=  ".1";
                        break;
                    case FlowCommandEnum.Linear:    
                        var all = data.CurrentOrderFlow.Split('.');
                        all[all.Length - 1] = all.Last() + 1;
                       
                        data.CurrentOrderFlow = string.Join('.', all);
                        break;
                    case FlowCommandEnum.Back:
                        var all1 = data.CurrentOrderFlow.Split('.').ToList();
                        all1.RemoveAt(all1.Count - 1);
                        data.CurrentOrderFlow = string.Join('.', all1);
                        break;
                    case FlowCommandEnum.Reset:
                        data.CurrentOrderFlow = "1";
                            break;
                } 
            }

            return messages;
        }
    }
}
