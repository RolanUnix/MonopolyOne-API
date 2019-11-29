using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
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
