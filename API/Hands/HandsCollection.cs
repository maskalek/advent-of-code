using System;
using System.Linq;

namespace API.Hands;

public class HandsCollection
{
    public Hand[] Hands { get; set; }

    public HandsCollection(string[] inputs, IHandProcessingStrategy strategy)
    {
        Hands = inputs.Select(input => new Hand(input, strategy)).ToArray();
    }

    public int CalculateTotal()
    {
        Array.Sort(Hands);
        foreach (var hand in Hands)
        {
            Console.WriteLine(hand.Cards.ToString());
        }
        int total = Hands.Sum(hand => hand.Bid);
        for (var i = 0; i < Hands.Length; i++)
        {
            var bid = Hands[i].Bid;
            total += bid * (i + 1);
        }

        return total;
    }
}