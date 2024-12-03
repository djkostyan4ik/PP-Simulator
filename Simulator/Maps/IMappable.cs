namespace Simulator.Maps;

public interface IMappable
{
    char Symbol { get; }
    void Go(Direction direction);
    void InitMapAndPosition(Map map, Point point);

}