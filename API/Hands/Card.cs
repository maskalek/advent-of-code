namespace API.Hands;

public class Card
{
    public char Value { get; set; }
    public int Rank { get; set; }

    public Card(char value, int rank)
    {
        Value = value;
        Rank = rank;
    }
}