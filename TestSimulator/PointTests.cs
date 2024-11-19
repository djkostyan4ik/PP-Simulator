using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Next_ShouldMoveCorrectlyInAllDirections()
    {
        // Arrange
        var point = new Point(0, 0);
        // Act & Assert
        Assert.Equal(new Point(0, 1), point.Next(Direction.Up));
        Assert.Equal(new Point(0, -1), point.Next(Direction.Down));
        Assert.Equal(new Point(-1, 0), point.Next(Direction.Left));
        Assert.Equal(new Point(1, 0), point.Next(Direction.Right));
    }
    [Theory]
    [InlineData(0, 0, Direction.Up, 0, 1)]
    [InlineData(0, 0, Direction.Left, -1, 0)]
    [InlineData(0, 0, Direction.Right, 1, 0)]
    [InlineData(0, 0, Direction.Down, 0, -1)]
    public void EdgeCase_ShouldMoveCorrectly(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var point = new Point(x, y);
        // Act
        var result = point.Next(direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), result);
    }
    [Theory]
    [InlineData((Direction)444)]
    [InlineData((Direction)999)]
    public void Next_ShouldThrowException_WhenInvalidDirection(Direction direction)
    {
        // Arrange
        var point = new Point(0, 0);
        // Act & Assert
        var exception = Assert.Throws<Exception>(() => point.Next(direction));
        Assert.Equal("Invalid direction value", exception.Message);
    }
    [Theory]
    [InlineData(0, 0, Direction.Up, 1, 1)]
    [InlineData(0, 0, Direction.Down, -1, -1)]
    [InlineData(1, 1, Direction.Left, 0, 2)]
    [InlineData(1, 1, Direction.Right, 2, 0)]
    public void NextDiagonal_ShouldMoveCorrectly(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var point = new Point(x, y);
        // Act
        var result = point.NextDiagonal(direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), result);
    }
}
