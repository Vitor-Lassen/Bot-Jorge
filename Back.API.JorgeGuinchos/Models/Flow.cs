using Back.API.JorgeGuinchos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.API.JorgeGuinchos.Models
{
    public class Flow
    {
        public string Order { get; set; }
        public string Title { get; set; }
        public IList<string> Aliases { get; set; } = new List<string>();
        public IList<string> Responses { get; set; }
        public FlowCommandEnum FlowCommandEnum{ get; set; }
        public string Action { get; set; }
    }
}
