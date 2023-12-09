using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    Dictionary<int, List<int>> cards = new ();
    private Dictionary<int, int> winning = new();

    public int Sum(string[] lines)
    {
        foreach (var line in lines)
        {
            Parse(line);
        }
        var res = 0;
        foreach (var card in cards.Keys)
        {
            res += GetWining(card);
            // Console.WriteLine("Card " + card + ": " + string.Join(", ", cards[card]));
        }
        return res;
    }

    private int GetWining(int card)
    {
        if (winning.ContainsKey(card)) return winning[card];
        var res = 1;
        foreach (var c in cards[card])
        {
            res += GetWining(c);
        }

        winning[card] = res;
        return res;
    }

    private void Parse(string line)
    {
        // Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
        string[] parts = line.Split(':');
        var cardId = int.Parse(parts[0].Split(" ").Last());
        string[] segments = parts[1].Split('|');
        
        // Console.WriteLine(segments[0]);
        // Console.WriteLine(segments[1]);
        //
        // Split each session into separate numbers and convert them to integers
        int[] firstSession = segments[0].Trim().Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(int.Parse).ToArray();
        int[] secondSession = segments[1].Trim().Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(int.Parse).ToArray();
    
        // Find the intersection between the two sessions
        int[] intersections = firstSession.Intersect(secondSession).ToArray();
        cards[cardId] = new();
        for(var i = 0; i < intersections.Length; i++)
        {
            cards[cardId].Add(cardId + i + 1);
        }
    }
}