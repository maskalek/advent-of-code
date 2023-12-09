using System;
using System.Linq;

public class Solution
{
    public int Sum(string[] lines)
    {
        var res = 0;
        foreach (var line in lines)
        {
            res += CalcWining(line);
        }

        return res;
    }

    private int CalcWining(string line)
    {
        // Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
        
        string[] segments = line.Split(':')[1].Split('|');
        
        // Console.WriteLine(segments[0]);
        // Console.WriteLine(segments[1]);
        //
        // Split each session into separate numbers and convert them to integers
        int[] firstSession = segments[0].Trim().Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(int.Parse).ToArray();
        int[] secondSession = segments[1].Trim().Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(int.Parse).ToArray();
    
        // Find the intersection between the two sessions
        int[] intersections = firstSession.Intersect(secondSession).ToArray();
    
        // Calculate the number of intersections
        int intersectionCount = intersections.Count();
    
        // Return 2 to the power of the number of intersections
        return (int)Math.Pow(2, intersectionCount - 1);
    }
}