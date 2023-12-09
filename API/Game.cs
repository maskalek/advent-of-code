using System;
using System.Linq;

public class Game
{
    public int Id { get; set; }
    public int MaxBlue { get; set; }
    public int MaxRed { get; set; }
    public int MaxGreen { get; set; }

    public Game(){}
    public Game(string input)
    {
        // Split the input string by ':' to get the ID and the color data
        var splitInput = input.Split(':');

        // The ID is the second word in the first part of the split input
        var idAsString = splitInput[0].Split()[1];
        Id = int.Parse(idAsString);

        // Get the game data after the ':'
        var gameDataAsString = splitInput[1].Trim();

        // Split the string by ';' to get game data
        var gameData = gameDataAsString.Split(';').Select(data => data.Trim()).ToList();

        foreach (var data in gameData)
        {
            // Split the game data by ',' to get individual color data
            var colorData = data.Split(',').Select(cd => cd.Trim()).ToList();

            foreach (var cd in colorData)
            {
                // Split the color data by ' ' to get the color and its count
                var splitData = cd.Split(' ');
                var count = int.Parse(splitData[0]);
                var color = splitData[1];

                // Set the color counts
                switch (color)
                {
                    case "blue":
                        MaxBlue = Math.Max(MaxBlue, count);
                        break;
                    case "red":
                        MaxRed = Math.Max(MaxRed, count);
                        break;
                    case "green":
                        MaxGreen = Math.Max(MaxGreen, count);
                        break;
                }
            }
        }
    }
}