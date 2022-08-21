namespace Ximer.CardGame.Core.Poker;

/// <summary>
/// Defined the standard of Poker 
/// </summary>
public interface IPoker
{
    /// <summary>
    /// The serial value of a Poker card
    /// <para>0-12: Spade, 13-25: Heart, 26-38: Club, 39-51: Diamond</para>
    /// <para>52: Little Joker, 53: Big Joker</para>
    /// </summary>
    byte PokerValue { get; set; }
}

public static class IPokerExtention
{
    /// <summary>
    /// Parse the suit and rank of IPoker
    /// </summary>
    /// <param name="poker"></param>
    /// <returns>Suit and rank</returns>
    /// <exception cref="ArgumentException"></exception>
    public static (PokerSuit Suit, PokerRank Rank) ParsePoker(this IPoker poker) => poker.PokerValue switch
    {
        52 => (PokerSuit.None, PokerRank.LittleJoker),
        53 => (PokerSuit.None, PokerRank.BigJoker),
        (>= 0) and (< 52) => ((PokerSuit)(poker.PokerValue / 13), (PokerRank)((poker.PokerValue % 13) + 1)),
        _ => throw new ArgumentException("PokerValue must range from 0 to 53")
    };
}
