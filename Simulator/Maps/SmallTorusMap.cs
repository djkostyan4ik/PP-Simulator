using System.Drawing;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    private readonly Rectangle _borders;
    public readonly int Size;

    public SmallTorusMap(int size)
    {

        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Size must be between 5 and 20");
        }

        Size = size;
        _borders = new Rectangle(0, 0, Size - 1, Size - 1);

    }
    public override bool Exist(Point p)
    {
        return _borders.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        var nextPoint = p.Next(d);
        return new Point((nextPoint.X + Size) % Size, (nextPoint.Y + Size) % Size);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var nextDiagonalPoint = p.NextDiagonal(d);
        return new Point((nextDiagonalPoint.X + Size) % Size, (nextDiagonalPoint.Y + Size) % Size);
    }
}