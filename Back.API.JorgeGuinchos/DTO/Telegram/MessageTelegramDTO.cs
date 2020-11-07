using System;

namespace Back.API.JorgeGuinchos.DTO.Telegram
{
    public class MessageTelegramDTO
    {
        public string Text { get; set; }
        public long Date { get; set; }
        public TelegramChatDTO Chat { get; set; }
    }
}