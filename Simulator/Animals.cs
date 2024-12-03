using Simulator.Maps;
using System.Xml.Linq;
using System;


namespace Simulator;

public class Animals: IMappable
{
    public Map Map { get; private set; }
    public Point Position { get; protected set; }
    public virtual char Symbol => 'A';
    // Default value "Unknown"
    private string _description = "Unknown";
    public required string Description 
    {
        get => _description;
        init
        {
            // Cannot have spaces at the beginning or end - remove excess
            _description = value?.Trim() ?? "Unknown";


            // Must be at least 3 characters long (fill in the missing ones with #)
            if (_description.Length < 3)
                _description = _description.PadRight(3, '#');


            // It can be a maximum of 15 characters (trim if too long, remove any spaces at the end)
            if (_description.Length > 15)
            {
                _description = _description.Substring(0, 15).TrimEnd();


                // Check if it has at least 3 characters after that and add # signs if necessary
                if (_description.Length < 3)
                    _description = _description.PadRight(3, '#');
            }

            // If the first character is a lowercase letter then convert it to uppercase
            if (char.IsLower(_description[0]))
                _description = char.ToUpper(_description[0]) + _description.Substring(1);
        }
    }
    public uint Size { get; set; } = 3;


    // Info property readonly
    public virtual string Info => $"{Description} <{Size}>";

    public virtual void Go(Direction direction)
    {
        if (Map == null) 
        {
            throw new InvalidOperationException("Animal can't move because it's not on the map!");
        }
        var newPosition = GetNewPosition(direction);
        Map.Move(this, Position, newPosition);
        Position = newPosition;
    }

    public void InitMapAndPosition(Map map, Point point)
    {
        if (map == null)
        {
            throw new ArgumentNullException(nameof(map));
        }
        if (Map != null)
        {
            throw new InvalidOperationException("This animal is already on a map.");
        }
        if (!map.Exist(point))
        {
            throw new ArgumentException("Non-existing position for this map.");
        }

        Map = map;
        Position = point;
        map.Add(this, point);
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

    protected virtual Point GetNewPosition(Direction direction)
    {
        return Map.Next(Position, direction);
    }

}

