namespace Ximer.CardGame.Core.Poker;

/// <summary>
/// Defined the standard of Poker 
/// (0-12: Spade, 13-25: Heart, 26-38: Club, 39-51: Diamond, 52: Little Joker, 53: Big Joker)
/// </summary>
public interface IPoker
{
    byte PokerValue { get; set; }
}

public static class IPokerExtention
{
    public static (PokerSuit Suit, PokerFaceValue FaceValue) ParsePoker(this IPoker poker)
    {
        return poker.PokerValue switch
        {
            52 => (PokerSuit.None, PokerFaceValue.LittleJoker),
            53 => (PokerSuit.None, PokerFaceValue.BigJoker),
            (>= 0) and (< 52) => ((PokerSuit)(poker.PokerValue / 13), (PokerFaceValue)((poker.PokerValue % 13) + 1)),
            _ => throw new ArgumentException("PokerValue must range from 0 to 53")
        };
    }
}
