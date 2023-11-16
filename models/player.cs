public enum PlayerStatusEnum
{
    ACTIVE = 'A',
    FOLDED = 'F',
    OUT = 'O'
}

public class Player
{
    public string name;
    public string status;
    public int stack;
    public int bet;
    public Card[] cards;
}
