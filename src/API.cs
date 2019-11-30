using System;
using System.Collections.Generic;
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
            ["is_tournament"] = "0",
            ["access_token"] = _token
        })["room_id"].ToObject<ulong>();

        private JToken CallMethod(string methodName, IDictionary<string, string> parameters)
        {
            JToken result;

            using (var web = new WebClient())
            {
                result = JToken.Parse(Encoding.UTF8.GetString(web.UploadValues($"https://monopoly-one.com/api/{methodName}", parameters.ToNameValueCollection())));
            }

            if (result["code"].ToObject<int>() != 0) throw new Exception(result["description"].ToObject<string>());

            return result["data"];
        }
    }
}
