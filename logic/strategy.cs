using client_dotnet.models;

public class Strategy
{
    public static Bet Decide(Table? table)
    {
        // fold on null data
        if (table is null) return new Bet(0);

        var ourPlayer = table.players[table.activePlayer];

        foreach (var ourPlayerCard in ourPlayer.cards)
        {
            ourPlayerCard?.rateCard();
        }

        var higherCard = ourPlayer.cards[0];
        var lowerCard = ourPlayer.cards[1];
        if (ourPlayer.cards[0].points < ourPlayer.cards[1].points)
        {
            higherCard = ourPlayer.cards[1];
            lowerCard = ourPlayer.cards[0];
        }

        float score = higherCard.points;

        // Cards suited?
        if (higherCard.rank == lowerCard.rank) score *= 2;

        var gap = higherCard.getGap(lowerCard);

        // Card gap
        if (gap >= 4) score -= 5;
        else if (gap == 3) score -= 4;
        else if (gap == 2) score -= 2;
        else if (gap == 1) score -= 1;
        else if (gap == 0) score -= 0;

        Console.WriteLine("ROUND: " + table.round);
        Console.WriteLine("Score: " + score);
        if (gap <= 1 && higherCard.rank != Rank.Q && higherCard.rank != Rank.K && higherCard.rank != Rank.A)
            score = score + 1;
        
        if (score >= 10) return new Bet(table.minimumRaise);
        
        if (score >= 9 && table.activePlayer <= 1) return new Bet(table.minimumRaise);
        if (score >= 8 && table.activePlayer <= 1) return new Bet(0);
        if (score >= 8 && table.activePlayer <= 3) return new Bet(table.minimumRaise);
        if (score >= 7 && table.activePlayer <= 3) return new Bet(0);
        
        if (score >= 7 && table.activePlayer <= 5) return new Bet(table.minimumRaise);
        if (score >= 6 && table.activePlayer <= 5) return new Bet(0);

        return new Bet(0);

    }
}