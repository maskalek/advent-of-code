using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution
{
    private string[] lines;
    public long Sum(string[] input)
    {
        lines = Expand(input);
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

        long total = 0;
        for (var i = 0; i < galaxies.Count; i++)
        {
            for (var j = i + 1; j < galaxies.Count; j++)
            {
                total += Distance(galaxies[i].ToArray(), galaxies[j].ToArray());
            }
        }

        return total;
    }

    private long Distance(int[] g1, int[] g2)
    {
        long res = 0;
        var step = g1[0] < g2[0] ? 1 : -1;
        while (g1[0] != g2[0])
        {
            g1[0] += step;
            var c = lines[g1[0]][g1[1]];
            if (c != '*')
            {
                res++;
            }
            else 
            {
                res += 2;
            }

        }
        step = g1[1] < g2[1] ? 1 : -1;
        while (g1[1] != g2[1])
        {
            g1[1] += step;
            var c = lines[g1[0]][g1[1]];
            if (c != '*')
            {
                res++;
            }
            else
            {
                res += 2;
            }
        }

        return res;
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
                if (cols[j] == 0 || rows[i] == 0)
                {
                    sb.Append('*');
                }
                else
                {
                    sb.Append(lines[i][j]);
                }
            }
            newLines.Add(sb.ToString());
        }

        return newLines.ToArray();

    }
}