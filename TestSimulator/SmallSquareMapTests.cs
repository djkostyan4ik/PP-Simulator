using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize() 
    {
        // Arrange
        int size = 10;
        // Act
        var map = new SmallSquareMap(size);
        // Assert
        Assert.Equal(size, map.SizeX);
        Assert.Equal(size, map.SizeY);

    }

    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void
        Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException
        (int size)
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
             new SmallSquareMap(size));
    }

    [Theory]
    [InlineData(3, 4, 5, true)]
    [InlineData(6, 1, 5, false)]
    [InlineData(19, 19, 20, true)]
    [InlineData(20, 20, 20, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y,
        int size, bool expected)
    {
        // Arrange
        var map = new SmallSquareMap(size);
        var point = new Point(x, y);
        // Act
        var result = map.Exist(point);
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 5, 11)]
    [InlineData(6, 6, Direction.Down, 6, 5)]
    [InlineData(5, 8, Direction.Left, 4, 8)]
    [InlineData(10, 10, Direction.Right, 11, 10)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(20);
        var point = new Point(x, y);
        // Act
        var nextPoint = map.Next(point, direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(4, 4, Direction.Up, 4, 4)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    [InlineData(4, 4, Direction.Right, 4, 4)]
    public void Next_ShouldReturnTheSamePoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(5);
        var point = new Point(x, y);
        // Act
        var nextPoint = map.Next(point, direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 6, 11)]
    [InlineData(5, 5, Direction.Down, 4, 4)]
    [InlineData(4, 8, Direction.Left, 3, 9)]
    [InlineData(10, 10, Direction.Right, 11, 9)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(20);
        var point = new Point(x, y);
        // Act
        var nextPoint = map.NextDiagonal(point, direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(4, 4, Direction.Up, 4, 4)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    [InlineData(4, 4, Direction.Right, 4, 4)]
    public void NextDiagonal_ShouldReturnTheSamePoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(5);
        var point = new Point(x, y);
        // Act
        var nextPoint = map.Next(point, direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}
