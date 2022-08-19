namespace Ximer.CardGame.Core;

public abstract class Match
{
    public long MatchID { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public abstract string MatchType { get; set; }

    public abstract IEnumerable<Player> Players { get; set; }

    public abstract IMatchController MatchController { get; set; }

    public abstract IEnumerable<Card> CardPool { get; set; }
}
