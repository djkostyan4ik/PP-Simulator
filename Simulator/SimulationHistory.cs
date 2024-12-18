using Simulator.Maps;

namespace Simulator;
public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        var map = _simulation.Map;
        while (!_simulation.Finished)
        {
            var currentMappable = _simulation.CurrentMappable;
            var move = _simulation.CurrentMoveName;
            var symbols = _simulation.Mappables.ToDictionary(
                m => m.Position,
                m => m.Symbol
                );
            TurnLogs.Add(new SimulationTurnLog
            {
                Mappable = currentMappable.ToString(),
                Move = move,
                Symbols = symbols
            });
            _simulation.Turn();
        }
    }
}
