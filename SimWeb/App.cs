using Simulator;
using Simulator.Maps;
namespace SimWeb;

public static class App
{
    public static SimulationHistory SimulationHistory { get; set; }
    static App()
    {
        var map = new BigTorusMap(8, 6);
        var creatures = new List<IMappable>
            {
            new Orc("Gorbag"),
                new Elf("Elandor"),
                new Animals { Description = "Rabbits", Size = 3 },
                new Birds { Description = "Eagles", Size = 2, CanFly = true },
                new Birds { Description = "Ostriches", Size = 2, CanFly = false }
            };
        var points = new List<Point>
            {
                new Point(2, 2),
                new Point(3, 1),
                new Point(5, 5),
                new Point(7, 3),
                new Point(0, 4)
            };
        string moves = "dlrludluddlrulrr";

        var simulation = new Simulation(map, creatures, points, moves);

        SimulationHistory = new SimulationHistory(simulation);
    }
}