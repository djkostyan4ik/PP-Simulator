using Simulator.Maps;

namespace Simulator;
public class SimulationHistory 
{
    private readonly List<State> _history = new();

    public void SaveState(int turn, Dictionary<IMappable, Point> positions, IMappable currentMappable, Direction? currentMove) =>
        _history.Add(new State
        {
            Turn = turn,
            Positions = new Dictionary<IMappable, Point>(positions),
            CurrentMappable = currentMappable,
            CurrentMove = currentMove
        });
    public void ShowState(int turn)
    {
        if (turn < 0 || turn >= _history.Count)
        {
            Console.WriteLine("Invalid turn.");
            return;
        }
        var state = _history[turn];
        Console.WriteLine($"Turn: {turn}");
        if (state.CurrentMappable != null && state.CurrentMove.HasValue) Console.WriteLine($"{state.CurrentMappable.ToString()} moved {state.CurrentMove}");

        foreach (var entry in state.Positions) Console.WriteLine($"{entry.Key} is at {entry.Value}");
    }

    private class State
    {
        public int Turn { get; set; }
        public Dictionary<IMappable, Point> Positions { get; set; } = new();
        public IMappable? CurrentMappable { get; set; }
        public Direction? CurrentMove { get; set; }
    }
}

