public class Card
{
    public string rank;
    public string suit;
    public float points = 0;
    

    public void rateCard()
    {
        if ("A" == rank)      points = 10;
        else if ("K" == rank) points = 8;
        else if ("Q" == rank) points = 7;
        else if ("J" == rank) points = 6;
        else if ("10" == rank) points = 5;
        else if ("9" == rank)  points = 9/2;
        else if ("8" == rank)  points = 4;
        else if ("7" == rank)  points = 7/2;
        else if ("6" == rank)  points = 3;
        else if ("5" == rank)  points = 5/2;
        else if ("4" == rank)  points = 2;
        else if ("3" == rank)  points = 3/2;
        else if ("2" == rank)  points = 1;
        else Console.WriteLine("CARD NOT FOUND");
    }
    
    public int getGap(Card card)
    {
        int gapNumber = card.getGapNumber();
        int gapNumber2 = this.getGapNumber();
        if (gapNumber > gapNumber2) return gapNumber - gapNumber2;
        return gapNumber2 - gapNumber;
    }

    public int getGapNumber()
    {
        if ("A" == rank)      return 13;
        if ("K" == rank) return 12;
        if ("Q" == rank) return 11;
        if ("J" == rank) return 10;
        if ("10" == rank) return 9;
        if ("9" == rank) return 8;
        if ("8" == rank) return 7;
        if ("7" == rank) return 6;
        if ("6" == rank) return 5;
        if ("5" == rank) return 4;
        if ("4" == rank) return 3;
        if ("3" == rank) return 2;
        if ("2" == rank) return 1;
        else Console.WriteLine("CARD NOT FOUND");
        return 0;
    }
}

