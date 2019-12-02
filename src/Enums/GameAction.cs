using System.ComponentModel;

namespace Monopoly.Enums
{
    public enum GameAction
    {
        [Description("rollDices")]
        RollDices,

        [Description("leave")]
        Leave,

        [Description("buy")]
        Buy,

        [Description("toAuction")]
        ToAuction,

        [Description("auctionAccept")]
        AuctionAccept,

        [Description("auctionDecline")]
        AuctionDecline,

        [Description("payRent")]
        PayRent,

        [Description("payToBank")]
        PayToBank,

        [Description("payForUnjail")]
        PayForUnJail,

        [Description("wormholeUse")]
        WormholeUse,

        [Description("wormholeDecline")]
        WormholeDecline,

        [Description("contract")]
        Contract,

        [Description("contract_accept")]
        ContractAccept,

        [Description("contract_decline")]
        ContractDecline,

        [Description("levelUp")]
        LevelUp,
    }
}
