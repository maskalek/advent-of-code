using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Hands;

public class CardsCollection : List<Card>
{
    private _handStringRepresentation

    public CardsCollection(string hand, Func<char, int> getRank)
    {
        foreach (var c in hand)
        {
            this.Add(new Card(c, getRank(c)));
        }
    }

    public override string ToString()
    {
        return string.Join(", ", _cards.Select(x => x.Value));
    }

    public Card this[int i]
    {
        get { return _cards[i]; }
    }
}