using Ximer.CardGame.Core.Mahjong;
using Ximer.CardGame.Core.Poker;

for (int i = 0; i < 45; i++)
{
    try
    {
        Console.WriteLine(new MahjongCard((byte)i));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

