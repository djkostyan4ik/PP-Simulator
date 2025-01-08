namespace Simulator.Maps;

public class SmallSquareMap : SmallMap 
{
    public SmallSquareMap(int size) : base(size, size) 
    {
        FNext = MoveRules.WallNext;
        FNextDiagonal = MoveRules.WallNextDiagonal;
    }

    //public override Point Next(Point p, Direction d)
    //{
    //    Point nextPoint = p.Next(d);
    //    return Exist(nextPoint) ? nextPoint : p;
    //}

    //public override Point NextDiagonal(Point p, Direction d)
    //{
    //    Point nextDiagonalPoint = p.NextDiagonal(d);
    //    return Exist(nextDiagonalPoint) ? nextDiagonalPoint : p;
    //}
}