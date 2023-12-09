using System.Linq;

public class Solution
{
    public int Sum(string[] lines)
    {
        var res = 0;
        foreach (var line in lines)
        {
            res += Extrapolate(line);
        }

        return res;
    }

    public int Extrapolate(string line)
    {
        // Parse the line into an array of integers
        int[] numbers = line.Split(' ').Select(int.Parse).ToArray();
        var res = numbers.Last();
    
        // Repeat the process until all values are zeros
        while (!numbers.All(n => n == 0))
        {
            // Create a new array to store the differences
            int[] differences = new int[numbers.Length - 1];
    
            // Calculate the differences between adjacent numbers
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                differences[i] = numbers[i + 1] - numbers[i];
            }
    
            // Replace the old numbers array with the difference array
            numbers = differences;
            res += differences.Last();
        }
        
        // Since all values are zeros, we can return zero as well.
        // If you want to return the count of zeros, return numbers.Length;
        return res;
    }
}