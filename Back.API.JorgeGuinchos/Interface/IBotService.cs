using Back.API.JorgeGuinchos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.API.JorgeGuinchos.Interface
{
    public interface IBotService
    {
        void Call(string message, Chat chat);
    }
}
