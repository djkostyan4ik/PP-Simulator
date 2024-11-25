using Simulator.Maps;

namespace Simulator;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        Lab7();

    }

    static void Lab7() 
    {
        var squareMap = new SmallSquareMap(5);
        var torusMap = new SmallTorusMap(5, 5);

        var elf = new Elf("Elf1", 3, 5);
        var elf2 = new Elf("Elf2", 1, 4);
        var orc = new Orc("Orc1", 2, 4);

        elf.InitMapAndPosition(squareMap, new Point(4, 4));
        elf2.InitMapAndPosition(squareMap, new Point(3, 3));
        //elf2.InitMapAndPosition(torusMap, new Point(3, 3));
        orc.InitMapAndPosition(torusMap, new Point(0, 0));

        Console.WriteLine($"Initial Position on Square Map (Elf): {elf.Position}");
        Console.WriteLine($"Initial Position on Torus Map (Orc): {orc.Position}");

        Console.WriteLine(elf.Go(Direction.Up));
        Console.WriteLine(elf.Go(Direction.Right));

        Console.WriteLine(orc.Go(Direction.Right));
        Console.WriteLine(orc.Go(Direction.Down));

        Console.WriteLine($"New Position on Square Map (Elf): {elf.Position}");
        Console.WriteLine($"New Position on Torus Map (Orc): {orc.Position}");

        Console.WriteLine("Square Map Creatures at (2,2):");
        var squareCreatures = squareMap.At(2, 2);
        Console.WriteLine($"Number of creatures at (2, 2) on Square Map: {squareCreatures?.Count ?? 0}");

        Console.WriteLine("Square Map Creatures at (3,3):");
        var squareCreatures2 = squareMap.At(3, 3);
        Console.WriteLine($"Number of creatures at (3, 3) on Square Map: {squareCreatures2?.Count ?? 0}");

        Console.WriteLine("Torus Map Creatures at (0,0):");
        var torusCreatures = torusMap.At(0, 0);
        Console.WriteLine($"Number of creatures at (0, 0) on Torus Map: {torusCreatures?.Count ?? 0}");

        Console.WriteLine("Torus Map Creatures at (1,4):");
        var torusCreatures2 = torusMap.At(1, 4);
        Console.WriteLine($"Number of creatures at (1, 4) on Torus Map: {torusCreatures2?.Count ?? 0}");
    }

}

