using System;
using System.Collections.Generic;

public class Solution
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    private Dictionary<char, int[][]> directionsMap = new()
    {
        {'|', new[] {new[] {-1, 0}, new[] {1, 0}}},
        {'-', new[] {new[] {0, -1}, new[] {0, 1}}},
        {'L', new[] {new[] {-1, 0}, new[] {0, 1}}},
        {'J', new[] {new[] {-1, 0}, new[] {0, -1}}},
        {'7', new[] {new[] {1, 0}, new[] {0, -1}}},
        {'F', new[] {new[] {1, 0}, new[] {0, 1}}},
        {'S', new[] {new[] {-1, 0}, new[] {1, 0}, new[] {0, 1}, new[] {0, -1}}}  // Added 'S' to generate all directions
    };
    
    private HashSet<Point> visited = new();
    
    public int Sum(string[] lines)
    {
        var start = FindStart();
        visited.Add(start);
        var left = Next(start);
        visited.Add(left);
        var right = Next(start);
        visited.Add(right);
        
        var distance = 1;
        while (!Equals(left, right))
        {
            left = Next(left);
            right = Next(right);
            distance++;
        }

        return distance;

        Point FindStart()
        {
            for (var i = 0; i < lines.Length; i++)
            {
                for (var j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == 'S')
                    {
                        return new Point(i, j);
                    }
                }
            }

            throw new Exception();
        }

        Point Next(Point curr)
        {
            visited.Add(curr);

            var c = lines[curr.X][curr.Y];
            var directions = directionsMap[c];
            foreach (var direction in directions)
            {
                var next = new Point(curr.X + direction[0], curr.Y + direction[1]);
                if (visited.Contains(next)) continue;
                if (next.X < 0 || next.X >= lines.Length || next.Y < 0 || next.Y >= lines[next.X].Length) continue;
                var nextC = lines[next.X][next.Y];
                if (!directionsMap.ContainsKey(nextC)) continue;
                return new Point(next.X, next.Y);
            }

            throw new Exception();
        }
    }
}