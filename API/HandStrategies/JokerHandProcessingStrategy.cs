using System.Collections.Generic;

namespace API.Hands;

public class JokerHandProcessingStrategy : IHandProcessingStrategy
{
    public EHandType DetermineHandType(CardsCollection cards)
    {
        var counts = new Dictionary<char, int>();

        var jacks = 0;
        foreach(var card in cards.ToString())
        {
            if (card == 'J')
            {
                jacks++;
                continue;
            }
            if(counts.ContainsKey(card)) counts[card]++;
            else counts[card] = 1;
        }
    
        var pairs = 0;
        var threeOfKind = false;
        var fourOfKind = false;
        var fiveOfKind = false;
    
        foreach(var count in counts.Values)
        {
            if(count == 2) pairs++;
            else if(count == 3) threeOfKind = true;
            else if(count == 4) fourOfKind = true;
            else if(count == 5) fiveOfKind = true;
        }
    
        if(fiveOfKind || fourOfKind && jacks == 1 || threeOfKind && jacks == 2 || pairs == 1 && jacks == 3 || jacks >= 4) return EHandType.FiveOfKind;
        else if(fourOfKind || threeOfKind && jacks >= 1 || pairs == 1 && jacks >= 2 || jacks >= 3) return EHandType.FourOfKind;
        else if(threeOfKind && pairs == 1 || pairs == 2 && jacks == 1 || threeOfKind && jacks >= 1 || pairs >= 1 && jacks >= 2) return EHandType.FullHouse;
        else if(threeOfKind || pairs >= 1 && jacks >= 1 || jacks >= 2) return EHandType.ThreeOfKind;
        else if(pairs == 2 || pairs == 1 && jacks >= 1 || jacks >= 2) return EHandType.TwoPair;
        else if(pairs == 1 || jacks >= 1) return EHandType.OnePair;
        
        return EHandType.HighCard;
    }

    public int GetRank(char c)
    {
        var ranks = new Dictionary<char, int>
        {
            { 'A', 14 }, { 'K', 13 }, { 'Q', 12 }, { 'J', 11 }, { 'T', 10 }, { '9', 9 }, { '8', 8 }, { '7', 7 },
            { '6', 6 }, { '5', 5 }, { '4', 4 }, { '3', 3 }, { '2', 2 }
        };
        return ranks[c];
    }
}