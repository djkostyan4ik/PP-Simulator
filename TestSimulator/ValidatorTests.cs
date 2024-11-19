using Simulator;

namespace TestSimulator;
public class ValidatorTests
{
    [Theory]
    [InlineData(5, 1, 10, 5)]
    [InlineData(0, 1, 10, 1)]
    [InlineData(15, 1, 10, 10)]
    [InlineData(1, 1, 10, 1)]
    [InlineData(10, 1, 10, 10)]
    public void Limiter_ShouldReturnCorrectValue(int value, int min, int max, int expected)
    {
        // Act
        var result = Validator.Limiter(value, min, max);
        // Assert
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData("test", 3, 6, '_', "Test")]
    [InlineData("too long value", 5, 10, '*', "Too long v")]
    [InlineData("short", 10, 15, '-', "Short-----")]
    [InlineData("  whitespace  ", 5, 10, '_', "Whitespace")]
    [InlineData("a                            troll name", 5, 15, '#', "A####")]
    [InlineData("Mice           are great", 3, 15, '#', "Mice")]
    [InlineData("  ", 3, 25, '#', "###")]
    [InlineData("Puss in Boots – a clever and brave cat.", 3, 25, '#', "Puss in Boots – a clever")]
    public void Shortener_ShouldReturnCorrectValue(string value, int min, int max, char placeholder, string expected)
    {
        // Act
        var result = Validator.Shortener(value, min, max, placeholder);
        // Assert
        Assert.Equal(expected, result);
    }
    [Fact]
    public void Shortener_ShouldHandleEmptyString()
    {
        // Arrange
        string value = "";
        int min = 5;
        int max = 10;
        char placeholder = '_';
        // Act
        var result = Validator.Shortener(value, min, max, placeholder);
        // Assert
        Assert.Equal("_____", result);
    }
    [Fact]
    public void Shortener_ShouldConvertFirstCharacterToUppercase()
    {
        // Arrange
        string value = "lowercase";
        int min = 5;
        int max = 15;
        char placeholder = '_';
        // Act
        var result = Validator.Shortener(value, min, max, placeholder);
        // Assert
        Assert.Equal("Lowercase", result);
    }
}