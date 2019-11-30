using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Monopoly;
using Monopoly.Enums;

namespace Tests
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var api = new Api("", "");
            var roomId = api.CreateRoom(GameMode.Simple, true, false, false, 5);
            Thread.Sleep(10000);
            api.DeleteRoom(roomId);
        }
    }
}
