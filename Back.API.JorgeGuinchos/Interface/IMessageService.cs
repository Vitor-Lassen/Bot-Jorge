using Back.API.JorgeGuinchos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.API.JorgeGuinchos.Interface
{
    public interface IMessageService
    {
        bool SendMessages(IList<string> messages, Chat chat);
    }
}
