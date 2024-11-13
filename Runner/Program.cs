using Simulator.Maps;

namespace Simulator;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        Lab5a();
        Lab5b();

    }

    static void Lab5a() 
    {

        try
        {

            var rect1 = new Rectangle(1, 2, 5, 6);
            Console.WriteLine($"Rectangle 1: {rect1}");
            
            var p1 = new Point(3, 4);
            var p2 = new Point(7, 8);
            var rect2 = new Rectangle(p1, p2);
            Console.WriteLine($"Rectangle 2: {rect2}");

            var rect3 = new Rectangle(6, 5, 3, 2);
            Console.WriteLine($"Rectangle 3: {rect3}");

            try
            {
                var rect4 = new Rectangle(2, 2, 2, 5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            var point1 = new Point(3, 4);
            var point2 = new Point(9, 10);
            Console.WriteLine($"Point {point1} is in rectangle: {rect1.Contains(point1)}");
            Console.WriteLine($"Point {point2} is in rectangle: {rect2.Contains(point2)}");

        }
        catch (ArgumentException ex) 
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }
    
    static void Lab5b() 
    {

        try
        {
            var map = new SmallSquareMap(8);
            Console.WriteLine($"Map size: {map.Size}");

            var point1 = new Point(6, 7);
            var point2 = new Point(10, 15);

            Console.WriteLine($"Point {point1} is in the map: {map.Exist(point1)}");
            Console.WriteLine($"Point {point2} is in the map: {map.Exist(point2)}");
            
            var point3 = new Point(6, 5);
            var nextPoint = map.Next(point3, Direction.Left);
            Console.WriteLine($"Next point: {nextPoint}");
            var diagonalPoint = map.NextDiagonal(point3, Direction.Up);
            Console.WriteLine($"Diagonal point: {diagonalPoint}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }

}

