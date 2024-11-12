namespace Simulator;

internal class Birds : Animals
{
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

}