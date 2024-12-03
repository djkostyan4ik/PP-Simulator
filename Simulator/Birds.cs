namespace Simulator;

public class Birds : Animals
{
    public override char Symbol => CanFly ? 'B' : 'b';
    public bool CanFly { get; set; } = true;

    public Birds(string description, uint size, bool canFly) : base() 
    {
        Description = description;
        Size = size;
        CanFly = canFly;
    }

    public Birds() : base() { }

    public override string Info => $"{base.Info} (fly{(CanFly ? "+" : "-")})";

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

    protected override Point GetNewPosition(Direction direction) => CanFly
            ? Map.Next(Map.Next(Position, direction), direction)
            : Map.NextDiagonal(Position, direction);

}