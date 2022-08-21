namespace Ximer.CardGame.Core;

public abstract class Match
{
    public abstract ICollection<Player> Players { get; set; }

    public abstract ICollection<Card> CardPool { get; set; }

    public abstract void Initialize();

    public abstract void Settle();
}
