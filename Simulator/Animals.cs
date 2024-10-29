namespace Simulator;

public class Animals
{
    public required string Description { get; init; }
    public uint Size { get; set; } = 3;


    // Info property readonly
    public string Info => $"{Description} <{Size}>";

}

