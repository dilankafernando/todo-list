using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
        
        public async Task<ToDo> GetToDoAsync(int id)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Url}/{id}");
                return JsonConvert.DeserializeObject<ToDo>(json);
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
}