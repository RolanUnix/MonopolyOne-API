using Newtonsoft.Json;

namespace Monopoly.Views
{
    public class Game
    {
        [JsonProperty("gs_id")] public uint Id;
        [JsonProperty("gs_game_id")] public ulong GameId;
    }
}
