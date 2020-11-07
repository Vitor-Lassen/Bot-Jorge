using Newtonsoft.Json;

namespace Back.API.JorgeGuinchos.DTO.Telegram
{
    public class TelegramChatDTO
    {
        public int Id { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }
       
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        
        [JsonProperty("userName")]
        public string UserName { get; set; }
    }
}