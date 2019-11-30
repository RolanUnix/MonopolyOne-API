using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Monopoly;
using Monopoly.Enums;

namespace Tests
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var api = new Api("", "");
            Console.WriteLine(api.CreateRoom(GameMode.Simple, true, false, false, 5));
        }
    }
}
