using System.Text;
using Simulator.Maps;
using Simulator;

namespace SimConsole;
internal class Program
{
    static void Main(string[] args)
    {

        Console.OutputEncoding = Encoding.UTF8;
        BigBounceMap map = new BigBounceMap(8,6);

        List<IMappable> creatures2 = new()
        {
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals { Description = "Rabbits", Size = 3 },
            new Birds { Description = "Eagles", Size = 2, CanFly = true },
            new Birds { Description = "Ostriches", Size = 2, CanFly = false }
        };

        List<Point> points2 = new()
        {
            new Point(2, 3),
            new Point(4, 4),
            new Point(1, 1),
            new Point(5, 5),
            new Point(0, 0)
        };

        string moves2 = "druldldrdlrluuulllll";




        Simulation simulation = new Simulation(map, creatures2, points2, moves2);
        MapVisualizer mapVisualizer = new MapVisualizer(map);

        Console.WriteLine("Simulation!");
        Console.WriteLine();
        Console.WriteLine("Starting positions:");

        mapVisualizer.Draw();
        int turn = 1;

        while (!simulation.Finished)
        {
            Console.WriteLine("Press any key to continue:");
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            Console.WriteLine($"Turn {turn}");
            Console.WriteLine($"{simulation.CurrentMappable} moves {simulation.CurrentMoveName}");

            if (keyInfo.Key != ConsoleKey.Escape)
            {
                simulation.Turn();
                mapVisualizer.Draw();
                turn++;
            }
            else 
            {
                Console.WriteLine("Exiting...");
                break;
            }
        }
        simulation.History.ShowState(5);
        simulation.History.ShowState(10);
        simulation.History.ShowState(15);
        simulation.History.ShowState(20);

    }
}