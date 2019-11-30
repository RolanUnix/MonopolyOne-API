using Newtonsoft.Json;

namespace Monopoly.Views
{
    public class Rank
    {
        [JsonProperty("id")] public int Id;
        [JsonProperty("title")] public string Title;
        [JsonProperty("img")] public string ImageUrl;
    }
}