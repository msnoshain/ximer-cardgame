namespace Ximer.CardGame.Core.Mahjong;

/// <summary>
/// Defined the standard of Mahjong 
/// </summary>
public interface IMahjong
{
    /// <summary>
    /// The serial value of a Mahjong card
    /// <para>0: Red - 红中, 1-9: Character - 万</para>
    /// <para>10: Green - 发, 11-19: Dot - 筒/饼</para>
    /// <para>20: White - 白, 21-29: Bamboo - 条/索</para>
    /// <para>31-38: Flower - 花, 41-44: Wind - 风</para>
    /// </summary>
    byte MahjongValue { get; set; }

    /// <summary>
    /// Get whether the MahjongValue represents Dragon - 箭牌
    /// </summary>
    bool IsDragon => MahjongValue % 10 == 0;

    /// <summary>
    /// Get whether the MahjongValue represents Wind - 风牌
    /// </summary>
    bool IsWind => MahjongValue >= 41 && MahjongValue <= 44;

    /// <summary>
    /// Get whether the MahjongValue represents Honor - 字牌/役牌
    /// </summary>
    bool IsHonor => IsDragon || IsWind;

    /// <summary>
    /// Get whether the MahjongValue represents Flower - 花牌
    /// </summary>
    bool IsFlower => MahjongValue >= 31 && MahjongValue <= 38;

    /// <summary>
    /// Get whether the MahjongValue represents Character - 万牌
    /// </summary>
    bool IsCharacter => MahjongValue >= 1 && MahjongValue <= 9;

    /// <summary>
    /// Get whether the MahjongValue represents Dot - 筒牌/饼牌
    /// </summary>
    bool IsDot => MahjongValue >= 11 && MahjongValue <= 19;

    /// <summary>
    /// Get whether the MahjongValue represents Bamboo - 条牌/索牌
    /// </summary>
    bool IsBamboo => MahjongValue >= 1 && MahjongValue <= 9;

    /// <summary>
    /// Get whether the MahjongValue represents Rank - 序数牌
    /// </summary>
    bool IsRank => IsCharacter || IsDot || IsBamboo;

    (MahjongSuit Suit, MahjongRank Rank) ParseMahjong() => this switch
    {
        IMahjong { IsDragon: true, MahjongValue: < 30 } => ((MahjongSuit)(MahjongValue / 10), MahjongRank.None),
        IMahjong { MahjongValue: < 30 } => ((MahjongSuit)(MahjongValue / 10 + 2), (MahjongRank)(MahjongValue % 10)),
        IMahjong { MahjongValue: (>= 31) and (<= 38) } => ((MahjongSuit)(MahjongValue - 25), MahjongRank.None),
        IMahjong { MahjongValue: (>= 41) and (<= 44) } => ((MahjongSuit)(MahjongValue - 27), MahjongRank.None),
        _ => throw new ArgumentException("MahjongValue must range from 0 to 29, 31 to 38 or 41 to 44"),
    };

    MahjongSuit MahjongSuit => this switch
    {
        IMahjong { IsDragon: true, MahjongValue: < 30 } => (MahjongSuit)(MahjongValue / 10),
        IMahjong { MahjongValue: < 30 } => (MahjongSuit)(MahjongValue / 10 + 2),
        IMahjong { MahjongValue: (>= 31) and (<= 38) } => (MahjongSuit)(MahjongValue - 25),
        IMahjong { MahjongValue: (>= 41) and (<= 44) } => (MahjongSuit)(MahjongValue - 27),
        _ => throw new ArgumentException("MahjongValue must range from 0 to 29, 31 to 38 or 41 to 44"),
    };

    MahjongRank MahjongRank => this switch
    {
        IMahjong { IsDragon: true, MahjongValue: < 30 } => MahjongRank.None,
        IMahjong { MahjongValue: < 30 } => (MahjongRank)(MahjongValue % 10),
        IMahjong { MahjongValue: (>= 31) and (<= 38) } => MahjongRank.None,
        IMahjong { MahjongValue: (>= 41) and (<= 44) } => MahjongRank.None,
        _ => throw new ArgumentException("MahjongValue must range from 0 to 29, 31 to 38 or 41 to 44"),
    };
}
