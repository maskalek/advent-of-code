﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using API.Hands;

/// <summary>
/// Represents a Solution for calculating total winning based on the bid values of cards.
/// </summary>
public class Solution
{
    public long GetTotalWining(string[] cards)
    {
        Array.Sort(cards, CompareHands);
        
        long totalWining = 0;

        for (var i = 0; i < cards.Length; i++)
        {
            var bid = Convert.ToInt32(cards[i].Split(" ")[1]);
            totalWining += (bid) * (i + 1);
        }
    
        return totalWining;
    }


    /// Compares two card values and returns the result.
    /// @param card1 The first card value to compare.
    /// @param card2 The second card value to compare.
    /// @returns Returns an integer value representing the result of the comparison:
    /// -1 if card1 is smaller than card2,
    /// 0 if card1 is equal to card2,
    /// 1 if card1 is greater than card2.
    /// /
    private int CompareHands(string handAndBid1, string handAndBid2)
    {
        var hand1 = (handAndBid1.Split(" ")[0]);
        var handType1 = GetHandType(hand1);
        var hand2 = (handAndBid2.Split(" ")[0]);
        var handType2 = GetHandType(hand2);

        if (handType1 == handType2)
        {
            for (var i = 0; i < 5; i++)
            {
                var card1 = hand1[i];
                var card2 = hand2[i];
                var rank1 = GetCardRank(card1);
                var rank2 = GetCardRank(card2);
                if (rank1 < rank2)
                {
                    return -1;
                }
                else if (rank1 > rank2)
                {
                    return 1;
                }
            }

            return 0;
        }

        return handType1 < handType2 ? -1 : 1;
    }

    private EHandType GetHandType(string hand)
    {
        var cards = hand.ToCharArray();
        var counts = new Dictionary<char, int>();
    
        foreach(var card in cards)
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
    private int GetCardRank(char card)
    {
        var ranks = new Dictionary<char, int> { { 'A', 14 }, { 'K', 13 }, { 'Q', 12 }, { 'J', 11 }, { 'T', 10 }, { '9', 9 }, { '8', 8 }, { '7', 7 }, { '6', 6 }, { '5', 5 }, { '4', 4 }, { '3', 3 }, { '2', 2 } };
        return ranks[card];
    }
}