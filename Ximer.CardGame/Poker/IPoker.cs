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

    (PokerSuit Suit, PokerRank Rank) ParsePoker() => PokerValue switch
    {
        52 => (PokerSuit.None, PokerRank.LittleJoker),
        53 => (PokerSuit.None, PokerRank.BigJoker),
        (>= 0) and (< 52) => ((PokerSuit)(PokerValue / 13), (PokerRank)((PokerValue % 13) + 1)),
        _ => throw new ArgumentException("PokerValue must range from 0 to 53")
    };

    PokerSuit PokerSuit => PokerValue switch
    {
        52 => PokerSuit.None,
        53 => PokerSuit.None,
        (>= 0) and (< 52) => (PokerSuit)(PokerValue / 13),
        _ => throw new ArgumentException("PokerValue must range from 0 to 53")
    };

    PokerRank PokerRank => PokerValue switch
    {
        52 => PokerRank.LittleJoker,
        53 => PokerRank.BigJoker,
        (>= 0) and (< 52) => (PokerRank)((PokerValue % 13) + 1),
        _ => throw new ArgumentException("PokerValue must range from 0 to 53")
    };

}
