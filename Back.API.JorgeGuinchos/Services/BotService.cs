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
        private readonly ActionService _actionService;

        public BotService(IMessageService messageServices, ActionService actionService)
        {
            _messageServices = messageServices;
            _actionService = actionService;
        }
        public void Call(string message, Chat chat)
        {
            var resposta = TreatmentMessage(message, chat);

            _messageServices.SendMessages(resposta, chat);

        }
        delegate void Action(UserInfo userInfo, string message);
        private IList<string> TreatmentMessage(string message, Chat chat)
        {
            var data = UserFlowRepository.GetUserData(chat.Id, out var isNewConversation);
            // logica do bot// 
            IList<string> messages = new List<string>();
            if (isNewConversation)
            {
                data.CurrentOrderFlow = "1";
                data.Name = chat.UserName;
                messages.Add("Ola bem vindo ao Jorge Guinchos!!");
                messages.Add("Mostrando opções");
                messages.Add("1 - novo Guincho ");


                return messages;
            }
            var flows = FlowRepositoy.GetFlow(data.CurrentOrderFlow);

            var selectedFlow = flows.Where(s => s.Aliases.Contains(message.ToLower())).FirstOrDefault();

            if (flows.Count == 1 && !string.IsNullOrEmpty( flows.First().Action))
            {
                Action action = (Action)Delegate.CreateDelegate(typeof(Action), _actionService, flows.First().Action, true);
                action(data, message);

                selectedFlow = flows.First();
            }

            if (selectedFlow != null)
            {
                messages = ReplaceParameters(selectedFlow.Responses, data.Data);

                switch (selectedFlow.FlowCommandEnum) {
                    case FlowCommandEnum.GoToInto:
                        data.CurrentOrderFlow +=  ".1";
                        break;
                    case FlowCommandEnum.Linear:    
                        var all = data.CurrentOrderFlow.Split('.');
                        all[all.Length - 1] = (Convert.ToInt32(all.Last()) + 1).ToString();
                       
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
        private static List<string> ReplaceParameters( IList<string> messages, IDictionary<string, string> parameters)
        {
            var responseMessages = new List<string>();
            foreach (var message in messages)
            {
                string temp = message; 
                foreach (var param in parameters)
                {
                    if (!message.Contains("{{"))
                        break;
                    temp = message.Replace("{{" + param.Key + "}}", param.Value);
                }
                responseMessages.Add(temp);
            }
            return responseMessages;
        }
    }
}
