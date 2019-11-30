using System.ComponentModel;

namespace Monopoly.Enums
{
    public enum ChangeParameter
    {
        [Description("private")]
        Private,

        [Description("autostart")]
        AutoStart,

        [Description("maxplayers")]
        MaxPlayers,

        [Description("game_timers")]
        Timer,

        [Description("br_corner")]
        AngularField
    }
}