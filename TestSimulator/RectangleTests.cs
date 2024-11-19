using Simulator;

namespace TestSimulator;
public class RectangleTests
{
    [Theory]
    [InlineData(3, 5, 1, 1, 1, 1, 3, 5)]
    [InlineData(1, 5, 3, 1, 1, 1, 3, 5)]
    [InlineData(-10, -10, 10, 10, -10, -10, 10, 10)]
    [InlineData(0, 0, 10, 10, 0, 0, 10, 10)]
    [InlineData(5, 5, 1, 1, 1, 1, 5, 5)]
    public void Constructor_ShouldSetCorrectCoordinates(int x1, int y1, int x2, int y2, int expectedX1, int expectedY1, int expectedX2, int expectedY2)
    {
        // Act
        var rectangle = new Rectangle(x1, y1, x2, y2);
        // Assert
        Assert.Equal(expectedX1, rectangle.X1);
        Assert.Equal(expectedY1, rectangle.Y1);
        Assert.Equal(expectedX2, rectangle.X2);
        Assert.Equal(expectedY2, rectangle.Y2);
    }
    [Theory]
    [InlineData(0, 0, 0, 10)]
    [InlineData(0, 0, 10, 0)]
    [InlineData(1, 1, 1, 5)]
    [InlineData(5, 5, 5, 5)]
    [InlineData(-4, -4, -2, -4)]
    public void Constructor_InvalidRectangle_ShouldThrowArgumentException(int x1, int y1, int x2, int y2)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }
    [Theory]
    [InlineData(1, 1, 3, 5, 2, 3, true)]
    [InlineData(1, 1, 3, 5, 4, 6, false)]
    [InlineData(1, 1, 3, 5, 1, 5, true)]
    [InlineData(1, 1, 3, 5, 3, 1, true)]
    [InlineData(0, 0, 10, 10, 5, 5, true)]
    [InlineData(0, 0, 10, 10, 0, 0, true)]
    [InlineData(0, 0, 10, 10, 10, 10, true)]
    [InlineData(0, 0, 10, 10, -1, -1, false)]
    [InlineData(0, 0, 10, 10, 11, 5, false)]
    [InlineData(0, 0, 10, 10, 5, 11, false)]
    public void Contains_ShouldReturnCorrectValue(int x1, int y1, int x2, int y2, int px, int py, bool expected)
    {
        // Arrange
        var rectangle = new Rectangle(x1, y1, x2, y2);
        var point = new Point(px, py);
        // Act
        var result = rectangle.Contains(point);
        // Assert
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData(0, 0, 10, 10, "(0, 0):(10, 10)")]
    [InlineData(5, 5, 1, 1, "(1, 1):(5, 5)")]
    [InlineData(-10, -5, 5, 10, "(-10, -5):(5, 10)")]
    public void ToString_ShouldReturnCorrectFormat(int x1, int y1, int x2, int y2, string expected)
    {
        // Arrange
        var rectangle = new Rectangle(x1, y1, x2, y2);
        // Act
        var result = rectangle.ToString();
        // Assert
        Assert.Equal(expected, result);
    }
}