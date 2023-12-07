namespace API.Hands;

public interface IHandProcessingStrategy
{
    EHandType DetermineHandType(CardsCollection cards);
    int GetRank(char с);
}