using System;
using System.Collections;
using System.Collections.Generic;

public class Solution
{
    public int Sum(string[] lines)
    {
        var res = 0;
        Dictionary<(int, int), List<int>> gears = new();
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
                    if (cur > 0)
                    {
                        foreach (var coords in FindAllGears(i, startIndex - 1, j))
                        {
                            if (!gears.ContainsKey(coords))
                            {
                                gears[coords] = new();
                            }
                            gears[coords].Add(cur);
                        }
                    }

                    cur = 0;
                    startIndex = -1;
                }
            }
        }

        foreach (var (gearCoords, numbers) in gears)
        {
            if (numbers.Count == 2)
            {
                res += numbers[0] * numbers[1];
            }
        }

        return res;

        IEnumerable<(int, int)> FindAllGears(int row, int startColumn, int endColumn)
        {
            foreach (var valueTuple in FindGears(row - 1, startColumn, endColumn)) yield return valueTuple;
            foreach (var valueTuple in FindGears(row, startColumn, startColumn)) yield return valueTuple;
            foreach (var valueTuple in FindGears(row, endColumn, endColumn)) yield return valueTuple;
            foreach (var valueTuple in FindGears(row + 1, startColumn, endColumn)) yield return valueTuple;
        }

        IEnumerable<(int, int)> FindGears(int row, int startColumn, int endColumn)
        {
            if (row < 0 || row >= lines.Length) yield break;
            
            for (var k = Math.Max(0, startColumn); k <= Math.Min(endColumn, lines[row].Length - 1); k++)
            {
                var c = lines[row][k];
                if (c == '*')
                {
                    yield return (row, k);
                }
            }
        }
    }
}