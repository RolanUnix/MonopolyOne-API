using Newtonsoft.Json;

namespace Monopoly.Views
{
    public class User
    {
        [JsonProperty("user_id")] public ulong UserId;
        [JsonProperty("approved")] public int Approved;
        [JsonProperty("nick")] public string Nick;
        [JsonProperty("gender")] public int Gender;
        [JsonProperty("avatar")] public string AvatarUrl;
        [JsonProperty("online")] public int Online;
        [JsonProperty("current_game")] public Game Game;
        [JsonProperty("rank")] public Rank Rank;
        [JsonProperty("vip")] public int Vip;
        [JsonProperty("moderator")] public int Moderator;
        [JsonProperty("superadmin")] public int SuperAdmin;
        [JsonProperty("muted")] public int Muted;
    }
}
