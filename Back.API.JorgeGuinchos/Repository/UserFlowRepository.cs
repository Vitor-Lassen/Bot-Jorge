using Back.API.JorgeGuinchos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.API.JorgeGuinchos.Repository
{
    public static class UserFlowRepository
    {
        private static List<UserInfo> _repository = new List<UserInfo>();

        public static UserInfo GetUserData(int chatId, out bool isNewConversation )
        {
            isNewConversation = false;
            var user = _repository.Where(f => f.Id == chatId).FirstOrDefault();
            if (user != null)
                return user;
            isNewConversation = true;
            user = new UserInfo(chatId);
            _repository.Add(user);
            return user;
        }

    }
}
