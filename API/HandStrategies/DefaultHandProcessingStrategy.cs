using System.Collections.Generic;
using System.Linq;

namespace API.Hands;

public class DefaultHandProcessingStrategy : IHandProcessingStrategy
{
    public EHandType DetermineHandType(CardsCollection cards)
    {
        Dictionary<char, int> counts = new();
        foreach(var card in cards.ToString())
        {
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
    
        if(fiveOfKind) return EHandType.FiveOfKind;
        else if(fourOfKind) return EHandType.FourOfKind;
        else if(threeOfKind && pairs == 1) return EHandType.FullHouse;
        else if(threeOfKind) return EHandType.ThreeOfKind;
        else if(pairs == 2) return EHandType.TwoPair;
        else if(pairs == 1) return EHandType.OnePair;
        
        return EHandType.HighCard;
    }

    public int GetRank(char c)
    {
        var ranks = new Dictionary<char, int>
        {
            { 'A', 14 }, { 'K', 13 }, { 'Q', 12 }, { 'J', 1 }, { 'T', 10 }, { '9', 9 }, { '8', 8 }, { '7', 7 },
            { '6', 6 }, { '5', 5 }, { '4', 4 }, { '3', 3 }, { '2', 2 }
        };
        return ranks[c];
    }
}