﻿namespace Ximer.CardGame.Core.Poker;

/// <summary>
/// GameCard that includes a PokerValue on it
/// </summary>
public class PokerCard : Card, IPoker
{
    public PokerCard()
    {

    }

    public PokerCard(byte pokerValue)
    {
        PokerValue = pokerValue;
    }

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
    /// Get the suit of the Card
    /// </summary>
    public PokerSuit Suit => this.ParsePoker().Suit;

    /// <summary>
    /// Get the face value of the Card
    /// </summary>
    public PokerFaceValue FaceValue => this.ParsePoker().FaceValue;

    public override string ToString()
    {
        var info = this.ParsePoker();
        return $"{{ Suit={info.Suit}, FaceValue={info.FaceValue} }}";
    }

}
