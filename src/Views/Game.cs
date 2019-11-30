using Newtonsoft.Json;

namespace Monopoly.Views
{
    public class Game
    {
        [JsonProperty("gs_id")] public uint ServerId;
        [JsonProperty("gs_game_id")] public ulong Id;
    }
}
