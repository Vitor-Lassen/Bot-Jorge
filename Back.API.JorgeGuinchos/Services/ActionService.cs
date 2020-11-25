using Back.API.JorgeGuinchos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.API.JorgeGuinchos.Services
{
    public class ActionService
    {
        public void SaveAddress( UserInfo userInfo, string message)
        {
            userInfo.Data["Address"]  = message;
        }
        public void SaveCPF(UserInfo userInfo, string message)
        {
            userInfo.Data["CPF"] = message; 
        }
    }
}
