namespace Ximer.CardGame.Core.Poker;

/// <summary>
/// Standard implement of Poker
/// </summary>
public class PokerCard : Card, IPoker
{
    public PokerCard() { }

    public PokerCard(byte pokerValue) => PokerValue = pokerValue;

    private byte pokerValue = 0;
    /// <summary>
    /// Get or set the Poker value of the Card 
    /// </summary>
    public byte PokerValue
    {
        get => pokerValue;
        set
        {
            if (pokerValue >= 0 && pokerValue <= 53) pokerValue = value;
            else throw new ArgumentException($"PokerValue must range from 0 to 53. The actual value is {value}");
        }
    }

    /// <summary>
    /// Get or set the suit of the Card
    /// </summary>
    public PokerSuit Suit => ((IPoker)this).PokerSuit;

    /// <summary>
    /// Get or set the rank of the Card
    /// </summary>
    public PokerRank Rank => ((IPoker)this).PokerRank;

    public override string ToString()
    {
        var info = ((IPoker)this).ParsePoker();
        return $"{{ Suit={info.Suit}, Rank={info.Rank} }}";
    }

}
