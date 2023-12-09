using System;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Tests;

public class GameTests
{
    private readonly ITestOutputHelper _output;

    public GameTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void Constructor_ShouldParseRandomInputCorrectly()
    {
        for (var i = 0; i < 10; i++)
        {
            // Arrange
            var (input, expectedGame) = GameStringGenerator.Generate();
            _output.WriteLine(input); 

            // Act 
            var game = new Game(input);

            // Assert 
            Assert.Equal(expectedGame.Id, game.Id);
            Assert.Equal(expectedGame.MaxBlue, game.MaxBlue);
            Assert.Equal(expectedGame.MaxRed, game.MaxRed);
            Assert.Equal(expectedGame.MaxGreen, game.MaxGreen);
        }
    }
} 

public static class GameStringGenerator
{
    private static readonly Random Random = new Random();
    private static readonly string[] Colors = { "green", "red", "blue" };

    public static (string, Game) Generate()
    {
        var game = new Game();

        var gameId = Random.Next(1, 1000);
        game.Id = gameId;
        var numSections = Random.Next(1, 5);
    
        var builder = new StringBuilder();
        builder.Append($"Game {gameId}:");
    
        for (var sectionIdx = 0; sectionIdx < numSections; sectionIdx++)
        {
            var numColors = Random.Next(1, Colors.Length + 1);
    
            builder.Append(" ");
    
            for (var colorIdx = 0; colorIdx < numColors; colorIdx++)
            {
                var count = Random.Next(1, 100);
                var color = Colors[colorIdx];
                if (color == "green")
                {
                    game.MaxGreen = Math.Max(game.MaxGreen, count);
                }
                if (color == "blue")
                {
                    game.MaxBlue = Math.Max(game.MaxBlue, count);
                }
                if (color == "red")
                {
                    game.MaxRed = Math.Max(game.MaxRed, count);
                }
                builder.Append($"{count} {color}");
    
                if (colorIdx < numColors - 1)
                {
                    builder.Append(", ");
                }
            }
    
            if (sectionIdx < numSections - 1)
            {
                builder.Append(";");
            }
        }
    
        return (builder.ToString(), game);
    }
}