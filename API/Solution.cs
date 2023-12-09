using System;

public class Solution
{
    public int Sum(string[] lines)
    {
        var res = 0;
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var cur = 0;
            var startIndex = -1;
            for (var j = 0; j < line.Length; j++)
            {
                var c = line[j];
                if (char.IsNumber(c))
                {
                    cur = 10 * cur + int.Parse(c.ToString());
                    if (startIndex == -1)
                    {
                        startIndex = j;
                    }
                }

                if (!char.IsNumber(c) || j == line.Length - 1)
                {
                    if (cur > 0 && CheckNumber(i, startIndex - 1, j))
                    {
                        res += cur;
                    }

                    cur = 0;
                    startIndex = -1;
                }
            }
        }

        return res;

        bool CheckNumber(int row, int startColumn, int endColumn)
        {
            return HasSymbol(row - 1, startColumn, endColumn)
                   || HasSymbol(row, startColumn, startColumn)
                   || HasSymbol(row, endColumn, endColumn)
                   || HasSymbol(row + 1, startColumn, endColumn);
        }

        bool HasSymbol(int row, int startColumn, int endColumn)
        {
            if (row < 0 || row >= lines.Length) return false;
            for (var k = Math.Max(0, startColumn); k <= Math.Min(endColumn, lines[row].Length - 1); k++)
            {
                var c = lines[row][k];
                if (c != '.' && !char.IsNumber(c))
                {
                    return true;
                }
            }

            return false;
        }
    }
}