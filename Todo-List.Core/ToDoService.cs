using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace Todo_List.Core
{
    public class ToDoService
    {
        
        private const string Url = "https://jsonplaceholder.typicode.com/todos";
        public async Task<List<ToDo>> GetToDosAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(Url);
                return JsonConvert.DeserializeObject<List<ToDo>>(json);
            }
        }
    }

    public class ToDo
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }
    }
}