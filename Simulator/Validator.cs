namespace Simulator;

public class Validator 
{
    public static int Limiter(int value, int min, int max) 
    {
        if (value < min)
            value = min;
        if (value > max)
            value = max;
        return value;
    }

    public static string Shortener(string value, int min, int max, char placeholder)
    {

        value = value.Trim();
        if (value.Length > max)
            value = value[0..max].Trim(); 
        if (value.Length < min)
            value = value.PadRight(min, placeholder);
        value = char.ToUpper(value[0]) + value[1..];
        return value;
    
    }
}