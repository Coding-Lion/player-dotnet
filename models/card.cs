public class Card
{
    public Rank rank;
    public Suit suit;
    public float points = 0;
    

    public void rateCard()
    {
        if (Rank.A == rank) points = 10;
        if (Rank.K == rank) points = 8;
        if (Rank.Q == rank) points = 7;
        if (Rank.J == rank) points = 6;
        if (Rank._10 == rank) points = 5;
        if (Rank._9 == rank) points = 9/2;
        if (Rank._8 == rank) points = 4;
        if (Rank._7 == rank) points = 7/2;
        if (Rank._6 == rank) points = 3;
        if (Rank._5 == rank) points = 5/2;
        if (Rank._4 == rank) points = 2;
        if (Rank._3 == rank) points = 3/2;
        if (Rank._2 == rank) points = 1;
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
        if (Rank.A == rank) return 13;
        if (Rank.K == rank) return 12;
        if (Rank.Q == rank) return 11;
        if (Rank.J == rank) return 10;
        if (Rank._10 == rank) return 9;
        if (Rank._9 == rank) return 8;
        if (Rank._8 == rank) return 7;
        if (Rank._7 == rank) return 6;
        if (Rank._6 == rank) return 5;
        if (Rank._5 == rank) return 4;
        if (Rank._4 == rank) return 3;
        if (Rank._3 == rank) return 2;
        if (Rank._2 == rank) return 1;
        return 0;
    }
}

