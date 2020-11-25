using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.API.JorgeGuinchos.Models
{
    public class UserInfo
    {
        public UserInfo(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        public string CurrentOrderFlow { get; set; }
        public string Name { get; set; }

        public IDictionary<string, string> Data { get; set; } = new Dictionary<string, string>();
    }
}
