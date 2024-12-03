using Simulator.Maps;

namespace Simulator;
public abstract class Creature : IMappable
 {
    public Map? Map { get; private set; }
    public Point Position { get; private set; }

    // Default value "Unknown"
    private string _name = "Unknown";
    
    private int _level = 1;

    public string Name 
    {
        get => _name;
        set
        {   // Can only be assigned once upon initiation
            if (_name != "Unknown") return;

            // Cannot have spaces at the beginning or end - remove excess
            _name = value?.Trim() ?? "Unknown";

            // Must be at least 3 characters long (fill in the missing ones with #)
            if (_name.Length < 3)
                _name = _name.PadRight(3, '#');

            // It can be a maximum of 25 characters (trim if too long, remove any spaces at the end)
            if (_name.Length > 25)
            {
                _name = _name.Substring(0,25).TrimEnd();

                // Check if it has at least 3 characters after that and add # signs if necessary
                if (_name.Length < 3)
                    _name = _name.PadRight(3, '#');
            }

            // If the first character is a lowercase letter then convert it to uppercase
            if (char.IsLower(_name[0]))
                _name = char.ToUpper(_name[0]) + _name.Substring(1);
        }
    }
    public int Level
    {
        get => _level;
        set
        {
            if (value < 1)
                _level = 1;
            else if (value > 10)
                _level = 10;
            else _level = value;
         
        }
    }

    // Constructor that accepts initial values ​​for Name and Level
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }


    // Constructor parameterless
    public Creature()
    { }


    // SayHi method
    public abstract string Greeting();

    // Power method
    public abstract int Power { get; }

    // Readonly property Info
    public abstract string Info 
    {
        get;
    }

    public virtual char Symbol => 'C';

    // Upgrade() method
    public void Upgrade() 
    {
        if (Level < 10)
            Level++;
    }


    // Method to move in multiple directions
    public void InitMapAndPosition(Map map, Point position)
    {
        if (map == null)
        {
            throw new ArgumentNullException(nameof(map));
        }
        if (Map != null)
        {
            throw new InvalidOperationException($"This creature is already on a map. It cannot be moved to a new map.");
        }
        if (!map.Exist(position))
        {
            throw new ArgumentException("Non-existing position for this map.");
        }
        Map = map;
        Position = position;
        map.Add(this, position);
    }

    public void Go(Direction direction)
    {
        if (Map == null)
        {
            throw new InvalidOperationException("Creature cannot move since it's not on the map!");
        }
        var newPosition = Map.Next(Position, direction);
        Map.Move(this, Position, newPosition);
        Position = newPosition;
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}

