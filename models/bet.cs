namespace client_dotnet.models;

public class Bet
{
    public int _bet;
    public int bet
    {
        get
        {
            return bet;
        }
        set
        {
            _bet = value;
        }
    }
    public Bet(int bet)
    {
        this._bet = bet;
    }
}