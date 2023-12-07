using System;
using System.IO;
using API.Hands;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lines = ParseInputFile();
            // var hands = new HandsCollection(lines, new DefaultHandProcessingStrategy());
            var hands = new HandsCollection(lines, new JokerHandProcessingStrategy());
            Console.WriteLine(hands.CalculateTotal());
            
            // 249004770
            // 246436046
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