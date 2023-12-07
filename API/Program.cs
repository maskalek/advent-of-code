using System;
using System.IO;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lines = ParseInputFile();
            var result = new Solution().Sum(lines);
            Console.WriteLine(result);
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
