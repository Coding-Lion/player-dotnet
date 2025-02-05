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

        // Pairs
        if (higherCard.rank == lowerCard.rank) score *= 2;

        // Cards suited?
        if (higherCard.suit == lowerCard.suit) score += 2;
        
        
        var gap = higherCard.getGap(lowerCard);

        Console.WriteLine();
        Console.WriteLine("ROUND: " + table.round);
        Console.WriteLine("High card: " + higherCard.rank + " " + higherCard.suit + " " + higherCard.points + " ");
        Console.WriteLine("Low card: " + lowerCard.rank + " " + lowerCard.suit + " " + lowerCard.points + " ");
        // Card gap
        if (gap >= 4) score -= 5;
        else if (gap == 3) score -= 4;
        else if (gap == 2) score -= 2;
        else if (gap == 1) score -= 1;
        else if (gap == 0) score -= 0;

        Console.WriteLine("Final Score: " + score);
        if (gap <= 1 && higherCard.rank != "Q" && higherCard.rank != "K" && higherCard.rank != "A")
            score += 1;

        if (score >= 11)
        {
            Console.WriteLine("ALL IN");
            return new Bet(ourPlayer.stack);
        }

        if (score >= 9) return new Bet(table.minimumRaise);

        var currentPosition = table.activePlayer - table.currentDealer;
        if (currentPosition < 0) currentPosition = table.players.Length - currentPosition - 1;

        Console.WriteLine("current Position: " + currentPosition + " " + table.currentDealer);
        var modifier = 0;
        var outPlayers = 0;
        foreach (var tablePlayer in table.players)
        {
            if (tablePlayer.status == "OUT") outPlayers++;
        }

        Console.WriteLine("outPlayers: " + outPlayers);
        if (outPlayers > 3) modifier = 1;
        if (outPlayers > 5) modifier = 3;

        if (score >= (7 - modifier) && currentPosition <= 1) return new Bet(table.minimumRaise);
        if (score >= (6 - modifier) && currentPosition <= 1)
        {
            Console.WriteLine("FOLD");
            return new Bet(0);
        }

        if (score >= (6 - modifier) && currentPosition <= 3) return new Bet(table.minimumRaise);
        if (score >= (5 - modifier) && currentPosition <= 3)
        {
            Console.WriteLine("FOLD");
            return new Bet(0);
        }

        if (score >= (5 - modifier) && currentPosition <= 5) return new Bet(table.minimumRaise);
        if (score >= (4 - modifier) && currentPosition <= 5)
        {
            Console.WriteLine("FOLD");
            return new Bet(0);
        }

        Console.WriteLine("FOLD");
        return new Bet(0);
    }
}