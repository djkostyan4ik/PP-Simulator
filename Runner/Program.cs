using Simulator.Maps;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        var creatures = new List<Creature>
            {
            new Orc("Gorbag") { Level = 5, Rage = 10 },
            new Elf("Elandor") { Level = 5, Agility = 7 },
            new Orc("Gorbag") { Level = 2, Rage = 5 },
            new Elf("Elandor") { Level = 5, Agility = 12 },
            new Orc("Gorbag") { Level = 8, Rage = 6 },
            new Elf("Elandor") { Level = 5, Agility = 2 },
            new Orc("Gorbag") { Level = 1, Rage = 2 },
            new Elf("Elandor") { Level = 5, Agility = 4 },
            new Orc("Gorbag") { Level = 2, Rage = 4 },
            new Elf("Elandor") { Level = 5, Agility = 9 }
            };
        Console.WriteLine("Before sort:");
        foreach (var creature in creatures) Console.WriteLine($"{creature.ToString()}, POWER: {creature.Power}");
        creatures.Sort((cr1, cr2) => cr1.Power.CompareTo(cr2.Power));
        Console.WriteLine("After sort:");
        foreach (var creature in creatures) Console.WriteLine($"{creature.ToString()}, POWER: {creature.Power}");

        //var squareMap = new SmallSquareMap(5);
        //var torusMap = new SmallTorusMap(5, 5);

        //var elf = new Elf("Elf1", 3, 5);
        //var elf2 = new Elf("Elf2", 1, 4);
        //var orc = new Orc("Orc1", 2, 4);

        //elf.InitMapAndPosition(squareMap, new Point(4, 4));
        //elf2.InitMapAndPosition(squareMap, new Point(3, 3));
        ////elf2.InitMapAndPosition(torusMap, new Point(3, 3));
        //orc.InitMapAndPosition(torusMap, new Point(0, 0));

        //Console.WriteLine($"Initial Position on Square Map (Elf): {elf.Position}");
        //Console.WriteLine($"Initial Position on Torus Map (Orc): {orc.Position}");

        ////Console.WriteLine(elf.Go(Direction.Up));
        ////Console.WriteLine(elf.Go(Direction.Right));

        ////Console.WriteLine(orc.Go(Direction.Right));
        ////Console.WriteLine(orc.Go(Direction.Down));

        //Console.WriteLine($"New Position on Square Map (Elf): {elf.Position}");
        //Console.WriteLine($"New Position on Torus Map (Orc): {orc.Position}");

        //Console.WriteLine("Square Map Creatures at (2,2):");
        //var squareCreatures = squareMap.At(2, 2);
        //Console.WriteLine($"Number of creatures at (2, 2) on Square Map: {squareCreatures?.Count ?? 0}");

        //Console.WriteLine("Square Map Creatures at (3,3):");
        //var squareCreatures2 = squareMap.At(3, 3);
        //Console.WriteLine($"Number of creatures at (3, 3) on Square Map: {squareCreatures2?.Count ?? 0}");

        //Console.WriteLine("Torus Map Creatures at (0,0):");
        //var torusCreatures = torusMap.At(0, 0);
        //Console.WriteLine($"Number of creatures at (0, 0) on Torus Map: {torusCreatures?.Count ?? 0}");

        //Console.WriteLine("Torus Map Creatures at (1,4):");
        //var torusCreatures2 = torusMap.At(1, 4);
        //Console.WriteLine($"Number of creatures at (1, 4) on Torus Map: {torusCreatures2?.Count ?? 0}");


        var jsonOptions = new JsonSerializerOptions { WriteIndented = true };

        //Orc o1 = new("Gorbag", 3, 5);
        //string json = JsonSerializer.Serialize(o1, jsonOptions);
        //Console.WriteLine(json);

        //Orc? o2 = JsonSerializer.Deserialize<Orc>(json);
        //Console.WriteLine(o2);

        //Point p1 = new(2, 4);
        //string json = JsonSerializer.Serialize(p1);
        //Console.WriteLine(json); // {}

        //Point p2 = JsonSerializer.Deserialize<Point>(json);
        //Console.WriteLine(p2);

        //Orc o1 = new("Gorbag", 3, 5);
        //Orc o2 = new("Morgash", 2, 7);

        //List<Orc> orcs = [o1, o2, o1];
        //Console.WriteLine(orcs[0] == orcs[2]);

        //string json = JsonSerializer.Serialize(orcs);

        //List<Orc> deserialized = JsonSerializer.Deserialize<List<Orc>>(json)!;
        //Console.WriteLine(deserialized[0] == deserialized[2]);

        //Console.WriteLine("\nJSON:");
        //Console.WriteLine(json);

        //var options = new JsonSerializerOptions
        //{
        //    WriteIndented = true,
        //    ReferenceHandler = ReferenceHandler.Preserve
        //};

        //Orc o1 = new("Gorbag", 3, 5);
        //Orc o2 = new("Morgash", 2, 7);

        //List<Orc> orcs = new() { o1, o2, o1 };
        //Console.WriteLine(orcs[0] == orcs[2]); // True

        //string json = JsonSerializer.Serialize(orcs, options);
        //Console.WriteLine("\nJSON:");
        //Console.WriteLine(json);

        //List<Orc> deserialized =
        //    JsonSerializer.Deserialize<List<Orc>>(json, options)!;

        //Console.Write("\nReference preserved:");
        //Console.WriteLine(deserialized[0] == deserialized[2]);

    //    var options = new JsonSerializerOptions { WriteIndented = true };

    //    List<Creature> creatures = [
    //        new Orc("Gorbag", 3, 5),
    //new Elf("Legolas", 2, 7)
    //    ];
    //    string json = JsonSerializer.Serialize(creatures, options);
    //    Console.WriteLine("\nJSON:");
    //    Console.WriteLine(json);

    //    List<Creature> deserialized =
    //        JsonSerializer.Deserialize<List<Creature>>(json, options)!;

    //    Console.WriteLine("\nPolimorfic OK:");
    //    Console.WriteLine(deserialized[0] is Orc);
    //    Console.WriteLine(deserialized[1] is Elf);


        var options = new JsonSerializerOptions { WriteIndented = true };

        List<IMappable> mapables = [
            new Orc("Gorbag", 3, 5),
    new Elf("Elandor", 2, 7),
    new Animals { Description = "Rasbbits", Size = 10 },
    new Birds { Description = "Eagles", Size = 15 },
    new Birds { Description = "Emu", Size = 8, CanFly = false }
        ];

        string json = JsonSerializer.Serialize(mapables, options);
        Console.WriteLine("\nJSON:");
        Console.WriteLine(json);

        List<IMappable> deserialized =
            JsonSerializer.Deserialize<List<IMappable>>(json, options)!;
    }

}

