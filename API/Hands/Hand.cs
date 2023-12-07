using System.Linq;
using System;

namespace API.Hands
{
    // New class - HandsCollection

    public class Hand : IComparable<Hand>
    {
        
        public CardsCollection Cards { get; set; }
        public int Bid { get; set; }
        public EHandType HandType { get; set; }

        public Hand(string input, IHandProcessingStrategy strategy)
        {
            var parts = input.Split(' ');
            Cards = new CardsCollection(parts[0], strategy.GetRank);
            Bid = int.Parse(parts[1]);
            HandType = strategy.DetermineHandType(Cards);
        }
        
        public int CompareTo(Hand other)
        {
            if (HandType == other.HandType)
            {
                for (int i = 0; i < Cards.Length; i++)
                {
                    int comparison = Cards[i].Rank.CompareTo(other.Cards[i].Rank);
                    if (comparison != 0)
                    {
                        return comparison;
                    }
                }
                return 0;
            }

            return HandType.CompareTo(other.HandType);
        }
    }
}