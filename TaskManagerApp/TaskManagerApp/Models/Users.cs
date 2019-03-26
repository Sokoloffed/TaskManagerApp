using Newtonsoft.Json;

namespace TaskManagerApp
{
    public class Users
    {
        [JsonProperty(PropertyName ="id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string username { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string password { get; set; }

        [JsonProperty(PropertyName = "Tasks")]
        public Tasks[] Tasks { get; set; }

        [JsonProperty(PropertyName = "Branches")]
        public Branches[] Branches { get; set; }
    }
}
