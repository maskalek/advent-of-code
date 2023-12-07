using System.Linq;

public class Solution
{
    public long Sum(string[] lines)
    {
        long total = 0;
        foreach (var line in lines)
        {
            total += GetCalibrationValue(line);
        }

        return total;
    }

    private int GetCalibrationValue(string line)
    {
        string cleanedLine = new string(line.Where(char.IsDigit).ToArray());

        string firstDigit = cleanedLine[0].ToString();
        string lastDigit = cleanedLine[^1].ToString();
        string twoDigitNumber = firstDigit + lastDigit;

        return int.Parse(twoDigitNumber);
    }
}