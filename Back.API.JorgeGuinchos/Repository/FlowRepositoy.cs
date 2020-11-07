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
                    Aliases = new List<string> {"queroguincho", "reboque", "socorro" },
                    FlowCommandEnum = FlowCommandEnum.GoToInto

                },
                new Flow()
                {
                    Order = "1.1",
                    Title = "novo",
                    Responses = new List<string> { "digite seu CPF" },
                    FlowCommandEnum = FlowCommandEnum.Linear
                },
                new Flow()
                {
                    Order = "1.2",
                    Title = "novo",
                    Responses = new List<string> { "Escolha o metodo de Pagamento" },
                    FlowCommandEnum = FlowCommandEnum.Linear
                },
                new Flow()
                {
                    Order = "1.2.1",
                    Title = "credito",
                    Responses = new List<string> { "" },
                    FlowCommandEnum = FlowCommandEnum.Back
                },
                new Flow()
                {
                    Order = "1.2.1",
                    Title = "debito",
                    Responses = new List<string> { "" },
                    FlowCommandEnum = FlowCommandEnum.Back
                },
                new Flow()
                {
                    Order = "1.2.1",
                    Title = "dinheiro",
                    Responses = new List<string> { "" },
                    FlowCommandEnum = FlowCommandEnum.Back
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
