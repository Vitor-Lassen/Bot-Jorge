using Back.API.JorgeGuinchos.Enum;
using Back.API.JorgeGuinchos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.API.JorgeGuinchos.Repository
{
    public static class FlowRepositoy
    {
        private static readonly List<Flow> _repository =
            new List<Flow>()
            {
                new Flow()
                {
                    Order = "1",
                    Title = "novo",
                    Responses = new List<string> { "digite o endereco que esta no momento" },
                    Aliases = new List<string> {"queroguincho", "reboque", "socorro", "1"  },
                    FlowCommandEnum = FlowCommandEnum.GoToInto

                },
                new Flow()
                {
                    Order = "1.1",
                    Title = "novo",
                    Responses = new List<string> { "digite seu CPF" },
                    FlowCommandEnum = FlowCommandEnum.Linear, 
                    Action = "SaveAddress" 
                },
                new Flow()
                {
                    Order = "1.2",
                    Title = "novo",
                    Responses = new List<string> { "Escolha o metodo de Pagamento", "1 - Cartão de Crédito", "2 - Cartão de Debito ", "3 - Dinheiro" },
                    FlowCommandEnum = FlowCommandEnum.GoToInto,
                    Action = "SaveCPF" 
                },
                new Flow()
                {
                    Order = "1.2.1",
                    Title = "credito",
                    Responses = new List<string> { "Obrigado,estaremos enviando um guincho para o local mencionado, qualquer duvida ligar para xxxxx-xxxx" },
                    FlowCommandEnum = FlowCommandEnum.Back,
                    Aliases = new List<string> {"1","cartao de credito"}
                },
                new Flow()
                {
                    Order = "1.2.1",
                    Title = "debito",
                    Responses = new List<string> { "Obrigado,estaremos enviando um guincho para o local mencionado, quer duvida ligar para xxxxx-xxxx" },
                    FlowCommandEnum = FlowCommandEnum.Back,
                    Aliases = new List<string> {"2","cartao de debito"}
                },
                new Flow()
                {
                    Order = "1.2.1",
                    Title = "dinheiro",
                    Responses = new List<string> { "Obrigado,estaremos enviando um guincho para o local mencionado, quer duvida ligar para xxxxx-xxxx" },
                    FlowCommandEnum = FlowCommandEnum.Back,
                    Aliases = new List<string> {"3","dinheiro"}
                },

                new Flow()
                {
                    Order = "1",
                    Title = "Andamento",
                    Responses = new List<string> { "andamento", "onde esta" },
                    FlowCommandEnum = FlowCommandEnum.GoToInto
                }
            };


        public static IList<Flow> GetFlow(string order)
        {
            return _repository.Where(f => f.Order == order).ToList();
        }

    }
}
