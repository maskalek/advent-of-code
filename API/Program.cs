using System;
using System.IO;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lines = ParseInputFile();
            var res = 0;
            foreach (var line in lines)
            {
                var game = new Game(line);
                if (game.MaxRed <= 12 && game.MaxGreen <= 13 && game.MaxBlue <= 14)
                {
                    res += game.Id;
                }
            }
            Console.WriteLine(res);
        }
        private static string[] ParseInputFile()
        {
            string filePath = "input.txt";
            string[] lines = null; 

            try
            {
                lines = File.ReadAllLines(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return lines;
        }
    }
}
