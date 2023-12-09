using System.Collections.Generic;
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
        var digitMap = new Dictionary<string, string>()
        {
            {"one", "o1e"}, {"two", "t2o"}, {"three", "t3e"}, {"four", "f4r"},
            {"five", "f5e"}, {"six", "s6x"}, {"seven", "s7n"}, {"eight", "e8t"}, {"nine", "n9e"}
        };

        foreach (var entry in digitMap)
        {
            line = line.Replace(entry.Key, entry.Value);
        }
        string cleanedLine = new string(line.Where(char.IsDigit).ToArray());

        string firstDigit = cleanedLine[0].ToString();
        string lastDigit = cleanedLine[^1].ToString();
        string twoDigitNumber = firstDigit + lastDigit;

        return int.Parse(twoDigitNumber);
    }
}