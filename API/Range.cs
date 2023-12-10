using System.Linq;

namespace API;

public class Transformation
{
    private long _start;
    private long _end;
    private long _diff;

    public Transformation(string line)
    {
        var parts = line.Split(" ").Select(x => long.Parse(x)).ToArray();
        _start = parts[1];
        _end = _start + parts[2] - 1;
        _diff = parts[0] - parts[1];
    }

    public bool Contains(long x)
    {
        if (x >= _start && x <= _end)
        {
            return true;
        }

        return false;
    }

    public long Transform(long x)
    {
        return x + _diff;
    }
}