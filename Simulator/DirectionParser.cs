namespace Simulator;

public static class DirectionParser 
{

    public static List<Direction> Parse(string input)
    { 
        List<Direction> directions = new List<Direction>();

        for (int i = 0; i < input.Length; i++)
        {
            char c = char.ToUpper(input[i]);
            switch (c)
            {
                case 'U':
                    directions.Add(Direction.Up);
                    break;
                case 'R':
                    directions.Add(Direction.Right);
                    break;
                case 'D':
                    directions.Add(Direction.Down);
                    break;
                case 'L':
                    directions.Add(Direction.Left);
                    break;
            }
        }

        return directions;
    }


    public static Direction Reverse(Direction direction) 
    {
        return direction switch
        {
            Direction.Up => Direction.Down,
            Direction.Down => Direction.Up,
            Direction.Left => Direction.Right,
            Direction.Right => Direction.Left,
            _ => throw new ArgumentException("Invalid direction")
        };
    }
}