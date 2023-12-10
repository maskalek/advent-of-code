using System;
using System.Collections.Generic;
using System.Linq;
using API;

public class Solution
{
    public long Sum(string[] lines)
    {
        // seeds: 79 14 55 13
        var seeds = lines[0].Split(":")[1].Trim().Split(" ").Select(x => long.Parse(x.ToString())).ToArray();

        var transformations = new List<Transformation>[7];
        // seed-to-soil map:
        // 50 98 2
        // 52 50 48
        var k = -1;
        for (var j = 1; j < lines.Length; j++)
        {
            var line = lines[j];
            if (string.IsNullOrEmpty(line) || !char.IsNumber(line[0]))
            {
                k++;
                j++;
                transformations[k] = new();
                continue;
            }
            transformations[k].Add(new Transformation(line));
        }
        
        foreach (var t in transformations)
        {
            for (var i = 0; i < seeds.Length; i++)
            {
                seeds[i] = Calculate(seeds[i], t);
            }
        }

        return seeds.Min();
    }

    private long Calculate(long seed, List<Transformation> transformations)
    {
        var res = long.MaxValue;
        foreach (var t in transformations)
        {
            if (t.Contains(seed))
            {
                res = Math.Min(res, t.Transform(seed));
            }
        }

        return res == long.MaxValue ? seed : res;
    }
}