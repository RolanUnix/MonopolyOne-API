using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Monopoly.Enums;
using Newtonsoft.Json.Linq;

namespace Monopoly
{
    public class Api
    {
        private readonly string _token;

        public Api(string email, string password)
        {
            _token = CallMethod("auth.signin", new Dictionary<string, string>
            {
                ["email"] = email,
                ["password"] = password
            })["access_token"].ToObject<string>();
        }

        public Api(string token)
        {
            _token = token;
        }
        
        public ulong CreateRoom(GameMode mode, bool @private, bool autoStart, bool twoAgainstTwo, int maxPlayers) => CallMethod("rooms.create", new Dictionary<string, string>
        {
            ["game_submode"] = ((int)mode).ToString(),
            ["game_2x2"] = twoAgainstTwo ? "1" : "0",
            ["maxplayers"] = maxPlayers.ToString(),
            ["option_private"] = @private ? "1" : "0",
            ["option_autostart"] = autoStart ? "1" : "0",
            ["is_tournament"] = "0"
        })["room_id"].ToObject<ulong>();

        public void DeleteRoom(ulong roomId) => CallMethod("rooms.delete", new Dictionary<string, string>
        {
            ["room_id"] = roomId.ToString()
        });

        public void InviteRoom(ulong userId, ulong roomId) => CallMethod("rooms.invite", new Dictionary<string, string>
        {
            ["user_id"] = userId.ToString(),
            ["room_id"] = roomId.ToString()
        });

        public void JoinRoom(ulong roomId) => CallMethod("rooms.join", new Dictionary<string, string>
        {
            ["room_id"] = roomId.ToString()
        });

        public void KickRoom(ulong userId, ulong roomId) => CallMethod("rooms.kick", new Dictionary<string, string>
        {
            ["room_id"] = roomId.ToString(),
            ["user_id"] = userId.ToString()
        });

        public void LeaveRoom() => CallMethod("rooms.leave", new Dictionary<string, string>());

        public void ChangeSettings(ChangeParameter parameter, int value, ulong roomId) => CallMethod("rooms.settingsChange", new Dictionary<string, string>
        {
            ["param"] = Extensions.GetEnumDescription(parameter),
            ["value"] = value.ToString(),
            ["room_id"] = roomId.ToString()
        });

        public void StartGame(ulong roomId) => CallMethod("rooms.startGame", new Dictionary<string, string>
        {
            ["room_id"] = roomId.ToString()
        });

        public string GetTokenGame(uint id, ulong gameId) => CallMethod("games.resolve", new Dictionary<string, string>
        {
            ["gs_id"] = id.ToString(),
            ["gs_game_id"] = gameId.ToString()
        })["gs_token"].ToObject<string>();

        private JToken CallMethod(string methodName, IDictionary<string, string> parameters)
        {
            JToken result;

            if (_token != null) parameters.Add("access_token", _token);

            using (var web = new WebClient())
            {
                result = JToken.Parse(Encoding.UTF8.GetString(web.UploadValues($"https://monopoly-one.com/api/{methodName}", parameters.ToNameValueCollection())));
            }

            if (result["code"].ToObject<int>() != 0) throw new Exception(result["description"].ToObject<string>());

            File.AppendAllText("log.txt", $"[{methodName}]: {result}\n\n");

            return result["data"];
        }
    }
}
