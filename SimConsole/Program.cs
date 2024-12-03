using System.Text;
using Simulator.Maps;
using Simulator;

namespace SimConsole;
internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        SmallSquareMap map = new(5);
        List<IMappable> mappables = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";

        Simulation simulation = new Simulation(map, mappables, points, moves);
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
    }
}