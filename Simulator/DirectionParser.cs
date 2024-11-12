namespace Simulator;

public static class DirectionParser 
{

    public static Direction[] Parse(string input)
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

        return directions.ToArray();
    }

}