using System;
using System.IO;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lines = ParseInputFile();
            long res = 0;
            foreach (var line in lines)
            {
                var game = new Game(line);
                var power = (long)game.MaxGreen * (long)game.MaxRed * (long)game.MaxBlue;
                res += power;
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
