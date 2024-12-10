namespace Simulator.Maps;
public class BigBounceMap: BigMap
{
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {

    }

    public override Point Next(Point p, Direction d)
    {
        var movedPoint = p.Next(d);
        if (!Exist(movedPoint)) 
        {
            var reversedPoint = p.Next(DirectionParser.Reverse(d));
            if (Exist(reversedPoint)) 
            {
                return reversedPoint;
            }
            return p;
        }
        return movedPoint;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var movedPoint = p.NextDiagonal(d);
        if (!Exist(movedPoint)) 
        {
            var reversedPoint = p.NextDiagonal(DirectionParser.Reverse(d));
            if (Exist(reversedPoint)) 
            {
                return reversedPoint;
            }
            return p;
        }
        return movedPoint;
    }
}