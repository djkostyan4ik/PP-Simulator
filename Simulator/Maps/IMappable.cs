namespace Simulator.Maps;

public interface IMappable
{
    Point Position { get; }
    public char Symbol { get; }
    public string ToString();
    void Go(Direction direction);
    void InitMapAndPosition(Map map, Point point);

}