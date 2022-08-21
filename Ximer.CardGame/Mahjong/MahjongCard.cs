namespace Ximer.CardGame.Core.Mahjong;

/// <summary>
/// Standard implement of Mahjong
/// </summary>
public class MahjongCard : Card, IMahjong
{
    public MahjongCard() { }

    public MahjongCard(byte mahjongValue) => MahjongValue = mahjongValue;

    private byte mahjongValue = 0;
    /// <summary>
    /// Get or set the Mahjong value of the Card 
    /// </summary>
    public byte MahjongValue
    {
        get => mahjongValue;
        set
        {
            if (mahjongValue >= 0 && mahjongValue <= 29 ||
                mahjongValue >= 31 && mahjongValue <= 38 ||
                mahjongValue >= 41 && mahjongValue <= 44)
                mahjongValue = value;
            else throw new ArgumentException($"MahjongValue must range from 0 to 29, 31 to 38 or 41 to 44. The actual value is {value}");
        }
    }

    /// <summary>
    /// Get the suit of the Card
    /// </summary>
    public MahjongSuit Suit => ((IMahjong)this).MahjongSuit;

    /// <summary>
    /// Get the rank of the Card
    /// </summary>
    public MahjongRank Rank => ((IMahjong)this).MahjongRank;

    public override string ToString()
    {
        var info = ((IMahjong)this).ParseMahjong();
        return $"{{ Suit={info.Suit}, Rank={info.Rank} }}";
    }
}
