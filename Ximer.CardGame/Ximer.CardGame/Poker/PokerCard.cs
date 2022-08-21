namespace Ximer.CardGame.Core.Poker;

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

    public byte PokerValue
    {
        get => pokerValue;
        set
        {
            if (pokerValue >= 0 && pokerValue <= 53) pokerValue = value;
            else throw new ArgumentException($"PokerValue must range from 0 to 53. The actual value is {value}");
        }
    }

    public PokerSuit Suit => this.ParsePoker().Suit;

    public PokerFaceValue FaceValue => this.ParsePoker().FaceValue;

    public override string ToString()
    {
        var info = this.ParsePoker();
        return $"{{ Suit={info.Suit}, FaceValue={info.FaceValue} }}";
    }

}
