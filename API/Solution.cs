using System;
using System.Collections.Generic;
using System.Text;

public class Solution
{
    public int Sum(string[] lines)
    {
        lines = Expand(lines);
        var galaxies = new List<int[]>();
        for (var i = 0; i < lines.Length; i++)
        {
            for (var j = 0; j < lines[0].Length; j++)
            {
                if (lines[i][j] == '#')
                {
                    galaxies.Add(new [] { i, j });
                }
            }
        }

        var total = 0;
        for (var i = 0; i < galaxies.Count; i++)
        {
            for (var j = i + 1; j < galaxies.Count; j++)
            {
                total += Distance(galaxies[i], galaxies[j]);
            }
        }

        return total;
    }

    private int Distance(int[] g1, int[] g2)
    {
        var xDist = Math.Abs(g1[0] - g2[0]);
        var yDist = Math.Abs(g1[1] - g2[1]);
        return xDist + yDist;
    }

    private string[] Expand(string[] lines)
    {
        var rows = new int[lines.Length];
        var cols = new int[lines[0].Length];
        for (var i = 0; i < lines.Length; i++)
        {
            for (var j = 0; j < lines[0].Length; j++)
            {
                if (lines[i][j] == '#')
                {
                    rows[i]++;
                    cols[j]++;
                }
            }
        }
        
        var newLines = new List<string>();
        for (var i = 0; i < lines.Length; i++)
        {
            var sb = new StringBuilder();
            for (var j = 0; j < lines[0].Length; j++)
            {
                sb.Append(lines[i][j]);
                if (cols[j] == 0)
                {
                    sb.Append(lines[i][j]);
                }
            }
            newLines.Add(sb.ToString());
            if (rows[i] == 0)
            {
                newLines.Add(sb.ToString());
            }
        }

        return newLines.ToArray();

    }
}